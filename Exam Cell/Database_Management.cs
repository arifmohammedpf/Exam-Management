using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        BindingSource Scheme_Source = new BindingSource();
        BindingSource Class_Source = new BindingSource();

        public Database_Management()
        {
            InitializeComponent();
        }

        void Class_dgv_Fill()
        {
            Class_dgv_radiobtn.Checked = true;
            SqlCommand command = new SqlCommand("select Class,Semester from Management Where (Class is not null) and (Semester is not null) order by Semester", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_class = new DataTable();
            adapter.Fill(table_class);
            Class_Source.DataSource = null;
            Class_Source.DataSource = table_class;
            Scheme_dgv.DataSource = Class_Source;
            
        }

        void Branch_dgv_Fill()
        {          
            SqlCommand command = new SqlCommand("select * from Scheme order by Scheme desc", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_scheme = new DataTable();
            adapter.Fill(table_scheme);
            Scheme_Source.DataSource = null;
            Scheme_Source.DataSource = table_scheme;
            Scheme_dgv.DataSource = Scheme_Source;

        }
        private void Branch_dgv_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Branch_dgv_radiobtn.Checked)
            {
                NewBranchGroupbox.Enabled = true;
                NewCourseGroupbox.Enabled = true;
                NewClassGroupbox.Enabled = false;
                Branch_dgv_Fill();
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
                Clear_All_ClassManagement();
            }
        }

        private void AddNewBranch_btn_Click(object sender, EventArgs e)
        {
            if(NewBranch_textbox.Text != "")
            {
                SqlCommand command = new SqlCommand("insert into Management(Branch)Values(" + " @Branch) ", con.ActiveCon());
                command.Parameters.AddWithValue("@Branch", NewBranch_textbox.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("New Branch Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BranchComboboxFill();
                Clear_All_ClassManagement();
            }
        }

        private void DeleteBranch_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to Delete ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {                
                try
                {
                    SqlCommand command2 = new SqlCommand("delete Scheme where Branch=@Branch", con.ActiveCon());
                    command2.Parameters.AddWithValue("@Branch", UpdateBranch_combobox.Text);
                    command2.ExecuteNonQuery();                    
                }
                catch (Exception) { }
                SqlCommand command = new SqlCommand("delete Management where Branch=@Branch", con.ActiveCon());
                command.Parameters.AddWithValue("@Branch", UpdateBranch_combobox.Text);
                command.ExecuteNonQuery();
                BranchComboboxFill();
                Clear_All_ClassManagement();
                Branch_dgv_Fill();
                MessageBox.Show("Branch Delete Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
                
                
            

        

        private void DeleteClass_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to Delete ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int f = 0;
                foreach (DataGridViewRow dr in Scheme_dgv.Rows)
                {
                    bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                    if (checkselected)
                    {
                        f = 1;
                        SqlCommand command = new SqlCommand("delete Management where Class=@Class", con.ActiveCon());
                        command.Parameters.AddWithValue("@Class", dr.Cells["Class"].Value.ToString());
                        command.ExecuteNonQuery();
                    }
                }
                if (f == 1)
                {
                    Class_dgv_Fill();
                    MessageBox.Show("Delete Done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Select any Class to delete, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        CheckBox headerchkbox = new CheckBox();
        private void Database_Management_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exam_CellDataSet_Students.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.exam_CellDataSet_Students.Students);
            RadioButton_panel.BringToFront();
            Class_radiobtn.Checked = true;
            AssignClass_fill();
            BranchComboboxFill();
            Class_dgv_radiobtn.Checked = true;
            
            //Schemedgv
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.Width = 30;
            checkbox.Name = "CheckboxColumn";
            Scheme_dgv.Columns.Insert(0, checkbox);
            //studentdgv
            DataGridViewCheckBoxColumn checkbox2 = new DataGridViewCheckBoxColumn();
            checkbox2.HeaderText = "";
            checkbox2.Width = 30;
            checkbox2.Name = "CheckboxColumn2";
            Student_dgv.Columns.Insert(0, checkbox2);

            AddHeaderchckbox(); //header checkbox added to candidate dgv
            headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
        }
        //function definition
        void AddHeaderchckbox()
        {
            try
            {
                //Locate Header Cell to place checkbox in correct position
                Point HeaderCellLocation = this.Student_dgv.GetCellDisplayRectangle(0, -1, true).Location;
                //place headercheckbox to the location
                headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 2);
                headerchkbox.BackColor = Color.White;
                headerchkbox.Size = new Size(18, 18);
                //add checkbox into dgv
                Student_dgv.Controls.Add(headerchkbox);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "AddHeaderchckbox", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        {
            try
            {
                Headerchckboxclick((CheckBox)sender);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Headerchckbox_Mouseclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //headerchckbox click event
        private void Headerchckboxclick(CheckBox Hcheckbox)
        {

            try
            {
                foreach (DataGridViewRow row in Student_dgv.Rows)
                    ((DataGridViewCheckBoxCell)row.Cells["checkBox2Column"]).Value = Hcheckbox.Checked;

                Student_dgv.RefreshEdit();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Headerchckboxclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        

        private void AddNewCourse_btn_Click(object sender, EventArgs e)
        {
            if(UpdateBranch_combobox.SelectedIndex!=0 && Semester_combobox.SelectedIndex!=0 && Course_textbox.Text != "" && Examcode_textbox.Text !="" && ACode_textbox.Text !="")
            {
                SqlCommand comm = new SqlCommand("Select Default_Scheme from Management where (Default_Scheme is not null)", con.ActiveCon());
                string scheme = (string)comm.ExecuteScalar();
                SqlCommand command = new SqlCommand("insert into Scheme(Scheme,Branch,Semester,Course,Sub_Code,Acode)Values(" + " @Scheme,@Branch,@Semester,@Course,@Sub_Code,@Acode) ", con.ActiveCon());
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
                MessageBox.Show("New Course Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fill Necessary Details, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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
            DialogResult result = MessageBox.Show("Do you really want to Delete ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int f = 0;
                foreach (DataGridViewRow dr in Scheme_dgv.Rows)
                {
                    bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                    if (checkselected)
                    {
                        f = 1;
                        SqlCommand command = new SqlCommand("delete Scheme where Course=@Course", con.ActiveCon());
                        command.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value.ToString());
                        command.ExecuteNonQuery();
                    }
                }
                if (f == 1)
                {
                    Clear_All_ClassManagement();
                    Branch_dgv_Fill();
                    MessageBox.Show("Course Delete Done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Select any Course to delete, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewClass_btn_Click(object sender, EventArgs e)
        {
            if (NewClassSem_combobox.SelectedIndex != 0)
            {
                SqlCommand command = new SqlCommand("insert into Management(Class,Semester)Values(" + " @Class,@Semester) ", con.ActiveCon());
                command.Parameters.AddWithValue("@Class", NewClass_textbox.Text);
                command.Parameters.AddWithValue("@Semester", NewClassSem_combobox.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("New Class Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear_All_ClassManagement();
                Class_dgv_Fill();
            }
            else
                MessageBox.Show("Select Semester", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void BranchComboboxFill()
        {
            SqlCommand sc = new SqlCommand("Select Branch from Management where Branch is not null", con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Branch", typeof(string)); // in datatable, a column should be created before adding rows
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            dt.Load(reader);

            UpdateBranch_combobox.ValueMember = "Branch";  //column name is given to get values to show in combobox
            UpdateBranch_combobox.DataSource = dt;

            
        }

        void AssignClass_fill()
        {
            SqlCommand sc = new SqlCommand("Select Class,Semester from Management where (Class is not null) and (Semester is not null)", con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Semester", typeof(string));           
            dt.Load(reader);

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Combo", typeof(string)); // in datatable, a column should be created before adding rows
            DataRow top = dt2.NewRow();
            top[0] = "-Select-";
            dt2.Rows.InsertAt(top, 0);
            foreach (DataRow dr in dt.Rows)
                dt2.Rows.Add(dr["Class"].ToString() + "  S"+dr["Semester"].ToString());
            AssignClass_combobox.ValueMember = "Combo";  //column name is given to get values to show in combobox
            AssignClass_combobox.DataSource = dt2;


        }

        private void ChangeScheme_btn_Click(object sender, EventArgs e)
        {
            if (ChangeScheme_textbox.Text != "")
            {
                if(Scheme_label.Text != "")
                {
                    SqlCommand comm = new SqlCommand("update Management set Default_Scheme=@Default_Scheme where (Default_Scheme is not null)", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Default_Scheme", ChangeScheme_textbox.Text);
                    comm.ExecuteNonQuery();
                    Schemelabel();
                }
                else
                {
                    SqlCommand comm = new SqlCommand("insert into Management(Default_Scheme)Values(" + " Default_Scheme=@Default_Scheme)", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Default_Scheme", ChangeScheme_textbox.Text);
                    comm.ExecuteNonQuery();
                    Schemelabel();
                }
            }
            else
                MessageBox.Show("Type New Default Scheme", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void Schemelabel()
        {
            try
            {
                SqlCommand comm = new SqlCommand("Select Default_Scheme from Management where (Default_Scheme is not null)", con.ActiveCon());
                string scheme = (string)comm.ExecuteScalar();
                Scheme_label.Text = scheme;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AssignClass_btn_Click(object sender, EventArgs e)
        {
            if(AssignClass_combobox.SelectedIndex != 0)
            {
                int f = 0;
                foreach (DataGridViewRow dr in Student_dgv.Rows)
                {
                    bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn2"].Value);
                    if (checkselected)
                    {
                        f = 1;
                        SqlCommand command = new SqlCommand("insert into Class(Reg_No,Name,Class)Values(" + "@Reg_No,@Name,@Class )", con.ActiveCon());
                        command.Parameters.AddWithValue("@Reg_No", dr.Cells["Reg_no"].Value.ToString());
                        command.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value.ToString());
                        command.Parameters.AddWithValue("@Class", AssignClass_combobox.Text);
                        command.ExecuteNonQuery();
                    }
                }
                if (f == 1)
                {
                    MessageBox.Show("Students Added to Class", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllStudent_Management();
                    Student_dgvFill();
                }
                else
                    MessageBox.Show("Select Any Students", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Select Class", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void ClearAllStudent_Management()
        {
            Regno_textbox.Clear();
            Name_textbox.Clear();
            YOA_textbox.Clear();
            Branch_combobox.SelectedIndex = 0;
            AssignClass_combobox.SelectedIndex = 0;
            AssignClassYOA_combobox.SelectedIndex = 0;
            AssignClassBranch_combobox.SelectedIndex = 0;
            Filepath_textbox.Clear();
            Sheet_combobox.Items.Clear();
        }

        private void Class_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            Class_Managmnt_panel.BringToFront();
            Student_mngmnt_panel.Enabled = false;
            Class_Managmnt_panel.Enabled = true;
            DefaultScheme_Panel.Enabled = false;
        }

        private void Studnt_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            Student_mngmnt_panel.BringToFront();
            Student_mngmnt_panel.Enabled = true;
            Class_Managmnt_panel.Enabled = false;
            DefaultScheme_Panel.Enabled = false;
            Student_dgvFill();
            ClassDgvView_checkbox.Checked = false;
            StudentBranchComboboxFill();
            ClassBranchComboboxFill();
            YearOfAdmissionFill();
            ClearAllStudent_Management();
        }

        private void AddStudent_btn_Click(object sender, EventArgs e)
        {
            if (Branch_combobox.SelectedIndex != 0 && Regno_textbox.Text != "" && Name_textbox.Text != "" && YOA_textbox.Text != "")
            {
                SqlCommand command = new SqlCommand("insert into Students(Reg_no,Name,Year_Of_Admission,Branch)Values(" + "@Reg_no,@Name,@Year_Of_Admission,@Branch)",con.ActiveCon());
                command.Parameters.AddWithValue("@Reg_no", Regno_textbox.Text);
                command.Parameters.AddWithValue("@Name", Name_textbox.Text);
                command.Parameters.AddWithValue("@Year_Of_Admission", YOA_textbox.Text);
                command.Parameters.AddWithValue("@Branch", Branch_combobox.Text);
                command.ExecuteNonQuery();
                ClearAllStudent_Management();
                Student_dgvFill();
            }
            else
            {
                MessageBox.Show("Fill Necessary Details, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }

        private void ClassDgvView_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ClassDgvView_checkbox.Checked)
            {
                Class_StudentsFill();
                add_stdnt_groupbox.Enabled = false;
                ImportGroupbox.Enabled = false;
                AssignClassYOA_combobox.Enabled = false;
                AssignClassBranch_combobox.Enabled = false;
                AssignClass_btn.Enabled = false;
                AssignClass_combobox.SelectedIndex = 0;
            }
            else
            {
                Student_dgvFill();
                add_stdnt_groupbox.Enabled = true;
                ImportGroupbox.Enabled = true;
                AssignClassYOA_combobox.Enabled = true;
                AssignClassBranch_combobox.Enabled = true;
                AssignClass_btn.Enabled = true;
                AssignClass_combobox.SelectedIndex = 0;
            }
        }
        BindingSource Student_Source = new BindingSource();
        BindingSource ClassView_Source = new BindingSource();
        void Student_dgvFill()
        {
            SqlCommand command = new SqlCommand("select * from Students order by Year_Of_Admission desc,Branch", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_Students = new DataTable();
            adapter.Fill(table_Students);
            Student_Source.DataSource = null;
            Student_Source.DataSource = table_Students;
            Student_dgv.DataSource = Student_Source;
        }
        void Class_StudentsFill()
        {
            SqlCommand command = new SqlCommand("select * from Class order by Class desc", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_Students = new DataTable();
            adapter.Fill(table_Students);
            ClassView_Source.DataSource = null;
            ClassView_Source.DataSource = table_Students;
            Student_dgv.DataSource = ClassView_Source;
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to Delete ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (AddFromExcel_Btn.Enabled == false)
                {
                    if (ClassDgvView_checkbox.Checked)
                    {
                        int f = 0;
                        foreach (DataGridViewRow dr in Student_dgv.Rows)
                        {
                            bool Selected = Convert.ToBoolean(dr.Cells["CheckboxColumn2"].Value);
                            if (Selected)
                            {
                                f = 1;
                                SqlCommand command = new SqlCommand("Delete Class Where Class=@Class and Name=@Name and Reg_No=@Reg_No", con.ActiveCon());
                                command.Parameters.AddWithValue("@Class", dr.Cells["Class"].Value);
                                command.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value);
                                command.Parameters.AddWithValue("@Reg_No", dr.Cells["Reg_No"].Value);
                                command.ExecuteNonQuery();
                            }
                        }
                        if (f == 1)
                        {
                            MessageBox.Show("Delete Done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearAllStudent_Management();
                            Class_StudentsFill();                            
                        }
                        else
                        {
                            MessageBox.Show("Select any Students to delete, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);                           
                        }
                    }
                    else
                    {
                        int f = 0;
                        foreach (DataGridViewRow dr in Student_dgv.Rows)
                        {
                            bool Selected = Convert.ToBoolean(dr.Cells["CheckboxColumn2"].Value);
                            if (Selected)
                            {
                                f = 1;
                                SqlCommand command = new SqlCommand("delete Students where Reg_no=@Reg_no and Name=@Name and Year_Of_Admission=@Year_Of_Admission and Branch=@Branch", con.ActiveCon());
                                command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value.ToString());
                                command.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value.ToString());
                                command.Parameters.AddWithValue("@Year_Of_Admission", dr.Cells["Year_Of_Admission"].Value.ToString());
                                command.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value.ToString());
                                command.ExecuteNonQuery();
                            }
                        }
                        if (f == 1)
                        {
                            MessageBox.Show("Delete Done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Student_dgvFill();
                        }
                        else
                            MessageBox.Show("Select any Students to delete, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("You Cannot delete an Excel data, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            string regno = Regno_textbox.Text;
            string name = Name_textbox.Text;
            string branchvalue = Branch_combobox.Text;
            string yoa = YOA_textbox.Text;

            string filter = "";        //filter string for sql statements to be written
            if(regno != "")
                filter = string.Format("Reg_no like '%{0}%'", regno);
            if(name != "")
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Name Like '%{0}%'", name);
            }
            if (branchvalue != "-Select-")
            {
                if (filter.Length > 0) filter += " AND ";                    //Put AND if there is existing Sql statement in filter string
                filter += string.Format("Branch Like '%{0}%'", branchvalue);     //Put sql statement in filter string
            }
            if (yoa != "")
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Year_Of_Admission Like '%{0}%'", yoa);
            }
            Student_Source.Filter = filter;
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Student_Source.RemoveFilter();
            ClearAllStudent_Management();
            if (ClassDgvView_checkbox.Checked)
                Class_dgv_Fill();
            else
                Student_dgvFill();
            AddFromExcel_Btn.Enabled = false;
        }

        private void UpgradeSem_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You Are Going To UPGRADE Every Class Semester. Are You Sure?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                SqlCommand sc = new SqlCommand("Select Class,Semester from Management where (Class is not null) and (Semester is not null)", con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Class", typeof(string));
                dt.Columns.Add("Semester", typeof(string));
                dt.Load(reader);

                foreach (DataRow dr in dt.Rows)
                {
                    string checksem = dr["Class"].ToString() + "  S" + dr["Semester"].ToString();
                    string sem = dr["Semester"].ToString(), newclass;
                    bool res = int.TryParse(sem, out int newsem);
                    newsem++;
                    newclass = dr["Class"].ToString() + "  S" + newsem;
                    SqlCommand command2 = new SqlCommand("update Class set Class=@Class where Class=@OldClass", con.ActiveCon());
                    command2.Parameters.AddWithValue("@OldClass", checksem);
                    command2.Parameters.AddWithValue("@Class", newclass);
                    command2.ExecuteNonQuery();
                }             
                
                SqlCommand command3 = new SqlCommand("update Management set Semester= Semester + 1",con.ActiveCon());
                command3.ExecuteNonQuery();
                AssignClass_fill();
                Class_StudentsFill();
                MessageBox.Show("Upgrade Done","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
        }

        private void DegradeClass_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You Are Going To DEGRADE Every Class Semester. Are You Sure?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SqlCommand sc = new SqlCommand("Select Class,Semester from Management where (Class is not null) and (Semester is not null)", con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Class", typeof(string));
                dt.Columns.Add("Semester", typeof(string));
                dt.Load(reader);

                foreach (DataRow dr in dt.Rows)
                {
                    string checksem = dr["Class"].ToString() + "  S" + dr["Semester"].ToString();
                    string sem = dr["Semester"].ToString(), newclass;
                    bool res = int.TryParse(sem, out int newsem);
                    newsem--;
                    newclass = dr["Class"].ToString() + "  S" + newsem;
                    SqlCommand command2 = new SqlCommand("update Class set Class=@Class where Class=@OldClass", con.ActiveCon());
                    command2.Parameters.AddWithValue("@OldClass", checksem);
                    command2.Parameters.AddWithValue("@Class", newclass);
                    command2.ExecuteNonQuery();
                }

                SqlCommand command = new SqlCommand("update Management set Semester= Semester - 1", con.ActiveCon());
                command.ExecuteNonQuery();
                AssignClass_fill();
                Class_StudentsFill();
                MessageBox.Show("Degrade Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void StudentBranchComboboxFill()
        {
            SqlCommand sc = new SqlCommand("Select Branch from Management where Branch is not null", con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Branch", typeof(string)); // in datatable, a column should be created before adding rows
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            dt.Load(reader);           
            
            Branch_combobox.ValueMember = "Branch";
            Branch_combobox.DataSource = dt;
        }
        void ClassBranchComboboxFill()
        {
            SqlCommand sc = new SqlCommand("Select Branch from Management where Branch is not null", con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Branch", typeof(string)); // in datatable, a column should be created before adding rows
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            dt.Load(reader);

            AssignClassBranch_combobox.ValueMember = "Branch";
            AssignClassBranch_combobox.DataSource = dt;
        }
        void YearOfAdmissionFill()
        {
            SqlCommand sc = new SqlCommand("Select distinct Year_Of_Admission from Students", con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Year_Of_Admission", typeof(string)); // in datatable, a column should be created before adding rows
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            dt.Load(reader);

            AssignClassYOA_combobox.ValueMember = "Year_Of_Admission";
            AssignClassYOA_combobox.DataSource = dt;
        }

        private void AssignClass_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ClassDgvView_checkbox.Checked)
            {
                if (AssignClass_combobox.SelectedIndex != 0)
                {
                    string classcombo = AssignClass_combobox.Text;
                    string filter = "";
                    filter = string.Format("Class like '%{0}%'", classcombo);
                    ClassView_Source.Filter = filter;
                }
                else
                    ClassView_Source.RemoveFilter();
            }
        }

        private void AssignClassBranch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignClassFilter();
        }

        private void AssignClassYOA_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignClassFilter();
        }
        void AssignClassFilter()
        {
            string filter = "";           
            if (AssignClassBranch_combobox.Text != "-Select-")
            {
                if (filter.Length > 0) filter += " AND ";                    
                filter += string.Format("Branch Like '%{0}%'", AssignClassBranch_combobox.Text);     
            }
            if (AssignClassYOA_combobox.Text != "-Select-")
            {
                bool res = int.TryParse(AssignClassYOA_combobox.Text, out int yoa);
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Convert(Year_Of_Admission,'System.String') like '%{0}%'", yoa );
            }
            Student_Source.Filter = filter;
        }

        private void DefaultScheme_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            DefaultScheme_Panel.BringToFront();
            DefaultScheme_Panel.Enabled = true;
            Class_Managmnt_panel.Enabled = false;
            Student_mngmnt_panel.Enabled = false;
            Schemelabel();
        }

        
        
        // EXCEL GROUP BOX EVENT START
        DataTableCollection tableCollection;
        //Excel Select button click event
        private void SelectExcel_btn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "Excel Files|*.xls|*xlsx|*.xlsm" }) //check if | is needed last?
                {
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        Filepath_textbox.Text = openFile.FileName;  //Filepath_textbox.Text --- filepath is displayed in textbox
                        using (var stream = File.Open(openFile.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                tableCollection = result.Tables;
                                Sheet_combobox.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    Sheet_combobox.Items.Add(table.TableName); //add sheet to combobox
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Excel_btn_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //Sheet Combobox Event
        private void Sheet_combobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = tableCollection[Sheet_combobox.SelectedItem.ToString()];
                //Candidate_datagridview.DataSource = dt;   // <-- what error this created ? why this wont work? please Check...

                // these codes was used instead of that One Line Code above
                if (dt != null)
                {
                    List<ExcelDBManagement> excst = new List<ExcelDBManagement>(); //<--here ExcelStudents is class name
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ExcelDBManagement excclass = new ExcelDBManagement();
                        excclass.Reg_no = dt.Rows[i]["Register No"].ToString();
                        excclass.Name = dt.Rows[i]["Name"].ToString();  //have to give Excel column names inside the[""]
                        excclass.Year_Of_Admission = dt.Rows[i]["YOA"].ToString();
                        excclass.Branch = dt.Rows[i]["Branch"].ToString();
                        excst.Add(excclass);
                    }
                    Student_dgv.DataSource = excst;
                    AddFromExcel_Btn.Enabled = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Sheet_combobox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void AddFromExcel_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int f = 0;
                foreach (DataGridViewRow dr in Student_dgv.Rows)
                {
                    bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn2"].Value);
                    if (checkselected)
                    {
                        f = 1;
                        SqlCommand command = new SqlCommand("insert into Students(Reg_no,Name,Year_Of_Admission,Branch)Values(" + "@Reg_no,@Name,@Year_Of_Admission,@Branch)", con.ActiveCon());
                        command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                        command.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value);
                        command.Parameters.AddWithValue("@Year_Of_Admission", dr.Cells["Year_Of_Admission"].Value);
                        command.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                        command.ExecuteNonQuery();

                    }
                }
                if (f == 1)
                {
                    MessageBox.Show("Add From Excel Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllStudent_Management();
                    AddFromExcel_Btn.Enabled = false;
                    Student_dgvFill();
                }
                else MessageBox.Show("Select any Students", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }



        //// Import Button Event
        //private void Import_Btn_Click_1(object sender, EventArgs e)
        //{
        //    string connectionString = @"Data Source=DESKTOP-P1AI33U\SQLEXPRESS;Initial Catalog=Exam_Cell;Integrated Security=True;";
        //    DapperPlusManager.Entity<ExcelDBManagement>().Table("Excel_Show"); //"Students" is Table name from sql to import
        //    List<ExcelDBManagement> excst = studentsBindingSource.DataSource as List<ExcelDBManagement>;
        //    if (excst != null)
        //    {
        //        using (IDbConnection db = new SqlConnection(connectionString))
        //        {
        //            db.BulkInsert(excst);
        //        }
        //        MessageBox.Show("Import Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //        MessageBox.Show("Error, Try again", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

    }
}
                
