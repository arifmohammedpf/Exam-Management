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
            SqlCommand command3 = new SqlCommand("select * from Rooms order by Priority and A_Series desc", con.ActiveCon());
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table_rooms = new DataTable();
            adapter3.Fill(table_rooms);
            dataGridView1.DataSource = table_rooms;

            foreach(DataRow roomrow in table_rooms.Rows)
            {
                int j = 0;
                foreach (DataRow row in table_timetable.Rows)
                {
                    string date = row["Date"].ToString();
                    string session = row["Session"].ToString();
                    string course = row["Course"].ToString();
                    string examcode = row["Exam_Code"].ToString();
                    List<string> reg_students = new List<string>();
                    List<string> name_students = new List<string>();
                    foreach (DataRow row2 in table_students.Rows)
                    {
                        string student_course = row2["Course"].ToString();
                        if (student_course == course)
                        {
                            name_students.Add(row2["Name"].ToString());
                            reg_students.Add(row2["Reg_no"].ToString());
                        }
                    }
                    int count = 0;
                    if (reg_students.Count != 0)
                    {
                        int series = int.Parse(roomrow["A_Series"].ToString());
                        for ( int i=j; i < series; i++)
                        {
                            SqlCommand command4 = new SqlCommand("insert into University_Alloted(Room_No,Seat,Session,Reg_no,Name,Exam_Code,Course)Values(" + "@Room_No,@Seat,@Reg_no,@Name,@Exam_Code,@Course", con.ActiveCon());
                            command4.Parameters.AddWithValue("@Room_No", roomrow["Room_No"].ToString());
                            command4.Parameters.AddWithValue("@Seat", "A" + i + 1);
                            command4.Parameters.AddWithValue("@Session", session);
                            command4.Parameters.AddWithValue("@Reg_no", reg_students[count]);
                            command4.Parameters.AddWithValue("@Name", name_students[count]);
                            command4.Parameters.AddWithValue("@Exam_Code", examcode);
                            command4.Parameters.AddWithValue("@Course", course);
                            j += 1;
                            if (reg_students.Last() == reg_students[count])
                            {
                                
                                break;
                            }
                            count = count + 1;
                            
                        }
                        
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
            SqlCommand command2 = new SqlCommand("select * from Series_candidates order by Course and Class and Name", con.ActiveCon());
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table_students = new DataTable();
            adapter2.Fill(table_students);

            //get rooms details
            SqlCommand command3 = new SqlCommand("select * from Rooms order by Priority and A_Series desc", con.ActiveCon());
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table_rooms = new DataTable();
            adapter3.Fill(table_rooms);
            dataGridView1.DataSource = table_rooms;

            //int no_of_students = table_students.Rows.Count;
            
            //var top50 = table_students.AsEnumerable()
            //        .Take(no_of_students);
            //var bottom50 = table_students.AsEnumerable()
            //        .Skip(no_of_students);

            
                int count = 0, f=0;
            List<string> reg_students = new List<string>();
            List<string> name_students = new List<string>();
            foreach (DataRow row3 in table_rooms.Rows)
            {
                foreach (DataRow row in table_timetable.Rows)
                {
                    string date = row["Date"].ToString();
                    string session = row["Session"].ToString();
                    string course = row["Course"].ToString();
                    string examcode = row["Exam_Code"].ToString();
                    
                    foreach (DataRow row2 in table_students.Rows)
                    {
                        string student_course = row2["Course"].ToString();
                        if (student_course == course)
                        {
                            name_students.Add(row2["Name"].ToString());
                            reg_students.Add(row2["Reg_no"].ToString());
                        }
                    }
                }
                    if (reg_students.Count != 0)
                    {
                        int series = int.Parse(row3["A_Series"].ToString());
                        for (int i = 0; i < series; i++)
                        {
                            SqlCommand command4 = new SqlCommand("insert into Series_Alloted(Room_No,Seat,Session,Reg_no,Name,Exam_Code,Course)Values(" + "@Room_No,@Seat,@Reg_no,@Name,@Exam_Code,@Course", con.ActiveCon());
                            command4.Parameters.AddWithValue("@Room_No", row3["Room_No"].ToString());
                            command4.Parameters.AddWithValue("@Seat", "A" + i + 1);
                            command4.Parameters.AddWithValue("@Session", session);
                            command4.Parameters.AddWithValue("@Reg_no", reg_students[count]);
                            command4.Parameters.AddWithValue("@Name", name_students[count]);
                            command4.Parameters.AddWithValue("@Exam_Code", examcode);
                            command4.Parameters.AddWithValue("@Course", course);
                            if (reg_students.Last() == reg_students[count])
                            {
                                f = 1;
                                break;
                            }

                            count = count + 1;
                        }

                    }
                    else
                        break;
                    if (f == 1)
                        break;


                
            }
        }

    }
}



