﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam_Cell.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Exam_Cell
{
    public partial class Absent_Statement : Form
    {
        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();
        public Absent_Statement()
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

        private void Absent_Statement_Load(object sender, EventArgs e)
        {
            Session_combobox.SelectedIndex = 0;
            DateComboboxFill();
            BranchComboboxFill();
            Exam_CodeComboboxFill();
            //SubjectComboboxFill();
            No_of_candidates_ViewText.Clear();
            No_of_Present_ViewText.Clear();
            No_of_Absent_ViewText.Clear();
            GetFileSavepath();
        }
        void GetFileSavepath()
        {
            SQLiteCommand comm = new SQLiteCommand("select Savepath from Management where Savepath is not null", con.ActiveCon());
            string savepath = (string)comm.ExecuteScalar();
            con.CloseCon();
            Filepath_textbox.Text = savepath;
        }
        void DateComboboxFill()
        {            
            try
            {
            SQLiteCommand comm = new SQLiteCommand("select distinct Date from Absentees order by Date", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }
        void BranchComboboxFill()
        {
            try
            {
            SQLiteCommand comm = new SQLiteCommand("select distinct Branch from Absentees order by Branch", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }
        void Exam_CodeComboboxFill()
        {
            try
            {
            SQLiteCommand comm = new SQLiteCommand("select distinct Exam_Code from Absentees order by Exam_Code", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.CloseCon();
            }
        }
        //void SubjectComboboxFill()
        //{
        //    SQLiteCommand comm = new SQLiteCommand("select distinct Course from Absentees order by Course", con.ActiveCon());
        //    SQLiteDataAdapter adapter = new SQLiteDataAdapter(comm);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    //for -select-
        //    DataRow top = table.NewRow();
        //    top[0] = "-Select-";
        //    table.Rows.InsertAt(top, 0);

        //    SubjectName_Combobox.DisplayMember = "Course";
        //    SubjectName_Combobox.ValueMember = "Course";
        //    SubjectName_Combobox.DataSource = table;
        //}

        DataTable table = new DataTable();
        BindingSource binding = new BindingSource();
        private void Search_btn_Click(object sender, EventArgs e)
        {
            try
            {
            SQLiteCommand command = new SQLiteCommand("select Reg_no,Name,Status,Branch,Course,Exam_Code from Absentees Where Date=@Date and Session=@Session and Branch=@Branch and Exam_Code=@Exam_Code order by Reg_no", con.ActiveCon());
            command.Parameters.AddWithValue("@Date", Date_combobox.Text);
            command.Parameters.AddWithValue("@Session", Session_combobox.Text);
            command.Parameters.AddWithValue("@Branch", Branch_combobox.Text);
            command.Parameters.AddWithValue("@Exam_Code", ExamCode_combobox.Text);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            table.Clear();
            adapter.Fill(table);
            binding.DataSource = null;
            binding.DataSource = table;
            Dgv.DataSource = binding;            
            NoofcandidatesFill();
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

        private void Prepare_Statement_btn_Click(object sender, EventArgs e)
        {
            if(Filepath_textbox.Text != "PLEASE_ADD_PATH")
            {

                if (table.Rows.Count != 0)
                {
                    try
                    {
                        string createStatePath = Filepath_textbox.Text + @"\Attendance Sheets";
                        Directory.CreateDirectory(createStatePath);

                        using (var package = new ExcelPackage())
                        {
                        //Add a new worksheet to the empty workbook
                        var worksheet = package.Workbook.Worksheets.Add(Branch_combobox.Text);
                        SQLiteCommand command2 = new SQLiteCommand("select Year_Of_Admission from Students where Reg_no=@Reg_no", con.ActiveCon());
                        command2.Parameters.AddWithValue("@Reg_no", table.Rows[0]["Reg_no"].ToString());
                        string semester = (string)command2.ExecuteScalar();
                        //Insert Items to ExcelSheet
                        worksheet.Cells["A1"].Value = "KMEA ENGINEERING COLLEGE";
                        worksheet.Cells["A2"].Value = Examination_Textbox.Text;
                        worksheet.Cells["A3"].Value = "ATTENDANCE STATEMENT";
                        worksheet.Cells["A4"].Value = Date_combobox.Text;
                        worksheet.Cells["D4"].Value = Session_combobox.Text;
                        worksheet.Cells["A5"].Value = Branch_combobox.Text;
                        worksheet.Cells["C5"].Value = "Year: " + semester;
                        worksheet.Cells["D5"].Value = Dgv.Rows[0].Cells["Course"].Value.ToString() + " " + ExamCode_combobox.Text;

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
                            range.Style.Font.Size = 12;
                            range.Style.Font.Bold = true;
                        }                        
                        using (var range = worksheet.Cells["A4:D4"])
                        {
                            range.Style.Font.Name = "Arial";
                            range.Style.Font.Size = 11;
                            range.Style.Font.Bold = true;
                        }
                        using (var range = worksheet.Cells["A5:D5"])
                        {
                            range.Style.Font.Name = "Arial";
                            range.Style.Font.Size = 11;
                            range.Style.Font.Bold = true;
                        }

                        // column headings
                        worksheet.Cells[6, 1].Value = "Sl.No";
                        worksheet.Cells[6, 1].Style.Font.Name = "Arial";
                        worksheet.Cells[6, 1].Style.Font.Size = 12;
                        worksheet.Cells[6, 1].Style.Font.Bold = true;
                        for (var i = 0; i < 3; i++)
                        {
                            worksheet.Cells[6, i + 2].Value = table.Columns[i].ColumnName;
                            worksheet.Cells[6, i + 2].Style.Font.Name = "Arial";
                            worksheet.Cells[6, i + 2].Style.Font.Size = 12;
                            worksheet.Cells[6, i + 2].Style.Font.Bold = true;
                        }
                        //rows filling
                        int count = 0;
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            worksheet.Cells[i + 7, 1].Value = i + 1;    //Sl.No Filling
                            for (var j = 0; j < 3; j++)
                            {
                                worksheet.Cells[i + 7, j + 2].Value = table.Rows[i][j];
                                if (table.Rows[i][j].ToString() == "Absent")
                                {
                                    worksheet.Cells[i+7,j+2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    worksheet.Cells[i + 7, j + 2].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                                    worksheet.Cells[i + 7, j + 2].Style.Font.Color.SetColor(Color.Red);
                                }
                            }
                            count = i + 9;
                        }
                        using (var range = worksheet.Cells[7, 1 , table.Rows.Count + 6, 4])
                        {
                            range.AutoFitColumns();
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        }
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                        worksheet.Cells[count, 3].Value = "No of Present = " + No_of_Present_ViewText.Text;
                        worksheet.Cells[count + 1, 3].Value = "No of Absent = " + No_of_Absent_ViewText.Text;



                        //Save Excel File  
                        string path = createStatePath + @"\AttndncStatmnt " + Session_combobox.Text +" "+ ExamCode_combobox.Text + " " + Branch_combobox.Text + ".xlsx"; 
                        Stream stream = File.Create(path);
                        package.SaveAs(stream);
                        stream.Close();                       
                       
                        Branch_combobox.SelectedIndex = 0;
                        ExamCode_combobox.SelectedIndex = 0;
                        //SubjectName_Combobox.SelectedIndex = 0;
                        No_of_candidates_ViewText.Clear();
                        No_of_Present_ViewText.Clear();
                        No_of_Absent_ViewText.Clear();
                        table.Clear();
                        Dgv.DataSource = null;
                        msgbox.show("Excel file created     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                    }
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
                else
                {
                    msgbox.show("Search Students First     ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                }

            }
            else
                msgbox.show("Filepath is not given   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
        }

        private void Filepath_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fp = new FolderBrowserDialog();
            if(fp.ShowDialog() == DialogResult.OK)
            {
                SQLiteCommand comm = new SQLiteCommand("update Management set Savepath=@savepath where Savepath is not null", con.ActiveCon());
                comm.Parameters.AddWithValue("@savepath", fp.SelectedPath.ToString());
                comm.ExecuteNonQuery();
                con.CloseCon();
                Filepath_textbox.Text = fp.SelectedPath;
            }
        }

        void NoofcandidatesFill()
        {
            int prescount = 0, abscount = 0;
            for(int i=0;i<table.Rows.Count;i++)
            {
                if(Dgv.Rows[i].Cells["Status"].Value.ToString() == "Absent")
                {
                    abscount++;
                    Dgv.Rows[i].Cells["Status"].Style.ForeColor = Color.Red;
                }
                else
                {
                    prescount++;
                }
            }
            //foreach(DataGridViewRow dr in Dgv.Rows)
            //{
            //    if (dr.Cells["Status"].ToString() == "Present")
            //    {
            //        prescount++;
            //        dr.Cells["Status"].Style.ForeColor = Color.Black;
            //    }
            //    else if (dr.Cells["Status"].ToString() == "Absent")
            //    {
            //        abscount++;
            //        dr.Cells["Status"].Style.ForeColor = Color.Red;
            //    }
            //}
            No_of_candidates_ViewText.Text = table.Rows.Count.ToString();
            No_of_Present_ViewText.Text = prescount.ToString();
            No_of_Absent_ViewText.Text = abscount.ToString();
        }
    }
}
