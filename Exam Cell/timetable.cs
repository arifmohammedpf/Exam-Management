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
        Undo_backup undo = new Undo_backup();
        
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
        BindingSource source = new BindingSource();
        BindingSource source2 = new BindingSource();
        void TimetableFill()
        {
            headerchkbox.Checked = false;
            SqlCommand command = new SqlCommand("select * from Timetable order by Date,Session", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_Time = new DataTable();
            adapter.Fill(table_Time);
            source.DataSource = null;
            source.DataSource = table_Time;
            Timetableview_dgv.DataSource = source;
        }
        void CourseFill()
        {
            headerchkbox.Checked = false;
            SqlCommand command = new SqlCommand("select * from Scheme order by Branch,Semester", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_course = new DataTable();
            adapter.Fill(table_course);
            source2.DataSource = null;
            source2.DataSource = table_course;
            Course_Select_dgv.DataSource = source2;
        }
        CheckBox headerchkbox = new CheckBox();
        private void formtimetable_Load(object sender, EventArgs e)
        {            
            //try
            //{
                BranchComboboxFill();
                SemesterComboboxFill();

                CourseFill();
                TimetableFill();
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
            //}
            //catch (Exception) { MessageBox.Show("Try Again", "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                Branch_combobox.DisplayMember = "Branch";
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
                Semester_combobox.DisplayMember = "Semester";
                Semester_combobox.ValueMember = "Semester";
                Semester_combobox.DataSource = dt;
            }
            catch (Exception) { MessageBox.Show("Try Again", "SemesterComboboxFill", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        int clearcount = 0;
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
                            SqlCommand comm = new SqlCommand("Insert into Timetable(Date,Session,Exam_Code,Course,Semester,Branch)Values(" + "@Date,@Session,@Exam_Code,@Course,@Semester,@Branch)", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
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
                        Undo_backup_function(flag);
                        Session_combobox.SelectedIndex = 0;
                        Examcode_box.Clear();
                        CourseFill();
                        TimetableFill();
                        MessageBox.Show("Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                CourseFill();
                TimetableFill();
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
                source2.Filter=filter ;
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

        void Timetablefilter()
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
                source.Filter = filter;
            }
            catch (Exception) { MessageBox.Show("Try Again", "timetablefilter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        

        private void SheduledBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Timetablefilter();
        }

        private void SheduledExamcode_TextChanged(object sender, EventArgs e)
        {
            Timetablefilter();
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
                SheduledBranch.DisplayMember = "Branch";
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
                Datepick_box.DisplayMember = "Date";
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
                    source.Filter = string.Format("Date Like '%{0}%'", Datepick_box.Text);
                else
                    source.RemoveFilter();

            }
            catch (Exception)
            {
                MessageBox.Show("Try Again", "Datepick_box_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        void Undo_backup_function(int f)
        {         
            int i,count;
            if (f == 1)
            {
                if(clearcount==0)
                {
                    foreach (DataGridViewRow dr in Course_Select_dgv.Rows)
                    {
                        bool checkboxselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkboxselect)
                        {
                            Undo_backup.date.Add(DateTimePicker.Text);
                            Undo_backup.session.Add(Session_combobox.SelectedItem.ToString());
                            Undo_backup.examcode.Add(dr.Cells["Sub_Code"].Value.ToString());
                            Undo_backup.semester.Add(dr.Cells["Semester"].Value.ToString());
                            Undo_backup.branch.Add(dr.Cells["Branch"].Value.ToString());
                        }
                    }
                    clearcount++;
                }
                else
                {
                    Clear_list();
                    clearcount = 0;
                    Undo_backup_function(1);
                }
            }
            else if(Undo_backup.session.Count!=0)
            {
                DialogResult result = MessageBox.Show("Do you want to Undo last operation ?", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(result==DialogResult.Yes)
                {
                    count = Undo_backup.session.Count;
                    for (i = 0; i < count; i++)
                    {
                        SqlCommand comm = new SqlCommand("Delete from Timetable where Date=@Date and Session=@Session and Exam_Code=@Exam_Code and Semester=@Semester and Branch=@Branch", con.ActiveCon());
                        comm.Parameters.AddWithValue("@Date", Undo_backup.date[i]);
                        comm.Parameters.AddWithValue("@Session", Undo_backup.session[i]);
                        comm.Parameters.AddWithValue("@Exam_Code", Undo_backup.examcode[i]);
                        comm.Parameters.AddWithValue("@Semester", Undo_backup.semester[i]);
                        comm.Parameters.AddWithValue("@Branch", Undo_backup.branch[i]);
                        comm.ExecuteNonQuery();
                    }
                    Clear_list();
                    MessageBox.Show("Undo Successfull");
                    CourseFill();
                    TimetableFill();
                }
                else { }
                
            }
            else { }
        }

        private void Undo_btn_Click(object sender, EventArgs e)
        {
            int f = 0;
            Undo_backup_function(f);
        }

        void Clear_list()
        {
            Undo_backup.date.Clear();
            Undo_backup.session.Clear();
            Undo_backup.examcode.Clear();
            Undo_backup.semester.Clear();
            Undo_backup.branch.Clear();
        }
    }    
}

                
                