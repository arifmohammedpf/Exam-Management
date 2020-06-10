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
            SqlCommand command = new SqlCommand("select Date,Session,Course from Timetable order by Date",con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_timetable = new DataTable();
            adapter.Fill(table_timetable);

            //get registered students details
            SqlCommand command2 = new SqlCommand("select * from Registered_candidates order by Reg_no", con.ActiveCon());
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
            int dcount=1;

            //start allotment loop
            foreach (DataRow row in table_timetable.Rows)
            {               
                string date = row["Date"].ToString();
                string session = row["Session"].ToString();
                string course = row["Course"].ToString();
                string examcode = row["Exam_Code"].ToString();
                if (distinctdate[dcount] == date) //might get error when distinctdate get out of range
                {
                    dcount += 1;
                    sr = 0;
                    j = 0;
                }
                else { }
                List<string> reg_students = new List<string>();
                List<string> name_students = new List<string>();
                foreach (DataRow row2 in table_students.Rows)
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
                        SqlCommand command4 = new SqlCommand("insert into University_Alloted(Room_No,Seat,Session,Reg_no,Name,Exam_Code,Course)Values(" + "@Room_No,@Seat,@Reg_no,@Name,@Exam_Code,@Course", con.ActiveCon());
                        command4.Parameters.AddWithValue("@Room_No", room);
                        command4.Parameters.AddWithValue("@Seat", "A" + j + 1);
                        command4.Parameters.AddWithValue("@Session", session);
                        command4.Parameters.AddWithValue("@Reg_no", reg_students[count]);
                        command4.Parameters.AddWithValue("@Name", name_students[count]);
                        command4.Parameters.AddWithValue("@Exam_Code", examcode);
                        command4.Parameters.AddWithValue("@Course", course);
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
                    
            
            
                
                
            
        }

        void Allot_Series()
        {
            //Get Timtable details
            SqlCommand command = new SqlCommand("select Date,Session,Course from Timetable order by Date", con.ActiveCon());
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

            int no_of_students = table_students.Rows.Count;

            var top50 = table_students.AsEnumerable()
                    .Take(no_of_students/2);
            var bottom50 = table_students.AsEnumerable()
                    .Skip(no_of_students/2);


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
            int dcount = 1;

            //start allotment loop
            foreach (DataRow row in table_timetable.Rows)
            {
                string date = row["Date"].ToString();
                string session = row["Session"].ToString();
                string course = row["Course"].ToString();
                string examcode = row["Exam_Code"].ToString();
                if (distinctdate[dcount] == date) //might get error when distinctdate get out of range
                {
                    dcount += 1;
                    sra = 0;
                    j = 0;
                    srb = 0;
                    k = 0;
                }
                else { }
                List<string> reg_studentsA = new List<string>();
                List<string> name_studentsA = new List<string>();
                List<string> reg_studentsB = new List<string>();
                List<string> name_studentsB = new List<string>();
                foreach (DataRow row2 in top50)
                {
                    string student_course = row2["Course"].ToString();
                    if (student_course.ToUpper().Contains(course.ToUpper()))
                    {
                        name_studentsA.Add(row2["Name"].ToString());
                        reg_studentsA.Add(row2["Reg_no"].ToString());
                    }
                }
                foreach (DataRow row2 in bottom50)
                {
                    string student_course = row2["Course"].ToString();
                    if (student_course == course)
                    {
                        name_studentsB.Add(row2["Name"].ToString());
                        reg_studentsB.Add(row2["Reg_no"].ToString());
                    }
                }
                int count = 0;

                if (reg_studentsA.Count != 0)
                {

                    for (int i = j; i < seriesA; i++)
                    {
                        SqlCommand command4 = new SqlCommand("insert into Series_Alloted(Room_No,Seat,Session,Reg_no,Name,Exam_Code,Course)Values(" + "@Room_No,@Seat,@Reg_no,@Name,@Exam_Code,@Course", con.ActiveCon());
                        command4.Parameters.AddWithValue("@Room_No", room);
                        command4.Parameters.AddWithValue("@Seat", "A" + j + 1);
                        command4.Parameters.AddWithValue("@Session", session);
                        command4.Parameters.AddWithValue("@Reg_no", reg_studentsA[count]);
                        command4.Parameters.AddWithValue("@Name", name_studentsA[count]);
                        command4.Parameters.AddWithValue("@Exam_Code", examcode);
                        command4.Parameters.AddWithValue("@Course", course);
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
                        SqlCommand command4 = new SqlCommand("insert into Series_Alloted(Room_No,Seat,Session,Reg_no,Name,Exam_Code,Course)Values(" + "@Room_No,@Seat,@Reg_no,@Name,@Exam_Code,@Course", con.ActiveCon());
                        command4.Parameters.AddWithValue("@Room_No", room);
                        command4.Parameters.AddWithValue("@Seat", "B" + k + 1);
                        command4.Parameters.AddWithValue("@Session", session);
                        command4.Parameters.AddWithValue("@Reg_no", reg_studentsB[countb]);
                        command4.Parameters.AddWithValue("@Name", name_studentsB[countb]);
                        command4.Parameters.AddWithValue("@Exam_Code", examcode);
                        command4.Parameters.AddWithValue("@Course", course);
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
            }
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



