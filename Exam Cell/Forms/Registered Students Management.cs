using Exam_Cell.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Cell
{
    public partial class Registered_Students_Management : Form
    {
        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();
        public Registered_Students_Management()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(53, 92, 125), Color.FromArgb(108, 91, 123), 280F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        //CheckBox headerchkbox = new CheckBox();
        private void Registered_Students_Management_Load(object sender, EventArgs e)
        {
            Secure_tools_disabled();
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "";
            chkbox.Width = 30;
            chkbox.Name = "checkBoxColumn";
            Registered_dgv.Columns.Insert(0, chkbox);

            //AddHeaderchckbox(); //header checkbox added to candidate dgv
            //headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
        }

        void StudentsCountLabel()
        {
            No_of_stud_count_label.Text = "No of Students : " + Registered_dgv.RowCount.ToString();
        }

        private void DeleteAll_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("You are going to Delete every Students in the list.    \n Are You Sure ?   ", "Warning", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            try
            {
            if (result == "Yes")
            {
                if (Univrsty_radiobtn.Checked)
                {
                    SQLiteCommand command = new SQLiteCommand("Delete from Registered_candidates", con.ActiveCon());
                    command.ExecuteNonQuery();
                    University_fill();
                    Clear_function();
                    msgbox.show("All Registered Candidates Deleted    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
                else if (Series_radiobtn.Checked)
                {
                    SQLiteCommand command = new SQLiteCommand("Delete from Series_candidates", con.ActiveCon());
                    command.ExecuteNonQuery();
                    Series_fill();
                    Clear_function();
                    msgbox.show("All Registered Candidates Deleted    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
                else if (AllotUniversty_radiobtn.Checked)
                {
                    SQLiteCommand command = new SQLiteCommand("Delete from University_Alloted", con.ActiveCon());
                    command.ExecuteNonQuery();
                    UniversityAlloted_fill();
                    Clear_function();
                    msgbox.show("All Alloted Candidates Deleted    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
                else if (AllotSeries_radiobtn.Checked)
                {
                    SQLiteCommand command = new SQLiteCommand("Delete from Series_Alloted", con.ActiveCon());
                    command.ExecuteNonQuery();
                    SeriesAlloted_fill();
                    Clear_function();
                    msgbox.show("All Alloted Candidates Deleted    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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

        //void AddHeaderchckbox()
        //{
        //    //Locate Header Cell to place checkbox in correct position
        //    Point HeaderCellLocation = this.Registered_dgv.GetCellDisplayRectangle(0, -1, true).Location;
        //    //place headercheckbox to the location
        //    headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 13);
        //    headerchkbox.BackColor = Color.RoyalBlue;
        //    headerchkbox.Size = new Size(18, 18);
        //    //add checkbox into dgv
        //    Registered_dgv.Controls.Add(headerchkbox);
        //}

        //private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        //{
        //    Headerchckboxclick((CheckBox)sender);
        //}

        ////headerchckbox click event
        //private void Headerchckboxclick(CheckBox Hcheckbox)
        //{
        //    foreach (DataGridViewRow row in Registered_dgv.Rows)
        //        ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

        //    Registered_dgv.RefreshEdit();
        //}

        BindingSource Universitybinding = new BindingSource();
        BindingSource UniversityAllotbinding = new BindingSource();
        BindingSource Seriesbinding = new BindingSource();
        BindingSource SeriesAllotbinding = new BindingSource();        
        void University_fill()
        {
            try
            {
            SQLiteCommand command = new SQLiteCommand("select * from Registered_candidates order by Branch,Reg_no", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable Unv_students = new DataTable();
            adapter.Fill(Unv_students);
            Universitybinding.DataSource = null;
            Universitybinding.DataSource = Unv_students;
            Registered_dgv.DataSource = null;
            Registered_dgv.DataSource = Universitybinding;
            StudentsCountLabel();
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
        void Series_fill()
        {
            try
            {
            SQLiteCommand command = new SQLiteCommand("select * from Series_candidates order by Course, Class, Name", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable Srs_students = new DataTable();
            adapter.Fill(Srs_students);
            Seriesbinding.DataSource = null;
            Seriesbinding.DataSource = Srs_students;
            Registered_dgv.DataSource = null;
            Registered_dgv.DataSource = Seriesbinding;
            StudentsCountLabel();
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
        void UniversityAlloted_fill()
        {
            try
            {
            SQLiteCommand command = new SQLiteCommand("select * from University_Alloted order by Date,Room_No,Reg_no", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable unv_allot = new DataTable();
            adapter.Fill(unv_allot);
            UniversityAllotbinding.DataSource = null;
            UniversityAllotbinding.DataSource = unv_allot;
            Registered_dgv.DataSource = null;
            Registered_dgv.DataSource = UniversityAllotbinding;
            StudentsCountLabel();
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
        void SeriesAlloted_fill()
        {
            try
            {
            SQLiteCommand command = new SQLiteCommand("select * from Series_Alloted order by Date, Room_No, Name", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable srs_allot = new DataTable();
            adapter.Fill(srs_allot);
            SeriesAllotbinding.DataSource = null;
            SeriesAllotbinding.DataSource = srs_allot;
            Registered_dgv.DataSource = null;
            Registered_dgv.DataSource = SeriesAllotbinding;
            StudentsCountLabel();
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
        private void Univrsty_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Univrsty_radiobtn.Checked)
            {
                Secure_tools_enabled();
                University_fill();
                Branch_ComboFill();
                Semester_combobox.SelectedIndex = 0;
                Series_radiobtn.Checked = false;
                AllotUniversty_radiobtn.Checked = false;
                AllotSeries_radiobtn.Checked = false;
            }
        }

        private void Series_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Series_radiobtn.Checked)
            {
                Secure_tools_enabled();
                Series_fill();
                Branch_ComboFill();
                Semester_combobox.SelectedIndex = 0;
                Univrsty_radiobtn.Checked = false;
                AllotUniversty_radiobtn.Checked = false;
                AllotSeries_radiobtn.Checked = false;
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Do you really want to Delete ?     ", "Confirm", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            try
            {
            if (result == "Yes")
            {
                        int f = 0;
                if (Univrsty_radiobtn.Checked)
                {
                    foreach (DataGridViewRow dr in Registered_dgv.Rows)
                    {
                        bool checkselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkselect)
                        {
                                f = 1;
                            SQLiteCommand command = new SQLiteCommand("Delete from Registered_candidates where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                        if (f == 1)
                        {
                            msgbox.show("Selected Candidates Deleted    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            University_fill();
                            Clear_function();
                        }
                        else
                        {
                            msgbox.show("No Candidates Selected     ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                        }
                    }
                else if (Series_radiobtn.Checked)
                {
                    foreach (DataGridViewRow dr in Registered_dgv.Rows)
                    {
                        bool checkselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkselect)
                        {
                                f = 1;
                            SQLiteCommand command = new SQLiteCommand("Delete from Series_candidates where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                        if (f == 1)
                        {
                            msgbox.show("Selected Candidates Deleted    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            Series_fill();
                            Clear_function();
                        }
                        else
                        {
                            msgbox.show("No Candidates Selected     ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                        }
                    }
                else if (AllotSeries_radiobtn.Checked)
                {
                    foreach (DataGridViewRow dr in Registered_dgv.Rows)
                    {
                        bool checkselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkselect)
                        {
                                f = 1;
                            SQLiteCommand command = new SQLiteCommand("Delete from Series_Alloted where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                        if (f == 1)
                        {
                            msgbox.show("Selected Alloted Candidates Deleted    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            SeriesAlloted_fill();
                            Clear_function();
                        }
                        else
                        {
                            msgbox.show("No Candidates Selected     ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                        }
                    }
                else if (AllotUniversty_radiobtn.Checked)
                {
                    foreach (DataGridViewRow dr in Registered_dgv.Rows)
                    {
                        bool checkselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkselect)
                        {
                                f = 1;
                            SQLiteCommand command = new SQLiteCommand("Delete from University_Alloted where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                        if (f == 1)
                        {
                            msgbox.show("Selected Alloted Candidates Deleted    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            UniversityAlloted_fill();
                            Clear_function();
                        }
                        else
                        {
                            msgbox.show("No Candidates Selected    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                        }
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

        private void AllotUniversty_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(AllotUniversty_radiobtn.Checked)
            {
                Secure_tools_enabled();
                Univrsty_radiobtn.Checked = false;
                Series_radiobtn.Checked = false;
                AllotSeries_radiobtn.Checked = false;
                Branch_combobox.Enabled = false;
                Semester_combobox.Enabled = false;
                UniversityAlloted_fill();
            }
        }

        private void AllotSeries_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(AllotSeries_radiobtn.Checked)
            {
                Secure_tools_enabled();
                Univrsty_radiobtn.Checked = false;
                Series_radiobtn.Checked = false;
                AllotUniversty_radiobtn.Checked = false;
                Branch_combobox.Enabled = false;
                Semester_combobox.Enabled = false;
                SeriesAlloted_fill();
            }
        }

        void Filter_Function()
        {            
            if (Univrsty_radiobtn.Checked)
            {
                string regno = Regno_textbox.Text;

                string filter = "";        //filter string for sql statements to be written
                if (regno != "")
                    filter = string.Format("Reg_no like '%{0}%'", regno);

                if (Branch_combobox.SelectedIndex != 0)
                {
                    if (filter.Length > 0) filter += " AND ";                    //Put AND if there is existing Sql statement in filter string
                    filter += string.Format("Branch Like '%{0}%'", Branch_combobox.Text);     //Put sql statement in filter string
                }
                if (Semester_combobox.SelectedIndex != 0)
                {
                    if (filter.Length > 0) filter += " AND ";
                    filter += string.Format("Semester Like '%{0}%'", Semester_combobox.Text);
                }
                Universitybinding.Filter = filter;
            }
            else if (Series_radiobtn.Checked)
            {
                string regno = Regno_textbox.Text;

                string filter = "";        //filter string for sql statements to be written
                if (regno != "")
                    filter = string.Format("Reg_no like '%{0}%'", regno);
                if (Branch_combobox.SelectedIndex != 0)
                {
                    if (filter.Length > 0) filter += " AND ";                    //Put AND if there is existing Sql statement in filter string
                    filter += string.Format("Class Like '%{0}%'", Branch_combobox.Text);     //Put sql statement in filter string
                }
                if (Semester_combobox.SelectedIndex != 0)
                {
                    if (filter.Length > 0) filter += " AND ";
                    filter += string.Format("Semester Like '%{0}%'", Semester_combobox.Text);
                }
                Seriesbinding.Filter = filter;
            }
            else if (AllotSeries_radiobtn.Checked || AllotUniversty_radiobtn.Checked)
            {
                string regno = Regno_textbox.Text;

                string filter = "";        //filter string for sql statements to be written
                if (regno != "")
                    filter = string.Format("Reg_no like '%{0}%'", regno);
                              
                if (AllotSeries_radiobtn.Checked)
                    SeriesAllotbinding.Filter = filter;
                else if (AllotUniversty_radiobtn.Checked)
                    UniversityAllotbinding.Filter = filter;
            }
            StudentsCountLabel();
        }

        private void Regno_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filter_Function();
            }
            catch (Exception) { }
        }

        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Filter_Function();
            }
            catch (Exception) { }
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Filter_Function();
            }
            catch (Exception) { }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear_function();
        }
        void Clear_function()
        {
            Branch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;
            Regno_textbox.Clear();
        }
        void Branch_ComboFill()
        {
            try
            {
                string commandString="";

                if (Univrsty_radiobtn.Checked) commandString = "Select Distinct Branch from Scheme";                
                else if (Series_radiobtn.Checked) commandString = "Select Distinct Class from Management";

            SQLiteCommand sc = new SQLiteCommand(commandString, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

                if (Univrsty_radiobtn.Checked)
                {
                    DataRow top = dt.NewRow();
                    top[0] = "-Select Branch-";
                    dt.Rows.InsertAt(top, 0);

                    Branch_combobox.ValueMember = "Branch";  //column name is given to get values to show in combobox
                }
                else if (Series_radiobtn.Checked)
                {
                    DataRow top = dt.NewRow();
                    top[0] = "-Select Class-";
                    dt.Rows.InsertAt(top, 0);

                    Branch_combobox.ValueMember = "Class";  //column name is given to get values to show in combobox
                }

            Branch_combobox.DataSource = dt;
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
        void Secure_tools_disabled()
        {
            Regno_textbox.Enabled = false;
            Branch_combobox.Enabled = false;
            Semester_combobox.Enabled = false;
            ClearBtn.Enabled = false;
            DeleteAll_btn.Enabled = false;
            Delete_btn.Enabled = false;
        }
        void Secure_tools_enabled()
        {
            Regno_textbox.Enabled = true;
            Branch_combobox.Enabled = true;
            Semester_combobox.Enabled = true;
            ClearBtn.Enabled = true;
            DeleteAll_btn.Enabled = true;
            Delete_btn.Enabled = true;
        }        

        private void closeBtn_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = (MenuForm)Application.OpenForms["MenuForm"];
            if (menuForm.Temp_btn == menuForm.menu_item_regstudmgmnt)
                menuForm.Temp_btn = null;
            menuForm.menu_item_regstudmgmnt.BackColor = Color.FromArgb(48, 43, 99);
            menuForm.regstudmgmnt_open = false;
            this.Close();
        }
    }
}
