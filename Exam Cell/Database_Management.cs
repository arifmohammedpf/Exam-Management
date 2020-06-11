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

namespace Exam_Cell
{
    public partial class Database_Management : Form
    {
        Connection con = new Connection();
        BindingSource Scheme_Source = new BindingSource();
        BindingSource Class_Source = new BindingSource();

        public Database_Management()
        {
            InitializeComponent();
        }

        void Class_dgv_Fill()
        {
            Class_dgv_radiobtn.Checked = true;
            SqlCommand command = new SqlCommand("select Class from Class Sort asc", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_class = new DataTable();
            adapter.Fill(table_class);
            Class_Source.DataSource = null;
            Class_Source.DataSource = table_class;
            Scheme_dgv.DataSource = Class_Source;
            
        }

        void Branch_dgv_Fill()
        {          
            SqlCommand command = new SqlCommand("select * from Scheme order by Scheme desc", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table_scheme = new DataTable();
            adapter.Fill(table_scheme);
            Scheme_Source.DataSource = null;
            Scheme_Source.DataSource = table_scheme;
            Scheme_dgv.DataSource = Scheme_Source;

        }
        private void Branch_dgv_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Branch_dgv_radiobtn.Checked)
            {
                NewBranchGroupbox.Enabled = true;
                NewCourseGroupbox.Enabled = true;
                NewClassGroupbox.Enabled = false;
                Branch_dgv_Fill();
                Clear_All_ClassManagement();
            }
            
        }

        private void Class_dgv_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Class_dgv_radiobtn.Checked)
            {
                NewBranchGroupbox.Enabled = false;
                NewCourseGroupbox.Enabled = false;
                NewClassGroupbox.Enabled = true;
                Class_dgv_Fill();
                Clear_All_ClassManagement();
            }
        }

        private void AddNewBranch_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Management(Branch)Values("+" @Branch) ", con.ActiveCon());
            command.Parameters.AddWithValue("@Branch", NewBranch_textbox.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("New Branch Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BranchComboboxFill();
            Branch_dgv_radiobtn.Checked = true;  // check whether it will work in checked state?????????????????????????
        }

        private void DeleteBranch_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("delete Management where Branch=@Branch) ", con.ActiveCon());
            command.Parameters.AddWithValue("@Branch", UpdateBranch_combobox.Text);
            command.ExecuteNonQuery();
            Branch_dgv_radiobtn.Checked = true;
            try
            {
                SqlCommand command2 = new SqlCommand("delete Scheme where Branch=@Branch) ", con.ActiveCon());
                command2.Parameters.AddWithValue("@Branch", UpdateBranch_combobox.Text);
                command2.ExecuteNonQuery();
                Branch_dgv_radiobtn.Checked = true;
            }    
            catch(Exception) { }
            MessageBox.Show("Branch Delete Done", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
                
                
            

        

        private void DeleteClass_btn_Click(object sender, EventArgs e)
        {
            int f = 0;
                foreach(DataGridViewRow dr in Scheme_dgv.Rows)
                {
                    bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                    if(checkselected)
                    {
                        f = 1;
                        SqlCommand command = new SqlCommand("delete Management where Class=@Class) ", con.ActiveCon());
                        command.Parameters.AddWithValue("@Class", dr.Cells["Class"].Value.ToString());
                        command.ExecuteNonQuery();
                    }
                }
                if (f == 1)
                {
                    Class_dgv_radiobtn.Checked = true;
                    MessageBox.Show("Delete Done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Select any Class to delete, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void Clear_All_ClassManagement()
        {
            NewClass_textbox.Clear();
            NewClassYOA_combobox.SelectedIndex = 0;
            NewBranch_textbox.Clear();
            UpdateBranch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;
            Course_textbox.Clear();
            Examcode_textbox.Clear();
            ACode_textbox.Clear();
        }

        private void Database_Management_Load(object sender, EventArgs e)
        {
            BranchComboboxFill();
            //Schemedgv
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.Width = 30;
            checkbox.Name = "CheckboxColumn";
            Scheme_dgv.Columns.Insert(0, checkbox);
            //studentdgv
            DataGridViewCheckBoxColumn checkbox2 = new DataGridViewCheckBoxColumn();
            checkbox2.HeaderText = "";
            checkbox2.Width = 30;
            checkbox2.Name = "CheckboxColumn2";
            Student_dgv.Columns.Insert(0, checkbox2);
        }

        private void AddNewCourse_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Scheme(Branch,Semester,Course,Exam_Code,A_Code)Values(" + " @Branch,@Semester,@Course,@Exam_Code,@A_Code) ", con.ActiveCon());
            command.Parameters.AddWithValue("@Branch", UpdateBranch_combobox.Text);
            command.Parameters.AddWithValue("@Semester", Semester_combobox.Text);
            command.Parameters.AddWithValue("@Course", Course_textbox.Text);
            command.Parameters.AddWithValue("@Exam_Code", Examcode_textbox.Text);
            command.Parameters.AddWithValue("@A_Code", ACode_textbox.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("New Course Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Branch_dgv_Fill();
            Course_textbox.Clear();
            Examcode_textbox.Clear();
            ACode_textbox.Clear();
            NewcourseFilter();
        }

        void NewcourseFilter()
        {           
            string branchvalue = UpdateBranch_combobox.Text;
            string semvalue = Semester_combobox.Text;

            string filter = "";        //filter string for sql statements to be written
            
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
            Scheme_Source.Filter = filter;
        }

        private void UpdateBranch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NewcourseFilter();
            }
            catch (Exception) { }
           
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NewcourseFilter();
            }
            catch (Exception) { }
        }

        private void DeleteCourse_btn_Click(object sender, EventArgs e)
        {
            int f = 0;
            foreach (DataGridViewRow dr in Scheme_dgv.Rows)
            {
                bool checkselected = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                if (checkselected)
                {
                    f = 1;
                    SqlCommand command = new SqlCommand("delete Scheme where Course=@Course) ", con.ActiveCon());
                    command.Parameters.AddWithValue("@Course", dr.Cells["Course"].Value.ToString());
                    command.ExecuteNonQuery();
                }
            }
            if (f == 1)
            {
                Branch_dgv_radiobtn.Checked = true;
                MessageBox.Show("Course Delete Done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Select any Course to delete, Try again.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddNewClass_btn_Click(object sender, EventArgs e)
        {
            if (NewClassYOA_combobox.SelectedIndex != 0)
            {
                SqlCommand command = new SqlCommand("insert into Management(Class)Values(" + " @Class) ", con.ActiveCon());
                command.Parameters.AddWithValue("@Class", NewClass_textbox.Text + " - " + NewClassYOA_combobox.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("New Class Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Class_dgv_radiobtn.Checked = true;
            }
            else
                MessageBox.Show("Select Semester", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void BranchComboboxFill()
        {
            SqlCommand sc = new SqlCommand("Select Branch from Management", con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Scheme", typeof(string)); // Whats the use of this lineofcode? //here Scheme is column name
            DataRow top = dt.NewRow();
            top[0] = "-Select-";
            dt.Rows.InsertAt(top, 0);
            dt.Load(reader);

            UpdateBranch_combobox.ValueMember = "Scheme";  // Whats the use of this lineofcode? // scheme is column name
            UpdateBranch_combobox.DataSource = dt;
        }
    }
}
