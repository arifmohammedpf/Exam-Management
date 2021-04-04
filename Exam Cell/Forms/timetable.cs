using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using Exam_Cell.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Exam_Cell
{
    public partial class formtimetable : Form
    {
        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();
        Undo_backup undo = new Undo_backup();        
        public formtimetable()
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

        BindingSource source = new BindingSource();
        BindingSource source2 = new BindingSource();
        void TimetableFill()
        {
            headerchkbox.Checked = false;
            try
            {
                SQLiteCommand command = new SQLiteCommand("select * from Timetable order by Date,Session", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable table_Time = new DataTable();
                adapter.Fill(table_Time);
                source.DataSource = null;
                source.DataSource = table_Time;
                Timetableview_dgv.DataSource = source;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }
        void CourseFill()
        {
            headerchkbox.Checked = false;
            try
            {
            SQLiteCommand command = new SQLiteCommand("select * from Scheme order by Branch,Semester", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable table_course = new DataTable();
            adapter.Fill(table_course);
            source2.DataSource = null;
            source2.DataSource = table_course;
            Course_Select_dgv.DataSource = source2;
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
        private void Formtimetable_Load(object sender, EventArgs e)
        {
            Session_combobox.SelectedIndex = 0;
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = "dd-MM-yyyy";
            DateTimePicker.Value = DateTime.Now;
            
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "";
            chkbox.Width = 30;
            chkbox.Name = "checkBoxColumn";
            Course_Select_dgv.Columns.Insert(0, chkbox);

            DataGridViewCheckBoxColumn chkbox2 = new DataGridViewCheckBoxColumn();
            chkbox2.HeaderText = "";
            chkbox2.Width = 30;
            chkbox2.Name = "checkBoxColumn2";
            Timetableview_dgv.Columns.Insert(0, chkbox2);

            //AddHeaderchckbox(); //header checkbox added to candidate dgv
            //headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
        }

        //void AddHeaderchckbox()
        //{
        //    //Locate Header Cell to place checkbox in correct position
        //    Point HeaderCellLocation = this.Course_Select_dgv.GetCellDisplayRectangle(0, -1, true).Location;
        //    //place headercheckbox to the location
        //    headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 13);
        //    headerchkbox.BackColor = Color.RoyalBlue;
        //    headerchkbox.Size = new Size(18, 18);
        //    //add checkbox into dgv
        //    Course_Select_dgv.Controls.Add(headerchkbox);
        //}

        //private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        //{
        //    Headerchckboxclick((CheckBox)sender);
        //}

        ////headerchckbox click event
        //private void Headerchckboxclick(CheckBox Hcheckbox)
        //{
        //    foreach (DataGridViewRow row in Course_Select_dgv.Rows)
        //        ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

        //    Course_Select_dgv.RefreshEdit();
        //}

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Session_combobox.SelectedIndex = 0;
            DateTimePicker.Value = DateTime.Now;
            Branch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;
            Examcode_box.ResetText();
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
                            SQLiteCommand comm = new SQLiteCommand("Insert into Timetable(Date,Session,Exam_Code,Course,Semester,Branch)Values(" + "@Date,@Session,@Exam_Code,@Course,@Semester,@Branch)", con.ActiveCon());
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
                        con.CloseCon();
                        Undo_backup_function(flag);
                        Examcode_box.Clear();
                        CourseFill();
                        TimetableFill();
                    }
                    else msgbox.Show("No Course Selected    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                }
                else msgbox.Show("Select Session    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                msgbox.Show(ex.ToString(), "Exception Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                CourseFill();
                TimetableFill();
            }
        }

        private void Examcode_box_TextChanged(object sender, EventArgs e)
        {
            Coursedgvfilter();
        }

        void Coursedgvfilter()
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
            source2.Filter = filter;
        }

        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Coursedgvfilter();
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Coursedgvfilter();
        }

        private void Datewise_radio_CheckedChanged(object sender, EventArgs e)
        {
            SheduledBranch.Enabled = false;
            SheduledExamcode.Enabled = false;
            Datepick_box.Enabled = true;
            DateComboboxFill();
        }

        private void Branchwise_radio_CheckedChanged(object sender, EventArgs e)
        {
            SheduledBranch.Enabled = true;
            SheduledExamcode.Enabled = true;
            Datepick_box.Enabled = false;
            SheduledBranchComboboxFill();
        }

        void Timetablefilter()
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
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            SheduledBranch.DisplayMember = "Branch";
            SheduledBranch.ValueMember = "Branch";
            SheduledBranch.DataSource = dt;
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

        void DateComboboxFill()
        {
            try
            {
            string command = string.Format("Select Distinct Date from Timetable");
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            Datepick_box.DisplayMember = "Date";
            Datepick_box.ValueMember = "Date";
            Datepick_box.DataSource = dt;
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

        private void Datepick_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Datepick_box.Text != "-Select-")
                source.Filter = string.Format("Date Like '%{0}%'", Datepick_box.Text);
            else
                source.RemoveFilter();
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
                            Undo_backup.Date.Add(DateTimePicker.Text);
                            Undo_backup.Session.Add(Session_combobox.SelectedItem.ToString());
                            Undo_backup.Examcode.Add(dr.Cells["Sub_Code"].Value.ToString());
                            Undo_backup.Semester.Add(dr.Cells["Semester"].Value.ToString());
                            Undo_backup.Branch.Add(dr.Cells["Branch"].Value.ToString());
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
            else if(Undo_backup.Session.Count!=0)
            {
                msgbox.Show("Do you want to Undo last operation ?   ", "Alert", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
                var result = msgbox.ReturnValue;
                if (result=="Yes")
                {
                    count = Undo_backup.Session.Count;
                    for (i = 0; i < count; i++)
                    {
                        try
                        {
                        SQLiteCommand comm = new SQLiteCommand("Delete from Timetable where Date=@Date and Session=@Session and Exam_Code=@Exam_Code and Semester=@Semester and Branch=@Branch", con.ActiveCon());
                        comm.Parameters.AddWithValue("@Date", Undo_backup.Date[i]);
                        comm.Parameters.AddWithValue("@Session", Undo_backup.Session[i]);
                        comm.Parameters.AddWithValue("@Exam_Code", Undo_backup.Examcode[i]);
                        comm.Parameters.AddWithValue("@Semester", Undo_backup.Semester[i]);
                        comm.Parameters.AddWithValue("@Branch", Undo_backup.Branch[i]);
                        comm.ExecuteNonQuery();
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
                    Clear_list();
                    CourseFill();
                    TimetableFill();
                    msgbox.Show("Last Operation have been Undone   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);                    
                }                
            }
        }

        private void Undo_btn_Click(object sender, EventArgs e)
        {            
                int f = 0;
                Undo_backup_function(f);            
        }

        void Clear_list()
        {
            Undo_backup.Date.Clear();
            Undo_backup.Session.Clear();
            Undo_backup.Examcode.Clear();
            Undo_backup.Semester.Clear();
            Undo_backup.Branch.Clear();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            BranchComboboxFill();
            SemesterComboboxFill();
            CourseFill();
            TimetableFill();
        }
        
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = (MenuForm)Application.OpenForms["MenuForm"];
            if(menuForm.Temp_btn == menuForm.menu_item_timetable)
                menuForm.Temp_btn = null;
            menuForm.menu_item_timetable.BackColor = Color.FromArgb(48, 43, 99);
            menuForm.timetable_open = false;
            this.Close();
        }

        void DeleteFunction(DataGridViewRow dr)
        {
            SQLiteCommand comm = new SQLiteCommand("Delete from Timetable where Date=@Date and Session=@Session and Exam_Code=@Exam_Code and Course=@Course and Semester=@Semester and Branch=@Branch", con.ActiveCon());
            comm.Parameters.AddWithValue("@Date", dr.Cells["Date"].Value);
            comm.Parameters.AddWithValue("@Session", dr.Cells["Session"].Value);
            comm.Parameters.AddWithValue("@Exam_Code", dr.Cells["Exam_Code"].Value);
            comm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
            comm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
            comm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
            comm.ExecuteNonQuery();
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            msgbox.Show("Do you really want to Delete ?     ", "Confirm", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            try
            {
                if (result == "Yes")
                {
                    int flag = 0;
                    foreach (DataGridViewRow dr in Timetableview_dgv.Rows)
                    {
                        bool checkboxselect = Convert.ToBoolean(dr.Cells["checkBoxColumn2"].Value);
                        if (checkboxselect)
                        {
                            flag = 1;
                            DeleteFunction(dr);
                        }
                    }
                    if (flag == 1)
                    {
                        con.CloseCon();
                        TimetableFill();
                    }
                    else msgbox.Show("No Selection made    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                TimetableFill();
            }
        }
    }    
}

                
                