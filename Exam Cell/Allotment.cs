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
using System.Runtime.InteropServices;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace Exam_Cell
{
    public partial class Allotment : Form
    {
        Connection con = new Connection();
        
        public Allotment()
        {
            InitializeComponent();
        }

        private void SingleAllotment_button_Click(object sender, EventArgs e)
        {
            Allot_University();
        }
        void Allot_University()
        {
            
            //Get Timtable details
            SqlCommand command = new SqlCommand("select Date,Session,Course,Exam_Code from Timetable order by Date,Session", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_timetable = new DataTable();
            adapter.Fill(table_timetable);
            if (table_timetable.Rows.Count == 0)
            {
                MessageBox.Show("No Timetable Assigned to Allot, Create Timetable First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //get registered students details
            SqlCommand command2 = new SqlCommand("select * from Registered_candidates order by Reg_no", con.ActiveCon());
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table_students = new DataTable();
            adapter2.Fill(table_students);
            if (table_students.Rows.Count == 0)
            {
                MessageBox.Show("No Candidates Registered to Allot, Register the candidates First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //get rooms details
            SqlCommand command3 = new SqlCommand("select * from Rooms order by Priority", con.ActiveCon());
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table_rooms = new DataTable();
            adapter3.Fill(table_rooms);
            if (table_rooms.Rows.Count == 0)
            {
                MessageBox.Show("No Rooms Assigned to Allot, Create Rooms First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // initialize and get room values outside loop
            List<string> roomno = new List<string>();
            List<string> Aseries = new List<string>();

            foreach (DataRow roomrow in table_rooms.Rows)
            {
                roomno.Add(roomrow["Room_No"].ToString());
                Aseries.Add(roomrow["A_Series"].ToString());
            }
            int sr = 0,j=0;
            int series = int.Parse(Aseries[sr].ToString());
            string room = roomno[sr];

            //get distinct dates to change sr value to 0
            SqlCommand commanddate = new SqlCommand("select distinct Date from Timetable order by Date", con.ActiveCon());
            SqlDataAdapter adapterdate = new SqlDataAdapter(commanddate);
            DataTable table_distinctdate = new DataTable();
            adapterdate.Fill(table_distinctdate);
            List<string> distinctdate = new List<string>();
            foreach (DataRow rowdate in table_distinctdate.Rows)
            {
                distinctdate.Add(rowdate["Date"].ToString());            
            }
            int dcount = 1 ;
            string SessionCheck = table_timetable.Rows[0]["Session"].ToString(); 
            //start allotment loop
            foreach (DataRow row in table_timetable.Rows)
            {               
                string date = row["Date"].ToString();
                string session = row["Session"].ToString();
                string course = row["Course"].ToString();
                string examcode = row["Exam_Code"].ToString();
                
                if (distinctdate[dcount] == date)
                {
                    if(distinctdate.Count!=dcount+1)
                    {
                        dcount += 1;
                        sr = 0;
                        j = 0;
                    }                  
                    else
                    {
                        dcount = 0;
                        sr = 0;
                        j = 0;
                    }                 
                }
                else { }
                if (SessionCheck != session)
                {
                    sr = 0;
                    j = 0;
                    SessionCheck = session;
                }

                List<string> reg_students = new List<string>();
                List<string> name_students = new List<string>();
                
                foreach(DataRow row2 in table_students.Rows)
                {
                    string student_course = row2["Course"].ToString();
                    if (student_course.ToUpper().Contains(course.ToUpper()))
                    {
                        name_students.Add(row2["Name"].ToString());
                        reg_students.Add(row2["Reg_no"].ToString());
                    }
                }
                int count = 0;
                
                if (reg_students.Count != 0)
                {
                    
                    for (int i = j; i < series; i++)
                    {
                        MessageBox.Show(j.ToString());
                        SqlCommand command4 = new SqlCommand("insert into University_Alloted(Date,Room_No,Seat,Session,Reg_no,Name,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Reg_no,@Name,@Exam_Code,@Course)", con.ActiveCon());
                        command4.Parameters.AddWithValue("@Date", date);
                        command4.Parameters.AddWithValue("@Room_No", room);
                        command4.Parameters.AddWithValue("@Seat", "A" + (j + 1));
                        command4.Parameters.AddWithValue("@Session", session);
                        command4.Parameters.AddWithValue("@Reg_no", reg_students[count]);
                        command4.Parameters.AddWithValue("@Name", name_students[count]);
                        command4.Parameters.AddWithValue("@Exam_Code", examcode);
                        command4.Parameters.AddWithValue("@Course", course);
                        command4.ExecuteNonQuery();
                        j += 1;
                        if (j == series)
                        {
                            sr += 1;
                            series = int.Parse(Aseries[sr].ToString());
                            room = roomno[sr];
                            j = 0;
                        }

                        if (reg_students.Last() == reg_students[count])
                        {

                            break;
                        }
                        count = count + 1;

                    }

                }
            }


            MessageBox.Show("University Seating Allot Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        void Allot_Series()
        {
            //Get Timtable details
            SqlCommand command = new SqlCommand("select Date,Session,Course,Exam_Code from Timetable order by Date,Session", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_timetable = new DataTable();
            adapter.Fill(table_timetable);

            //get registered students details
            SqlCommand command2 = new SqlCommand("select * from Series_candidates order by Course, Class, Name", con.ActiveCon());
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table_students = new DataTable();
            adapter2.Fill(table_students);

            //get rooms details
            SqlCommand command3 = new SqlCommand("select * from Rooms order by Priority", con.ActiveCon());
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table_rooms = new DataTable();
            adapter3.Fill(table_rooms);
            dataGridView1.DataSource = table_rooms;

            // initialize and get room values outside loop
            List<string> roomno = new List<string>();
            List<string> Aseries = new List<string>();
            List<string> Bseries = new List<string>();

            foreach (DataRow roomrow in table_rooms.Rows)
            {
                roomno.Add(roomrow["Room_No"].ToString());
                Aseries.Add(roomrow["A_Series"].ToString());
                Bseries.Add(roomrow["B_Series"].ToString());
            }
            int sra = 0, j = 0,srb=0,k=0;
            int seriesA = int.Parse(Aseries[sra].ToString());
            int seriesB = int.Parse(Aseries[sra].ToString());
            string room = roomno[sra];

            //get distinct dates to change sr value to 0
            SqlCommand commanddate = new SqlCommand("select distinct Date from Timetable order by Date", con.ActiveCon());
            SqlDataAdapter adapterdate = new SqlDataAdapter(commanddate);
            DataTable table_distinctdate = new DataTable();
            adapterdate.Fill(table_distinctdate);
            List<string> distinctdate = new List<string>();
            foreach (DataRow rowdate in table_distinctdate.Rows)
            {
                distinctdate.Add(rowdate["Date"].ToString());
            }
            int dcount = 1,backupcount=1,checkcount=table_timetable.Rows.Count;
            string SessionCheck = table_timetable.Rows[0]["Session"].ToString();

            DataTable SelectedStudents = new DataTable();
            SelectedStudents = table_students.Clone();
            //start allotment loop
            foreach (DataRow row in table_timetable.Rows)
            {
                checkcount -= 1;
                string date = row["Date"].ToString();
                string session = row["Session"].ToString();
                string course = row["Course"].ToString();
                string examcode = row["Exam_Code"].ToString();

                List<string> reg_studentsA = new List<string>();
                List<string> name_studentsA = new List<string>();
                List<string> reg_studentsB = new List<string>();
                List<string> name_studentsB = new List<string>();
                List<string> course_studentsA = new List<string>();
                List<string> course_studentsB = new List<string>();
                List<string> class_studentsA = new List<string>();
                List<string> class_studentsB = new List<string>();

                if (distinctdate[dcount] != date || SessionCheck == session)
                {
                    foreach (DataRow dataRow2 in table_students.Rows)
                    {
                        string student_course = dataRow2["Course"].ToString();
                        if (student_course.ToUpper().Contains(course.ToUpper()))
                        {
                            SelectedStudents.ImportRow(dataRow2);

                        }

                    }
                }

                if (distinctdate[dcount] == date || checkcount==0 || SessionCheck != session) //idk whether it gets error when distinctdate get out of range
                {
                    int no_of_students = SelectedStudents.Rows.Count;

                    var top50 = SelectedStudents.AsEnumerable()
                            .Take(no_of_students / 2);
                    var bottom50 = SelectedStudents.AsEnumerable()
                            .Skip(no_of_students / 2);

                    foreach (DataRow row2 in top50)
                    {

                        name_studentsA.Add(row2["Name"].ToString());
                        reg_studentsA.Add(row2["Reg_no"].ToString());
                        course_studentsA.Add(row2["Course"].ToString());
                        class_studentsA.Add(row2["Class"].ToString());

                    }
                    foreach (DataRow row2 in bottom50)
                    {

                        name_studentsB.Add(row2["Name"].ToString());
                        reg_studentsB.Add(row2["Reg_no"].ToString());
                        course_studentsB.Add(row2["Course"].ToString());
                        class_studentsB.Add(row2["Class"].ToString());
                    }
                    int count = 0;

                    if (reg_studentsA.Count != 0)
                    {

                        for (int i = j; i < seriesA; i++)
                        {
                            SqlCommand command4 = new SqlCommand("insert into Series_Alloted(Date,Room_No,Seat,Session,Class,Reg_no,Name,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Class,@Reg_no,@Name,@Exam_Code,@Course)", con.ActiveCon());
                            command4.Parameters.AddWithValue("@Date", distinctdate[backupcount - 1]);
                            command4.Parameters.AddWithValue("@Room_No", room);
                            command4.Parameters.AddWithValue("@Seat", "A" + (j + 1));
                            command4.Parameters.AddWithValue("@Session", session);
                            command4.Parameters.AddWithValue("@Class", class_studentsA[count]);
                            command4.Parameters.AddWithValue("@Reg_no", reg_studentsA[count]);
                            command4.Parameters.AddWithValue("@Name", name_studentsA[count]);
                            command4.Parameters.AddWithValue("@Exam_Code", examcode);
                            command4.Parameters.AddWithValue("@Course", course_studentsA[count]);
                            command3.ExecuteNonQuery();
                            j += 1;
                            if (j == seriesA)
                            {
                                sra += 1;
                                seriesA = int.Parse(Aseries[sra].ToString());
                                room = roomno[sra];
                                j = 0;
                            }

                            if (reg_studentsA.Last() == reg_studentsA[count])
                            {

                                break;
                            }
                            count = count + 1;

                        }

                    }
                    int countb = 0;
                    if (reg_studentsB.Count != 0)
                    {

                        for (int i = k; i < seriesB; i++)
                        {
                            SqlCommand command4 = new SqlCommand("insert into Series_Alloted(Date,Room_No,Seat,Session,Class,Reg_no,Name,Exam_Code,Course)Values(" + "@Date,@Room_No,@Seat,@Session,@Class,@Reg_no,@Name,@Exam_Code,@Course)", con.ActiveCon());
                            command4.Parameters.AddWithValue("@Date", distinctdate[backupcount - 1]);
                            command4.Parameters.AddWithValue("@Room_No", room);
                            command4.Parameters.AddWithValue("@Seat", "B" + (k + 1));
                            command4.Parameters.AddWithValue("@Session", session);
                            command4.Parameters.AddWithValue("@Class", class_studentsB[count]);
                            command4.Parameters.AddWithValue("@Reg_no", reg_studentsB[countb]);
                            command4.Parameters.AddWithValue("@Name", name_studentsB[countb]);
                            command4.Parameters.AddWithValue("@Exam_Code", examcode);
                            command4.Parameters.AddWithValue("@Course", course_studentsB[count]);
                            command4.ExecuteNonQuery();
                            k += 1;
                            if (k == seriesB)
                            {
                                srb += 1;
                                seriesB = int.Parse(Bseries[srb].ToString());
                                room = roomno[srb];
                                k = 0;
                            }

                            if (reg_studentsB.Last() == reg_studentsB[count])
                            {

                                break;
                            }
                            countb = countb + 1;

                        }

                    }

                    SelectedStudents.Rows.Clear();
                    //since distinctdate is equal if condition was false above ,so we have to insert before timetable date change
                    if(checkcount!=0)
                    {
                        foreach (DataRow dataRow2 in table_students.Rows)
                        {
                            string student_course = dataRow2["Course"].ToString();
                            if (student_course.ToUpper().Contains(course.ToUpper()))
                            {
                                SelectedStudents.ImportRow(dataRow2);

                            }

                        }
                        if(distinctdate[dcount]==date)
                        {
                            if (distinctdate.Count != dcount + 1)
                            {
                                dcount += 1;
                            }
                            else
                                dcount = 0;
                            backupcount += 1;
                        }
                        if (SessionCheck != session)
                            SessionCheck = session;
                        sra = 0;
                        j = 0;
                        srb = 0;
                        k = 0;
                    }
                }
                else { }
                
            }
            MessageBox.Show("Series Seating Allot Completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MultiAllotment_button_Click(object sender, EventArgs e)
        {
            Allot_Series();
        }

        private void Shift_button_Click(object sender, EventArgs e)
        {
            string fromroom = FromRoom_textbox.Text;
            
        }

        private void RoomPrint_button_Click(object sender, EventArgs e)
        {
            RoomExcel_panel.Enabled = true;
            DisplaySheet_Panel.Enabled = false;
            Signature_panel.Enabled = false;
            RoomExcel_panel.BringToFront();
            Generation_Panel.Enabled = false;
        }

        private void Save_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog(); 
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    Folder_path_text.Text = fdb.SelectedPath;
                }
            }

        private void Excel_generate_btn_Click(object sender, EventArgs e)
        {
            if (UnvRoomGen_radio.Checked || SeriesRoomGen_radio.Checked)
            {
                Excel_Generation_function(0);
            }
            else
                MessageBox.Show("Select Exam Type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RoomPanelClose_btn_Click(object sender, EventArgs e)
        {
            Generation_Panel.BringToFront();
            Generation_Panel.Enabled = true;
            RoomExcel_panel.Enabled = false;
        }

        private void SignatureSheet_button_Click(object sender, EventArgs e)
        {
            Signature_panel.Enabled = true;
            Signature_panel.BringToFront();
            Generation_Panel.Enabled = false;
            RoomExcel_panel.Enabled = false;
            DisplaySheet_Panel.Enabled = false;
        }

        private void Signature_close_btn_Click(object sender, EventArgs e)
        {
            Generation_Panel.BringToFront();
            Generation_Panel.Enabled = true;
            Signature_panel.Enabled = false;
        }

        private void Signature_generate_btn_Click(object sender, EventArgs e)
        {
            if (UnvSignature_radio.Checked || SeriesSignature_radio.Checked)
            {
                Excel_Generation_function(1);
            }
            else
                MessageBox.Show("Select Exam Type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void Excel_Generation_function(int f)
        {
            if (Folder_path_text.Text != "")
            {
                int flag = 0;

                DataTable dstnctdatatable = new DataTable();
                SqlCommand command = new SqlCommand("SELECT Distinct Date from Series_Alloted", con.ActiveCon());
                SqlDataAdapter distinctadapter = new SqlDataAdapter(command);
                distinctadapter.Fill(dstnctdatatable);

                if (dstnctdatatable.Rows.Count == 0)
                {
                    MessageBox.Show("Allot Students First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (f == 0)
                    {
                        Generation_Panel.BringToFront();
                        Generation_Panel.Enabled = true;
                        RoomExcel_panel.Enabled = false;
                    }
                    else if (f == 1)
                    {
                        Generation_Panel.BringToFront();
                        Generation_Panel.Enabled = true;
                        Signature_panel.Enabled = false;
                    }
                    flag = 1;
                }
                else
                {
                    foreach (DataRow dr in dstnctdatatable.Rows)
                    {

                        string session = "Forenoon";
                        for (int count = 0; count < 2; count++)
                        {
                            //Create the data set and table
                            //DataSet ds = new DataSet("New_DataSet");
                            DataTable dt = new DataTable();

                            if (SeriesSignature_radio.Checked || SeriesRoomGen_radio.Checked)
                            {
                                //Create a query and fill the data table with the data from the DB            
                                SqlCommand cmd = new SqlCommand("SELECT Seat,Reg_no,Name,Exam_code from Series_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                cmd.Parameters.AddWithValue("@Session", session);
                                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                                adptr.Fill(dt);
                            }
                            else if (UnvRoomGen_radio.Checked || UnvSignature_radio.Checked)
                            {
                                //Create a query and fill the data table with the data from the DB            
                                SqlCommand cmd = new SqlCommand("SELECT Seat,Reg_no,Name,Exam_code from University_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                cmd.Parameters.AddWithValue("@Session", session);
                                SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                                adptr.Fill(dt);
                            }

                            DataTable dstnctroomdatatable = new DataTable();
                            SqlCommand commandroom = new SqlCommand("SELECT Distinct Room_No from Series_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                            commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                            commandroom.Parameters.AddWithValue("@Session", session);
                            SqlDataAdapter distinctroomadapter = new SqlDataAdapter(commandroom);
                            distinctroomadapter.Fill(dstnctroomdatatable);

                            if (dt.Rows.Count != 0)
                            {
                                using(var package = new ExcelPackage())
                                {
                                    foreach (DataRow dstrw in dstnctroomdatatable.Rows)
                                    {
                                        string checkroom = dstrw["Room_No"].ToString();
                                        //Add a new worksheet to the empty workbook
                                        var worksheet = package.Workbook.Worksheets.Add(checkroom);
                                        //Insert Items to ExcelSheet
                                        worksheet.Cells["A1"].Value = "KMEA ENGINEERING COLLEGE";
                                        if (f == 0)
                                        {
                                            worksheet.Cells["A2"].Value = MonthYear_textbox.Text;
                                            worksheet.Cells["A3"].Value = "STUDENTS LIST";
                                        }
                                        else if (f == 1)
                                        {
                                            worksheet.Cells["A2"].Value = Signature_examtype_textbox.Text;
                                            worksheet.Cells["A3"].Value = "ATTENDANCE STATEMENT";
                                        }
                                        worksheet.Cells["A4"].Value = checkroom;
                                        worksheet.Cells["E4"].Value = dr["Date"].ToString() + " " + session;

                                        using (var range = worksheet.Cells["A1:F1"])
                                        {
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 14;
                                            range.Style.Font.Bold = true;
                                        }
                                        using (var range = worksheet.Cells["A2:F2"])
                                        {
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 12;
                                            range.Style.Font.Bold = true;
                                        }
                                        using (var range = worksheet.Cells["A3:F3"])
                                        {
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                        }
                                        using (var range = worksheet.Cells["A4:C4"])
                                        {
                                            range.Merge = true;
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                        }
                                        using (var range = worksheet.Cells["A4:F4"])
                                        {
                                            range.Merge = true;
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                        }

                                        // column headings
                                        worksheet.Cells[5, 1].Value = "Sl.No";
                                        worksheet.Cells[5, 1].Style.Font.Name = "Arial";
                                        worksheet.Cells[5, 1].Style.Font.Size = 10;
                                        worksheet.Cells[5, 1].Style.Font.Bold = true;
                                        if (f == 1)
                                            worksheet.Cells[5, dt.Columns.Count + 2].Value = "Signature";
                                        for (var i = 0; i < dt.Columns.Count; i++)
                                        {
                                            worksheet.Cells[5, i + 2].Value = dt.Columns[i].ColumnName;
                                            worksheet.Cells[5, i + 2].Style.Font.Name = "Arial";
                                            worksheet.Cells[5, i + 2].Style.Font.Size = 10;
                                            worksheet.Cells[5, i + 2].Style.Font.Bold = true;
                                        }

                                        // rows
                                        for (var i = 0; i < dt.Rows.Count; i++)
                                        {
                                            if (dt.Rows[i]["Room_No"].ToString() == checkroom)
                                            {
                                                worksheet.Cells[i + 6, 1].Value = i + 1;    //Sl.No Filling
                                                for (var j = 0; j < dt.Columns.Count; j++)
                                                {
                                                    worksheet.Cells[i + 6, j + 2].Value = dt.Rows[i][j];
                                                }
                                            }

                                        }
                                        if (f == 0)
                                        {
                                            worksheet.Cells[5, 1, dt.Rows.Count + 4, dt.Columns.Count + 1].AutoFitColumns();
                                            using (var range = worksheet.Cells[5, 1, dt.Rows.Count + 4, dt.Columns.Count + 1])
                                            {
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                                            }
                                        }
                                        else if (f == 1)
                                        {
                                            worksheet.Cells[5, 1, dt.Rows.Count + 4, dt.Columns.Count + 2].AutoFitColumns();
                                            using (var range = worksheet.Cells[5, 1, dt.Rows.Count + 4, dt.Columns.Count + 2])
                                            {
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                                            }
                                            worksheet.Cells[dt.Rows.Count + 6, 1].Value = " Write the Register Numbers of the absentees in the box";
                                            using (var range = worksheet.Cells[dt.Rows.Count + 7, 1, dt.Rows.Count + 15, 4])
                                            {
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                                            }
                                            worksheet.Cells[dt.Rows.Count + 15, 5].Value = " Name and Signature of Invigilator(s)";
                                        }
                                    }
                                    //Save Excel File
                                    /* below might get error since Date has '\' in between ... CHECK if we have to use array 
                                    or something else to remove the '\' .   */                                     
                                    string path = Folder_path_text.Text + @"\Room Sheet " + dr["Date"].ToString() + " " + session + ".xlsx";                               
                                    if (f == 1)
                                        path = Folder_path_text.Text + @"\Signature Sheet " + dr["Date"].ToString() + " " + session + ".xlsx";

                                    Stream stream = File.Create(path);
                                    package.SaveAs(stream);
                                    stream.Close();

                                    session = "Afternoon";
                                }
                            }
                        }



                    }
                }
                if (flag == 0)
                    MessageBox.Show("Excel files created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Filepath is not given", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (f == 0)
            {
                Generation_Panel.BringToFront();
                Generation_Panel.Enabled = true;
                RoomExcel_panel.Enabled = false;
            }
            else if (f == 1)
            {
                Generation_Panel.BringToFront();
                Generation_Panel.Enabled = true;
                Signature_panel.Enabled = false;
            }
        }

        private void DisplaySheet_generate_btn_Click(object sender, EventArgs e)
        {
            if(UnvDisplay_radio.Checked || SeriesDisplay_radio.Checked)
            {
                if (Folder_path_text.Text != "")
                {
                    DataTable dstnctdatatable = new DataTable();
                    SqlCommand command = new SqlCommand("SELECT Distinct Date from Series_Alloted", con.ActiveCon());
                    SqlDataAdapter distinctadapter = new SqlDataAdapter(command);
                    distinctadapter.Fill(dstnctdatatable);

                    if (dstnctdatatable.Rows.Count == 0)
                    {
                        MessageBox.Show("Allot Students First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Generation_Panel.BringToFront();
                        Generation_Panel.Enabled = true;
                        DisplaySheet_Panel.Enabled = false;
                        return;
                    }
                    else
                    {
                        foreach (DataRow dr in dstnctdatatable.Rows)
                        {

                            string session = "Forenoon";
                            for (int count = 0; count < 2; count++)
                            {
                                //Create the data set and table
                                //DataSet ds = new DataSet("New_DataSet");
                                DataTable dt = new DataTable();

                                if (SeriesDisplay_radio.Checked)
                                {
                                    //Create a query and fill the data table with the data from the DB            
                                    SqlCommand cmd = new SqlCommand("SELECT Reg_no,Room_No,Seat,Exam_code,Course from Series_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                    cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                    cmd.Parameters.AddWithValue("@Session", session);
                                    SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                                    adptr.Fill(dt);
                                }
                                else if (UnvDisplay_radio.Checked)
                                {
                                    //Create a query and fill the data table with the data from the DB            
                                    SqlCommand cmd = new SqlCommand("SELECT Reg_no,Room_No,Seat,Exam_code,Course from University_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                    cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                    cmd.Parameters.AddWithValue("@Session", session);
                                    SqlDataAdapter adptr = new SqlDataAdapter(cmd);
                                    adptr.Fill(dt);
                                }

                                DataTable dt2 = new DataTable();
                                SqlCommand commandroom = new SqlCommand("SELECT Reg_no,Branch from Students", con.ActiveCon());
                                SqlDataAdapter adptr2 = new SqlDataAdapter(commandroom);
                                adptr2.Fill(dt2);

                                dt.Columns.Add("Branch", typeof(string));
                                foreach (DataRow getreg in dt.Rows)
                                {
                                    foreach (DataRow getdr in dt2.Rows)
                                    {
                                        if (getreg["Reg_no"].ToString() == getdr["Reg_no"].ToString())
                                        {
                                            getreg["Branch"] = getdr["Branch"].ToString();

                                            break;
                                        }
                                    }
                                }

                                // datatable with distinct branch from 'dt'
                                DataTable distinctBranch = dt.DefaultView.ToTable(true, "Branch");
                                dataGridView2.DataSource = distinctBranch;
                                MessageBox.Show("--Tester-- \n Check whether distinct code works in dgv");
                                //Excel Designing
                                if (dt.Rows.Count != 0)
                                {
                                    using (var package = new ExcelPackage())
                                    {
                                        foreach (DataRow dstrw in distinctBranch.Rows)
                                        {
                                            string checkbranch = dstrw["Branch"].ToString();
                                            //Add a new worksheet to the empty workbook
                                            var worksheet = package.Workbook.Worksheets.Add(checkbranch);
                                            //Insert Items to ExcelSheet
                                            worksheet.Cells["A1"].Value = "KMEA ENGINEERING COLLEGE";
                                            worksheet.Cells["A2"].Value = Display_examtype_textbox.Text;
                                            worksheet.Cells["A3"].Value = dr["Date"].ToString() + " " + session;
                                            worksheet.Cells["A4"].Value = checkbranch;
                                            worksheet.Cells["A5"].Value = "Register No - Room No - Seat No";

                                            using (var range = worksheet.Cells["A1:D1"])
                                            {
                                                range.Merge = true;
                                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 16;
                                                range.Style.Font.Bold = true;
                                            }
                                            using (var range = worksheet.Cells["A2:D2"])
                                            {
                                                range.Merge = true;
                                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                            }
                                            using (var range = worksheet.Cells["A3:D3"])
                                            {
                                                range.Merge = true;
                                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                            }
                                            using (var range = worksheet.Cells["A4:D4"])
                                            {
                                                range.Merge = true;
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                            }
                                            using (var range = worksheet.Cells["A5"])
                                            {
                                                range.Merge = true;
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                            }

                                            // rows
                                            DataTable selectedBranchStudents = dt.Clone();
                                            DataTable isolated = new DataTable();
                                            isolated.Columns.Add("Course", typeof(string));
                                            for (var i = 0; i < dt.Rows.Count; i++)
                                            {
                                                if (dt.Rows[i]["Branch"].ToString() == checkbranch)
                                                {
                                                    isolated.Rows.Add(dt.Rows[i]["Course"]);
                                                    for (var j = 0; j < dt.Columns.Count; j++)
                                                    {
                                                        selectedBranchStudents.Rows.Add(dt.Rows[i][j]);
                                                    }
                                                }

                                            }
                                            DataTable distinctIsolateCourse = isolated.DefaultView.ToTable(true, "Course");
                                            int excelcount = 5, exd = 1;
                                            foreach (DataRow isocourse in distinctIsolateCourse.Rows)
                                            {
                                                excelcount++;
                                                //have to loop according to Course from here
                                                worksheet.Cells[excelcount, 1].Value = isocourse["Course"].ToString();
                                                using (var range = worksheet.Cells[excelcount, 1])
                                                {
                                                    range.Merge = true;
                                                    range.Style.Font.Name = "Arial";
                                                    range.Style.Font.Size = 14;
                                                    range.Style.Font.Bold = true;
                                                }
                                                excelcount++;
                                                for (var i = 0; i < selectedBranchStudents.Rows.Count; i++)
                                                {
                                                    if (selectedBranchStudents.Rows[i]["Course"].ToString() == isocourse["Course"].ToString())
                                                    {
                                                        if (exd == 4)
                                                        {
                                                            exd = 1;
                                                            excelcount++;
                                                        }
                                                        string excString = "";
                                                        for (var j = 0; j < 3; j++)
                                                        {
                                                            excString = excString + selectedBranchStudents.Rows[i][j].ToString() + " ";
                                                        }
                                                        worksheet.Cells[excelcount, exd].Value = excString;
                                                        exd++;
                                                    }

                                                }
                                            }
                                        }
                                        //Save Excel File
                                        /* below might get error since Date has '\' in between ... CHECK if we have to use array 
                                        or something else to remove the '\' .   */
                                        string path = Folder_path_text.Text + @"\Display Sheet " + dr["Date"].ToString() + " " + session + ".xlsx";
                                        Stream stream = File.Create(path);
                                        package.SaveAs(stream);
                                        stream.Close();

                                        session = "Afternoon";
                                    }

                                }
                            }
                        }
                    }
                    MessageBox.Show("Excel files created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Filepath is not given", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Generation_Panel.BringToFront();
                Generation_Panel.Enabled = true;
                DisplaySheet_Panel.Enabled = false;
            }
            else
                MessageBox.Show("Select Exam Type", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DisplayPanel_closebtn_Click(object sender, EventArgs e)
        {
            Generation_Panel.BringToFront();
            Generation_Panel.Enabled = true;
            DisplaySheet_Panel.Enabled = false;
        }

        private void DisplayPrint_button_Click(object sender, EventArgs e)
        {
            DisplaySheet_Panel.Enabled = true;
            DisplaySheet_Panel.BringToFront();
            Generation_Panel.Enabled = false;
            Signature_panel.Enabled = false;
            RoomExcel_panel.Enabled = false;
        }

        private void Allotment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Generation_Panel.BringToFront();
            Generation_Panel.Enabled = true;
            DisplaySheet_Panel.Enabled = false;
            Signature_panel.Enabled = false;
            RoomExcel_panel.Enabled = false;
        }
    }
}

        



