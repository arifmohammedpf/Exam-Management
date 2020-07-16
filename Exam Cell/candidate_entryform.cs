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
using System.IO;
using ExcelDataReader;
using System.Collections;

namespace Exam_Cell
{
    public partial class formti : Form
    {
        
        Connection con = new Connection();      //to establish Sql connection from Class 'Connection'
        
       
        public formti()
        {
            InitializeComponent();
        }



        CheckBox headerchkbox = new CheckBox();
        
        // Main Form Open
        private void formti_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exam_CellDataSetStudentsNew.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter3.Fill(this.exam_CellDataSetStudentsNew.Students);
            // TODO: This line of code loads data into the 'exam_CellScheme.Scheme' table. You can move, or remove it, as needed.
            this.schemeTableAdapter1.Fill(this.exam_CellScheme.Scheme);
            // TODO: This line of code loads data into the 'exam_CellDataSet_forscheme1519.Scheme' table. You can move, or remove it, as needed.
            this.schemeTableAdapter.Fill(this.exam_CellDataSet_forscheme1519.Scheme);
            // TODO: This line of code loads data into the 'exam_CellDataSet_forscheme1519.Scheme_2019' table. You can move, or remove it, as needed.
            this.scheme_2019TableAdapter1.Fill(this.exam_CellDataSet_forscheme1519.Scheme_2019);
            // TODO: This line of code loads data into the 'exam_CellDataSet_forscheme1519.Scheme_2015' table. You can move, or remove it, as needed.
            this.scheme_2015TableAdapter1.Fill(this.exam_CellDataSet_forscheme1519.Scheme_2015);
            // TODO: This line of code loads data into the 'exam_CellDataSet1.Registered_candidates' table. You can move, or remove it, as needed.
            this.registered_candidatesTableAdapter.Fill(this.exam_CellDataSet1.Registered_candidates);
            // TODO: This line of code loads data into the 'exam_CellDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter2.Fill(this.exam_CellDataSet.Students);
            // TODO: This line of code loads data into the 'exam_CellDataSet_Students.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter1.Fill(this.exam_CellDataSet_Students.Students);
            
            // TODO: This line of code loads data into the 'exam_CellDataSet_Tables.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.exam_CellDataSet_Tables.Students);


