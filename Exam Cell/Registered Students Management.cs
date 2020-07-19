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
    public partial class Registered_Students_Management : Form
    {
        Connection con = new Connection();
        public Registered_Students_Management()
        {
            InitializeComponent();
        }

        CheckBox headerchkbox = new CheckBox();
        private void Registered_Students_Management_Load(object sender, EventArgs e)
        {
            Secure_tools_disabled();
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "";
            chkbox.Width = 30;
            chkbox.Name = "checkBoxColumn";
            Registered_dgv.Columns.Insert(0, chkbox);

            AddHeaderchckbox(); //header checkbox added to candidate dgv
            headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
        }

        private void DeleteAll_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are going to Delete every Students in the list, Are You Sure ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (Univrsty_radiobtn.Checked)
                {
                    SqlCommand command = new SqlCommand("Delete Registered_candidates", con.ActiveCon());
                    command.ExecuteNonQuery();
                    MessageBox.Show("All Candidates Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    University_fill();
                    Clear_function();
                }
                else if (Series_radiobtn.Checked)
                {
                    SqlCommand command = new SqlCommand("Delete Series_candidates", con.ActiveCon());
                    command.ExecuteNonQuery();
                    MessageBox.Show("All Candidates Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Series_fill();
                    Clear_function();
                }
                else if (AllotUniversty_radiobtn.Checked)
                {
                    SqlCommand command = new SqlCommand("Delete University_Alloted", con.ActiveCon());
                    command.ExecuteNonQuery();
                    MessageBox.Show("All Alloted Candidates Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UniversityAlloted_fill();
                    Clear_function();
                }
                else if (AllotSeries_radiobtn.Checked)
                {
                    SqlCommand command = new SqlCommand("Delete Series_Alloted", con.ActiveCon());
                    command.ExecuteNonQuery();
                    MessageBox.Show("All Alloted Candidates Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SeriesAlloted_fill();
                    Clear_function();
                }
            }

        }

        void AddHeaderchckbox()
        {
            try
            {
                //Locate Header Cell to place checkbox in correct position
                Point HeaderCellLocation = this.Registered_dgv.GetCellDisplayRectangle(0, -1, true).Location;
                //place headercheckbox to the location
                headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 2);
                headerchkbox.BackColor = Color.White;
                headerchkbox.Size = new Size(18, 18);
                //add checkbox into dgv
                Registered_dgv.Controls.Add(headerchkbox);
            }
            catch (Exception) { MessageBox.Show("Try Again", "AddHeaderchckbox", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        {
            try
            {
                Headerchckboxclick((CheckBox)sender);
            }
            catch (Exception) { MessageBox.Show("Try Again", "Headerchckbox_Mouseclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //headerchckbox click event
        private void Headerchckboxclick(CheckBox Hcheckbox)
        {

            try
            {
                foreach (DataGridViewRow row in Registered_dgv.Rows)
                    ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

                Registered_dgv.RefreshEdit();
            }
            catch (Exception) { MessageBox.Show("Try Again", "Headercheckboxclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        BindingSource Universitybinding = new BindingSource();
        BindingSource UniversityAllotbinding = new BindingSource();
        BindingSource Seriesbinding = new BindingSource();
        BindingSource SeriesAllotbinding = new BindingSource();        
        void University_fill()
        {
            SqlCommand command = new SqlCommand("select * from Registered_candidates order by Branch,Reg_no", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable Unv_students = new DataTable();
            adapter.Fill(Unv_students);
            Universitybinding.DataSource = null;
            Universitybinding.DataSource = Unv_students;
            Registered_dgv.DataSource = null;
            Registered_dgv.DataSource = Universitybinding;
        }
        void Series_fill()
        {
            SqlCommand command = new SqlCommand("select * from Series_candidates order by Course, Class, Name", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable Srs_students = new DataTable();
            adapter.Fill(Srs_students);
            Seriesbinding.DataSource = null;
            Seriesbinding.DataSource = Srs_students;
            Registered_dgv.DataSource = null;
            Registered_dgv.DataSource = Seriesbinding;
        }
        void UniversityAlloted_fill()
        {
            SqlCommand command = new SqlCommand("select * from University_Alloted order by Date,Room_No,Reg_no", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable unv_allot = new DataTable();
            adapter.Fill(unv_allot);
            UniversityAllotbinding.DataSource = null;
            UniversityAllotbinding.DataSource = unv_allot;
            Registered_dgv.DataSource = null;
            Registered_dgv.DataSource = UniversityAllotbinding;
        }
        void SeriesAlloted_fill()
        {
            SqlCommand command = new SqlCommand("select * from Series_Alloted order by Date, Room_No, Name", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable srs_allot = new DataTable();
            adapter.Fill(srs_allot);
            SeriesAllotbinding.DataSource = null;
            SeriesAllotbinding.DataSource = srs_allot;
            Registered_dgv.DataSource = null;
            Registered_dgv.DataSource = SeriesAllotbinding;
        }
        private void Univrsty_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Univrsty_radiobtn.Checked)
            {
                Secure_tools_enabled();
                Branch_ComboFill();
                Series_radiobtn.Checked = false;
                AllotUniversty_radiobtn.Checked = false;
                AllotSeries_radiobtn.Checked = false;
                University_fill();
            }
        }

        private void Series_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(Series_radiobtn.Checked)
            {
                Secure_tools_enabled();
                Univrsty_radiobtn.Checked = false;
                AllotUniversty_radiobtn.Checked = false;
                AllotSeries_radiobtn.Checked = false;
                Series_fill();
                Branch_combobox.Enabled = false;
                Semester_combobox.Enabled = false;
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to Delete ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (Univrsty_radiobtn.Checked)
                {
                    foreach (DataGridViewRow dr in Registered_dgv.Rows)
                    {
                        bool checkselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkselect)
                        {
                            SqlCommand command = new SqlCommand("Delete Registered_candidates where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Selected Candidates Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    University_fill();
                    Clear_function();
                }
                else if (Series_radiobtn.Checked)
                {
                    foreach (DataGridViewRow dr in Registered_dgv.Rows)
                    {
                        bool checkselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkselect)
                        {
                            SqlCommand command = new SqlCommand("Delete Series_candidates where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Selected Candidates Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Series_fill();
                    Clear_function();
                }
                else if (AllotSeries_radiobtn.Checked)
                {
                    foreach (DataGridViewRow dr in Registered_dgv.Rows)
                    {
                        bool checkselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkselect)
                        {
                            SqlCommand command = new SqlCommand("Delete Series_Alloted where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Selected Alloted Candidates Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SeriesAlloted_fill();
                    Clear_function();
                }
                else if (AllotUniversty_radiobtn.Checked)
                {
                    foreach (DataGridViewRow dr in Registered_dgv.Rows)
                    {
                        bool checkselect = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                        if (checkselect)
                        {
                            SqlCommand command = new SqlCommand("Delete University_Alloted where Reg_no=@Reg_no", con.ActiveCon());
                            command.Parameters.AddWithValue("@Reg_no", dr.Cells["Reg_no"].Value);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Selected Alloted Candidates Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UniversityAlloted_fill();
                    Clear_function();
                }
            }
        }

        private void AllotUniversty_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(AllotUniversty_radiobtn.Checked)
            {
                Secure_tools_enabled();
                Univrsty_radiobtn.Checked = false;
                Series_radiobtn.Checked = false;
                AllotSeries_radiobtn.Checked = false;
                UniversityAlloted_fill();
                Branch_combobox.Enabled = false;
                Semester_combobox.Enabled = false;
            }
        }

        private void AllotSeries_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if(AllotSeries_radiobtn.Checked)
            {
                Secure_tools_enabled();
                Univrsty_radiobtn.Checked = false;
                Series_radiobtn.Checked = false;
                AllotUniversty_radiobtn.Checked = false;
                SeriesAlloted_fill();
                Branch_combobox.Enabled = false;
                Semester_combobox.Enabled = false;
            }
        }

        void Filter_Function()
        {
            
            if (Univrsty_radiobtn.Checked)
            {
                string regno = Regno_textbox.Text;

                string filter = "";        //filter string for sql statements to be written
                if (regno != "")
                    filter = string.Format("Reg_no like '%{0}%'", regno);

                if (Branch_combobox.SelectedIndex != 0)
                {
                    if (filter.Length > 0) filter += " AND ";                    //Put AND if there is existing Sql statement in filter string
                    filter += string.Format("Branch Like '%{0}%'", Branch_combobox.Text);     //Put sql statement in filter string
                }
                if (Semester_combobox.SelectedIndex != 0)
                {
                    if (filter.Length > 0) filter += " AND ";
                    filter += string.Format("Semester Like '%{0}%'", Semester_combobox.Text);
                }
                Universitybinding.Filter = filter;
            }
            else if (Series_radiobtn.Checked)
            {
                string regno = Regno_textbox.Text;

                string filter = "";        //filter string for sql statements to be written
                if (regno != "")
                    filter = string.Format("Reg_no like '%{0}%'", regno);
                
                if (Semester_combobox.SelectedIndex != 0)
                {
                    if (filter.Length > 0) filter += " AND ";
                    filter += string.Format("Semester Like '%{0}%'", Semester_combobox.Text);
                }
                Seriesbinding.Filter = filter;
            }
            else if (AllotSeries_radiobtn.Checked || AllotUniversty_radiobtn.Checked)
            {
                string regno = Regno_textbox.Text;

                string filter = "";        //filter string for sql statements to be written
                if (regno != "")
                    filter = string.Format("Reg_no like '%{0}%'", regno);
                              
                if (AllotSeries_radiobtn.Checked)
                    SeriesAllotbinding.Filter = filter;
                else if (AllotUniversty_radiobtn.Checked)
                    UniversityAllotbinding.Filter = filter;
            }
            
            

        }

        private void Regno_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filter_Function();
            }
            catch (Exception) { }
        }

        private void Branch_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Filter_Function();
            }
            catch (Exception) { }
        }

        private void Semester_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Filter_Function();
            }
            catch (Exception) { }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear_function();
        }
        void Clear_function()
        {
            Branch_combobox.SelectedIndex = 0;
            Semester_combobox.SelectedIndex = 0;
            Regno_textbox.Clear();
        }
        void Branch_ComboFill()
        {
            SqlCommand sc = new SqlCommand("Select Distinct Branch from Scheme", con.ActiveCon());
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Branch", typeof(string)); // in datatable, a column should be created before adding rows
            DataRow top = dt.NewRow();
            top[0] = "-Select Branch-";
            dt.Rows.InsertAt(top, 0);
            dt.Load(reader);

            Branch_combobox.ValueMember = "Branch";  //column name is given to get values to show in combobox
            Branch_combobox.DataSource = dt;
        }
        void Secure_tools_disabled()
        {
            Regno_textbox.Enabled = false;
            Branch_combobox.Enabled = false;
            Semester_combobox.Enabled = false;
            ClearBtn.Enabled = false;
            DeleteAll_btn.Enabled = false;
            Delete_btn.Enabled = false;
        }
        void Secure_tools_enabled()
        {
            Regno_textbox.Enabled = true;
            Branch_combobox.Enabled = true;
            Semester_combobox.Enabled = true;
            ClearBtn.Enabled = true;
            DeleteAll_btn.Enabled = true;
            Delete_btn.Enabled = true;
        }
    }
}
