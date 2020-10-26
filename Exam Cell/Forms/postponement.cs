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

        BindingSource source = new BindingSource();
        void ScheduledExamFill()
        {
            headerchkbox.Checked = false;
            SqlCommand command = new SqlCommand("select * from Timetable order by Date,Session", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_Time = new DataTable();
            adapter.Fill(table_Time);
            source.DataSource = null;
            source.DataSource = table_Time;
            ScheduledExam_dgv.DataSource = source;
        }
        CheckBox headerchkbox = new CheckBox();
        private void postponement_Load(object sender, EventArgs e)
        {
            ScheduledExamFill();
            BranchComboboxFill();
            SemesterComboboxFill();
            ScheduledExam_dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = "dd-MM-yyyy";
            DateTimePicker.Value = DateTime.Now;
            Branch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;
            NewSession_combobox.SelectedIndex = 0;
            NewDateTimePicker.Format = DateTimePickerFormat.Custom;
            NewDateTimePicker.CustomFormat = "dd-MM-yyyy";
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
            //Locate Header Cell to place checkbox in correct position
            Point HeaderCellLocation = this.ScheduledExam_dgv.GetCellDisplayRectangle(0, -1, true).Location;
            //place headercheckbox to the location
            headerchkbox.Location = new Point(HeaderCellLocation.X - 18, HeaderCellLocation.Y + 13);
            headerchkbox.BackColor = Color.RoyalBlue;
            headerchkbox.Size = new Size(18, 18);
            //add checkbox into dgv
            ScheduledExam_dgv.Controls.Add(headerchkbox);
        }

        private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        {
            Headerchckboxclick((CheckBox)sender);
        }

        //headerchckbox click event
        private void Headerchckboxclick(CheckBox Hcheckbox)
        {
            foreach (DataGridViewRow row in ScheduledExam_dgv.Rows)
                ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

            ScheduledExam_dgv.RefreshEdit();
        }

        void BranchComboboxFill()
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
            Branch_combobox.DisplayMember = "Branch";
            Branch_combobox.ValueMember = "Branch";
            Branch_combobox.DataSource = dt;
        }

        void SemesterComboboxFill()
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
            Semester_combobox.DisplayMember = "Semester";
            Semester_combobox.ValueMember = "Semester";
            Semester_combobox.DataSource = dt;
        }
        private void Postpone_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Click Yes to Confirm", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result == DialogResult.Yes)
            {
                if (NewSession_combobox.SelectedItem.ToString() != "-Optional-")
                {
                    Postpone_with_session();
                }
                else
                {
                    Postpone_without_session();
                }
            }
        }

        void Postpone_with_session()
        {            
            int flag = 0;
            foreach (DataGridViewRow dr in ScheduledExam_dgv.Rows)
            {
                bool checkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                if (checkboxselected)
                {
                    flag = 1;
                    string date = NewDateTimePicker.Text;
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
                ScheduledExamFill();
                MessageBox.Show("Exam Postponed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Please Select Exam to be postponed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void Postpone_without_session()
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
                ScheduledExamFill();
                MessageBox.Show("Exam Postponed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Please Select Exam to be postponed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            ScheduledExamFill();
            NewDateTimePicker.Value = DateTime.Now;
            NewSession_combobox.SelectedIndex = 0;
            DateTimePicker.Value = DateTime.Now;
            Branch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;            
        }

        void Coursedgvfilter()
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
            source.Filter = filter;
        }

        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Coursedgvfilter();
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Coursedgvfilter();
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Coursedgvfilter();
        }

        private void Examcode_textbox_TextChanged(object sender, EventArgs e)
        {
            Coursedgvfilter();
        }

        private void DateCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(DateCheckbox.Checked)
            {
                DateTimePicker.Enabled = true;
                Coursedgvfilter();
            }
            else
            {
                source.RemoveFilter();
                DateTimePicker.Enabled = false;
            }
        }
    }
}
