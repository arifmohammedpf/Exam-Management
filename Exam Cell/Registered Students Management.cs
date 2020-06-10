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

        private void Univrsty_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            Series_radiobtn.Checked = false;

            SqlCommand command = new SqlCommand("select * from Registered_candidates order by Reg_no", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable Unv_students = new DataTable();
            adapter.Fill(Unv_students);
            Registered_dgv.DataSource = Unv_students;
        }

        private void Series_radiobtn_CheckedChanged(object sender, EventArgs e)
        {
            Univrsty_radiobtn.Checked = false;

            SqlCommand command = new SqlCommand("select * from Series_candidates order by Course and Class and Name", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable Srs_students = new DataTable();
            adapter.Fill(Srs_students);
            Registered_dgv.DataSource = Srs_students;
        }
    }
}
