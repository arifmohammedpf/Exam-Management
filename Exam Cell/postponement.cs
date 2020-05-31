using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Cell
{
    public partial class postponement : Form
    {
        Connection con = new Connection();
        public postponement()
        {
            InitializeComponent();
        }

        private void examdetails_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        CheckBox headerchkbox = new CheckBox();
        private void postponement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exam_CellTimeTableNew.Timetable' table. You can move, or remove it, as needed.
            this.timetableTableAdapter1.Fill(this.exam_CellTimeTableNew.Timetable);

            ScheduledExam_dgv.DataSource = timetableBindingSource1;
            BranchComboboxFill();
            SemesterComboboxFill();
            ScheduledExam_dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = "dd/MM/yyyy";
            DateTimePicker.Value = DateTime.Now;
            Branch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;
            NewSession_combobox.SelectedIndex = 0;
            NewDateTimePicker.Format = DateTimePickerFormat.Custom;
            NewDateTimePicker.CustomFormat = "dd/MM/yyyy";
            NewDateTimePicker.Value = DateTime.Now;
            DateTimePicker.Enabled = false;
            

            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "";
            chkbox.Width = 30;
            chkbox.Name = "checkBoxColumn";
            ScheduledExam_dgv.Columns.Insert(0, chkbox);

            AddHeaderchckbox(); //header checkbox added to candidate dgv
            headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
        }

        void AddHeaderchckbox()
        {
            try
            {
                //Locate Header Cell to place checkbox in correct position
                Point HeaderCellLocation = this.ScheduledExam_dgv.GetCellDisplayRectangle(0, -1, true).Location;
                //place headercheckbox to the location
                headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 2);
                headerchkbox.BackColor = Color.White;
                headerchkbox.Size = new Size(18, 18);
                //add checkbox into dgv
                ScheduledExam_dgv.Controls.Add(headerchkbox);
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
                foreach (DataGridViewRow row in ScheduledExam_dgv.Rows)
                    ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

                ScheduledExam_dgv.RefreshEdit();
            }
            catch (Exception) { MessageBox.Show("Try Again", "Headercheckboxclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
        private void Postpone_button_Click(object sender, EventArgs e)
        {   
            //try
            //{
                if(NewSession_combobox.SelectedItem.ToString() != "-Select-")
                {
                    postpone_with_session();
                }
                else
                {
                    postpone_without_session();
                }
            //}
            //catch (Exception) { MessageBox.Show("Try Again", "Postpone_button_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void postpone_with_session()
        {
            
            int flag = 0;
            foreach (DataGridViewRow dr in ScheduledExam_dgv.Rows)
            {
                bool checkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                if (checkboxselected)
                {
                    flag = 1;
                    string date = NewDateTimePicker.Text;
                    MessageBox.Show(dr.Cells["Exam_Code"].Value.ToString());
                    SqlCommand comm = new SqlCommand("Update Timetable set Date=@Date,Session=@Session where Exam_Code=@Examcode and Branch=@Branch", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Date", date);
                    comm.Parameters.AddWithValue("@Session", NewSession_combobox.SelectedItem);
                    comm.Parameters.AddWithValue("@Examcode", dr.Cells["Exam_Code"].Value);
                    comm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                    comm.ExecuteNonQuery();

                }
            }
            if (flag == 1)
            {
                this.timetableTableAdapter1.Fill(this.exam_CellTimeTableNew.Timetable);
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Please Select Exam to be postponed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void postpone_without_session()
        {
            int flag = 0;
            foreach (DataGridViewRow dr in ScheduledExam_dgv.Rows)
            {
                bool checkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                if (checkboxselected)
                {
                    flag = 1;
                    string date = NewDateTimePicker.Text;
                    SqlCommand comm = new SqlCommand("Update Timetable set Date=@Date where Exam_Code=@Examcode and Branch=@Branch", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Date", date);
                    comm.Parameters.AddWithValue("@Examcode", dr.Cells["Exam_Code"].Value);
                    comm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                    comm.ExecuteNonQuery();

                }
            }
            if (flag == 1)
            {
                this.timetableTableAdapter1.Fill(this.exam_CellTimeTableNew.Timetable);
                MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Please Select Exam to be postponed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            NewDateTimePicker.Value = DateTime.Now;
            NewSession_combobox.SelectedIndex = 0;
            DateTimePicker.Value = DateTime.Now;
            Branch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;
            ScheduledExam_dgv.DataSource = null;
            ScheduledExam_dgv.DataSource = timetableBindingSource1;
        }

        void coursedgvfilter()
        {
            try
            {
                string branch = Branch_combobox.Text;
                string semester = Semester_combobox.Text;
                string examcode = Examcode_textbox.Text;
                string date = DateTimePicker.Text;


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
                    filter += string.Format("Exam_Code Like '%{0}%'", examcode);
                }
                if (DateCheckbox.Checked)
                {
                    
                    if (filter.Length > 0) filter += " And ";
                    filter += string.Format("Date Like '%{0}%'", date);
                }
                timetableBindingSource1.Filter = filter;
            }
            catch (Exception) { MessageBox.Show("Try Again", "coursedgvfilter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            coursedgvfilter();
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            coursedgvfilter();
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            coursedgvfilter();
        }

        private void Examcode_textbox_TextChanged(object sender, EventArgs e)
        {
            coursedgvfilter();
        }

        private void DateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(DateCheckbox.Checked)
            {
                DateTimePicker.Enabled = true;
                coursedgvfilter();
            }
            else
            {
                timetableBindingSource1.RemoveFilter();
                DateTimePicker.Enabled = false;
            }
        }
    }
}
