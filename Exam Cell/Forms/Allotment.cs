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

        string Allot_Type = "", date="", session="";
        private void SingleAllotment_button_Click(object sender, EventArgs e)
        {
            Allot_Type = "Single";
            date = DateTimePicker.Text;
            session = Session_combobox.Text;
            using (ProgressForm progressForm = new ProgressForm(Allotment_Function))
            {
                progressForm.ShowDialog(this);
            }            
        }
        private void MultiAllot_Click(object sender, EventArgs e)
        {
            Allot_Type = "Multi";
            date = DateTimePicker.Text;
            session = Session_combobox.Text;
            using (ProgressForm progressForm = new ProgressForm(Allotment_Function))
            {
                progressForm.ShowDialog(this);
            }
        }
        
        void Allotment_Function()
        {
            try
            {
                //get rooms details
                SQLiteCommand command3 = new SQLiteCommand("select * from Rooms order by Priority", con.ActiveCon());
                SQLiteDataAdapter adapter3 = new SQLiteDataAdapter(command3);
                DataTable table_rooms = new DataTable();
                adapter3.Fill(table_rooms);
                con.CloseCon();
                if (table_rooms.Rows.Count == 0)
                {
                    msgbox.Show("No Rooms Assigned to Allot,     \n Create Rooms First   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    return;
                }
                string commandQuery = "";
                if (Unv_radio.Checked)
                    commandQuery = string.Format("select RC.Reg_no,RC.Name,RC.Branch,TT.Exam_Code,TT.Course from Registered_candidates as RC,Timetable as TT where TT.Date=@Date and TT.Session=@Session and RC.Course=TT.Course order by TT.Course,RC.Reg_no");
                else
                    commandQuery = string.Format("select SC.Reg_no,SC.Name,SC.Class,SC.Branch,TT.Exam_Code,TT.Course from Series_candidates as SC,Timetable as TT where TT.Date=@Date and TT.Session=@Session and SC.Course=TT.Course order by TT.Course,SC.Class,SC.Reg_no");

                //get registered students details
                SQLiteCommand command2 = new SQLiteCommand(commandQuery, con.ActiveCon());
                command2.Parameters.AddWithValue("@Date", date);
                command2.Parameters.AddWithValue("@Session", session);
                SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(command2);
                DataTable table_students = new DataTable();
                adapter2.Fill(table_students);
                con.CloseCon();
                if (table_students.Rows.Count == 0)
                {
                    msgbox.Show("No Candidates Registered or Timetable set to Allot,   \n Register the candidates First    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                foreach (DataRow branchDr in table_branchPriority.Rows)
                {
                    foreach (DataRow studDr in table_students.Rows)
                    {
                        if (studDr["Branch"] == branchDr["Branch"])
                        {
                            studDr["BranchPriority"] = branchDr["Priority"];
                        }
                    }
                }
                if (Unv_radio.Checked) table_students.DefaultView.Sort = "BranchPriority,Course,Reg_no";
                else table_students.DefaultView.Sort = "BranchPriority,Course,Class,Reg_no";
                table_students = table_students.DefaultView.ToTable();

                //Allot
                if (Allot_Type == "Single") Single_Allotment(table_students, table_rooms);
                else if (Allot_Type == "Multi") Multi_Allotment(table_students, table_rooms);
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        void Single_Allotment(DataTable table_students, DataTable table_rooms)
        {                        
            try
            {
                string insertQuery = "";
                int studCount=table_students.Rows.Count, count = 0, flag = 0;                 
                foreach (DataRow roomrow in table_rooms.Rows)
                {
                    int series = Int32.Parse(roomrow["A_Series"].ToString());
                    for (int i = 0; i < series; i++)
                    {
                        if (count < studCount)
                        {
                            if (Unv_radio.Checked) insertQuery = string.Format("insert into University_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Branch,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Branch,@Exam_Code,@Course)");
                            else insertQuery = string.Format("insert into Series_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Class,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Class,@Exam_Code,@Course)");
                            SQLiteCommand command4 = new SQLiteCommand(insertQuery, con.ActiveCon());
                            command4.Parameters.AddWithValue("@Date", date);
                            command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                            command4.Parameters.AddWithValue("@Seat", "A" + (i + 1));
                            command4.Parameters.AddWithValue("@Session", session);
                            command4.Parameters.AddWithValue("@Reg_no", table_students.Rows[count]["Reg_no"].ToString());
                            command4.Parameters.AddWithValue("@Name", table_students.Rows[count]["Name"].ToString());
                            if(Unv_radio.Checked) command4.Parameters.AddWithValue("@Branch", table_students.Rows[count]["Branch"].ToString());
                            else command4.Parameters.AddWithValue("@Class", table_students.Rows[count]["Class"].ToString());
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

                AllocatedRoomComboboxFill();
                AllotedRoomsDgvFilling();
                msgbox.Show("Single Seating Allot Completed     ", "Allot Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void Multi_Allotment(DataTable table_students, DataTable table_rooms)
        {            
            try
            {
                string insertQuery = "";
                int studCount = table_students.Rows.Count, count = 0, flag = 0;
                //divide students by half to seat as A & B
                DataTable Students_Aseries = table_students.Clone();
                DataTable Students_Bseries = table_students.Clone();
                table_students.AsEnumerable().Take(studCount / 2).CopyToDataTable(Students_Aseries,LoadOption.OverwriteChanges);
                table_students.AsEnumerable().Skip(studCount / 2).CopyToDataTable(Students_Bseries,LoadOption.OverwriteChanges);
                
                //allot for A series
                foreach (DataRow roomrow in table_rooms.Rows)
                {
                    int series = Int32.Parse(roomrow["A_Series"].ToString());
                    for (int i = 0; i < series; i++)
                    {
                        if (count < Students_Aseries.Rows.Count)
                        {
                            if (Unv_radio.Checked) insertQuery = string.Format("insert into University_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Branch,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Branch,@Exam_Code,@Course)");
                            else insertQuery = string.Format("insert into Series_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Class,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Class,@Exam_Code,@Course)");
                            SQLiteCommand command4 = new SQLiteCommand(insertQuery, con.ActiveCon());
                            command4.Parameters.AddWithValue("@Date", date);
                            command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                            command4.Parameters.AddWithValue("@Seat", "A" + (i + 1));
                            command4.Parameters.AddWithValue("@Session", session);
                            command4.Parameters.AddWithValue("@Reg_no", Students_Aseries.Rows[count]["Reg_no"].ToString());
                            command4.Parameters.AddWithValue("@Name", Students_Aseries.Rows[count]["Name"].ToString());
                            if (Unv_radio.Checked) command4.Parameters.AddWithValue("@Branch", Students_Aseries.Rows[count]["Branch"].ToString());
                            else command4.Parameters.AddWithValue("@Class", Students_Aseries.Rows[count]["Class"].ToString());
                            command4.Parameters.AddWithValue("@Exam_Code", Students_Aseries.Rows[count]["Exam_Code"].ToString());
                            command4.Parameters.AddWithValue("@Course", Students_Aseries.Rows[count]["Course"].ToString());
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

                //allot for B series
                count = 0; flag = 0;
                foreach (DataRow roomrow in table_rooms.Rows)
                {
                    int series = Int32.Parse(roomrow["B_Series"].ToString());
                    for (int i = 0; i < series; i++)
                    {
                        if (count < Students_Bseries.Rows.Count)
                        {
                            if (Unv_radio.Checked) insertQuery = string.Format("insert into University_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Branch,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Branch,@Exam_Code,@Course)");
                            else insertQuery = string.Format("insert into Series_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Class,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Class,@Exam_Code,@Course)");
                            SQLiteCommand command4 = new SQLiteCommand(insertQuery, con.ActiveCon());
                            command4.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                            command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                            command4.Parameters.AddWithValue("@Seat", "B" + (i + 1));
                            command4.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            command4.Parameters.AddWithValue("@Reg_no", Students_Bseries.Rows[count]["Reg_no"].ToString());
                            command4.Parameters.AddWithValue("@Name", Students_Bseries.Rows[count]["Name"].ToString());
                            if (Unv_radio.Checked) command4.Parameters.AddWithValue("@Branch", Students_Bseries.Rows[count]["Branch"].ToString());
                            else command4.Parameters.AddWithValue("@Class", Students_Bseries.Rows[count]["Class"].ToString());
                            command4.Parameters.AddWithValue("@Exam_Code", Students_Bseries.Rows[count]["Exam_Code"].ToString());
                            command4.Parameters.AddWithValue("@Course", Students_Bseries.Rows[count]["Course"].ToString());
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
                AllocatedRoomComboboxFill();
                AllotedRoomsDgvFilling();
                msgbox.Show("Multi Seating Allot Completed     ", "Allot Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
                msgbox.Show("Are You Sure To SHIFT the Selected Students ?   ", "Confirm", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
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
                            msgbox.Show("Please fill datas correctly, including Date and Session      ", "Invalid inputs", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                                msgbox.Show("Given Series End-number is larger than Room Capacity.\t \n Please enter correct input.  ", "Invalid inputs", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                                msgbox.Show("Not enough seats in selected Room     ", "Unable to Swap    ", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                                MessageBox.Show("This is for testing ---- "+fromseries + i); ///////////////////for testing...after that delete this line
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
                            con.CloseCon();
                            msgbox.Show("Shift Completed    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
                                MessageBox.Show("This is for testing ---- " + fromseries + i); ///////////////////for testing...after that delete this line
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
                            con.CloseCon();
                            msgbox.Show("Shift Completed    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        msgbox.Show(ex.ToString(), "Exception Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                msgbox.Show("Give necessary details    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                string selectQuery = "";
                if (Unv_radio.Checked) selectQuery = string.Format("select distinct R.Room_No,R.A_Series,R.B_Series from Rooms as R,University_Alloted as UA where UA.Date=@Date and UA.Session=@Session and UA.Room_No=R.Room_No order by UA.Room_No");
                else selectQuery = string.Format("select distinct R.Room_No,R.A_Series,R.B_Series from Rooms as R,Series_Alloted as SA where SA.Date=@Date and SA.Session=@Session and SA.Room_No=R.Room_No order by SA.Room_No");                

                SQLiteCommand comm = new SQLiteCommand(selectQuery, con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.CloseCon();
                
                roomfill.DataSource = null;                
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
                    SQLiteCommand comm2 = new SQLiteCommand("select Count(Reg_No) from Registered_candidates where Course=@Course and Branch=@Branch", con.ActiveCon());
                    comm2.Parameters.AddWithValue("@Course", dr["Course"]);
                    comm2.Parameters.AddWithValue("@Branch", dr["Branch"]);
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
            string selectQuery = "";
            if (Unv_radio.Checked) selectQuery = string.Format("select Reg_no,Name,Exam_Code,Room_No,Seat from University_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Reg_no");
            else if (Series_radio.Checked) selectQuery = string.Format("select Reg_no,Name,Exam_Code,Room_No,Seat from Series_Alloted where Date=@Date and Session=@Session and Room_No=@Room_No order by Reg_no");
            SQLiteCommand comm = new SQLiteCommand(selectQuery, con.ActiveCon());
            comm.Parameters.AddWithValue("@Date", DateTimePicker.Text);
            comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
            comm.Parameters.AddWithValue("@Room_No", AllocatedRoom_combobox.Text);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            AllotedStudentsRooms_dgv.DataSource = null;
            AllotedStudentsRooms_dgv.DataSource = dataTable;
            no_of_stud_in_room_label.Text = "No of Students : " + dataTable.Rows.Count.ToString();
            con.CloseCon();
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
                msgbox.Show("Are You Sure To SWAP the Selected Students ?    ", "Confirm", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
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
                            msgbox.Show("Please fill datas correctly, including Date and Session    ", "Invalid inputs", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                                msgbox.Show("Given Series End-number is larger than Room Capacity.\t \n Please enter correct input.     ", "Invalid inputs", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                                msgbox.Show("Not enough seats in selected Room      ", "Unable to Swap", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                            msgbox.Show("Swap Completed     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
                            msgbox.Show("Swap Completed     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        msgbox.Show(ex.ToString(), "Exception Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    msgbox.Show("Give necessary Details     ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                if (Session_combobox.SelectedIndex == 0) msgbox.Show("Select Session/Date    ","Error",CustomMessageBox.MessageBoxButtons.OK,CustomMessageBox.MessageBoxIcon.Error);
                else
                {
                    ExcelSheetGeneration excelSheetGeneration = new ExcelSheetGeneration();
                    excelSheetGeneration.ShowDialog();
                }
            }
            else
            {
                msgbox.Show("Filepath is not given   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
        }

        private void Session_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session_combobox.SelectedIndex != 0)
            {
                
                // AllotedDGVFill() and AllotedBriefDGVFill() will be showing Registered Candidates info, not Alloted.
                AllotedDGVFill();
                AllotedBriefDGVFill();
                AllocatedRoomComboboxFill();
                AllotedRoomsDgvFilling(); // might need to re-query
            }
        }        
    }
}

        



