using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using Exam_Cell.Forms;

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
        private void formtimetable_Load(object sender, EventArgs e)
        {
            //timer1.Start();

            //BranchComboboxFill();
            //SemesterComboboxFill();
            //CourseFill();
            //TimetableFill();

            Session_combobox.SelectedIndex = 0;
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = "dd-MM-yyyy";
            DateTimePicker.Value = DateTime.Now;
            

            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "";
            chkbox.Width = 30;
            chkbox.Name = "checkBoxColumn";
            Course_Select_dgv.Columns.Insert(0, chkbox);

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
            //Datepick_box.ResetText();
            //Datewise_radio.Checked = false;
            //Branchwise_radio.Checked = false;
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
            msgbox.show("Click Yes to Add", "Confirmation", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Information);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
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
                            Session_combobox.SelectedIndex = 0;
                            Examcode_box.Clear();
                            CourseFill();
                            TimetableFill();
                            msgbox.show("Success", "", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                        }
                        else msgbox.show("No Course Selected", "Alert", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    }
                    else msgbox.show("Select Session", "Alert", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);

                }
                catch (Exception ex)
                {
                    msgbox.show(ex.ToString(), "Exception Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    Session_combobox.SelectedIndex = 0;
                    //Course_Select_dgv.Update();
                    //Course_Select_dgv.Refresh();
                    //Timetableview_dgv.Update();
                    //Timetableview_dgv.Refresh();
                    CourseFill();
                    TimetableFill();
                }
            }
                
        }

        private void Examcode_box_TextChanged(object sender, EventArgs e)
        {
            coursedgvfilter();
        }

        void coursedgvfilter()
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
            coursedgvfilter();
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            coursedgvfilter();
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
                msgbox.show("Do you want to Undo last operation ?", "Warning", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Warning);
                var result = msgbox.ReturnValue;
                if (result=="Yes")
                {
                    count = Undo_backup.session.Count;
                    for (i = 0; i < count; i++)
                    {
                        try
                        {
                        SQLiteCommand comm = new SQLiteCommand("Delete from Timetable where Date=@Date and Session=@Session and Exam_Code=@Exam_Code and Semester=@Semester and Branch=@Branch", con.ActiveCon());
                        comm.Parameters.AddWithValue("@Date", Undo_backup.date[i]);
                        comm.Parameters.AddWithValue("@Session", Undo_backup.session[i]);
                        comm.Parameters.AddWithValue("@Exam_Code", Undo_backup.examcode[i]);
                        comm.Parameters.AddWithValue("@Semester", Undo_backup.semester[i]);
                        comm.Parameters.AddWithValue("@Branch", Undo_backup.branch[i]);
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
                    msgbox.show("Undo Successfull", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);                    
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            BranchComboboxFill();
            SemesterComboboxFill();
            CourseFill();
            TimetableFill();
        }
    }    
}

                
                