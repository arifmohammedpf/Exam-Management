using Exam_Cell.Forms;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Exam_Cell
{
    public partial class Student_Management : Form
    {
        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();

        public Student_Management()
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

        CheckBox headerchkbox = new CheckBox();
        private void Student_Management_Load(object sender, EventArgs e)
        {
            progressPanel.Show();
            //studentdgv
            DataGridViewCheckBoxColumn checkbox2 = new DataGridViewCheckBoxColumn();
            checkbox2.HeaderText = "";
            checkbox2.Width = 30;
            checkbox2.Name = "CheckboxColumn2";
            Student_dgv.Columns.Insert(0, checkbox2);

            //AddHeaderchckbox(); //header checkbox added to student dgv
            //headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);           
        }

        //function definition
        //void AddHeaderchckbox()
        //{
        //    //Locate Header Cell to place checkbox in correct position
        //    Point HeaderCellLocation = this.Student_dgv.GetCellDisplayRectangle(0, -1, true).Location;
        //    //place headercheckbox to the location
        //    headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 13);
        //    headerchkbox.BackColor = Color.RoyalBlue;
        //    headerchkbox.Size = new Size(18, 18);
        //    //add checkbox into dgv
        //    Student_dgv.Controls.Add(headerchkbox);
        //}

        //object send; 
        //private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        //{
        //    send = sender;
        //    progressPanel.Show();
        //    timerHeaderCheck.Start();
        //}
        //private void timerHeaderCheck_Tick(object sender, EventArgs e)
        //{
        //    timerHeaderCheck.Stop();
        //    Headerchckboxclick((CheckBox)send);
        //    progressPanel.Hide();
        //}
        ////headerchckbox click event
        //private void Headerchckboxclick(CheckBox Hcheckbox)
        //{
        //    foreach (DataGridViewRow row in Student_dgv.Rows)
        //        ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn2"]).Value = Hcheckbox.Checked;

        //    Student_dgv.RefreshEdit();
        //}

        void AssignClass_fill()
        {
            try
            {
                SQLiteCommand sc = new SQLiteCommand("Select Class,Semester from Management where (Class is not null) and (Semester is not null)", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Combo", typeof(string)); // in datatable, a column should be created before adding rows
                DataRow top = dt2.NewRow();
                top[0] = "-Select-";
                dt2.Rows.InsertAt(top, 0);
                foreach (DataRow dr in dt.Rows)
                    dt2.Rows.Add(dr["Class"].ToString() + "  S" + dr["Semester"].ToString());
                AssignClass_combobox.ValueMember = "Combo";  //column name is given to get values to show in combobox
                AssignClass_combobox.DataSource = dt2;
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

        void Class_Assign_students(DataGridViewRow dr)
        {
            SQLiteCommand command = new SQLiteCommand("insert into Class(Reg_No,Name,Class,Branch)Values(" + "@Reg_No,@Name,@Class,@Branch )", con.ActiveCon());
            command.Parameters.AddWithValue("@Reg_No", dr.Cells["Reg_no"].Value.ToString());
            command.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value.ToString());
            command.Parameters.AddWithValue("@Class", AssignClass_combobox.Text);
            command.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value.ToString());
            command.ExecuteNonQuery();
        }
        private void AssignClass_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AssignClass_combobox.SelectedIndex != 0)
                {
                    if (SelectAllCheckbox.Checked)
                    {
                        foreach (DataGridViewRow dr in Student_dgv.Rows)
                        {
                            Class_Assign_students(dr);
                        }
                        con.CloseCon();
                        AssignClass_combobox.SelectedIndex = 0;
                        Student_dgvFill();
                        SelectAllCheckbox.Checked = false;
                        msgbox.show("Students Added to Class    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                    }
                    else
                    {
                        int f = 0;
                        foreach (DataGridViewRow dr in Student_dgv.Rows)
                        {
                            bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn2"].Value);
                            if (checkselected)
                            {
                                f = 1;
                                Class_Assign_students(dr);
                            }
                        }
                        if (f == 1)
                        {
                            con.CloseCon();
                            AssignClass_combobox.SelectedIndex = 0;
                            Student_dgvFill();
                            msgbox.show("Selected Students Added to Class    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                        }
                        else
                            msgbox.show("Select Any Students    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    }
                }
                else
                    msgbox.show("Select Class   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                con.CloseCon();
                MessageBox.Show(ex.ToString());
            }
        }
        void ClearAllStudent_Management()
        {
            SelectAllCheckbox.Checked = false;
            AddFromExcel_Btn.Enabled = false;

            if (ClassDgvView_checkbox.Checked)
            {
                AssignClass_combobox.SelectedIndex = 0;
            }
            else
            {
                Regno_textbox.Clear();
                Name_textbox.Clear();
                YOA_textbox.Clear();
                Branch_combobox.SelectedIndex = 0;
                AssignClassYOA_combobox.SelectedIndex = 0;
                AssignClassBranch_combobox.SelectedIndex = 0;
                Filepath_textbox.Clear();
                Sheet_combobox.Items.Clear();
                FilterStudentRecord();
            }
        }
        private void AddStudent_btn_Click(object sender, EventArgs e)
        {
            if (Branch_combobox.SelectedIndex != 0 && Regno_textbox.Text != "" && Name_textbox.Text != "" && YOA_textbox.Text != "")
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand("insert into Students(Reg_no,Name,Year_Of_Admission,Branch)Values(" + "@Reg_no,@Name,@Year_Of_Admission,@Branch)", con.ActiveCon());
                    command.Parameters.AddWithValue("@Reg_no", Regno_textbox.Text);
                    command.Parameters.AddWithValue("@Name", Name_textbox.Text);
                    command.Parameters.AddWithValue("@Year_Of_Admission", YOA_textbox.Text);
                    command.Parameters.AddWithValue("@Branch", Branch_combobox.Text);
                    command.ExecuteNonQuery();
                    YearOfAdmissionFill();
                    ClearAllStudent_Management();
                    Student_dgvFill();
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
                msgbox.show("Fill Necessary Details.    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
        }

        private void ClassDgvView_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            progressPanel.Show();
            timerFlag = "ClassViewCheckboxClick";
            timerTool.Start();
        }

        void ClassviewCheckBoxFunction()
        {
            SelectAllCheckbox.Checked = false;

            if (ClassDgvView_checkbox.Checked)
            {
                Class_StudentsFill();
                add_stdnt_groupbox.Enabled = false;
                ImportGroupbox.Enabled = false;
                AssignClassYOA_combobox.Enabled = false;
                AssignClassBranch_combobox.Enabled = false;
                AssignClass_btn.Enabled = false;
                AssignClass_combobox.SelectedIndex = 0;
            }
            else
            {
                Student_dgvFill();
                add_stdnt_groupbox.Enabled = true;
                ImportGroupbox.Enabled = true;
                AssignClassYOA_combobox.Enabled = true;
                AssignClassBranch_combobox.Enabled = true;
                AssignClass_btn.Enabled = true;
                AssignClass_combobox.SelectedIndex = 0;
            }
        }
        BindingSource Student_Source = new BindingSource();
        BindingSource ClassView_Source = new BindingSource();
        void Student_dgvFill()
        {
            try
            {
                headerchkbox.Checked = false;
                SQLiteCommand command = new SQLiteCommand("select * from Students order by Year_Of_Admission desc,Branch", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable table_Students = new DataTable();
                adapter.Fill(table_Students);
                Student_Source.DataSource = null;
                Student_Source.DataSource = table_Students;
                Student_dgv.DataSource = Student_Source;
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
        void Class_StudentsFill()
        {
            try
            {
                headerchkbox.Checked = false;
                SQLiteCommand command = new SQLiteCommand("select * from Class order by Class desc", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable table_Students = new DataTable();
                adapter.Fill(table_Students);
                ClassView_Source.DataSource = null;
                ClassView_Source.DataSource = table_Students;
                Student_dgv.DataSource = ClassView_Source;
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

        void Delete_Class_Students(DataGridViewRow dr)
        {
            SQLiteCommand command = new SQLiteCommand("Delete from Class Where Class=@Class and Name=@Name and Reg_No=@Reg_No", con.ActiveCon());
            command.Parameters.AddWithValue("@Class", dr.Cells["Class"].Value);
            command.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value);
            command.Parameters.AddWithValue("@Reg_No", dr.Cells["Reg_No"].Value);
            command.ExecuteNonQuery();
        }
        void Delete_Student_record(DataGridViewRow dr)
        {
            SQLiteCommand command = new SQLiteCommand("delete from Students where Reg_no=@Reg_no and Name=@Name and Year_Of_Admission=@Year_Of_Admission and Branch=@Branch", con.ActiveCon());
            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value.ToString());
            command.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value.ToString());
            command.Parameters.AddWithValue("@Year_Of_Admission", dr.Cells["Year_Of_Admission"].Value.ToString());
            command.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value.ToString());
            command.ExecuteNonQuery();
            //will also delete from Class
            SQLiteCommand command2 = new SQLiteCommand("Delete Class where Reg_No=@Reg_no", con.ActiveCon());
            command2.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
            command2.ExecuteNonQuery();
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Do you really want to Delete ?     ", "Confirm Deletion", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
            {
                try
                {
                    if (AddFromExcel_Btn.Enabled == false)
                    {
                        if (ClassDgvView_checkbox.Checked)
                        {
                            if (SelectAllCheckbox.Checked)
                            {
                                foreach (DataGridViewRow dr in Student_dgv.Rows)
                                {
                                    Delete_Class_Students(dr);
                                }
                                con.CloseCon();
                                ClearAllStudent_Management();
                                Class_StudentsFill();
                                SelectAllCheckbox.Checked = false;
                                msgbox.show("All Students deleted.   ", "Delete Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                            {
                                int f = 0;
                                foreach (DataGridViewRow dr in Student_dgv.Rows)
                                {
                                    bool Selected = Convert.ToBoolean(dr.Cells["CheckboxColumn2"].Value);
                                    if (Selected)
                                    {
                                        f = 1;
                                        Delete_Class_Students(dr);
                                    }
                                }
                                if (f == 1)
                                {
                                    con.CloseCon();
                                    ClearAllStudent_Management();
                                    Class_StudentsFill();
                                    msgbox.show("Selected Students deleted.   ", "Delete Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                                }
                                else
                                {
                                    msgbox.show("Select any Students to delete.     ", "Delete Failed", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            if (SelectAllCheckbox.Checked)
                            {
                                foreach (DataGridViewRow dr in Student_dgv.Rows)
                                {
                                    Delete_Student_record(dr);
                                }
                                con.CloseCon();
                                Student_dgvFill();
                                SelectAllCheckbox.Checked = false;
                                msgbox.show("All students deleted.   ", "Delete Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                            {
                                int f = 0;
                                foreach (DataGridViewRow dr in Student_dgv.Rows)
                                {
                                    bool Selected = Convert.ToBoolean(dr.Cells["CheckboxColumn2"].Value);
                                    if (Selected)
                                    {
                                        f = 1;
                                        Delete_Student_record(dr);
                                    }
                                }
                                if (f == 1)
                                {
                                    con.CloseCon();
                                    Student_dgvFill();
                                    msgbox.show("Selected Students deleted.   ", "Delete Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                                }
                                else
                                    msgbox.show("Select any Students to delete.     ", "Delete Failed", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                        msgbox.show("You Cannot delete an Excel data.   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    con.CloseCon();
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            FilterStudentRecord();
        }
        void FilterStudentRecord()
        {
            string regno = Regno_textbox.Text;
            string name = Name_textbox.Text;
            string branchvalue = Branch_combobox.Text;
            string yoa = YOA_textbox.Text;

            string filter = "";        //filter string for sql statements to be written
            if (regno != "")
                filter = string.Format("Reg_no like '%{0}%'", regno);
            if (name != "")
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Name Like '%{0}%'", name);
            }
            if (branchvalue != "-Select-")
            {
                if (filter.Length > 0) filter += " AND ";                    //Put AND if there is existing Sql statement in filter string
                filter += string.Format("Branch Like '%{0}%'", branchvalue);     //Put sql statement in filter string
            }
            if (yoa != "")
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Year_Of_Admission Like '%{0}%'", yoa);
            }
            Student_Source.Filter = filter;
        }
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            progressPanel.Show();
            timerFlag = "ClearBtnClick";
            timerTool.Start();
        }

        private void UpgradeSem_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("You Are Going To UPGRADE Every Class Semester.     \n Are You Sure?   ", "Warning", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
            {
                try
                {
                    SQLiteCommand sc = new SQLiteCommand("Select Class,Semester from Management where (Class is not null) and (Semester is not null)", con.ActiveCon());
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        string checksem = dr["Class"].ToString() + "  S" + dr["Semester"].ToString();
                        string sem = dr["Semester"].ToString(), newclass;
                        bool res = int.TryParse(sem, out int newsem);
                        newsem++;
                        newclass = dr["Class"].ToString() + "  S" + newsem;
                        SQLiteCommand command2 = new SQLiteCommand("update Class set Class=@Class where Class=@OldClass", con.ActiveCon());
                        command2.Parameters.AddWithValue("@OldClass", checksem);
                        command2.Parameters.AddWithValue("@Class", newclass);
                        command2.ExecuteNonQuery();
                    }
                    SQLiteCommand command3 = new SQLiteCommand("update Management set Semester= Semester + 1", con.ActiveCon());
                    command3.ExecuteNonQuery();
                    AssignClass_fill();
                    Class_StudentsFill();
                    msgbox.show("Semester Upgrade Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
        }

        private void DegradeClass_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("You Are Going To DEGRADE Every Class Semester.     \n Are You Sure?    ", "Warning", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
            {
                try
                {
                    SQLiteCommand sc = new SQLiteCommand("Select Class,Semester from Management where (Class is not null) and (Semester is not null)", con.ActiveCon());
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        string checksem = dr["Class"].ToString() + "  S" + dr["Semester"].ToString();
                        string sem = dr["Semester"].ToString(), newclass;
                        bool res = int.TryParse(sem, out int newsem);
                        newsem--;
                        newclass = dr["Class"].ToString() + "  S" + newsem;
                        SQLiteCommand command2 = new SQLiteCommand("update Class set Class=@Class where Class=@OldClass", con.ActiveCon());
                        command2.Parameters.AddWithValue("@OldClass", checksem);
                        command2.Parameters.AddWithValue("@Class", newclass);
                        command2.ExecuteNonQuery();
                    }

                    SQLiteCommand command = new SQLiteCommand("update Management set Semester= Semester - 1", con.ActiveCon());
                    command.ExecuteNonQuery();
                    AssignClass_fill();
                    Class_StudentsFill();
                    msgbox.show("Degrade Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
        }
        void StudentBranchComboboxFill()
        {
            try
            {
                SQLiteCommand sc = new SQLiteCommand("Select Branch from Management where Branch is not null", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);

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
        void ClassBranchComboboxFill()
        {
            try
            {
                SQLiteCommand sc = new SQLiteCommand("Select Branch from Management where Branch is not null", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);

                AssignClassBranch_combobox.ValueMember = "Branch";
                AssignClassBranch_combobox.DataSource = dt;
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
        void YearOfAdmissionFill()
        {
            try
            {
                SQLiteCommand sc = new SQLiteCommand("Select distinct Year_Of_Admission from Students", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);

                AssignClassYOA_combobox.ValueMember = "Year_Of_Admission";
                AssignClassYOA_combobox.DataSource = dt;
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

        private void AssignClass_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClassDgvView_checkbox.Checked)
            {
                if (AssignClass_combobox.SelectedIndex != 0)
                {
                    string classcombo = AssignClass_combobox.Text;
                    string filter = "";
                    filter = string.Format("Class like '%{0}%'", classcombo);
                    ClassView_Source.Filter = filter;
                }
                else
                    ClassView_Source.RemoveFilter();
            }
        }

        private void AssignClassBranch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignClassFilter();
        }

        private void AssignClassYOA_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignClassFilter();
        }
        void AssignClassFilter()
        {
            string filter = "";
            if (AssignClassBranch_combobox.Text != "-Select-")
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Branch Like '%{0}%'", AssignClassBranch_combobox.Text);
            }
            if (AssignClassYOA_combobox.Text != "-Select-")
            {
                bool res = int.TryParse(AssignClassYOA_combobox.Text, out int yoa);
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Convert(Year_Of_Admission,'System.String') like '%{0}%'", yoa);
            }
            Student_Source.Filter = filter;
        }
        // EXCEL GROUP BOX EVENT START
        int messflag = 0;
        DataTableCollection tableCollection;
        //Excel Select button click event
        private void SelectExcel_btn_Click(object sender, EventArgs e)
        {
            if (messflag == 0)
            {
                messflag = 1;
                msgbox.show("ExcelSheet must only contains Table data.  \n ExcelSheet Header Naming Must Be as follows :      \n Register No ,Name, YOA, Branch   ", "Warning", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Warning);
            }
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "Excel Files|*.xls|*xlsx|*.xlsm" }) //check if | is needed last?
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Filepath_textbox.Text = openFile.FileName;  //Filepath_textbox.Text --- filepath is displayed in textbox
                    using (var stream = File.Open(openFile.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            Sheet_combobox.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                Sheet_combobox.Items.Add(table.TableName); //add sheet to combobox
                        }
                    }
                }
            }
        }

        //Sheet Combobox Event
        private void Sheet_combobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = tableCollection[Sheet_combobox.SelectedItem.ToString()];
                //Candidate_datagridview.DataSource = dt;   // <-- what error this created ? why this wont work? please Check...

                // these codes was used instead of that One Line Code above
                if (dt != null)
                {
                    List<ExcelDBManagement> excst = new List<ExcelDBManagement>(); //<--here ExcelStudents is class name
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ExcelDBManagement excclass = new ExcelDBManagement();
                        excclass.Reg_no = dt.Rows[i]["Register No"].ToString();
                        excclass.Name = dt.Rows[i]["Name"].ToString();  //have to give Excel column names inside the[""]
                        excclass.Year_Of_Admission = dt.Rows[i]["YOA"].ToString();
                        excclass.Branch = dt.Rows[i]["Branch"].ToString();
                        excst.Add(excclass);
                    }
                    headerchkbox.Checked = false;
                    Student_dgv.DataSource = excst;
                    AddFromExcel_Btn.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                msgbox.show(ex.ToString(), "Exception Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
        }

        private void AddFromExcel_Btn_Click(object sender, EventArgs e)
        {
            progressPanel.Show();
            timerFlag = "AddExcelBtnClick";
            timerTool.Start();
        }

        void AddFromExcelFunction()
        {
            try
            {
                foreach (DataGridViewRow dr in Student_dgv.Rows)
                {
                    SQLiteCommand command = new SQLiteCommand("insert into Students(Reg_no,Name,Year_Of_Admission,Branch)Values(" + "@Reg_no,@Name,@Year_Of_Admission,@Branch)", con.ActiveCon());
                    command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                    command.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value);
                    command.Parameters.AddWithValue("@Year_Of_Admission", dr.Cells["Year_Of_Admission"].Value);
                    command.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                    command.ExecuteNonQuery();
                }
                con.CloseCon();
                YearOfAdmissionFill();
                ClearAllStudent_Management();
                AddFromExcel_Btn.Enabled = false;
                Student_dgvFill();
                msgbox.show("Add From Excel Completed   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                con.CloseCon();
                MessageBox.Show(ex.ToString());
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            AssignClass_fill();
            StudentBranchComboboxFill();
            ClassBranchComboboxFill();
            YearOfAdmissionFill();
            ClassDgvView_checkbox.Checked = false;
            Student_dgvFill();
            progressPanel.Hide();
        }

        string timerFlag;
        private void TimerTool_Tick(object sender, EventArgs e)
        {
            timerTool.Stop();
            if (timerFlag == "AddExcelBtnClick")
            {
                AddFromExcelFunction();
            }
            else if (timerFlag == "ClassViewCheckboxClick")
            {
                ClassviewCheckBoxFunction();
            }
            else if (timerFlag == "ClearBtnClick")
            {
                ClearAllStudent_Management();
            }
            progressPanel.Hide();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = (MenuForm)Application.OpenForms["MenuForm"];
            if (menuForm.Temp_btn == menuForm.menu_dropitem_student)
                menuForm.Temp_btn = null;
            menuForm.menu_dropitem_student.BackColor = Color.FromArgb(48, 43, 99);
            menuForm.studmgmnt_open = false;
            this.Close();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Make sure Student Name, Y.O.A, Branch is not empty.   \n Continue ?   ", "Confirm Update", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Warning);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
            {
                try
                {
                    foreach (DataGridViewRow dr in Student_dgv.Rows)
                    {
                        bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn2"].Value);
                        if (checkselected)
                        {
                            SQLiteCommand command = new SQLiteCommand("Update Students set Name=@Name,Year_Of_Admission=@Year_of_Admission,Branch=@Branch where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.Parameters.AddWithValue("@Name", Name_textbox.Text);
                            command.Parameters.AddWithValue("@Year_Of_Admission", YOA_textbox.Text);
                            command.Parameters.AddWithValue("@Branch", Branch_combobox.Text);
                            command.ExecuteNonQuery();
                            break;
                        }
                    }
                    con.CloseCon();
                    YearOfAdmissionFill();
                    ClearAllStudent_Management();
                    Student_dgvFill();
                    msgbox.show("Student Update Completed   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    con.CloseCon();
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
