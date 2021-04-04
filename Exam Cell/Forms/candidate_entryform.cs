using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using ExcelDataReader;
using Exam_Cell.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Exam_Cell
{
    public partial class formti : Form
    {        
        Connection con = new Connection();      //to establish Sql connection from Class 'Connection'
        CustomMessageBox msgbox = new CustomMessageBox();

        public formti()
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

        //CheckBox headerchkbox = new CheckBox();

        // Main Form Open
        private void Formti_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            UnvBranchCombobox.Enabled = false;
            YOACombobox.Enabled = false;
            SubjectDetails_groupbox.Enabled = false;
            Unv_Student_details_groupbox.Enabled = false;
            //Fill subject details box
            Schemecomboboxfill();
            Branchsecondcomboboxfill();
            Semestercomboboxfill();
            
            Candidate_datagridview.Enabled = false;
            Courses_dgv.Enabled = false;

            //give checkboxes to both dgv
            //courses dgv
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "";
            chkbox.Width = 30;
            chkbox.Name = "checkBoxColumn";
            Courses_dgv.Columns.Insert(0, chkbox);
            //candidate dgv
            DataGridViewCheckBoxColumn chkbox2 = new DataGridViewCheckBoxColumn();
            chkbox2.HeaderText = "";
            chkbox2.Width = 30;
            chkbox2.Name = "checkBox2Column";
            Candidate_datagridview.Columns.Insert(0, chkbox2);

            //AddHeaderchckbox(); //header checkbox added to candidate dgv
            //headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
        }

        //function definition
        //void AddHeaderchckbox()
        //{
        //    //Locate Header Cell to place checkbox in correct position
        //    Point HeaderCellLocation = this.Candidate_datagridview.GetCellDisplayRectangle(0, -1, true).Location;
        //    //place headercheckbox to the location
        //    headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 13);
        //    headerchkbox.BackColor = Color.RoyalBlue;
        //    headerchkbox.Size = new Size(18, 18);
        //    //add checkbox into dgv
        //    Candidate_datagridview.Controls.Add(headerchkbox);
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
        //    foreach (DataGridViewRow row in Candidate_datagridview.Rows)
        //        ((DataGridViewCheckBoxCell)row.Cells["checkBox2Column"]).Value = Hcheckbox.Checked;

        //    Candidate_datagridview.RefreshEdit();
        //}

        void UnvBranchComboboxFill()
        {
            try
            {
            string command = string.Format("Select Distinct Branch from Scheme");
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            UnvBranchCombobox.DisplayMember = "Branch";
            UnvBranchCombobox.ValueMember = "Branch";
            UnvBranchCombobox.DataSource = dt;
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

        void YoaComboboxFill()
        {
            try
            {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select Distinct Year_Of_Admission from Students", con.ActiveCon());
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            //display -select-
            DataRow topItem = dtbl.NewRow();
            topItem[0] = "-Select-";
            dtbl.Rows.InsertAt(topItem, 0);

            YOACombobox.DisplayMember = "Year_Of_Admission";
            YOACombobox.ValueMember = "Year_Of_Admission";
            YOACombobox.DataSource = dtbl;
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

        //Scheme combobox Populate
        void Schemecomboboxfill()
        {
            try
            {
            string command = string.Format("Select Distinct Scheme from Scheme");
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);

            Scheme_combobox.ValueMember = "Scheme";  // scheme is column name
            Scheme_combobox.DataSource = dt;
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

        //Branch combobox Populate
        void Branchsecondcomboboxfill()
        {
            try
            {
            string command = string.Format("Select Distinct Branch from Scheme");
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
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

        //Semester ComboBox Populate
        void Semestercomboboxfill()
        {
            try
            {
            string command = string.Format("Select Distinct Semester from Scheme");
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);

            Semester_combobox.ValueMember = "Semester";
            Semester_combobox.DataSource = dt;
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

        private void Unvrsty_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Unvrsty_rdbtn.Checked==true)
            {
                RegRegCnd_btn.Enabled = false;
                SelectAllCheckbox.Enabled = false;
                Unv_Student_details_groupbox.Enabled = true;
                Unv_Student_details_groupbox.BringToFront();
                Courses_dgv.Enabled = false;
                SubjectDetails_groupbox.Enabled = false;
                Candidate_datagridview.Enabled = true;
                UnvCheckbox.Checked = false;
                Candidate_datagridview.DataSource = null;
                UnvBranchCombobox.Enabled = false;
                YOACombobox.Enabled = false;
                UnvBranchComboboxFill();
                YoaComboboxFill();
                Series_Student_details_groupbox.Enabled = false;   //student details box disabled since not needed
                Excel_Group.Enabled = true;        //excel group box enabled           
                Sheet_combobox.ResetText();
                groupboxExtraReg.Enabled = true; // extra reg for university                
            }
        }
        //for candidate dgv ...bindingsource is used for filter function
        BindingSource source = new BindingSource();
        void Sourcefill()
        {
            try
            {
            //headerchkbox.Checked = false;
            SelectAllCheckbox.Checked = false;
            SQLiteCommand command = new SQLiteCommand("select * from Class order by Class", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable table_Students = new DataTable();
            adapter.Fill(table_Students);
            source.DataSource = null;
            source.DataSource = table_Students;
            Candidate_datagridview.DataSource = source;
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
        void Unvsourcefill()
        {
            try
            {
            //headerchkbox.Checked = false;
            SelectAllCheckbox.Checked = false;
            SQLiteCommand command = new SQLiteCommand("select * from Students order by Branch,Reg_no", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataTable table_Students = new DataTable();
            adapter.Fill(table_Students);
            source.DataSource = null;
            source.DataSource = table_Students;
                Candidate_datagridview.DataSource = null;
            Candidate_datagridview.DataSource = source;
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
        
        private void Series_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (Series_rdbtn.Checked == true)
            {
                RegRegCnd_btn.Enabled = true;
                SelectAllCheckbox.Enabled = true;
                Series_Student_details_groupbox.Enabled = true;
                Unv_Student_details_groupbox.Enabled = false;
                Series_Student_details_groupbox.BringToFront();
                Candidate_datagridview.DataSource = null;
                //populate class combobox
                Classcomboboxfill();
                Excel_Group.Enabled = false;   //excel groubbox disabled since not needed                
                Sourcefill();
                Series_Student_details_groupbox.Enabled = true;     //rest enabled
                SubjectDetails_groupbox.Enabled = true;
                Courses_dgv.Enabled = true;
                Candidate_datagridview.Enabled = true;
                groupboxExtraReg.Enabled = false; // extra reg for university
            }
        }

        void Classcomboboxfill()
        {            
            try
            {
            string command = string.Format("Select Distinct Class from Class");
            SQLiteCommand sc = new SQLiteCommand(command, con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sc);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);

            Class_drpdwn.ValueMember = "Class";
            Class_drpdwn.DataSource = dt;
            Class_drpdwn.SelectedIndex = 0; //set selected index as first index
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

        //Scheme Combobox Event
        private void Scheme_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
            {
                if(Scheme_combobox.SelectedIndex == 0 && (Branch_combobox.SelectedIndex !=0 || Semester_combobox.SelectedIndex !=0))
                    msgbox.Show("Select Scheme   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                else
                    Sql_subject_filter();
            }
        }

        //Branch ComboBox Event
        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
            {                
                if(Scheme_combobox.SelectedIndex == 0)
                    msgbox.Show("Select Scheme   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                else
                    Sql_subject_filter();
            }
        }

        //SemesterComboBox event
        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
            {
                //subjectdetailsfilter();
                if (Scheme_combobox.SelectedIndex == 0)
                    msgbox.Show("Select Scheme   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                else
                    Sql_subject_filter();
            }
        }

        BindingSource schemesource = new BindingSource();
        void Sql_subject_filter()
        {
            string schemekey = Scheme_combobox.Text;
            string branchvalue = Branch_combobox.Text;
            string semvalue = Semester_combobox.Text;

            if (branchvalue != "-Select-" || semvalue != "-Select-")
            {
                if (branchvalue == "-Select-")
                    branchvalue = "";
                else if (semvalue == "-Select-")
                    semvalue = "";
                string comm = string.Format("Select * from Scheme where (Scheme = '{0}' and Branch Like '%{1}%' and Semester Like '%{2}%') order by Branch",schemekey, branchvalue, semvalue);
                try
                {
                    SQLiteCommand command = new SQLiteCommand(comm, con.ActiveCon());
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable table_Scheme = new DataTable();
                    adapter.Fill(table_Scheme);
                    schemesource.DataSource = null;
                    schemesource.DataSource = table_Scheme;
                    Courses_dgv.DataSource = schemesource;
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
                Courses_dgv.DataSource = null;
            }
        }

        // EXCEL GROUP BOX EVENT START
        int messflag = 0;
        DataTableCollection tableCollection;
        //Excel Select button click event
        private void Excel_btn_Click(object sender, EventArgs e)
        {
            if (messflag == 0)
            {
                messflag = 1;
                msgbox.Show("ExcelSheet Header Naming Must Be as follows (order can be any) :    \n Register No ,Student Name, Semester, Branch, Course", "Warning", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Warning);
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
        private void Sheet_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[Sheet_combobox.SelectedItem.ToString()];
            //Candidate_datagridview.DataSource = dt;   // <-- what error this created ? why this wont work? please Check...

            // these codes was used instead of that One Line Code above
            if (dt != null)
            {
                List<ExcelStudents> excst = new List<ExcelStudents>(); //<--here ExcelStudents is class name
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ExcelStudents excclass = new ExcelStudents();
                    excclass.Name = dt.Rows[i]["Student Name"].ToString();  //have to give Excel column names inside the[""]
                    excclass.Reg_No = dt.Rows[i]["Register No"].ToString();
                    excclass.Branch = dt.Rows[i]["Branch"].ToString();
                    excclass.Semester = dt.Rows[i]["Semester"].ToString();
                    excclass.Course = dt.Rows[i]["Course"].ToString();

                    excst.Add(excclass);
                }
                Candidate_datagridview.DataSource = excst;
                RegRegCnd_btn.Enabled = true;
            }
        }

        //Class combobox Event
        private void Class_drpdwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get selected item from Class combobox
            string key = Class_drpdwn.Text;

            //Filter the dgv
            if (key == "-Select-")
                source.RemoveFilter();  //remove filters 
            else
                source.Filter = string.Format("Class LIKE '%{0}%'", key);   //filter with sql statement
        }      

        //Register button click Event
        private void RegRegCnd_btn_Click(object sender, EventArgs e)        //PLEASE CHECK IF WE NEED SEPERATE TABLES FOR REGSTRD CANDIDTE IN SQL FOR SERIES AND UNVIRSTY....
        {
            progressPanel.Show();
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            RegisterFunction();
        }

        void Register_Query(DataGridViewRow dr, DataGridViewRow dr2, string QueryCommand)
        {
            //selected datas from both dgv will be inserted to Table Registered Candidates
            //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
            SQLiteCommand sqlcomm = new SQLiteCommand(QueryCommand, con.ActiveCon()); //con.ActiveCon() is for sqlconnection
                                                                                                                                                                                                              //giving values to the reference...values from dgv
            sqlcomm.Parameters.AddWithValue("@Reg_no", dr2.Cells["Reg_no"].Value);
            sqlcomm.Parameters.AddWithValue("@Name", dr2.Cells["Name"].Value);
            if(Series_rdbtn.Checked) sqlcomm.Parameters.AddWithValue("@Class", Class_drpdwn.Text);
            sqlcomm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
            sqlcomm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
            sqlcomm.Parameters.AddWithValue("@Branch", dr2.Cells["Branch"].Value);
            //execute sql query to insert into tables
            sqlcomm.ExecuteNonQuery();
        }
        void RegisterFunction()
        {
            //For Series Exam
            if (Series_rdbtn.Checked == true)
            {
                if (Class_drpdwn.SelectedIndex != 0)
                {
                    if(SelectAllCheckbox.Checked)
                    {
                        try
                        {
                            int f = 0;
                            string query = string.Format("Insert into Series_candidates(Name,Reg_no,Class,Semester,Course,Branch)Values(" + "@Name,@Reg_no,@Class,@Semester,@Course,@Branch)");
                            //select checkbox from course dgv
                            foreach (DataGridViewRow dr in Courses_dgv.Rows)
                            {
                                bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);  //<--here checkBoxColumn is the name given for coursedgv checkbox in formload function

                                if (chkboxselected)
                                {
                                    f = 1;
                                    //select all from candidate dgv
                                    foreach (DataGridViewRow dr2 in Candidate_datagridview.Rows)
                                        Register_Query(dr,dr2,query);
                                }
                            }
                            if (f == 1)
                            {
                                SelectAllCheckbox.Checked = false;
                                msgbox.Show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                                msgbox.Show("Select Course to Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                        try
                        {
                            int f = 0;
                            string query = string.Format("Insert into Series_candidates(Name,Reg_no,Class,Semester,Course,Branch)Values(" + "@Name,@Reg_no,@Class,@Semester,@Course,@Branch)");
                            //select checkbox from course dgv
                            foreach (DataGridViewRow dr in Courses_dgv.Rows)
                            {
                                bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);  //<--here checkBoxColumn is the name given for coursedgv checkbox in formload function

                                if (chkboxselected)
                                {
                                    //select checkbox from candidate dgv
                                    foreach (DataGridViewRow dr2 in Candidate_datagridview.Rows)
                                    {
                                        bool checkbox2selected = Convert.ToBoolean(dr2.Cells["checkBox2Column"].Value);   //<--here checkBox2Column is the name given for candidte dgv checkbox in formload function
                                        if (checkbox2selected)
                                        {
                                            f = 1;
                                            Register_Query(dr, dr2,query);
                                        }
                                    }
                                }
                            }
                            if (f == 1)
                            {

                                msgbox.Show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                                msgbox.Show("Select Student and Course to Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                else { msgbox.Show("Select Class    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error); }
            }

            //For University Exams
            else if (Unvrsty_rdbtn.Checked == true)
            {
                try
                {
                    if (UnvCheckbox.Checked)
                    {
                        if(SelectAllCheckbox.Checked)
                        {
                            int f = 0;
                            string query = string.Format("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)");
                            //select checkbox from course dgv
                            foreach (DataGridViewRow dr in Courses_dgv.Rows)
                            {
                                bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);  //<--here checkBoxColumn is the name given for coursedgv checkbox in formload function

                                if (chkboxselected)
                                {
                                    f = 1;
                                    //select all from candidate dgv
                                    foreach (DataGridViewRow dr2 in Candidate_datagridview.Rows)
                                        Register_Query(dr, dr2, query);
                                }
                            }
                            if (f == 1)
                            {
                                    UnvBranchCombobox.SelectedIndex = 0;
                                    YOACombobox.SelectedIndex = 0;
                                //headerchkbox.Checked = false;
                                SelectAllCheckbox.Checked = false;
                                msgbox.Show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                                msgbox.Show("Select Course to Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                        }
                        else
                        {
                            int f = 0;
                            string query = string.Format("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)");
                            //select checkbox from course dgv
                            foreach (DataGridViewRow dr in Courses_dgv.Rows)
                            {
                                bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);  //<--here checkBoxColumn is the name given for coursedgv checkbox in formload function

                                if (chkboxselected)
                                {
                                    //select checkbox from candidate dgv
                                    foreach (DataGridViewRow dr2 in Candidate_datagridview.Rows)
                                    {
                                        bool checkbox2selected = Convert.ToBoolean(dr2.Cells["checkBox2Column"].Value);   //<--here checkBox2Column is the name given for candidte dgv checkbox in formload function
                                        if (checkbox2selected)
                                        {
                                            f = 1;
                                            Register_Query(dr, dr2, query);
                                        }
                                    }
                                }
                            }
                            if (f == 1)
                            {
                                UnvBranchCombobox.SelectedIndex = 0;
                                YOACombobox.SelectedIndex = 0;                                
                                msgbox.Show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                                msgbox.Show("Select Student and Course to Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // EXCEL REGISTER
                        //select checkbox from candidate dgv
                        foreach (DataGridViewRow dr in Candidate_datagridview.Rows)
                        {
                                //selected datas from dgv will be inserted to Table Registered Candidates
                                //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
                                SQLiteCommand sqlcomm = new SQLiteCommand("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
                                                                                                                                                                                                                         //giving values to the reference...values from dgv
                                sqlcomm.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                                sqlcomm.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value);
                                sqlcomm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                                sqlcomm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
                                sqlcomm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
                                //execute sql query to insert into tables
                                sqlcomm.ExecuteNonQuery();
                            
                        }
                            SelectAllCheckbox.Checked = false;
                            RegRegCnd_btn.Enabled = false;
                            msgbox.Show("Register Done from Excel Data   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
                msgbox.Show("Necessary details are not given    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            progressPanel.Hide();
        }

        private void UnvBranchCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(UnvCheckbox.Checked)
                Display_unv_stdts_dgv();
        }

        private void YOACombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnvCheckbox.Checked)
                Display_unv_stdts_dgv();
        }

        void Display_unv_stdts_dgv()
        {
            SelectAllCheckbox.Checked = false;

            string branchvalue = UnvBranchCombobox.Text;
            string yoavalue = YOACombobox.Text;
            if(branchvalue != "-Select-" || yoavalue != "-Select-")
            {
                if (branchvalue == "-Select-")
                    branchvalue = "";
                else if (yoavalue == "-Select-")
                    yoavalue = "";
                string comm = string.Format("Select * from Students where (Branch Like '%{0}%' and Year_Of_Admission Like '%{1}%') order by Branch,Reg_no", branchvalue, yoavalue);
                sql_filter_dgv(comm);
            }
            else
                Candidate_datagridview.DataSource = null;
           
            void sql_filter_dgv(string command_string)
            {
                try
                {
                    //headerchkbox.Checked = false;
                    SelectAllCheckbox.Checked = false;
                    SQLiteCommand command = new SQLiteCommand(command_string, con.ActiveCon());
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable table_Students = new DataTable();
                    adapter.Fill(table_Students);
                    source.DataSource = null;
                    source.DataSource = table_Students;
                    Candidate_datagridview.DataSource = source;
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

        private void UnvCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(UnvCheckbox.Checked)
            {
                RegRegCnd_btn.Enabled = true;
                Courses_dgv.Enabled = true;
                SubjectDetails_groupbox.Enabled = true;
                Excel_Group.Enabled = false;
                UnvBranchCombobox.Enabled = true;
                YOACombobox.Enabled = true;
                UnvBranchComboboxFill();
                YoaComboboxFill();
                SelectAllCheckbox.Enabled = true;
            }
            else
            {
                RegRegCnd_btn.Enabled = false;
                SelectAllCheckbox.Enabled = false;
                Courses_dgv.Enabled = false;
                SubjectDetails_groupbox.Enabled = false;
                Excel_Group.Enabled = true;
                UnvBranchCombobox.Enabled = false;
                YOACombobox.Enabled = false;
                Candidate_datagridview.DataSource = null;
            }
        }

        private void ExtraReg_btn_Click(object sender, EventArgs e)
        {
            if(Extra_Name_Textbox.Text != "" && Extra_Reg_no_Textbox.Text != "")
            {
                int f = 0;
                //select checkbox from course dgv
                foreach (DataGridViewRow dr in Courses_dgv.Rows)
                {
                    bool checkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                    if (checkboxselected)
                    {
                        f = 1;
                        
                        //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
                        SQLiteCommand sqlcomm = new SQLiteCommand("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
                        //giving values to the reference...values from dgv                                                                                                                                                                            
                        sqlcomm.Parameters.AddWithValue("@Reg_no", Extra_Reg_no_Textbox.Text);
                        sqlcomm.Parameters.AddWithValue("@Name", Extra_Name_Textbox.Text);
                        sqlcomm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                        sqlcomm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
                        sqlcomm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
                        //execute sql query to insert into tables
                        sqlcomm.ExecuteNonQuery();
                    }
                }
                if (f == 1)
                    msgbox.Show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                else
                    msgbox.Show("Select Course To Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            else
            {
                msgbox.Show("Enter Reg_No and Name   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = (MenuForm)Application.OpenForms["MenuForm"];
            if (menuForm.Temp_btn == menuForm.menu_item_candidateentry)
                menuForm.Temp_btn = null;
            menuForm.menu_item_candidateentry.BackColor = Color.FromArgb(48, 43, 99);
            menuForm.candidateentry_open = false;
            this.Close();
        }
    }
}