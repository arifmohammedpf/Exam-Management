using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exam_Cell
{
    public partial class formtimetable : Form
    {
        Connection con = new Connection();
        public formtimetable()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        CheckBox headerchkbox = new CheckBox();
        private void formtimetable_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exam_CellTimeTableNew.Timetable' table. You can move, or remove it, as needed.
            this.timetableTableAdapter1.Fill(this.exam_CellTimeTableNew.Timetable);
            
            // TODO: This line of code loads data into the 'exam_CellScheme.Scheme' table. You can move, or remove it, as needed.
            this.schemeTableAdapter.Fill(this.exam_CellScheme.Scheme);
            try
            {
                BranchComboboxFill();
                SemesterComboboxFill();
                
                Course_Select_dgv.DataSource = schemeBindingSource;
                Timetableview_dgv.DataSource = timetableBindingSource1;
                Course_Select_dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
                Timetableview_dgv.RowsDefaultCellStyle.ForeColor = Color.Black;

                Session_combobox.SelectedIndex = 0;
                DateTimePicker.Format = DateTimePickerFormat.Custom;
                DateTimePicker.CustomFormat = "dd/MM/yyyy";
                DateTimePicker.Value = DateTime.Now;
                Branch_combobox.SelectedIndex = 0;
                Semester_combobox.SelectedIndex = 0;

                DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
                chkbox.HeaderText = "";
                chkbox.Width = 30;
                chkbox.Name = "checkBoxColumn";
                Course_Select_dgv.Columns.Insert(0, chkbox);

                AddHeaderchckbox(); //header checkbox added to candidate dgv
                headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
            }
            catch (Exception) { MessageBox.Show("Try Again", "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void AddHeaderchckbox()
        {
            try
            {
                //Locate Header Cell to place checkbox in correct position
                Point HeaderCellLocation = this.Course_Select_dgv.GetCellDisplayRectangle(0, -1, true).Location;
                //place headercheckbox to the location
                headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 2);
                headerchkbox.BackColor = Color.White;
                headerchkbox.Size = new Size(18, 18);
                //add checkbox into dgv
                Course_Select_dgv.Controls.Add(headerchkbox);
            }
            catch (Exception) { MessageBox.Show("Try Again", "AddHeaderchckbox", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        {
            try
            {
                Headerchckboxclick((CheckBox)sender);
            }
            catch (Exception) { MessageBox.Show("Try Again", "Headerchckbox_Mouseclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //headerchckbox click event
        private void Headerchckboxclick(CheckBox Hcheckbox)
        {

            try
            {
                foreach (DataGridViewRow row in Course_Select_dgv.Rows)
                    ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

                Course_Select_dgv.RefreshEdit();
            }
            catch (Exception) { MessageBox.Show("Try Again", "Headercheckboxclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            try
            {
               
                Session_combobox.SelectedIndex = 0;
                DateTimePicker.Value = DateTime.Now;
                Branch_combobox.SelectedIndex = 0;
                Semester_combobox.SelectedIndex = 0;
                Examcode_box.ResetText();
                //Datepick_box.ResetText();
                //Datewise_radio.Checked = false;
                //Branchwise_radio.Checked = false;
                
            }
            catch (Exception) { MessageBox.Show("Try Again", "Clear_btn_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        void BranchComboboxFill()
        {
            try
            {
                string command = string.Format("Select Distinct Branch from Scheme");
                SqlCommand sc = new SqlCommand(command, con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Branch", typeof(string));
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);
                dt.Load(reader);

                Branch_combobox.ValueMember = "Branch";
                Branch_combobox.DataSource = dt;

                
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again", "BranchComboboxFill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void SemesterComboboxFill()
        {
            try
            {
                string command = string.Format("Select Distinct Semester from Scheme");
                SqlCommand sc = new SqlCommand(command, con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Semester", typeof(string));
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);
                dt.Load(reader);

                Semester_combobox.ValueMember = "Semester";
                Semester_combobox.DataSource = dt;
            }
            catch (Exception) { MessageBox.Show("Try Again", "SemesterComboboxFill", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }



        private void Add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session_combobox.Text != "-Select-")
                {
                    int flag = 0;
                    foreach (DataGridViewRow dr in Course_Select_dgv.Rows)
                    {
                        bool checkboxselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkboxselect)
                        {
                            flag = 1;
                            string date = DateTimePicker.Text;
                            SqlCommand comm = new SqlCommand("Insert into Timetable(Date,Session,Exam_Code,Course,Semester,Branch)Values(" + "@Date,@Session,@Exam_Code,@Course,@Semester,@Branch)", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Date", date);
                            comm.Parameters.AddWithValue("@Session", Session_combobox.SelectedItem.ToString());
                            comm.Parameters.AddWithValue("@Exam_Code", dr.Cells["Sub_Code"].Value);
                            comm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
                            comm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
                            comm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                            comm.ExecuteNonQuery();

                        }
                    }
                    if (flag == 1)
                    {
                        MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Session_combobox.SelectedIndex = 0;
                        //Course_Select_dgv.Update();
                        //Course_Select_dgv.Refresh();
                        //Timetableview_dgv.Update();
                        //Timetableview_dgv.Refresh();
                        this.timetableTableAdapter1.Fill(this.exam_CellTimeTableNew.Timetable);
                        this.schemeTableAdapter.Fill(this.exam_CellScheme.Scheme);
                    }
                    else MessageBox.Show("No Course Selected", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Select Session", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception)
            {
                MessageBox.Show("Try Again","Exception Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Session_combobox.SelectedIndex = 0;
                //Course_Select_dgv.Update();
                //Course_Select_dgv.Refresh();
                //Timetableview_dgv.Update();
                //Timetableview_dgv.Refresh();
                this.timetableTableAdapter1.Fill(this.exam_CellTimeTableNew.Timetable);
                this.schemeTableAdapter.Fill(this.exam_CellScheme.Scheme);


            }
        }

        private void Examcode_box_TextChanged(object sender, EventArgs e)
        {
            try
            {
                coursedgvfilter();
            }
            catch (Exception) { MessageBox.Show("Try Again", "Examcode_box_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void coursedgvfilter()
        {
            try
            {
                string branch = Branch_combobox.Text;
                string semester = Semester_combobox.Text;
                string examcode = Examcode_box.Text;

                string filter = "";
                if (branch != "-Select-")
                {
                    if (filter.Length > 0) filter += " And ";
                    filter += string.Format("Branch Like '%{0}%'", branch);
                }
                if (semester != "-Select-")
                {
                    if (filter.Length > 0) filter += " And ";
                    filter += string.Format("Semester Like '%{0}%'", semester);
                }
                if (examcode != "")
                {
                    if (filter.Length > 0) filter += " And ";
                    filter += string.Format("Sub_Code Like '%{0}%'", examcode);
                }
                schemeBindingSource.Filter=filter ;
            }
            catch (Exception) { MessageBox.Show("Try Again", "coursedgvfilter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                coursedgvfilter();
            }
            catch (Exception) { MessageBox.Show("Try Again", "Branch_combobox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                coursedgvfilter();
            }
            catch (Exception) { MessageBox.Show("Try Again", "Semester_combobox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Datewise_radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SheduledBranch.Enabled = false;
                SheduledExamcode.Enabled = false;
                Datepick_box.Enabled = true;
                DateComboboxFill();

            }
            catch (Exception) { MessageBox.Show("Try Again", "Datewise_radio_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Branchwise_radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SheduledBranch.Enabled = true;
                SheduledExamcode.Enabled = true;
                Datepick_box.Enabled = false;
                SheduledBranchComboboxFill();
            }
            catch (Exception) { MessageBox.Show("Try Again", "Branchwise_radio_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void timetablefilter()
        {
            try
            {
                string branch = SheduledBranch.Text;
                string examcode = SheduledExamcode.Text;

                string filter = "";
                if (branch != "-Select-")
                {
                    if (filter.Length > 0) filter += " And ";
                    filter += string.Format("Branch Like '%{0}%'", branch);
                }
               
                if (examcode != "")
                {
                    if (filter.Length > 0) filter += " And ";
                    filter += string.Format("Exam_Code Like '%{0}%'", examcode);
                }
                timetableBindingSource1.Filter = filter;
            }
            catch (Exception) { MessageBox.Show("Try Again", "timetablefilter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        

            private void SheduledBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            timetablefilter();
        }

        private void SheduledExamcode_TextChanged(object sender, EventArgs e)
        {
            timetablefilter();
        }
        void SheduledBranchComboboxFill()
        {
            try
            {
                string command = string.Format("Select Distinct Branch from Scheme");
                SqlCommand sc = new SqlCommand(command, con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Branch", typeof(string));
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);
                dt.Load(reader);

                SheduledBranch.ValueMember = "Branch";
                SheduledBranch.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again", "SheduledBranchComboboxFill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DateComboboxFill()
        {
            try
            {
                string command = string.Format("Select Date from Timetable");
                SqlCommand sc = new SqlCommand(command, con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(string));
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);
                dt.Load(reader);

                Datepick_box.ValueMember = "Date";
                Datepick_box.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again", "DateComboboxFill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Datepick_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Datepick_box.Text != "-Select-")
                    timetableBindingSource1.Filter = string.Format("Date Like '%{0}%'", Datepick_box.Text);
                else
                    timetableBindingSource1.RemoveFilter();

            }
            catch (Exception)
            {
                MessageBox.Show("Try Again", "Datepick_box_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }    
}

                
                