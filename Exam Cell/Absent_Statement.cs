using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Exam_Cell
{
    public partial class Absent_Statement : Form
    {
        Connection con = new Connection();
        Excel.Application xlApp = new Excel.Application();
        public Absent_Statement()
        {
            InitializeComponent();
        }

        private void Absent_Statement_Load(object sender, EventArgs e)
        {
            Session_combobox.SelectedIndex = 0;
            DateComboboxFill();
            BranchComboboxFill();
            Exam_CodeComboboxFill();
            SubjectComboboxFill();
            No_of_candidates_ViewText.Clear();
            No_of_Present_ViewText.Clear();
            No_of_Absent_ViewText.Clear();            
        }

        void DateComboboxFill()
        {
            SqlCommand comm = new SqlCommand("select distinct Date from Absentees order by Date", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            //for -select-
            DataRow top = table.NewRow();
            top[0] = "-Select-";
            table.Rows.InsertAt(top, 0);

            Date_combobox.DisplayMember = "Date";
            Date_combobox.ValueMember = "Date";
            Date_combobox.DataSource = table;
        }
        void BranchComboboxFill()
        {
            SqlCommand comm = new SqlCommand("select distinct Branch from Absentees order by Branch", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            //for -select-
            DataRow top = table.NewRow();
            top[0] = "-Select-";
            table.Rows.InsertAt(top, 0);

            Branch_combobox.DisplayMember = "Branch";
            Branch_combobox.ValueMember = "Branch";
            Branch_combobox.DataSource = table;
        }
        void Exam_CodeComboboxFill()
        {
            SqlCommand comm = new SqlCommand("select distinct Exam_Code from Absentees order by Exam_Code", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            //for -select-
            DataRow top = table.NewRow();
            top[0] = "-Select-";
            table.Rows.InsertAt(top, 0);

            ExamCode_combobox.DisplayMember = "Exam_Code";
            ExamCode_combobox.ValueMember = "Exam_Code";
            ExamCode_combobox.DataSource = table;
        }
        void SubjectComboboxFill()
        {
            SqlCommand comm = new SqlCommand("select distinct Course from Absentees order by Course", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            //for -select-
            DataRow top = table.NewRow();
            top[0] = "-Select-";
            table.Rows.InsertAt(top, 0);

            SubjectName_Combobox.DisplayMember = "Course";
            SubjectName_Combobox.ValueMember = "Course";
            SubjectName_Combobox.DataSource = table;
        }

        DataTable table = new DataTable();
        private void Search_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select Reg_no,Name,Status,Branch,Course,Exam_Code from Absentees Where Date=@Date and Session=@Session and Branch=@Branch,Exam_Code=@Exam_Code,Course=@Course order by Reg_no", con.ActiveCon());
            command.Parameters.AddWithValue("@Date", Date_combobox.Text);
            command.Parameters.AddWithValue("@Session", Session_combobox.Text);
            command.Parameters.AddWithValue("@Branch", Branch_combobox.Text);
            command.Parameters.AddWithValue("@Exam_Code", ExamCode_combobox.Text);
            command.Parameters.AddWithValue("@Course", SubjectName_Combobox.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);            
            adapter.Fill(table);
            Dgv.DataSource = null;
            Dgv.DataSource = table;

            NoofcandidatesFill();            
        }

        private void Prepare_Statement_btn_Click(object sender, EventArgs e)
        {
            if(Filepath_textbox.Text != "")
            {
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ////for getting semester
                    //DataTable sem = new DataTable();
                    //foreach(DataRow row in dt.Rows)
                    //{
                    //    SqlCommand command2 = new SqlCommand("select Semester from Registered_candidates where Exam_Code=@Exam_Code", con.ActiveCon());
                    //    command2.Parameters.AddWithValue("@Exam_Code", row["Exam_Code"].ToString());
                    //    string semester = (string)command2.ExecuteScalar();
                    //}

                    if (table.Rows.Count != 0)
                    {
                        Excel.Range excelCellrange;
                        Excel.Workbook xlWorkBook;
                        Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;
                        //for excel alerts
                        xlApp.Visible = false;
                        xlApp.DisplayAlerts = false;
                        //Create New Workbook
                        xlWorkBook = xlApp.Workbooks.Add(misValue);
                        //Create new Worksheet
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(Branch_combobox.Text);
                        SqlCommand command2 = new SqlCommand("select Semester from Students where Reg_no=@Reg_no", con.ActiveCon());
                        command2.Parameters.AddWithValue("@Reg_no", table.Rows[0]["Reg_no"].ToString());
                        string semester = (string)command2.ExecuteScalar();
                        //Insert Items to ExcelSheet
                        xlWorkSheet.get_Range("A1").Value2 = "KMEA ENGINEERING COLLEGE";
                        xlWorkSheet.get_Range("A2").Value2 = Examination_Textbox.Text;
                        xlWorkSheet.get_Range("A3").Value2 = "ATTENDANCE STATEMENT";
                        xlWorkSheet.get_Range("A4").Value2 = Date_combobox.Text;
                        xlWorkSheet.get_Range("D4").Value2 = Session_combobox.Text;
                        xlWorkSheet.get_Range("A5").Value2 = "Branch: "+Branch_combobox.Text;
                        xlWorkSheet.get_Range("C5").Value2 = "Semester: "+semester;
                        xlWorkSheet.get_Range("D5").Value2 = "Subject: "+SubjectName_Combobox.Text+" "+ExamCode_combobox.Text;

                        excelCellrange = xlWorkSheet.get_Range("A1", "D1");
                        excelCellrange.Merge();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        excelCellrange.Cells.Font.Name = "Arial";
                        excelCellrange.Cells.Font.Size = "16";
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange = xlWorkSheet.get_Range("A2", "D2");
                        excelCellrange.Merge();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        excelCellrange.Cells.Font.Name = "Arial";
                        excelCellrange.Cells.Font.Size = "14";
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange = xlWorkSheet.get_Range("A3", "D3");
                        excelCellrange.Merge();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        excelCellrange.Cells.Font.Name = "Arial";
                        excelCellrange.Cells.Font.Size = "12";
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange = xlWorkSheet.get_Range("A4", "D4");
                        excelCellrange.Cells.AutoFit();
                        excelCellrange.Cells.Font.Name = "Arial";
                        excelCellrange.Cells.Font.Size = "12";
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange = xlWorkSheet.get_Range("A5", "D5");
                        excelCellrange.Cells.Font.Name = "Arial";
                        excelCellrange.Cells.Font.Size = "12";
                        excelCellrange.Cells.Font.Bold = true;
                        xlWorkSheet.get_Range("D5").AutoFit();
                        
                        // column headings
                        xlWorkSheet.Cells[6, 1] = "Sl.No";
                        xlWorkSheet.Cells[6, 1].Font.Name = "Arial";
                        xlWorkSheet.Cells[6, 1].Font.Size = "12";
                        xlWorkSheet.Cells[6, 1].Font.Bold = true;
                        for (var i = 0; i < 3; i++)
                        {
                            xlWorkSheet.Cells[6, i + 2] = table.Columns[i].ColumnName;
                            xlWorkSheet.Cells[6, i + 2].Font.Name = "Arial";
                            xlWorkSheet.Cells[6, i + 2].Font.Size = "12";
                            xlWorkSheet.Cells[6, i + 2].Font.Bold = true;
                        }
                        //rows filling
                        int count=0;
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            xlWorkSheet.Cells[i + 7, 1] = i + 1;    //Sl.No Filling
                            for (var j = 0; j < 3; j++)
                            {
                                xlWorkSheet.Cells[i + 7, j + 2] = table.Rows[i][j];
                                if (table.Rows[i][j].ToString() == "Absent")
                                    xlWorkSheet.Cells[i + 7, j + 2].Interior.Color = Color.Yellow;
                            }
                            count = i + 9;
                        }
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[7, 1], xlWorkSheet.Cells[table.Rows.Count + 6, 4]];
                        Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                        border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        border.Weight = 2d;
                        xlWorkSheet.Cells[count, 3] = "No of Present = "+ No_of_Present_ViewText.Text;
                        xlWorkSheet.Cells[count+1, 3] = "No of Absent = "+ No_of_Absent_ViewText.Text;

                        //Save Excel File                        
                        string save;
                        save = Filepath_textbox.Text + @"\Attendance Statement " + Date_combobox.Text + " " + Session_combobox.Text + ".xls";
                        xlWorkBook.SaveAs(save, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(0, misValue, misValue);
                        xlApp.Quit();                        
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelCellrange);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                        Branch_combobox.SelectedIndex = 0;
                        ExamCode_combobox.SelectedIndex = 0;
                        SubjectName_Combobox.SelectedIndex = 0;
                        No_of_candidates_ViewText.Clear();
                        No_of_Present_ViewText.Clear();
                        No_of_Absent_ViewText.Clear();
                        MessageBox.Show("Excel file created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(save);                        
                    }
                    else
                    {
                        MessageBox.Show("Search Students First", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Filepath is not given", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Filepath_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fp = new FolderBrowserDialog();
            if(fp.ShowDialog() == DialogResult.OK)
            {
                Filepath_textbox.Text = fp.SelectedPath;
            }
        }

        void NoofcandidatesFill()
        {
            int prescount = 0, abscount = 0;
            foreach(DataRow dr in table.Rows)
            {
                if (dr["Status"].ToString() == "Present")
                    prescount++;
                else if (dr["Status"].ToString() == "Absent")
                    abscount++;
            }
            No_of_candidates_ViewText.Text = table.Rows.Count.ToString();
            No_of_Present_ViewText.Text = prescount.ToString();
            No_of_Absent_ViewText.Text = abscount.ToString();
        }
        
    }
}
