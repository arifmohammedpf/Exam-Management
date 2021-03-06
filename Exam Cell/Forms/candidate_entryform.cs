﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using ExcelDataReader;
using Exam_Cell.Forms;

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



        //CheckBox headerchkbox = new CheckBox();
        
        // Main Form Open
        private void formti_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            UnvBranchComboboxFill();
            YoaComboboxFill();
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
            //Scheme_combobox.Items.Add(new KeyValuePair<string, string>("-Select-", "-Select-"));
            //Scheme_combobox.Items.Add(new KeyValuePair<string, string>("Scheme_2015", "Scheme_2015"));
            //Scheme_combobox.Items.Add(new KeyValuePair<string, string>("Scheme_2019", "Scheme_2019"));

            //Scheme_combobox.DisplayMember = "key";
            //Scheme_combobox.ValueMember = "value";

            //Scheme_combobox.SelectedIndex = 0;

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

            Scheme_combobox.ValueMember = "Scheme";  // Whats the use of this lineofcode? // scheme is column name
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
            //Branch_combobox.Items.Add(new KeyValuePair<string, string>("-Select-", "-Select-"));
            //Branch_combobox.Items.Add(new KeyValuePair<string, string>("Computer Science Eng", "cse"));
            //Branch_combobox.Items.Add(new KeyValuePair<string, string>("Mechanical Eng", "mee"));
            //Branch_combobox.Items.Add(new KeyValuePair<string, string>("Civil Eng", "Civil Eng"));
            //Branch_combobox.Items.Add(new KeyValuePair<string, string>("Electronics & Communication Eng", "ece"));
            //Branch_combobox.Items.Add(new KeyValuePair<string, string>("Electrical & Electronics Eng", "eee"));
            //Branch_combobox.Items.Add(new KeyValuePair<string, string>("ec", "ec"));
            //Branch_combobox.Items.Add(new KeyValuePair<string, string>("cs", "cs"));

            //Branch_combobox.DisplayMember = "key";
            //Branch_combobox.ValueMember = "value";
            //Branch_combobox.SelectedIndex = 0;

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

            // IF WE USE BELOW METHOD TO POPULATE COMBOBOX THEN HOW TO USE DISPLAY AND VALUE MEMBERS LIKE combobox.selecteditem();??? please check

            ////sqlconnection
            //SQLiteDataAdapter sda = new SQLiteDataAdapter("Select Distinct Branch from Students", con.ActiveCon());
            //DataTable dtbl = new DataTable();
            //sda.Fill(dtbl);
            ////display -select-
            //DataRow topItem = dtbl.NewRow();
            //topItem[0] = "-Select-";
            //dtbl.Rows.InsertAt(topItem, 0);
            ////display branches
            //Branch_combobox.DisplayMember = "Branch";
            //Branch_combobox.ValueMember = "Branch";
            //Branch_combobox.DataSource = dtbl;
        }

        //Semester ComboBox Populate
        void Semestercomboboxfill()
        {
            //Semester_combobox.Items.Add("-Select-");
            //Semester_combobox.Items.Add("Semester 1");
            //Semester_combobox.Items.Add("Semester 2");
            //Semester_combobox.Items.Add("Semester 3");
            //Semester_combobox.Items.Add("Semester 4");
            //Semester_combobox.Items.Add("Semester 5");
            //Semester_combobox.Items.Add("Semester 6");
            //Semester_combobox.Items.Add("Semester 7");
            //Semester_combobox.Items.Add("Semester 8");

            //Semester_combobox.SelectedIndex = 0;


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

        //University RadioButton Event
        private void Unvrsty_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Unvrsty_rdbtn.Checked==true)
            {
                RegRegCnd_btn.Enabled = false;
                SelectAllCheckbox.Enabled = false;
                Unv_Student_details_groupbox.Enabled = true;
                Unv_Student_details_groupbox.BringToFront();
                Courses_dgv.Enabled = false;
                Candidate_datagridview.Enabled = true;
                UnvCheckbox.Checked = false;
                Candidate_datagridview.DataSource = null;
                UnvBranchCombobox.Enabled = false;
                YOACombobox.Enabled = false;
                SubjectDetails_groupbox.Enabled = true;
                Series_Student_details_groupbox.Enabled = false;   //student details box disabled since not needed
                Excel_Group.Enabled = true;        //excel group box enabled           
                Sheet_combobox.ResetText();
                groupboxExtraReg.Enabled = true; // extra reg for university
                
                
                //ARE THESE NEEDED?
                //Class_label.Text = "Branch";
                //Branchcomboboxfill();
                //Yearofadmissionboxfill();
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
        //Series RadioButton Event
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
                classcomboboxfill();
                Excel_Group.Enabled = false;   //excel groubbox disabled since not needed                
                Sourcefill();
                Series_Student_details_groupbox.Enabled = true;     //rest enabled
                SubjectDetails_groupbox.Enabled = true;
                Courses_dgv.Enabled = true;
                Candidate_datagridview.Enabled = true;
                groupboxExtraReg.Enabled = false; // extra reg for university
            }
        }

        void classcomboboxfill()
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
        

        BindingSource schemesource = new BindingSource();
        void Schemesourcefill()
        {
            try
            {
            SQLiteCommand command = new SQLiteCommand("select * from Scheme order by Branch", con.ActiveCon());
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
        //Scheme Combobox Event
        private void Scheme_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////get selected item
            //KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)Scheme_combobox.SelectedItem;
            //string value = kvp.Value.ToString();

            // if (value == "Scheme_2015")
            //{
            //    Branch_combobox.SelectedIndex = 0;
            //    Semester_combobox.SelectedIndex = 0;
            //    scheme2015BindingSource2.RemoveFilter();
            //    Courses_dgv.DataSource = scheme2015BindingSource2;
            //}
            //else if (value == "Scheme_2019")
            //{
            //    Branch_combobox.SelectedIndex = 0;
            //    Semester_combobox.SelectedIndex = 0;
            //    scheme2019BindingSource2.RemoveFilter();
            //    Courses_dgv.DataSource = scheme2019BindingSource2;
            //}
            //else
            //{
            //    Courses_dgv.DataSource = null;

            //}

            //Course dgv fill

            if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
            {
                Schemesourcefill();
                subjectdetailsfilter();
            }
        }

               

        //Branch ComboBox Event
        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
                //Function Call for filter
                subjectdetailsfilter();
        }


        //SemesterComboBox event
        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
                //Function Call for filter
                subjectdetailsfilter();
        }

        //Filter function for Subject details
        void subjectdetailsfilter()
        {
            ////Get selected items of Scheme,Branch,Semester Comboboxes
            //KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)Scheme_combobox.SelectedItem;
            //string schemekey = keyValuePair.Key.ToString();

            string schemekey = Scheme_combobox.Text;
            string branchvalue = Branch_combobox.Text;
            string semvalue = Semester_combobox.Text;

            //Filter dgv
            if (schemekey != "-Select-")
            {

                string filter = "";        //filter string for sql statements to be written
                filter += string.Format("Scheme Like '%{0}%'", schemekey);

                if (branchvalue != "-Select-")
                {
                    if (filter.Length > 0) filter += " AND ";                    //Put AND if there is existing Sql statement in filter string
                    filter += string.Format("Branch Like '%{0}%'", branchvalue);     //Put sql statement in filter string
                }
                if (semvalue != "-Select-")
                {
                    if (filter.Length > 0) filter += " AND ";
                    filter += string.Format("Semester Like '%{0}%'", semvalue);
                }
                schemesource.Filter = filter;
            }
            else
            {
                msgbox.show("Select Scheme   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                msgbox.show("ExcelSheet Header Naming Must Be as follows (order can be any) :    \n Register No ,Student Name, Semester, Branch, Course", "Warning", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Warning);
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

        //// Import Button Event
        //private void Import_btn_Click(object sender, EventArgs e)
        //{
        //    string connectionString = @"Data Source=DESKTOP-P1AI33U\SQLEXPRESS;Initial Catalog=Exam_Cell;Integrated Security=True;";
        //    DapperPlusManager.Entity<ExcelStudents>().Table("Excel_Show"); //"Excel_Show" is Table name from sql to import
        //    List<ExcelStudents> excst = excelShowBindingSource.DataSource as List<ExcelStudents>;
        //    if (excst != null)
        //    {
        //        using (IDbConnection db = new SqlConnection(connectionString))
        //        {
        //            db.BulkInsert(excst);
        //        }
        //    }
        //    MessageBox.Show("is this function needed ???");
        //}


        //Class combobox Event
        private void Class_drpdwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get selected item from Class combobox
            string key = Class_drpdwn.Text;

            //Filter the dgv
            if (key == "-Select-")
            {
                source.RemoveFilter();  //remove filters 
            }
            else
            {
                source.Filter = string.Format("Class LIKE '%{0}%'", key);   //filter with sql statement
            }
        }      

        //Register button click Event
        private void RegRegCnd_btn_Click(object sender, EventArgs e)        //PLEASE CHECK IF WE NEED SEPERATE TABLES FOR REGSTRD CANDIDTE IN SQL FOR SERIES AND UNVIRSTY....
        {
            progressPanel.Show();
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            RegisterFunction();
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
                            //select checkbox from course dgv
                            foreach (DataGridViewRow dr in Courses_dgv.Rows)
                            {
                                bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);  //<--here checkBoxColumn is the name given for coursedgv checkbox in formload function

                                if (chkboxselected)
                                {
                                    f = 1;
                                    //select all from candidate dgv
                                    foreach (DataGridViewRow dr2 in Candidate_datagridview.Rows)
                                    {
                                            //selected datas from both dgv will be inserted to Table Registered Candidates
                                            //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
                                            SQLiteCommand sqlcomm = new SQLiteCommand("Insert into Series_candidates(Name,Reg_no,Class,Semester,Course)Values(" + "@Name,@Reg_no,@Class,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
                                                    //giving values to the reference...values from dgv
                                            sqlcomm.Parameters.AddWithValue("@Reg_no", dr2.Cells["Reg_no"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Name", dr2.Cells["Name"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Class", Class_drpdwn.Text);
                                            sqlcomm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
                                            //execute sql query to insert into tables
                                            sqlcomm.ExecuteNonQuery();                                        
                                    }
                                }
                            }
                            if (f == 1)
                            {
                                msgbox.show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                                SelectAllCheckbox.Checked = false;
                            }
                            else
                                msgbox.show("Select Course to Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                                            //selected datas from both dgv will be inserted to Table Registered Candidates
                                            //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
                                            SQLiteCommand sqlcomm = new SQLiteCommand("Insert into Series_candidates(Name,Reg_no,Class,Semester,Course)Values(" + "@Name,@Reg_no,@Class,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
                                                                                                                                                                                                                               //giving values to the reference...values from dgv
                                            sqlcomm.Parameters.AddWithValue("@Reg_no", dr2.Cells["Reg_no"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Name", dr2.Cells["Name"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Class", Class_drpdwn.Text);
                                            sqlcomm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
                                            //execute sql query to insert into tables
                                            sqlcomm.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            if (f == 1)
                            {

                                msgbox.show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                                msgbox.show("Select Student and Course to Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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
                else { msgbox.show("Select Class    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error); }
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
                            //select checkbox from course dgv
                            foreach (DataGridViewRow dr in Courses_dgv.Rows)
                            {
                                bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);  //<--here checkBoxColumn is the name given for coursedgv checkbox in formload function

                                if (chkboxselected)
                                {
                                    f = 1;
                                    //select all from candidate dgv
                                    foreach (DataGridViewRow dr2 in Candidate_datagridview.Rows)
                                    {
                                            //selected datas from both dgv will be inserted to Table Registered Candidates
                                            //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
                                            SQLiteCommand sqlcomm = new SQLiteCommand("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
                                                                                                                                                                                                                                     //giving values to the reference...values from dgv
                                            sqlcomm.Parameters.AddWithValue("@Reg_no", dr2.Cells["Reg_no"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Name", dr2.Cells["Name"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Branch", dr2.Cells["Branch"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
                                            //execute sql query to insert into tables
                                            sqlcomm.ExecuteNonQuery();                                        
                                    }
                                }
                            }
                            if (f == 1)
                            {
                                    UnvBranchCombobox.SelectedIndex = 0;
                                    YOACombobox.SelectedIndex = 0;
                                //headerchkbox.Checked = false;
                                SelectAllCheckbox.Checked = false;
                                msgbox.show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                                msgbox.show("Select Course to Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                        }
                        else
                        {
                            int f = 0;
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
                                            //selected datas from both dgv will be inserted to Table Registered Candidates
                                            //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
                                            SQLiteCommand sqlcomm = new SQLiteCommand("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
                                                                                                                                                                                                                                     //giving values to the reference...values from dgv
                                            sqlcomm.Parameters.AddWithValue("@Reg_no", dr2.Cells["Reg_no"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Name", dr2.Cells["Name"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Branch", dr2.Cells["Branch"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
                                            sqlcomm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
                                            //execute sql query to insert into tables
                                            sqlcomm.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            if (f == 1)
                            {
                                UnvBranchCombobox.SelectedIndex = 0;
                                YOACombobox.SelectedIndex = 0;                                
                                msgbox.show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                            }
                            else
                                msgbox.show("Select Student and Course to Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
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
                            msgbox.show("Register Done from Excel Data   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
                msgbox.show("Necessary details are not given    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            progressPanel.Hide();
        }

        private void UnvBranchCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(UnvCheckbox.Checked)
            {
                Studentsdgvfilter();
            }
        }

        private void YOACombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UnvCheckbox.Checked)
            {
                Studentsdgvfilter();
            }
        }
         void Studentsdgvfilter()
         {
            //headerchkbox.Checked = false;
            SelectAllCheckbox.Checked = false;
            string branchvalue = UnvBranchCombobox.Text;
            string yoavalue = YOACombobox.Text;

            string filter = "";        //filter string for sql statements to be written
            
            if (branchvalue != "-Select-")
            {
                if (filter.Length > 0) filter += " AND ";                    //Put AND if there is existing Sql statement in filter string
                filter += string.Format("Branch Like '%{0}%'", branchvalue);     //Put sql statement in filter string
            }
            if (yoavalue != "-Select-")
            {
                if (filter.Length > 0) filter += " AND ";
                filter += string.Format("Year_Of_Admission Like '%{0}%'", yoavalue);
            }
            source.Filter = filter;
         }

        private void UnvCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(UnvCheckbox.Checked)
            {
                RegRegCnd_btn.Enabled = true;
                Courses_dgv.Enabled = true;
                Excel_Group.Enabled = false;
                UnvBranchCombobox.Enabled = true;
                YOACombobox.Enabled = true;
                UnvBranchComboboxFill();
                YoaComboboxFill();
                Unvsourcefill();
                SelectAllCheckbox.Enabled = true;
            }
            else
            {
                RegRegCnd_btn.Enabled = false;
                SelectAllCheckbox.Enabled = false;
                Courses_dgv.Enabled = false;
                Excel_Group.Enabled = true;
                UnvBranchComboboxFill();
                YoaComboboxFill();
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
                    msgbox.show("Register Done   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                else
                    msgbox.show("Select Course To Register   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
            else
            {
                msgbox.show("Enter Reg_No and Name   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
            }
        }
    }
}