            try
            {
                this.WindowState = FormWindowState.Normal;
                UnvBranchComboboxFill();
                YoaComboboxFill();
                UnvBranchCombobox.Enabled = false;
                YOACombobox.Enabled = false;
                SubjectDetails_groupbox.Enabled = false;
                //Fill subject details box
                Schemecomboboxfill();
                Branchsecondcomboboxfill();
                Semestercomboboxfill();

                //somehow dgv font became white,so it has to be changed to black
                Candidate_datagridview.RowsDefaultCellStyle.ForeColor = Color.Black;
                Courses_dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
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

                AddHeaderchckbox(); //header checkbox added to candidate dgv
                headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "form load", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        //function definition
        void AddHeaderchckbox()
        {
            try
            {
                //Locate Header Cell to place checkbox in correct position
                Point HeaderCellLocation = this.Candidate_datagridview.GetCellDisplayRectangle(0, -1, true).Location;
                //place headercheckbox to the location
                headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 2);
                headerchkbox.BackColor = Color.White;
                headerchkbox.Size = new Size(18, 18);
                //add checkbox into dgv
                Candidate_datagridview.Controls.Add(headerchkbox);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "AddHeaderchckbox", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        {
            try
            {
                Headerchckboxclick((CheckBox)sender);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Headerchckbox_Mouseclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //headerchckbox click event
        private void Headerchckboxclick(CheckBox Hcheckbox)
        {

            try
            {
                foreach (DataGridViewRow row in Candidate_datagridview.Rows)
                    ((DataGridViewCheckBoxCell)row.Cells["checkBox2Column"]).Value = Hcheckbox.Checked;

                Candidate_datagridview.RefreshEdit();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Headerchckboxclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }



        }

        void UnvBranchComboboxFill()
        {
            string command = string.Format("Select Distinct Branch from Scheme");
            SqlCommand sc = new SqlCommand(command, con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Branch", typeof(string));
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            dt.Load(reader);

            UnvBranchCombobox.ValueMember = "Branch";
            UnvBranchCombobox.DataSource = dt;
        }

        void YoaComboboxFill()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Year_Of_Admission from Students", con.ActiveCon());
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

        //Scheme combobox Populate
        void Schemecomboboxfill()
        {
            try
            {
                //Scheme_combobox.Items.Add(new KeyValuePair<string, string>("-Select-", "-Select-"));
                //Scheme_combobox.Items.Add(new KeyValuePair<string, string>("Scheme_2015", "Scheme_2015"));
                //Scheme_combobox.Items.Add(new KeyValuePair<string, string>("Scheme_2019", "Scheme_2019"));

                //Scheme_combobox.DisplayMember = "key";
                //Scheme_combobox.ValueMember = "value";

                //Scheme_combobox.SelectedIndex = 0;

                string command = string.Format("Select Distinct Scheme from Scheme");
                SqlCommand sc = new SqlCommand(command, con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Scheme", typeof(string)); // since we create new datatable, we give column first //here Scheme is column name
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);
                dt.Load(reader);

                Scheme_combobox.ValueMember = "Scheme";  // Whats the use of this lineofcode? // scheme is column name
                Scheme_combobox.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Schemecomboboxfill", MessageBoxButtons.OK, MessageBoxIcon.Error); }

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
                SqlCommand sc = new SqlCommand(command, con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Branch", typeof(string));
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);
                dt.Load(reader);
               
                Branch_combobox.ValueMember = "Branch";
                Branch_combobox.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Branchsecondcomboboxfill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // IF WE USE BELOW METHOD TO POPULATE COMBOBOX THEN HOW TO USE DISPLAY AND VALUE MEMBERS LIKE combobox.selecteditem();??? please check

            ////sqlconnection
            //SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Branch from Students", con.ActiveCon());
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
            

            try
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

                
                string command = string.Format("Select Distinct Semester from Scheme");
                SqlCommand sc = new SqlCommand(command, con.ActiveCon());
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Semester", typeof(string));
                DataRow top = dt.NewRow();
                top[0] = "-Select-";
                dt.Rows.InsertAt(top, 0);
                dt.Load(reader);

                Semester_combobox.ValueMember = "Semester";
                Semester_combobox.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Semestercomboboxfill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //University RadioButton Event
        private void Unvrsty_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Unvrsty_rdbtn.Checked==true)
            {
                Unv_Student_details_groupbox.Enabled = true;
                Unv_Student_details_groupbox.BringToFront();
                Candidate_datagridview.Enabled = true;
                UnvCheckbox.Checked = false;
                Candidate_datagridview.DataSource = null;
                UnvBranchCombobox.Enabled = false;
                YOACombobox.Enabled = false;
                SubjectDetails_groupbox.Enabled = true;
                Series_Student_details_groupbox.Enabled = false;   //student details box disabled since not needed
                Excel_Group.Enabled = true;        //excel group box enabled           
                Sheet_combobox.ResetText();
                
                
                //ARE THESE NEEDED?
                //Class_label.Text = "Branch";
                //Branchcomboboxfill();
                //Yearofadmissionboxfill();
            }
        }


        //Series RadioButton Event
        private void Series_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (Series_rdbtn.Checked == true)
            {
                Series_Student_details_groupbox.Enabled = true;
                Unv_Student_details_groupbox.Enabled = false;
                Series_Student_details_groupbox.BringToFront();
                Candidate_datagridview.DataSource = null;
                //populate class combobox
                classcomboboxfill();
                Excel_Group.Enabled = false;   //excel groubbox disabled since not needed                
                Candidate_datagridview.DataSource = studentsBindingSource3;
                Series_Student_details_groupbox.Enabled = true;     //rest enabled
                SubjectDetails_groupbox.Enabled = true;
                Courses_dgv.Enabled = true;
                Candidate_datagridview.Enabled = true;                
            }
        }

        void classcomboboxfill()
        {
            string command = string.Format("Select Class from Class");
            SqlCommand sc = new SqlCommand(command, con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Class", typeof(string));
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            dt.Load(reader);

            Class_drpdwn.ValueMember = "Class";
            Class_drpdwn.DataSource = dt;
            Class_drpdwn.SelectedIndex = 0; //set selected index as first index
        }

        //DELETE IF BRANCH FILTER IS NOT NEEDED FOR UNIVERSITY DGV
        //void Branchcomboboxfill()
        //{   //sqlconnection
        //    SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Branch from Students", con.ActiveCon());
        //    DataTable dtbl = new DataTable();
        //    sda.Fill(dtbl);
        //    //display -select-
        //    DataRow topItem = dtbl.NewRow();
        //    topItem[0] = "-Select-";
        //    dtbl.Rows.InsertAt(topItem, 0);

        ////convert datatable to array for selecting 
        //    ArrayList rows = new ArrayList();   //import using.system.collections for ArrayList
        //    foreach (DataRow dataRow in dtbl.Rows)
        //        rows.Add(string.Join(";", dataRow.ItemArray.Select(item => item.ToString())));
        //    //display branches
        //    Class_drpdwn.DisplayMember = "Branch";
        //    Class_drpdwn.ValueMember = "Branch";
        //    Class_drpdwn.DataSource = rows;
        //}


        //Scheme Combobox Event
        private void Scheme_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
                {
                    Courses_dgv.DataSource = schemeBindingSource1;
                    subjectdetailsfilter();
                }    
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Scheme_combobox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

               

        //Branch ComboBox Event
        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
                    //Function Call for filter
                    subjectdetailsfilter();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Branch_combobox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
               
        }


        //SemesterComboBox event
        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Series_rdbtn.Checked || Unvrsty_rdbtn.Checked)
                    //Function Call for filter
                    subjectdetailsfilter();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Semester_combobox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                
        }

        //Filter function for Subject details
        void subjectdetailsfilter()
        {
            try
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
                    schemeBindingSource1.Filter = filter;
                }
                else
                {
                    MessageBox.Show("Select Scheme");   //Error Box appear
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "subjectdetailsfilter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }
            

        //DELETE IF Y O A FILTER IS NOT NEEDED FOR UNIVERSITY DGV
        //void Yearofadmissionboxfill()
        //{

        //    //sql connection
        //    SqlDataAdapter sda = new SqlDataAdapter("Select Distinct Year_Of_Admission from Students", con.ActiveCon());
        //    DataTable dtbl = new DataTable();
        //    sda.Fill(dtbl);
        //    //display -select-
        //    DataRow topItem = dtbl.NewRow();
        //    //topItem[0] = "-Select-";  //can't do becoz YOA is int Type
        //    dtbl.Rows.InsertAt(topItem, 0);

        //    // display YOA
        //    YOA_drpdwn.DisplayMember = "Year_Of_Admission";
        //    YOA_drpdwn.ValueMember = "Year_Of_Admission";
        //    YOA_drpdwn.DataSource = dtbl;
        //    YOA_drpdwn.SelectedIndex = 0;
        //}








        // EXCEL GROUP BOX EVENT START
        DataTableCollection tableCollection;
        //Excel Select button click event
        private void Excel_btn_Click(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception ex) { MessageBox.Show(ex.Message, "Excel_btn_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        //Sheet Combobox Event
        private void Sheet_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Sheet_combobox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
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
            try
            {
                //Get selected item from Class combobox
                string key = Class_drpdwn.Text;

                //Filter the dgv
                if (key == "-Select-")
                {
                    studentsBindingSource3.RemoveFilter();  //remove filters 
                }
                else
                {
                    studentsBindingSource3.Filter = string.Format("Branch LIKE '%{0}%'", key);   //filter with sql statement
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Class_drpdwn_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }


        


        

        //Register button click Event
        private void RegRegCnd_btn_Click(object sender, EventArgs e)        //PLEASE CHECK IF WE NEED SEPERATE TABLES FOR REGSTRD CANDIDTE IN SQL FOR SERIES AND UNVIRSTY....
        {
            try
            {
                //For Series Exam
                if (Series_rdbtn.Checked == true)
                {
                    if(Class_drpdwn.SelectedIndex != 0)
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
                                        SqlCommand sqlcomm = new SqlCommand("Insert into Series_candidates(Name,Reg_no,Class,Semester,Course)Values(" + "@Name,@Reg_no,@Class,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
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
                        if(f==1)
                            MessageBox.Show("Register Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Select Student and Course to Register", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else { MessageBox.Show("Select Class", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }

                //For University Exams
                else if (Unvrsty_rdbtn.Checked == true)
                {
                    if(UnvCheckbox.Checked)
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
                                        SqlCommand sqlcomm = new SqlCommand("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
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
                            MessageBox.Show("Register Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Select Student and Course to Register", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int f = 0;
                        //select checkbox from candidate dgv
                        foreach (DataGridViewRow dr in Candidate_datagridview.Rows)
                        {
                            bool checkboxselected = Convert.ToBoolean(dr.Cells["checkBox2Column"].Value);
                            if (checkboxselected)
                            {
                                f = 1;
                                //selected datas from dgv will be inserted to Table Registered Candidates
                                //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
                                SqlCommand sqlcomm = new SqlCommand("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
                                                                                                                                                                                                                   //giving values to the reference...values from dgv
                                sqlcomm.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                                sqlcomm.Parameters.AddWithValue("@Name", dr.Cells["Name"].Value);           
                                sqlcomm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                                sqlcomm.Parameters.AddWithValue("@Semester", dr.Cells["Semester"].Value);
                                sqlcomm.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value);
                                //execute sql query to insert into tables
                                sqlcomm.ExecuteNonQuery();
                            }
                        }
                        if (f == 1)
                            MessageBox.Show("Register Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Select Someone To Register", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Necessary details are not given", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "RegRegCnd_btn_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void UnvBranchCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Unvrsty_rdbtn.Checked)
            {
                studentsdgvfilter();
            }
        }

        private void YOACombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Unvrsty_rdbtn.Checked)
            {
                studentsdgvfilter();
            }
        }
         void studentsdgvfilter()
         {
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
            studentsBindingSource3.Filter = filter;
         }

        private void UnvCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(UnvCheckbox.Checked)
            {
                Excel_Group.Enabled = false;
                UnvBranchCombobox.Enabled = true;
                YOACombobox.Enabled = true;
                UnvBranchComboboxFill();
                YoaComboboxFill();
                Candidate_datagridview.DataSource = studentsBindingSource3;
            }
            else
            {
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
                        //selected datas from dgv will be inserted to Table Registered Candidates
                        //here first bracket is sqltable column names and 2nd bracket with @ is refernce for values to be inserted
                        SqlCommand sqlcomm = new SqlCommand("Insert into Registered_candidates(Name,Reg_no,Branch,Semester,Course)Values(" + "@Name,@Reg_no,@Branch,@Semester,@Course)", con.ActiveCon()); //con.ActiveCon() is for sqlconnection
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
                    MessageBox.Show("Register Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Select Course To Register", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




































































































