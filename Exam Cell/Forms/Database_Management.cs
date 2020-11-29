using Exam_Cell.Forms;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Cell
{
    public partial class Database_Management : Form
    {
        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();
        BindingSource Scheme_Source = new BindingSource();
        BindingSource Class_Source = new BindingSource();

        public Database_Management()
        {
            InitializeComponent();
        }

        void Class_dgv_Fill()
        {
            try
            {
            Class_dgv_radiobtn.Checked = true;
            SQLiteCommand command = new SQLiteCommand("select Class,Semester from Management Where (Class is not null) and (Semester is not null) order by Semester,Class", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable table_class = new DataTable();
            adapter.Fill(table_class);
            Class_Source.DataSource = null;
            Class_Source.DataSource = table_class;
            Scheme_dgv.DataSource = Class_Source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }

        }

        void Branch_dgv_Fill()
        {          
            try
            {
            SQLiteCommand command = new SQLiteCommand("select * from Scheme order by Scheme desc", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable table_scheme = new DataTable();
            adapter.Fill(table_scheme);
            Scheme_Source.DataSource = null;
            Scheme_Source.DataSource = table_scheme;
            Scheme_dgv.DataSource = Scheme_Source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }

        }
        private void Branch_dgv_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Branch_dgv_radiobtn.Checked)
            {
                NewBranchGroupbox.Enabled = true;
                NewCourseGroupbox.Enabled = true;
                NewClassGroupbox.Enabled = false;
                Branch_dgv_Fill();
                BranchComboboxFill();
                Clear_All_ClassManagement();
            }
            
        }

        private void Class_dgv_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Class_dgv_radiobtn.Checked)
            {
                NewBranchGroupbox.Enabled = false;
                NewCourseGroupbox.Enabled = false;
                NewClassGroupbox.Enabled = true;
                Class_dgv_Fill();
                BranchComboboxFill();
                Clear_All_ClassManagement();
            }
        }

        private void AddNewBranch_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Click Yes to Add New Branch", "Confirmation", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Information);
            var result = msgbox.ReturnValue;
            try
            {
            if (result == "Yes")
            {
                if (NewBranch_textbox.Text != "")
                {
                    SQLiteCommand command = new SQLiteCommand("insert into Management(Branch)Values(" + " @Branch) ", con.ActiveCon());
                    command.Parameters.AddWithValue("@Branch", NewBranch_textbox.Text);
                    command.ExecuteNonQuery();
                    msgbox.show("New Branch Added", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                    BranchComboboxFill();
                    Clear_All_ClassManagement();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }

        private void DeleteBranch_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Do you really want to Delete ?", "Alert", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
            {                
                try
                {
                    SQLiteCommand command2 = new SQLiteCommand("delete from Scheme where Branch=@Branch", con.ActiveCon());
                    command2.Parameters.AddWithValue("@Branch", UpdateBranch_combobox.Text);
                    command2.ExecuteNonQuery();
                    con.CloseCon();
                }
                catch (Exception) { }
                SQLiteCommand command = new SQLiteCommand("delete from Management where Branch=@Branch", con.ActiveCon());
                command.Parameters.AddWithValue("@Branch", UpdateBranch_combobox.Text);
                command.ExecuteNonQuery();
                BranchComboboxFill();
                Clear_All_ClassManagement();
                Branch_dgv_Fill();
                msgbox.show("Branch Delete Done", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                con.CloseCon();
            }
        }
                
                
            

        

        private void DeleteClass_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Do you really want to Delete ?", "Alert", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            try
            {
            if (result == "Yes")
            {
                int f = 0;
                foreach (DataGridViewRow dr in Scheme_dgv.Rows)
                {
                    bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                    if (checkselected)
                    {
                        f = 1;
                        SQLiteCommand command = new SQLiteCommand("delete from Management where Class=@Class and Semester=@Semester", con.ActiveCon());
                        command.Parameters.AddWithValue("@Class", dr.Cells["Class"].Value.ToString());
                        command.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value.ToString());
                        command.ExecuteNonQuery();
                    }
                }
                if (f == 1)
                {
                    Class_dgv_Fill();
                    msgbox.show("Delete Done.", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
                else
                    msgbox.show("Select any Class to delete, Try again.", "Alert", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }

        void Clear_All_ClassManagement()
        {
            NewClass_textbox.Clear();
            NewClassSem_combobox.SelectedIndex = 0;
            NewBranch_textbox.Clear();
            UpdateBranch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;
            Course_textbox.Clear();
            Examcode_textbox.Clear();
            ACode_textbox.Clear();
        }

        private void Database_Management_Load(object sender, EventArgs e)
        {
            RadioButton_panel.BringToFront();
            Class_radiobtn.Checked = true;
            Class_dgv_radiobtn.Checked = true;
            
            //Schemedgv
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.Width = 30;
            checkbox.Name = "CheckboxColumn";
            Scheme_dgv.Columns.Insert(0, checkbox);
            
        }
        


        

        private void AddNewCourse_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Click Yes to Add New Course", "Confirmation", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Information);
            var result = msgbox.ReturnValue;
            try
            {
            if (result == "Yes")
            {
                if (UpdateBranch_combobox.SelectedIndex != 0 && Semester_combobox.SelectedIndex != 0 && Course_textbox.Text != "" && Examcode_textbox.Text != "" && ACode_textbox.Text != "")
                {
                    SQLiteCommand comm = new SQLiteCommand("Select Default_Scheme from Management where (Default_Scheme is not null)", con.ActiveCon());
                    string scheme = (string)comm.ExecuteScalar();
                    SQLiteCommand command = new SQLiteCommand("insert into Scheme(Scheme,Branch,Semester,Course,Sub_Code,Acode)Values(" + " @Scheme,@Branch,@Semester,@Course,@Sub_Code,@Acode) ", con.ActiveCon());
                    command.Parameters.AddWithValue("@Scheme", scheme);
                    command.Parameters.AddWithValue("@Branch", UpdateBranch_combobox.Text);
                    command.Parameters.AddWithValue("@Semester", Semester_combobox.Text);
                    command.Parameters.AddWithValue("@Course", Course_textbox.Text);
                    command.Parameters.AddWithValue("@Sub_Code", Examcode_textbox.Text);
                    command.Parameters.AddWithValue("@Acode", ACode_textbox.Text);
                    command.ExecuteNonQuery();
                    Branch_dgv_Fill();
                    Course_textbox.Clear();
                    Examcode_textbox.Clear();
                    ACode_textbox.Clear();
                    NewcourseFilter();
                    msgbox.show("New Course Added", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
                else
                {
                    msgbox.show("Fill Necessary Details, Try again.", "Alert", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }

        void NewcourseFilter()
        {           
            string branchvalue = UpdateBranch_combobox.Text;
            string semvalue = Semester_combobox.Text;

            string filter = "";        //filter string for sql statements to be written
            
            if (branchvalue != "-Select-")
            {
                if (filter.Length > 0) filter += " AND ";                    //Put AND if there is existing Sql statement in filter string
                filter += string.Format("Branch Like '%{0}%'", branchvalue);     //Put sql statement in filter string
            }
            if (semvalue != "-Select-")
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Semester Like '%{0}%'", semvalue);
            }
            Scheme_Source.Filter = filter;
        }

        private void UpdateBranch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NewcourseFilter();
            }
            catch (Exception) { }
           
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NewcourseFilter();
            }
            catch (Exception) { }
        }

        private void DeleteCourse_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Do you really want to Delete ?", "Alert", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            try
            {
            if (result == "Yes")
            {
                int f = 0;
                foreach (DataGridViewRow dr in Scheme_dgv.Rows)
                {
                    bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                    if (checkselected)
                    {
                        f = 1;
                        SQLiteCommand command = new SQLiteCommand("delete from Scheme where Course=@Course", con.ActiveCon());
                        command.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value.ToString());
                        command.ExecuteNonQuery();
                    }
                }
                if (f == 1)
                {
                    Clear_All_ClassManagement();
                    Branch_dgv_Fill();
                    msgbox.show("Course Delete Done.", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
                else
                    msgbox.show("Select any Course to delete, Try again.", "Alert", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }

        private void AddNewClass_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Click Yes to Add New Class", "Confirmation", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Information);
            var result = msgbox.ReturnValue;
            try
            {
            if (result == "Yes")
            {
                if (NewClassSem_combobox.SelectedIndex != 0)
                {
                    SQLiteCommand command = new SQLiteCommand("insert into Management(Class,Semester)Values(" + " @Class,@Semester) ", con.ActiveCon());
                    command.Parameters.AddWithValue("@Class", NewClass_textbox.Text);
                    command.Parameters.AddWithValue("@Semester", NewClassSem_combobox.Text);
                    command.ExecuteNonQuery();
                    msgbox.show("New Class Added", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                    NewClassSem_combobox.SelectedIndex = 0;
                    Class_dgv_Fill();
                }
                else
                    msgbox.show("Select Semester", "Alert", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }

        void BranchComboboxFill()
        {
            try
            {
            SQLiteCommand sc = new SQLiteCommand("Select Branch from Management where Branch is not null", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);

            UpdateBranch_combobox.ValueMember = "Branch";  //column name is given to get values to show in combobox
            UpdateBranch_combobox.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }

        

        private void ChangeScheme_btn_Click(object sender, EventArgs e)
        {
            if (ChangeScheme_textbox.Text != "")
            {
                try
                {
                if(Scheme_label.Text != "")
                {
                    SQLiteCommand comm = new SQLiteCommand("update Management set Default_Scheme=@Default_Scheme where (Default_Scheme is not null)", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Default_Scheme", ChangeScheme_textbox.Text);
                    comm.ExecuteNonQuery();
                    Schemelabel();
                }
                else
                {
                    SQLiteCommand comm = new SQLiteCommand("insert into Management(Default_Scheme)Values(" + " Default_Scheme=@Default_Scheme)", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Default_Scheme", ChangeScheme_textbox.Text);
                    comm.ExecuteNonQuery();
                    Schemelabel();
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.CloseCon();
                }
            }
            else
                msgbox.show("Type New Default Scheme", "Alert", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
        }
        void Schemelabel()
        {
            try
            {
                SQLiteCommand comm = new SQLiteCommand("Select Default_Scheme from Management where (Default_Scheme is not null)", con.ActiveCon());
                string scheme = (string)comm.ExecuteScalar();
                Scheme_label.Text = scheme;
            }
            catch(Exception ex)
            {
                msgbox.show(ex.ToString(), "Alert", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            finally
            {
                con.CloseCon();
            }
        }

        

        private void Class_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            DefaultScheme_Panel.SendToBack();
            groupBoxContents.Enabled = true;
            DefaultScheme_Panel.Enabled = false;
        }

        

        

        private void DefaultScheme_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            DefaultScheme_Panel.BringToFront();
            DefaultScheme_Panel.Enabled = true;
            groupBoxContents.Enabled = false;
            Schemelabel();
        }
    }
}
                
