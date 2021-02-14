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
    public partial class postponement : Form
    {
        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();
        public postponement()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        BindingSource source = new BindingSource();
        void ScheduledExamFill()
        {
            try
            {
            headerchkbox.Checked = false;
            SQLiteCommand command = new SQLiteCommand("select * from Timetable order by Date,Session", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable table_Time = new DataTable();
            adapter.Fill(table_Time);
            source.DataSource = null;
            source.DataSource = table_Time;
            ScheduledExam_dgv.DataSource = source;
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
            headerchkbox.BackColor = Color.FromArgb(64, 0, 0);
            headerchkbox.Size = new Size(18, 18);
            //add checkbox into dgv
            ScheduledExam_dgv.Controls.Add(headerchkbox);
        }

        object send;
        private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        {
            send = sender;
            progressPanel.Show();
            timerHeader.Start();
        }
        private void timerHeader_Tick(object sender, EventArgs e)
        {
            timerHeader.Stop();
            Headerchckboxclick((CheckBox)send);
            progressPanel.Hide();
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
            try
            {
            string command = string.Format("Select Distinct Branch from Scheme");
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);            
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            Branch_combobox.DisplayMember = "Branch";
            Branch_combobox.ValueMember = "Branch";
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

        void SemesterComboboxFill()
        {
            try
            {
            string command = string.Format("Select Distinct Semester from Scheme");
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);            
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            Semester_combobox.DisplayMember = "Semester";
            Semester_combobox.ValueMember = "Semester";
            Semester_combobox.DataSource = dt;
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
        private void Postpone_button_Click(object sender, EventArgs e)
        {
            msgbox.show("Click Yes to Confirm   ", "Confirm", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Warning);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
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
            try
            {
            int flag = 0;
            foreach (DataGridViewRow dr in ScheduledExam_dgv.Rows)
            {
                bool checkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                if (checkboxselected)
                {
                    flag = 1;
                    string date = NewDateTimePicker.Text;
                    SQLiteCommand comm = new SQLiteCommand("Update Timetable set Date=@Date,Session=@Session where Exam_Code=@Examcode and Branch=@Branch", con.ActiveCon());
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
                msgbox.show("Exam Postponed     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
            }
            else { msgbox.show("Please Select Exam to be postponed     ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error); }
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

        void Postpone_without_session()
        {
            try
            {
            int flag = 0;
            foreach (DataGridViewRow dr in ScheduledExam_dgv.Rows)
            {
                bool checkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                if (checkboxselected)
                {
                    flag = 1;
                    string date = NewDateTimePicker.Text;
                    SQLiteCommand comm = new SQLiteCommand("Update Timetable set Date=@Date where Exam_Code=@Examcode and Branch=@Branch", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Date", date);
                    comm.Parameters.AddWithValue("@Examcode", dr.Cells["Exam_Code"].Value);
                    comm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                    comm.ExecuteNonQuery();

                }
            }
            if (flag == 1)
            {
                ScheduledExamFill();
                msgbox.show("Exam Postponed     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
            }
            else { msgbox.show("Please Select Exam to be postponed      ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error); }
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

        private void closeBtn_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = (MenuForm)Application.OpenForms["MenuForm"];
            if (menuForm.Temp_btn == menuForm.menu_item_postponement)
                menuForm.Temp_btn = null;
            menuForm.menu_item_postponement.BackColor = Color.FromArgb(48, 43, 99);
            menuForm.postponment_open = false;
            this.Close();
        }
    }
}
