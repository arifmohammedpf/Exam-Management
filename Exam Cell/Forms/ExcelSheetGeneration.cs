using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SQLite;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Exam_Cell.Forms
{
    public partial class ExcelSheetGeneration : Form
    {
        public ExcelSheetGeneration()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(148, 142, 153), Color.FromArgb(46, 20, 55), 280F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();
        Allotment allotment = (Allotment)Application.OpenForms["Allotment"];
        private void Signature_generate_btn_Click(object sender, EventArgs e)
        {
            Excel_Generation_function(1);
        }

        private void room_generate_btn_Click(object sender, EventArgs e)
        {
            Excel_Generation_function(0);
        }

        private void display_generate_btn_Click(object sender, EventArgs e)
        {
            display_generation_function();
        }

        void Excel_Generation_function(int f)
        {
            try
            {
                string commandtext;
                if (allotment.Series_radio.Checked)
                    commandtext = "SELECT Distinct Date from Series_Alloted";
                else
                    commandtext = "SELECT Distinct Date from University_Alloted";
                DataTable dstnctdatatable = new DataTable();
                SQLiteCommand command = new SQLiteCommand(commandtext, con.ActiveCon());
                SQLiteDataAdapter distinctadapter = new SQLiteDataAdapter(command);
                distinctadapter.Fill(dstnctdatatable);
                con.CloseCon();
                if (dstnctdatatable.Rows.Count == 0)
                {
                    msgbox.show("Allot Students First    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string createRoomPath = allotment.Folder_path_text.Text + @"\Room Sheets";
                    string createSignaturePath = allotment.Folder_path_text.Text + @"\Signature Sheets";
                    Directory.CreateDirectory(createRoomPath);
                    Directory.CreateDirectory(createSignaturePath);

                    foreach (DataRow dr in dstnctdatatable.Rows)
                    {

                        string session = "Forenoon";
                        for (int count = 0; count < 2; count++)
                        {
                            DataTable dt = new DataTable();

                            if (allotment.Series_radio.Checked)
                            {
                                //Create a query and fill the data table with the data from the DB            
                                SQLiteCommand cmd = new SQLiteCommand("SELECT Seat,Reg_no,Name,Exam_code,Room_No from Series_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                cmd.Parameters.AddWithValue("@Session", session);
                                SQLiteDataAdapter adptr = new SQLiteDataAdapter(cmd);
                                adptr.Fill(dt);
                                con.CloseCon();
                            }
                            else
                            {
                                //Create a query and fill the data table with the data from the DB            
                                SQLiteCommand cmd = new SQLiteCommand("SELECT Seat,Reg_no,Name,Exam_code,Room_No from University_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                cmd.Parameters.AddWithValue("@Session", session);
                                SQLiteDataAdapter adptr = new SQLiteDataAdapter(cmd);
                                adptr.Fill(dt);
                                con.CloseCon();
                            }

                            DataTable dstnctroomdatatable = new DataTable();
                            if (allotment.Series_radio.Checked)
                            {
                                SQLiteCommand commandroom = new SQLiteCommand("SELECT Distinct Room_No from Series_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                                commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                commandroom.Parameters.AddWithValue("@Session", session);
                                SQLiteDataAdapter distinctroomadapter = new SQLiteDataAdapter(commandroom);
                                distinctroomadapter.Fill(dstnctroomdatatable);
                                con.CloseCon();
                            }
                            else
                            {
                                SQLiteCommand commandroom = new SQLiteCommand("SELECT Distinct Room_No from University_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                                commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                commandroom.Parameters.AddWithValue("@Session", session);
                                SQLiteDataAdapter distinctroomadapter = new SQLiteDataAdapter(commandroom);
                                distinctroomadapter.Fill(dstnctroomdatatable);
                                con.CloseCon();
                            }

                            if (dt.Rows.Count != 0)
                            {
                                using (var package = new ExcelPackage())
                                {
                                    foreach (DataRow dstrw in dstnctroomdatatable.Rows)
                                    {
                                        string checkroom = dstrw["Room_No"].ToString();
                                        //Add a new worksheet to the empty workbook
                                        var worksheet = package.Workbook.Worksheets.Add(checkroom);
                                        //Insert Items to ExcelSheet
                                        worksheet.Cells["A1"].Value = "KMEA ENGINEERING COLLEGE";
                                        worksheet.Cells["A2"].Value = examtype_textbox.Text;
                                        if (f == 0)
                                        {
                                            worksheet.Cells["A3"].Value = "STUDENTS LIST";
                                        }
                                        else if (f == 1)
                                        {
                                            worksheet.Cells["A3"].Value = "ATTENDANCE STATEMENT";
                                        }
                                        worksheet.Cells["A4"].Value = "Room " + checkroom;
                                        worksheet.Cells["E4"].Value = dr["Date"].ToString() + " " + session;

                                        using (var range = worksheet.Cells["A1:F1"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 14;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A2:F2"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 12;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A3:F3"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A4:C4"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                        }
                                        using (var range = worksheet.Cells["A4:F4"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 10;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                        }

                                        // column headings
                                        worksheet.Cells[5, 1].Value = "Sl.No";
                                        worksheet.Cells[5, 1].Style.Font.Name = "Arial";
                                        worksheet.Cells[5, 1].Style.Font.Size = 10;
                                        worksheet.Cells[5, 1].Style.Font.Bold = true;
                                        if (f == 1)
                                        {
                                            worksheet.Cells[5, dt.Columns.Count + 2].Value = "Signature";
                                            worksheet.Cells[5, dt.Columns.Count + 2].Style.Font.Bold = true;
                                        }
                                        for (int i = 0; i < dt.Columns.Count; i++)
                                        {
                                            worksheet.Cells[5, i + 2].Value = dt.Columns[i].ColumnName;
                                            worksheet.Cells[5, i + 2].Style.Font.Name = "Arial";
                                            worksheet.Cells[5, i + 2].Style.Font.Size = 10;
                                            worksheet.Cells[5, i + 2].Style.Font.Bold = true;
                                        }

                                        // rows
                                        int rc = 0;
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            if (dt.Rows[i]["Room_No"].ToString() == checkroom)
                                            {
                                                worksheet.Cells[rc + 6, 1].Value = rc + 1;    //Sl.No Filling
                                                for (int j = 0; j < dt.Columns.Count; j++)
                                                {
                                                    worksheet.Cells[rc + 6, j + 2].Value = dt.Rows[i][j];
                                                }
                                                rc++;
                                            }

                                        }
                                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                                        if (f == 0)
                                        {
                                            using (var range = worksheet.Cells[5, 1, rc + 5, dt.Columns.Count + 1])
                                            {
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                            }
                                        }
                                        else if (f == 1)
                                        {
                                            using (var range = worksheet.Cells[5, 1, rc + 5, dt.Columns.Count + 2])
                                            {
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                            }
                                            worksheet.Cells[rc + 7, 1].Value = " Write the Register Numbers of the absentees in the box";
                                            using (var range = worksheet.Cells[rc + 8, 1, rc + 16, 4])
                                            {
                                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                            }
                                            worksheet.Cells[rc + 16, 5].Value = " Name and Signature of Invigilator(s)";
                                        }
                                    }
                                    //Save Excel File
                                    /* below might get error since Date has '\' in between ... CHECK if we have to use array 
                                    or something else to remove the '\' .   */


                                    string path = createRoomPath + @"\Room Sheet " + dr["Date"].ToString() + " " + session + ".xlsx";
                                    if (f == 1)
                                    {
                                        path = createSignaturePath + @"\Signature Sheet " + dr["Date"].ToString() + " " + session + ".xlsx";
                                    }


                                    Stream stream = File.Create(path);
                                    package.SaveAs(stream);
                                    stream.Close();

                                    session = "Afternoon";
                                }
                            }
                        }
                    }
                    msgbox.show("Excel files created    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void display_generation_function()
        {
            try
            {
                string commandtext;
                if (allotment.Series_radio.Checked)
                    commandtext = "SELECT Distinct Date from Series_Alloted";
                else
                    commandtext = "SELECT Distinct Date from University_Alloted";
                DataTable dstnctdatatable = new DataTable();
                SQLiteCommand command = new SQLiteCommand(commandtext, con.ActiveCon());
                SQLiteDataAdapter distinctadapter = new SQLiteDataAdapter(command);
                distinctadapter.Fill(dstnctdatatable);
                con.CloseCon();
                if (dstnctdatatable.Rows.Count == 0)
                {
                    msgbox.show("Allot Students First    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string createDisplayPath = allotment.Folder_path_text.Text + @"\Display Sheets";
                    Directory.CreateDirectory(createDisplayPath);

                    foreach (DataRow dr in dstnctdatatable.Rows)
                    {
                        string session = "Forenoon";
                        for (int count = 0; count < 2; count++)
                        {
                            DataTable dt = new DataTable();

                            if (allotment.Series_radio.Checked)
                            {
                                //Create a query and fill the data table with the data from the DB            
                                SQLiteCommand cmd = new SQLiteCommand("SELECT Reg_no,Room_No,Seat,Exam_code,Course,Class from Series_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                cmd.Parameters.AddWithValue("@Session", session);
                                SQLiteDataAdapter adptr = new SQLiteDataAdapter(cmd);
                                adptr.Fill(dt);
                            }
                            else
                            {
                                //Create a query and fill the data table with the data from the DB            
                                SQLiteCommand cmd = new SQLiteCommand("SELECT Reg_no,Room_No,Seat,Exam_code,Course,Branch from University_Alloted Where Date=@Date and Session=@Session order by Room_No", con.ActiveCon());
                                cmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                cmd.Parameters.AddWithValue("@Session", session);
                                SQLiteDataAdapter adptr = new SQLiteDataAdapter(cmd);
                                adptr.Fill(dt);
                            }
                            con.CloseCon();
                            DataTable dt2 = new DataTable();
                            if (allotment.Unv_radio.Checked)
                            {
                                SQLiteCommand commandroom = new SQLiteCommand("SELECT Distinct Branch from University_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                                commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                commandroom.Parameters.AddWithValue("@Session", session);
                                SQLiteDataAdapter adptr2 = new SQLiteDataAdapter(commandroom);
                                adptr2.Fill(dt2);
                            }
                            else
                            {
                                SQLiteCommand commandroom = new SQLiteCommand("SELECT Distinct Class from Series_Alloted Where Date=@Date and Session=@Session", con.ActiveCon());
                                commandroom.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                commandroom.Parameters.AddWithValue("@Session", session);
                                SQLiteDataAdapter adptr2 = new SQLiteDataAdapter(commandroom);
                                adptr2.Fill(dt2);
                            }
                            con.CloseCon();

                            //dt.Columns.Add("Branch", typeof(string));
                            //foreach (DataRow getreg in dt.Rows)
                            //{
                            //    foreach (DataRow getdr in dt2.Rows)
                            //    {
                            //        if (getreg["Reg_no"].ToString() == getdr["Reg_no"].ToString())
                            //        {
                            //            getreg["Branch"] = getdr["Branch"].ToString();

                            //            break;
                            //        }
                            //    }
                            //}

                            //// datatable with distinct branch from 'dt'
                            //DataTable distinctBranch = dt.DefaultView.ToTable(true, "Branch");
                            //MessageBox.Show("--Tester-- \n Check whether distinct code works in dgv");
                            //AllotedStudentsRooms_dgv.DataSource = distinctBranch; ////only for testing delete after that
                            //MessageBox.Show("--Tester-- \n Check whether distinct code works in dgv");
                            //Excel Designing
                            if (dt.Rows.Count != 0)
                            {
                                using (var package = new ExcelPackage())
                                {
                                    foreach (DataRow dstrw in dt2.Rows)
                                    {
                                        string checkbranch;
                                        if (allotment.Unv_radio.Checked)
                                            checkbranch = dstrw["Branch"].ToString();
                                        else
                                            checkbranch = dstrw["Class"].ToString();

                                        //Add a new worksheet to the empty workbook
                                        var worksheet = package.Workbook.Worksheets.Add(checkbranch);
                                        //Insert Items to ExcelSheet
                                        worksheet.Cells["A1"].Value = "KMEA ENGINEERING COLLEGE";
                                        worksheet.Cells["A2"].Value = examtype_textbox.Text;
                                        worksheet.Cells["A3"].Value = dr["Date"].ToString() + " " + session;
                                        worksheet.Cells["A4"].Value = checkbranch;
                                        worksheet.Cells["A5"].Value = "Register No - Room No - Seat No";
                                        using (var range = worksheet.Cells["A5"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 14;
                                            range.Style.Font.Bold = true;
                                        }
                                        using (var range = worksheet.Cells["A1:D1"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 16;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A2:D2"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 14;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A3:D3"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 14;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }
                                        using (var range = worksheet.Cells["A4:D4"])
                                        {
                                            range.Style.Font.Name = "Arial";
                                            range.Style.Font.Size = 14;
                                            range.Style.Font.Bold = true;
                                            range.Merge = true;
                                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        }

                                        if (allotment.Unv_radio.Checked)
                                        {
                                            SQLiteCommand coursecommand = new SQLiteCommand("Select Course from University_Alloted where Branch=@Branch and Date=@Date and Session=@Session ", con.ActiveCon());
                                            coursecommand.Parameters.AddWithValue("@Branch", checkbranch);
                                            coursecommand.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                            coursecommand.Parameters.AddWithValue("@Session", session);
                                            string Course = (string)coursecommand.ExecuteScalar();
                                            worksheet.Cells["A6"].Value = Course;
                                            using (var range = worksheet.Cells["A6"])
                                            {
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                            }
                                            SQLiteCommand coursecmd = new SQLiteCommand("SELECT Reg_no,Room_No,Seat from University_Alloted Where Date=@Date and Session=@Session and Course=@Course order by Reg_no", con.ActiveCon());
                                            coursecmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                            coursecmd.Parameters.AddWithValue("@Session", session);
                                            coursecmd.Parameters.AddWithValue("@Course", Course);
                                            DataTable coursedt = new DataTable();
                                            SQLiteDataAdapter courseadptr = new SQLiteDataAdapter(coursecmd);
                                            courseadptr.Fill(coursedt);
                                            con.CloseCon();
                                            int j = 1, k = 7;
                                            for (var i = 0; i < coursedt.Rows.Count; i++)
                                            {
                                                if (j == 4)
                                                {
                                                    k++;
                                                    j = 1;
                                                }
                                                worksheet.Cells[k, j].Value = coursedt.Rows[i][0] + " - " + coursedt.Rows[i][1] + " - " + coursedt.Rows[i][2];
                                                j++;
                                            }
                                            using (var range = worksheet.Cells[7, 1, k, 3])
                                            {
                                                range.Style.Font.Name = "Arial";
                                                range.Style.Font.Size = 14;
                                                range.Style.Font.Bold = true;
                                            }
                                        }
                                        else
                                        {
                                            SQLiteCommand coursecommand = new SQLiteCommand("Select Distinct Course from Series_Alloted where Class=@Class and Date=@Date and Session=@Session ", con.ActiveCon());
                                            coursecommand.Parameters.AddWithValue("@Class", checkbranch);
                                            coursecommand.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                            coursecommand.Parameters.AddWithValue("@Session", session);
                                            DataTable coursedata = new DataTable();
                                            SQLiteDataAdapter coursedataadptr = new SQLiteDataAdapter(coursecommand);
                                            coursedataadptr.Fill(coursedata);
                                            con.CloseCon();
                                            int c = 6;
                                            foreach (DataRow dataRow in coursedata.Rows)
                                            {
                                                worksheet.Cells[c, 1].Value = dataRow["Course"].ToString();
                                                using (var range = worksheet.Cells[c, 1])
                                                {
                                                    range.Style.Font.Name = "Arial";
                                                    range.Style.Font.Size = 14;
                                                    range.Style.Font.Bold = true;
                                                }
                                                c++;
                                                SQLiteCommand coursecmd = new SQLiteCommand("SELECT Reg_no,Room_No,Seat from Series_Alloted Where Date=@Date and Session=@Session and Course=@Course order by Reg_no", con.ActiveCon());
                                                coursecmd.Parameters.AddWithValue("@Date", dr["Date"].ToString());
                                                coursecmd.Parameters.AddWithValue("@Session", session);
                                                coursecommand.Parameters.AddWithValue("@Course", dataRow["Course"].ToString());
                                                DataTable coursedt = new DataTable();
                                                SQLiteDataAdapter courseadptr = new SQLiteDataAdapter(coursecmd);
                                                courseadptr.Fill(coursedt);
                                                con.CloseCon();
                                                int j = 1;
                                                for (var i = 0; i < coursedt.Rows.Count; i++)
                                                {
                                                    if (j == 4)
                                                    {
                                                        c++;
                                                        j = 1;
                                                    }
                                                    worksheet.Cells[c, j].Value = coursedt.Rows[i][0] + " - " + coursedt.Rows[i][1] + " - " + coursedt.Rows[i][2];
                                                    j++;
                                                }
                                                using (var range = worksheet.Cells[7, 1, c, 3])
                                                {
                                                    range.Style.Font.Name = "Arial";
                                                    range.Style.Font.Size = 14;
                                                    range.Style.Font.Bold = true;
                                                }
                                                c++;
                                            }
                                        }
                                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                                    }
                                    //Save Excel File
                                    /* below might get error since Date has '\' in between ... CHECK if we have to use array 
                                    or something else to remove the '\' .   */
                                    string path = createDisplayPath + @"\Display Sheet " + dr["Date"].ToString() + " " + session + ".xlsx";
                                    Stream stream = File.Create(path);
                                    package.SaveAs(stream);
                                    stream.Close();

                                    session = "Afternoon";
                                }
                            }
                        }
                    }
                    msgbox.show("Excel files created    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
