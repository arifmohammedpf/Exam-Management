using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using Exam_Cell.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Exam_Cell
{
    public partial class Allotment : Form
    {
        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();

        public Allotment()
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

        private void SingleAllotment_button_Click(object sender, EventArgs e)
        {
            using (ProgressForm progressForm = new ProgressForm(Single_Allotment))
            {
                progressForm.ShowDialog(this);
            }            
        }
        private void MultiAllot_Click(object sender, EventArgs e)
        {
            using (ProgressForm progressForm = new ProgressForm(Multi_Allotment))
            {
                progressForm.ShowDialog(this);
            }
        }
        void Single_Allotment()
        {                        
            try
            {
            //get registered students details
            SQLiteCommand command2 = new SQLiteCommand("select RC.Reg_no,RC.Name,RC.Branch,TT.Exam_Code,TT.Course from Registered_candidates as RC,Timetable as TT where TT.Date=@Date and TT.Session=@Session and RC.Course=TT.Course order by TT.Course,RC.Reg_no", con.ActiveCon());
            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(command2);
            DataTable table_students = new DataTable();
            adapter2.Fill(table_students);
            con.CloseCon();
            if (table_students.Rows.Count == 0)
            {
                msgbox.show("No Candidates Registered or Timetable set to Allot,   \n Register the candidates First    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                return;
            }            
            //get rooms details
            SQLiteCommand command3 = new SQLiteCommand("select * from Rooms order by Priority", con.ActiveCon());
            SQLiteDataAdapter adapter3 = new SQLiteDataAdapter(command3);
            DataTable table_rooms = new DataTable();
            adapter3.Fill(table_rooms);
            con.CloseCon();
            if (table_rooms.Rows.Count == 0)
            {
                msgbox.show("No Rooms Assigned to Allot,     \n Create Rooms First   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                return;
            }
                //get branch priority
                SQLiteCommand command = new SQLiteCommand("select * from Branch_Priority order by Priority", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable table_branchPriority = new DataTable();
                adapter.Fill(table_branchPriority);
                con.CloseCon();
                //sort table_students according to branch priority                
                table_students.Columns.Add("BranchPriority");
                foreach(DataRow branchDr in table_branchPriority.Rows)
                {
                    foreach(DataRow studDr in table_students.Rows)
                    {
                        if (studDr["Branch"] == branchDr["Branch"])
                        {
                            studDr["BranchPriority"] = branchDr["Priority"];
                        }
                    }
                }                
                table_students.DefaultView.Sort = "Priority,Course,Reg_no";
                table_students = table_students.DefaultView.ToTable();

                //allot room
                int studCount=table_students.Rows.Count, count = 0, flag = 0;                 
                foreach (DataRow roomrow in table_rooms.Rows)
                {
                    int series = Int32.Parse(roomrow["A_Series"].ToString());
                    for (int i = 0; i < series; i++)
                    {
                        if (count < studCount)
                        {
                            SQLiteCommand command4 = new SQLiteCommand("insert into University_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Branch,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Branch,@Exam_Code,@Course)", con.ActiveCon());
                            command4.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                            command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                            command4.Parameters.AddWithValue("@Seat", "A" + (i + 1));
                            command4.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            command4.Parameters.AddWithValue("@Reg_no", table_students.Rows[count]["Reg_no"].ToString());
                            command4.Parameters.AddWithValue("@Name", table_students.Rows[count]["Name"].ToString());
                            command4.Parameters.AddWithValue("@Branch", table_students.Rows[count]["Branch"].ToString());
                            command4.Parameters.AddWithValue("@Exam_Code", table_students.Rows[count]["Exam_Code"].ToString());
                            command4.Parameters.AddWithValue("@Course", table_students.Rows[count]["Course"].ToString());
                            command4.ExecuteNonQuery();

                            count++;
                        }
                        else
                        {
                            flag = 1;
                            break;
                        }
                    }
                        if (flag == 1) break;
                }

                msgbox.show("University Seating Allot Completed     ", "Allot Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void Multi_Allotment()
        {            
            try
            {
            //get registered students details
            SQLiteCommand command2 = new SQLiteCommand("select * from Series_candidates order by Course, Class, Name", con.ActiveCon());
            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(command2);
            DataTable table_students = new DataTable();
            adapter2.Fill(table_students);
                con.CloseCon();
            if (table_students.Rows.Count == 0)
            {
                msgbox.show("No Candidates Registered to Allot,\t \n Register the candidates First  ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                return;
            }

            //get rooms details
            SQLiteCommand command3 = new SQLiteCommand("select * from Rooms order by Priority", con.ActiveCon());
            SQLiteDataAdapter adapter3 = new SQLiteDataAdapter(command3);
            DataTable table_rooms = new DataTable();
            adapter3.Fill(table_rooms);
            Alloted_dgv.DataSource = table_rooms;
                con.CloseCon();
            if (table_rooms.Rows.Count == 0)
            {
                msgbox.show("No Rooms Assigned to Allot,\t \n Create Rooms First    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                return;
            }
            //get distinct dates
            SQLiteCommand commanddate = new SQLiteCommand("select distinct Date from Timetable order by Date", con.ActiveCon());
            SQLiteDataAdapter adapterdate = new SQLiteDataAdapter(commanddate);
            DataTable table_distinctdate = new DataTable();
            adapterdate.Fill(table_distinctdate);
                con.CloseCon();
            if (table_distinctdate.Rows.Count == 0)
            {
                msgbox.show("No Timetable Assigned to Allot,\t \n Create Timetable First    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                return;
            }
            int totalstudents = table_students.Rows.Count;
            //ALLOTMENT START
            foreach (DataRow rowdate in table_distinctdate.Rows)
            {
                string session = "Forenoon";
                for (int z = 0; z < 2; z++)
                {
                    //Get Timtable details
                    SQLiteCommand command = new SQLiteCommand("select Date,Session,Course,Exam_Code from Timetable where Date=@Date and Session=@Session order by Date,Session,Course", con.ActiveCon());
                    command.Parameters.AddWithValue("@Date", rowdate["Date"].ToString());
                    command.Parameters.AddWithValue("@Session", session);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable table_timetable = new DataTable();
                    adapter.Fill(table_timetable);
                        con.CloseCon();

                    if (table_timetable.Rows.Count != 0)
                    {
                        List<string> reg_studentsA = new List<string>();
                        List<string> name_studentsA = new List<string>();
                        List<string> course_studentsA = new List<string>();
                        List<string> class_studentsA = new List<string>();
                        List<string> date_studentsA = new List<string>();
                        List<string> examcode_studentsA = new List<string>();
                        List<string> reg_studentsB = new List<string>();
                        List<string> name_studentsB = new List<string>();
                        List<string> course_studentsB = new List<string>();
                        List<string> class_studentsB = new List<string>();
                        List<string> date_studentsB = new List<string>();
                        List<string> examcode_studentsB = new List<string>();
                        DataTable SelectedStudents = new DataTable();
                        SelectedStudents = table_students.Clone();

                        foreach (DataRow row in table_timetable.Rows)
                        {
                            string date = row["Date"].ToString();
                            string course = row["Course"].ToString();
                            string examcode = row["Exam_Code"].ToString();

                            foreach (DataRow row2 in table_students.Rows)
                            {
                                string student_course = row2["Course"].ToString();
                                if (student_course.ToUpper().Contains(course.ToUpper()))
                                {
                                    SelectedStudents.ImportRow(row2);
                                }
                            }
                        }
                        int no_of_students = SelectedStudents.Rows.Count;
                        var top50 = SelectedStudents.AsEnumerable()
                                .Take(no_of_students / 2);
                        var bottom50 = SelectedStudents.AsEnumerable()
                                .Skip(no_of_students / 2);

                        foreach(DataRow row in table_timetable.Rows)
                        {
                            string date = row["Date"].ToString();
                            string course = row["Course"].ToString();
                            string examcode = row["Exam_Code"].ToString();

                            foreach (DataRow row2 in top50)
                            {
                                string student_course = row2["Course"].ToString();
                                if (student_course.ToUpper().Contains(course.ToUpper()))
                                {
                                    name_studentsA.Add(row2["Name"].ToString());
                                    date_studentsA.Add(row["Date"].ToString());
                                    examcode_studentsA.Add(row["Exam_Code"].ToString());
                                    reg_studentsA.Add(row2["Reg_no"].ToString());
                                    course_studentsA.Add(row2["Course"].ToString());
                                    class_studentsA.Add(row2["Class"].ToString());
                                }
                            }
                            foreach (DataRow row2 in bottom50)
                            {
                                string student_course = row2["Course"].ToString();
                                if (student_course.ToUpper().Contains(course.ToUpper()))
                                {
                                    name_studentsB.Add(row2["Name"].ToString());
                                    date_studentsB.Add(row["Date"].ToString());
                                    examcode_studentsB.Add(row["Exam_Code"].ToString());
                                    reg_studentsB.Add(row2["Reg_no"].ToString());
                                    course_studentsB.Add(row2["Course"].ToString());
                                    class_studentsB.Add(row2["Class"].ToString());
                                }                                
                            }
                        }
                        int count = 0;
                        foreach (DataRow roomrow in table_rooms.Rows)
                        {
                            int series = Int32.Parse(roomrow["A_Series"].ToString());
                            int flag = 0 ;
                            for(int i=0;i<series;i++)
                            {
                                SQLiteCommand command4 = new SQLiteCommand("insert into Series_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Class,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Class,@Exam_Code,@Course)", con.ActiveCon());
                                command4.Parameters.AddWithValue("@Date", date_studentsA[count]);
                                command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                                command4.Parameters.AddWithValue("@Seat", "A" + (i + 1));
                                command4.Parameters.AddWithValue("@Session", session);
                                command4.Parameters.AddWithValue("@Reg_no", reg_studentsA[count]);
                                command4.Parameters.AddWithValue("@Name", name_studentsA[count]);
                                command4.Parameters.AddWithValue("@Class", class_studentsA[count]);
                                command4.Parameters.AddWithValue("@Exam_Code", examcode_studentsA[count]);
                                command4.Parameters.AddWithValue("@Course", course_studentsA[count]);
                                command4.ExecuteNonQuery();

                                if (reg_studentsA.Last() == reg_studentsA[count])
                                {
                                    con.CloseCon();
                                    flag = 1;
                                    break;
                                }
                                count++;
                            }
                            if (flag == 1)
                                break;
                        }
                        count = 0;
                        foreach (DataRow roomrow in table_rooms.Rows)
                        {
                            int series = Int32.Parse(roomrow["B_Series"].ToString());
                            int flag = 0;
                            for (int i = 0; i < series; i++)
                            {
                                SQLiteCommand command4 = new SQLiteCommand("insert into Series_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Class,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Class,@Exam_Code,@Course)", con.ActiveCon());
                                command4.Parameters.AddWithValue("@Date", date_studentsB[count]);
                                command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                                command4.Parameters.AddWithValue("@Seat", "B" + (i + 1));
                                command4.Parameters.AddWithValue("@Session", session);
                                command4.Parameters.AddWithValue("@Reg_no", reg_studentsB[count]);
                                command4.Parameters.AddWithValue("@Name", name_studentsB[count]);
                                command4.Parameters.AddWithValue("@Class", class_studentsB[count]);
                                command4.Parameters.AddWithValue("@Exam_Code", examcode_studentsB[count]);
                                command4.Parameters.AddWithValue("@Course", course_studentsB[count]);
                                command4.ExecuteNonQuery();

                                if (reg_studentsB.Last() == reg_studentsB[count])
                                {
                                    con.CloseCon();
                                    flag = 1;
                                    break;
                                }
                                count++;
                            }
                            if (flag == 1)
                                break;
                        }
                    }
                    session = "Afternoon";
                }
            }
            msgbox.show("Series Seating Allot Completed     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Shift_button_Click(object sender, EventArgs e)
        {
            ShiftFunction();
        }
        void ShiftFunction()
        {
            if (FromSeries_combobox.SelectedIndex != 0 && ToSeries_combobox.SelectedIndex != 0 && FromRoom_textbox.Text != "" && FromStart_textbox.Text != "" && FromEnd_textbox.Text != "" && ToRoom_textbox.Text != "" && ToStart_textbox.Text != "")
            {
                msgbox.show("Are You Sure To SHIFT the Selected Students ?   ", "Confirm", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
                var result = msgbox.ReturnValue;
                if (result == "Yes")
                {
                    try
                    {
                        string fromroom = FromRoom_textbox.Text, fromseries = FromSeries_combobox.Text, fromstart = FromStart_textbox.Text, fromend = FromEnd_textbox.Text;
                        string toroom = ToRoom_textbox.Text, toseries = ToSeries_combobox.Text, tostart = ToStart_textbox.Text;
                        int fromstartint = Int32.Parse(fromstart);
                        int fromendint = Int32.Parse(fromend);
                        int tostartint = Int32.Parse(tostart);


                        // ----- validating user inputs ----- //
                        if (fromendint < fromstartint || fromendint < 0 || fromstartint < 0 || tostartint < 0 || Session_combobox.Text == "-Select-")
                        {
                            msgbox.show("Please fill datas correctly, including Date and Session      ", "Invalid inputs", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            SQLiteCommand comm = new SQLiteCommand("Select @series from Rooms where Room_No=@Room_No", con.ActiveCon());
                            comm.Parameters.AddWithValue("@series", fromseries);
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            int fromseriesCount = Convert.ToInt32(comm.ExecuteScalar());
                            if (fromseriesCount < fromendint)
                            {
                                msgbox.show("Given Series End-number is larger than Room Capacity.\t \n Please enter correct input.  ", "Invalid inputs", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                                return;
                            }

                            SQLiteCommand comm2 = new SQLiteCommand("Select @series from Rooms where Room_No=@Room_No", con.ActiveCon());
                            comm2.Parameters.AddWithValue("@series", toseries);
                            comm2.Parameters.AddWithValue("@Room_No", toroom);
                            int toseriesCount = Convert.ToInt32(comm2.ExecuteScalar());
                            int toRoomCount = (toseriesCount - tostartint) + 1;
                            int fromRoomCount = (fromendint - fromstartint) + 1;
                            if (fromRoomCount > toRoomCount)
                            {
                                msgbox.show("Not enough seats in selected Room     ", "Unable to Swap    ", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                                return;
                            }
                        }
                        // ----- validating user inputs ----- //


                        if (Unv_radio.Checked)
                        {
                            SQLiteCommand comm = new SQLiteCommand("Select Room_No,Seat,Reg_no from University_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                            comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            con.CloseCon();
                            for (int i = fromstartint; i <= fromendint; i++)
                            {
                                MessageBox.Show(fromseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == fromseries + i)
                                    {
                                        dataRow["Room_No"] = toroom;
                                        dataRow["Seat"] = toseries + tostartint;
                                        tostartint++;
                                        //break;
                                    }
                                }
                            }
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                SQLiteCommand comm2 = new SQLiteCommand("update University_Alloted set Room_No=@Room_No,Seat=@Seat where Date=@Date and Session=@Session and Reg_no=@Reg_no", con.ActiveCon());
                                comm2.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm2.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                                comm2.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm2.ExecuteNonQuery();
                            }
                            msgbox.show("Shift Completed    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            con.CloseCon();
                        }
                        else if (Series_radio.Checked)
                        {
                            SQLiteCommand comm = new SQLiteCommand("Select Room_No,Seat,Reg_no from Series_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                            comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            con.CloseCon();

                            for (int i = fromstartint; i <= fromendint; i++)
                            {
                                MessageBox.Show(fromseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == fromseries + i)
                                    {
                                        dataRow["Room_No"] = toroom;
                                        dataRow["Seat"] = toseries + tostartint;
                                        tostartint++;
                                        //break;
                                    }
                                }
                            }
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                SQLiteCommand comm2 = new SQLiteCommand("update Series_Alloted set Room_No=@Room_No,Seat=@Seat where Date=@Date and Session=@Session and Reg_no=@Reg_no", con.ActiveCon());
                                comm2.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm2.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                                comm2.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm2.ExecuteNonQuery();
                            }
                            msgbox.show("Shift Completed    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            con.CloseCon();
                        }
                    }
                    catch (Exception ex)
                    {
                        msgbox.show(ex.ToString(), "Exception Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                msgbox.show("Give necessary details    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
        }

        private void Save_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog(); 
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    SQLiteCommand comm = new SQLiteCommand("update Management set Savepath=@savepath where Savepath is not null", con.ActiveCon());
                    comm.Parameters.AddWithValue("@savepath", fdb.SelectedPath.ToString());
                    comm.ExecuteNonQuery();
                    con.CloseCon();
                    Folder_path_text.Text = fdb.SelectedPath;
                }
        }       

        private void Allotment_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            Generation_Panel.Enabled = false;
            panel1.Enabled = false;
            groupBox1.Enabled = false;
            GetFileSavepath();
        }
        void GetFileSavepath()
        {
            SQLiteCommand comm = new SQLiteCommand("select Savepath from Management where Savepath is not null", con.ActiveCon());
            string savepath = (string) comm.ExecuteScalar();
            con.CloseCon();
            Folder_path_text.Text = savepath;
        }
        BindingSource roomfill = new BindingSource();
        BindingSource dgvfill = new BindingSource();
        BindingSource briefdgv = new BindingSource();
        void AllotedDGVFill()
        {
            try
            {
            DataTable dataTable = new DataTable();
            if (Unv_radio.Checked)
            {
                    //SQLiteCommand comm = new SQLiteCommand("select * from University_Alloted where Date=@Date and Session=@Session order by Room_No,Seat",con.ActiveCon());
                    //SQLiteCommand comm = new SQLiteCommand("select * from Registered_candidates as RC and Date,Session,Exam_Code from TimeTable as TT where TT.Date=@Date and TT.Session=@Session and RC.Course=TT.Course order by RC.Reg_no", con.ActiveCon());
                    SQLiteCommand comm = new SQLiteCommand("select RC.*,TT.Date,TT.Session,TT.Exam_Code  from Registered_candidates as RC ,TimeTable as TT where TT.Date=@Date and TT.Session=@Session and RC.Course=TT.Course order by RC.Reg_no", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);                
                adapter.Fill(dataTable);                
            }
            else
            {
                    //SQLiteCommand comm = new SQLiteCommand("select * from Series_Alloted where Date=@Date and Session=@Session order by Room_No,Seat",con.ActiveCon());
                    //SQLiteCommand comm = new SQLiteCommand("select SC.*,TT.Date,TT.Session,TT.Exam_Code from Series_candidates as SC,TimeTable as TT where TT.Date=@Date and TT.Session=@Session and SC.Course=TT.Course order by SC.Reg_no", con.ActiveCon());
                    SQLiteCommand comm = new SQLiteCommand("select SC.*,TT.Date,TT.Session,TT.Exam_Code from Series_candidates as SC,TimeTable as TT where TT.Date=@Date and TT.Session=@Session and SC.Course=TT.Course order by SC.Reg_no", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                adapter.Fill(dataTable);
            }
            con.CloseCon();
            dgvfill.DataSource = null;
            dgvfill.DataSource = dataTable;
            Alloted_dgv.DataSource = null;
            Alloted_dgv.DataSource = dgvfill;
            no_of_stud_reg_label.Text = "No of Students registered : "+ dataTable.Rows.Count.ToString();                
            }
            catch(Exception ex)
            {
                con.CloseCon();
                MessageBox.Show(ex.ToString());
            }
        }
        void AllotedRoomsDgvFilling()
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (Unv_radio.Checked)
                {
                    //SQLiteCommand comm = new SQLiteCommand("select * from University_Alloted where Date=@Date and Session=@Session order by Room_No,Seat", con.ActiveCon());
                    SQLiteCommand comm = new SQLiteCommand("select R.Room_No,R.A_Series,R.B_Series from Rooms as R,University_Alloted as UA where UA.Date=@Date and UA.Session=@Session and UA.Room_No=R.Room_No order by UA.Room_No", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                    comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                    adapter.Fill(dataTable);
                }
                else
                {
                    //SQLiteCommand comm = new SQLiteCommand("select * from Series_Alloted where Date=@Date and Session=@Session order by Room_No,Seat", con.ActiveCon());
                    SQLiteCommand comm = new SQLiteCommand("select R.Room_No,R.A_Series,R.B_Series from Rooms as R,Series_Alloted as SA where SA.Date=@Date and SA.Session=@Session and SA.Room_No=R.Room_No order by SA.Room_No", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                    comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                    adapter.Fill(dataTable);
                }
                con.CloseCon();

                //SQLiteCommand comm2 = new SQLiteCommand("select Room_No,A_Series,B_Series from Rooms", con.ActiveCon());
                //SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(comm2);
                //DataTable dataTable2 = new DataTable();
                //adapter2.Fill(dataTable2);
                //con.CloseCon();
                //DataTable dataTable3 = dataTable2.Clone();
                //foreach (DataRow dr2 in dataTable2.Rows)
                //{
                //    foreach (DataRow dr in dataTable.Rows)
                //    {
                //        if (dr["Room_No"].ToString() == dr2["Room_No"].ToString())
                //        {
                //            dataTable3.ImportRow(dr2);
                //            break;
                //        }
                //    }
                //}
                roomfill.DataSource = null;
                //roomfill.DataSource = dataTable3;
                roomfill.DataSource = dataTable;
                AllotedRooms_dgv.DataSource = null;
                AllotedRooms_dgv.DataSource = roomfill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void AllotedBriefDGVFill()
        {
            if (Unv_radio.Checked)
            {
                SQLiteCommand comm = new SQLiteCommand("select Distinct (RC.Branch),TT.Exam_Code,TT.Course from Timetable as TT,Registered_candidates as RC where TT.Date=@Date and TT.Session=@Session and TT.Course=RC.Course", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                DataTable dataTablebrief = new DataTable();
                adapter.Fill(dataTablebrief);
                con.CloseCon();
                dataTablebrief.Columns.Add("No of Students", typeof(int));
                foreach (DataRow dr in dataTablebrief.Rows)
                {
                    SQLiteCommand comm2 = new SQLiteCommand("select Count(Reg_No) from Registered_candidates where Course=@Course", con.ActiveCon());
                    comm2.Parameters.AddWithValue("@Course", dr["Course"]);
                    int count = Convert.ToInt32(comm2.ExecuteScalar());
                    dr["No of Students"] = count;
                }
                con.CloseCon();
                briefdgv.DataSource = null;
                briefdgv.DataSource = dataTablebrief;
            }
            else
            {
                SQLiteCommand comm = new SQLiteCommand("select Distinct (SC.Class),TT.Exam_Code,TT.Course from Timetable as TT,Series_candidates as SC where TT.Date=@Date and TT.Session=@Session and TT.Course=SC.Course", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.CloseCon();
                dataTable.Columns.Add("No of Students", typeof(int));
                foreach (DataRow dr in dataTable.Rows)
                {
                    SQLiteCommand comm2 = new SQLiteCommand("select Count(Reg_No) from Series_candidates where Course=@Course", con.ActiveCon());
                    comm2.Parameters.AddWithValue("@Course", dr["Course"]);
                    int count = Convert.ToInt32(comm2.ExecuteScalar());
                    dr["No of Students"] = count;
                }
                con.CloseCon();
                briefdgv.DataSource = null;
                briefdgv.DataSource = dataTable;
            }
            AllotedBrief_dgv.DataSource = null;
            AllotedBrief_dgv.DataSource = briefdgv;
        }
        void AllotedStudentsDGVFill()
        {
            if (Unv_radio.Checked)
            {
                SQLiteCommand comm = new SQLiteCommand("select Reg_no,Name,Exam_Code,Room_No,Seat from University_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                comm.Parameters.AddWithValue("@Room_No", AllocatedRoom_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                DataTable dataTabledgv = new DataTable();
                adapter.Fill(dataTabledgv);
                AllotedStudentsRooms_dgv.DataSource = null;
                AllotedStudentsRooms_dgv.DataSource = dataTabledgv;
                no_of_stud_in_room_label.Text = "No of Students : " + dataTabledgv.Rows.Count.ToString();
                con.CloseCon();
            }
            else if (Series_radio.Checked)
            {
                SQLiteCommand comm = new SQLiteCommand("select Reg_no,Name,Exam_Code,Room_No,Seat from Series_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                comm.Parameters.AddWithValue("@Room_No", AllocatedRoom_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                AllotedStudentsRooms_dgv.DataSource = null;
                AllotedStudentsRooms_dgv.DataSource = dataTable;
                no_of_stud_in_room_label.Text = "No of Students : "+dataTable.Rows.Count.ToString();
                con.CloseCon();
            }
        }        
        void AllocatedRoomComboboxFill()
        {
            DataTable dataTablecombo = new DataTable();
            if(Series_radio.Checked)
            {
                SQLiteCommand comm = new SQLiteCommand("select Distinct Room_No from Series_Alloted where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                adapter.Fill(dataTablecombo);
            }
            else
            {
                SQLiteCommand comm = new SQLiteCommand("select Distinct Room_No from University_Alloted where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                adapter.Fill(dataTablecombo);
            }
            con.CloseCon();
            DataRow top = dataTablecombo.NewRow();
            top[0] = "-Select-";
            dataTablecombo.Rows.InsertAt(top, 0);
            AllocatedRoom_combobox.DisplayMember = "Room_No";
            AllocatedRoom_combobox.ValueMember = "Room_No";
            AllocatedRoom_combobox.DataSource = dataTablecombo;

            AllocatedRoom_combobox.SelectedIndex = 0;
        }

        private void Unv_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (Unv_radio.Checked)
            {
                examRadioSelectEnabling();
            }
        }

        private void Series_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (Series_radio.Checked)
            {
                examRadioSelectEnabling();
            }
        }
        void examRadioSelectEnabling()
        {
            Generation_Panel.Enabled = true;
            panel1.Enabled = true;
            groupBox1.Enabled = true;
            RefreshAll();
        }
       
        private void AllocatedRoom_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(AllocatedRoom_combobox.SelectedIndex!=0)
            {
                AllotedStudentsDGVFill();
            }
        }
        void RefreshAll()
        {
            AllotedBrief_dgv.DataSource = null;
            AllotedRooms_dgv.DataSource = null;
            AllotedStudentsRooms_dgv.DataSource = null;
            Alloted_dgv.DataSource = null;
            no_of_stud_reg_label.Text = "No of Students registered : ";
            no_of_stud_in_room_label.Text = "No of Students : ";
            AllocatedRoom_combobox.DataSource = null;
            FromRoom_textbox.Clear();
            FromStart_textbox.Clear();
            FromEnd_textbox.Clear();
            ToStart_textbox.Clear();
            ToRoom_textbox.Clear();
            DateTimePicker.Format = DateTimePickerFormat.Custom;
            DateTimePicker.CustomFormat = "dd-MM-yyyy";
            DateTimePicker.Value = DateTime.Now;
            Session_combobox.SelectedIndex = 0;
            FromSeries_combobox.SelectedIndex = 0;
            ToSeries_combobox.SelectedIndex = 0;
        }

        private void Swap_button_Click(object sender, EventArgs e)
        {
            SwapFunction();
        }
        void SwapFunction()
        {
            if (FromSeries_combobox.SelectedIndex != 0 && ToSeries_combobox.SelectedIndex != 0 && FromRoom_textbox.Text != "" && FromStart_textbox.Text != "" && FromEnd_textbox.Text != "" && ToRoom_textbox.Text != "" && ToStart_textbox.Text != "")
            {
                msgbox.show("Are You Sure To SWAP the Selected Students ?    ", "Confirm", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
                var result = msgbox.ReturnValue;
                if (result == "Yes")
                {
                    try
                    {
                        string fromroom = FromRoom_textbox.Text, fromseries = FromSeries_combobox.Text, fromstart = FromStart_textbox.Text, fromend = FromEnd_textbox.Text;
                        string toroom = ToRoom_textbox.Text, toseries = ToSeries_combobox.Text, tostart = ToStart_textbox.Text;
                        int fromstartint = Int32.Parse(fromstart);
                        int fromendint = Int32.Parse(fromend);
                        int tostartint = Int32.Parse(tostart);
                        int fromtemp = fromstartint, totemp = tostartint;


                        // ----- validating user inputs ----- //
                        if (fromendint < fromstartint || fromendint < 0 || fromstartint < 0 || tostartint < 0 || Session_combobox.Text=="-Select-")
                        {
                            msgbox.show("Please fill datas correctly, including Date and Session    ", "Invalid inputs", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            SQLiteCommand comm = new SQLiteCommand("Select @series from Rooms where Room_No=@Room_No", con.ActiveCon());
                            comm.Parameters.AddWithValue("@series", fromseries);
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            int fromseriesCount = Convert.ToInt32(comm.ExecuteScalar());
                            if (fromseriesCount < fromendint)
                            {
                                msgbox.show("Given Series End-number is larger than Room Capacity.\t \n Please enter correct input.     ", "Invalid inputs", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                                return;
                            }

                            SQLiteCommand comm2 = new SQLiteCommand("Select @series from Rooms where Room_No=@Room_No", con.ActiveCon());
                            comm2.Parameters.AddWithValue("@series", toseries);
                            comm2.Parameters.AddWithValue("@Room_No", toroom);
                            int toseriesCount = Convert.ToInt32(comm2.ExecuteScalar());
                            int toRoomCount = (toseriesCount - tostartint) + 1;
                            int fromRoomCount = (fromendint - fromstartint) + 1;
                            if (fromRoomCount > toRoomCount)
                            {
                                msgbox.show("Not enough seats in selected Room      ", "Unable to Swap", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                                return;
                            }
                        }
                        // ----- validating user inputs ----- //


                        if (Unv_radio.Checked)
                        {
                            SQLiteCommand comm = new SQLiteCommand("Select Room_No,Seat,Reg_no from University_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                            comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            con.CloseCon();
                            SQLiteCommand comm2 = new SQLiteCommand("Select Room_No,Seat,Reg_no from University_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                            comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            comm2.Parameters.AddWithValue("@Room_No", toroom);
                            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(comm2);
                            DataTable dataTable2 = new DataTable();
                            adapter2.Fill(dataTable2);
                            con.CloseCon();
                            int f = 0;
                            for (int i = fromstartint; i <= fromendint; i++)
                            {
                                f++;
                                MessageBox.Show(fromseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == fromseries + i)
                                    {
                                        dataRow["Room_No"] = toroom;
                                        dataRow["Seat"] = toseries + totemp;
                                        totemp++;
                                        //break;
                                    }
                                }
                            }
                            for (int i = tostartint; i < tostartint + f; i++)
                            {
                                MessageBox.Show(toseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable2.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == toseries + i)
                                    {
                                        dataRow["Room_No"] = fromroom;
                                        dataRow["Seat"] = fromseries + fromtemp;
                                        fromtemp++;
                                        //break;
                                    }
                                }
                            }
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                SQLiteCommand comm3 = new SQLiteCommand("update University_Alloted set Room_No=@Room_No,Seat=@Seat where Date=@Date and Session=@Session and Reg_no=@Reg_no", con.ActiveCon());
                                comm3.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm3.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                                comm3.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm3.ExecuteNonQuery();
                            }
                            con.CloseCon();
                            foreach (DataRow dataRow in dataTable2.Rows)
                            {
                                SQLiteCommand comm3 = new SQLiteCommand("update University_Alloted set Room_No=@Room_No,Seat=@Seat where Date=@Date and Session=@Session and Reg_no=@Reg_no", con.ActiveCon());
                                comm3.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm3.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                                comm3.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm3.ExecuteNonQuery();
                            }
                            con.CloseCon();
                            msgbox.show("Swap Completed     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                        }
                        else if (Series_radio.Checked)
                        {
                            SQLiteCommand comm = new SQLiteCommand("Select Room_No,Seat,Reg_no from Series_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                            comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            comm.Parameters.AddWithValue("@Room_No", fromroom);
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            con.CloseCon();
                            SQLiteCommand comm2 = new SQLiteCommand("Select Room_No,Seat,Reg_no from Series_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                            comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            comm2.Parameters.AddWithValue("@Room_No", toroom);
                            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(comm2);
                            DataTable dataTable2 = new DataTable();
                            adapter2.Fill(dataTable2);
                            con.CloseCon();
                            int f = 0;
                            for (int i = fromstartint; i <= fromendint; i++)
                            {
                                f++;
                                MessageBox.Show(fromseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == fromseries + i)
                                    {
                                        dataRow["Room_No"] = toroom;
                                        dataRow["Seat"] = toseries + totemp;
                                        totemp++;
                                        //break;
                                    }
                                }
                            }
                            for (int i = tostartint; i < tostartint + f; i++)
                            {
                                MessageBox.Show(toseries + i); ///////////////////for testing...after that delete this line
                                foreach (DataRow dataRow in dataTable2.Rows)
                                {
                                    if (dataRow["Seat"].ToString() == toseries + i)
                                    {
                                        dataRow["Room_No"] = fromroom;
                                        dataRow["Seat"] = fromseries + fromtemp;
                                        fromtemp++;
                                        //break;
                                    }
                                }
                            }
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                SQLiteCommand comm3 = new SQLiteCommand("update Series_Alloted set Room_No=@Room_No,Seat=@Seat where Date=@Date and Session=@Session and Reg_no=@Reg_no", con.ActiveCon());
                                comm3.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm3.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                                comm3.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm3.ExecuteNonQuery();
                            }
                            con.CloseCon();
                            foreach (DataRow dataRow in dataTable2.Rows)
                            {
                                SQLiteCommand comm3 = new SQLiteCommand("update Series_Alloted set Room_No=@Room_No,Seat=@Seat where Date=@Date and Session=@Session and Reg_no=@Reg_no", con.ActiveCon());
                                comm3.Parameters.AddWithValue("@Room_No", dataRow["Room_No"]);
                                comm3.Parameters.AddWithValue("@Seat", dataRow["Seat"]);
                                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                                comm3.Parameters.AddWithValue("@Reg_no", dataRow["Reg_no"]);
                                comm3.ExecuteNonQuery();
                            }
                            con.CloseCon();
                            msgbox.show("Swap Completed     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        msgbox.show(ex.ToString(), "Exception Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    msgbox.show("Give necessary Details     ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                }
            }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = (MenuForm)Application.OpenForms["MenuForm"];
            if (menuForm.Temp_btn == menuForm.menu_item_allotment)
                menuForm.Temp_btn = null;
            menuForm.menu_item_allotment.BackColor = Color.FromArgb(48, 43, 99);
            menuForm.allotment_open = false;
            this.Close();
        }

        private void ExcelSheet_button_Click(object sender, EventArgs e)
        {
            if (Folder_path_text.Text != "PLEASE_ADD_PATH")
            {
                ExcelSheetGeneration excelSheetGeneration = new ExcelSheetGeneration();
                excelSheetGeneration.ShowDialog();
            }
            else
            {
                msgbox.show("Filepath is not given   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
        }

        private void Session_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session_combobox.SelectedIndex != 0)
            {
                // need to re code
                // AllotedDGVFill() and AllotedBriefDGVFill() will be showing Registered Candidates info, not Alloted.
                AllotedDGVFill();
                AllotedBriefDGVFill();
                AllocatedRoomComboboxFill();
                AllotedRoomsDgvFilling(); // might need to re-query
            }
        }        
    }
}

        



