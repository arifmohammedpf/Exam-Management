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
            SqlCommand command3 = new SqlCommand("select * from Rooms order by Priority, A_Series desc", con.ActiveCon());
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
            SqlCommand command3 = new SqlCommand("select * from Rooms order by Priority, A_Series desc", con.ActiveCon());
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
    }
}



