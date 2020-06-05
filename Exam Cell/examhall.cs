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
    public partial class examhall : Form
    {
        Connection con = new Connection();
        public examhall()
        {
            InitializeComponent();
        }


        CheckBox headerchkbox = new CheckBox();
        private void examhall_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'exam_Cell_Rooms.Rooms' table. You can move, or remove it, as needed.
            this.roomsTableAdapter.Fill(this.exam_Cell_Rooms.Rooms);
            
            Rooms_dgv.DataSource = roomsBindingSource;
            Rooms_dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            FillCapacity();
            Priority_combobox.SelectedIndex = 0;

            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.Width = 30;
            checkbox.Name = "CheckboxColumn";
            Rooms_dgv.Columns.Insert(0,checkbox);

            AddHeaderchckbox(); //header checkbox added to candidate dgv
            headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
        }

        void AddHeaderchckbox()
        {
            try
            {
                //Locate Header Cell to place checkbox in correct position
                Point HeaderCellLocation = this.Rooms_dgv.GetCellDisplayRectangle(0, -1, true).Location;
                //place headercheckbox to the location
                headerchkbox.Location = new Point(HeaderCellLocation.X + 8, HeaderCellLocation.Y + 2);
                headerchkbox.BackColor = Color.White;
                headerchkbox.Size = new Size(18, 18);
                //add checkbox into dgv
                Rooms_dgv.Controls.Add(headerchkbox);
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
                foreach (DataGridViewRow row in Rooms_dgv.Rows)
                    ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

                Rooms_dgv.RefreshEdit();
                Fill_checked_capacity();
            }
            catch (Exception) { MessageBox.Show("Try Again", "Headercheckboxclick", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void FillCapacity()
        {
            int a, b,result_a=0,result_b=0;
            foreach (DataGridViewRow dr in Rooms_dgv.Rows)
            {
               if (int.TryParse(dr.Cells["A_Series"].Value.ToString(), out a) && int.TryParse(dr.Cells["B_Series"].Value.ToString(), out b))
                {
                    result_a += a;
                    result_b += b;
                }
                
                TotalRoom_textbox.Text = Rooms_dgv.RowCount.ToString();
                TotalCapacity_textbox.Text = ("A - " + result_a + "  B - " + result_b);
            }

        }
                
        private void Save_button_Click(object sender, EventArgs e)
        {
            if(Priority_combobox.SelectedIndex!=0)
            {
                int flag = 0;
                if (Rooms_dgv.RowCount.ToString() != "0" && RoomNo_textbox.Text!="")
                {
                    foreach (DataGridViewRow dr in Rooms_dgv.Rows)
                    {
                        if (RoomNo_textbox.Text.Equals(dr.Cells["Room_No"].Value.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            flag = 1;
                        }
                        
                    }
                    if(flag == 1)
                    {
                        SqlUpdateCommand();
                    }
                    else 
                    {
                        SqlInsertCommand();
                    }
                }
                else if (RoomNo_textbox.Text != "")
                {
                    SqlInsertCommand();
                }
                else
                {
                    MessageBox.Show("Enter Room", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select Priority", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SqlInsertCommand()
        {
            if (int.TryParse(A_series_textbox.Text, out int a) && int.TryParse(B_series_textbox.Text, out int b))
            {
                SqlCommand comm = new SqlCommand("Insert into Rooms(Room_No,Priority,A_Series,B_Series)Values(" + "@RoomNo,@Priority,@A_series,@B_series)", con.ActiveCon());
                comm.Parameters.AddWithValue("@RoomNo", RoomNo_textbox.Text);
                comm.Parameters.AddWithValue("@Priority", Priority_combobox.SelectedItem);
                comm.Parameters.AddWithValue("@A_series", a);
                comm.Parameters.AddWithValue("@B_series", b);
                comm.ExecuteNonQuery();
                MessageBox.Show("New Room Saved");
                Cleardata();
            }
            else
            {
                MessageBox.Show("A & B Series must be Numbers","Alert",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }
            
        }

        void SqlUpdateCommand()
        {
            if (int.TryParse(A_series_textbox.Text, out int a) && int.TryParse(B_series_textbox.Text, out int b))
            {
                SqlCommand comm = new SqlCommand("Update Rooms set Priority=@Priority,A_Series=@A_series,B_Series=@B_series where Room_No=@RoomNo", con.ActiveCon());
                comm.Parameters.AddWithValue("@RoomNo", RoomNo_textbox.Text);
                comm.Parameters.AddWithValue("@Priority", Priority_combobox.SelectedItem);
                comm.Parameters.AddWithValue("@A_series", a);
                comm.Parameters.AddWithValue("@B_series", b);
                comm.ExecuteNonQuery();
                MessageBox.Show(RoomNo_textbox.Text+" Updated");
                Cleardata();
            }
            else
            {
                MessageBox.Show("A & B Series must be Numbers", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        void Cleardata()
        {
            RoomNo_textbox.ResetText();
            Priority_combobox.SelectedIndex = 0;
            A_series_textbox.ResetText();
            B_series_textbox.ResetText();
            this.roomsTableAdapter.Fill(this.exam_Cell_Rooms.Rooms);
            FillCapacity();
        }
        private void TotalRoom_textbox_TextChanged(object sender, EventArgs e)
        {

        }

       

        void Fill_checked_capacity()
        {
            
            int a, b, result_a = 0, result_b = 0, f = 0,count=0; 
            foreach (DataGridViewRow dr in Rooms_dgv.Rows)
            {
                
                bool chckselected = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                if(chckselected)
                {
                    f = 1;
                    count += 1;
                    a = int.Parse(dr.Cells["A_Series"].Value.ToString());
                    b = int.Parse(dr.Cells["B_Series"].Value.ToString());
                    result_a += a;
                    result_b += b;
                    TotalRoom_textbox.Text = count.ToString();
                    TotalCapacity_textbox.Text = ("A - " + result_a + "  B - " + result_b);
                    RoomNo_textbox.ResetText();
                    Priority_combobox.SelectedIndex = 0;
                    A_series_textbox.ResetText();
                    B_series_textbox.ResetText();
                }
                if(f==0)
                {
                    FillCapacity();
                }    
            }
        }        

                    
            

        private void ResetPriority_button_Click(object sender, EventArgs e)
        {
            if(Priority_combobox.SelectedIndex !=0 )
            {
                SqlCommand comm = new SqlCommand("Update Rooms set Priority=@Priority", con.ActiveCon());
                comm.Parameters.AddWithValue("@Priority", Priority_combobox.SelectedItem);
                comm.ExecuteNonQuery();
                Cleardata();
            }
            else
                MessageBox.Show("Select A Priority to Reset", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        private void Rooms_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Rooms_dgv.Columns["CheckboxColumn"].Index)
                Fill_checked_capacity();
        }

        private void Rooms_dgv_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == Rooms_dgv.Columns["CheckboxColumn"].Index)
                Rooms_dgv.EndEdit();
        }

        private void UpdatePriority_button_Click(object sender, EventArgs e)
        {
            int f = 0;
            if(Priority_combobox.SelectedIndex != 0 )
            {
                foreach (DataGridViewRow dr in Rooms_dgv.Rows)
                {
                    bool chckselect = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                    if (chckselect)
                    {
                        f = 1;
                        SqlCommand comm = new SqlCommand("Update Rooms set Priority=@Priority where Room_No=@Room_No", con.ActiveCon());
                        comm.Parameters.AddWithValue("@Room_No", dr.Cells["Room_No"].Value);
                        comm.Parameters.AddWithValue("@Priority", Priority_combobox.SelectedItem);
                        comm.ExecuteNonQuery();
                        
                    }
                }
                if(f==0)
                    MessageBox.Show("No Selection made", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cleardata();
            }
            else
                MessageBox.Show("Select A Priority", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Rooms_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int f = 0;
            foreach (DataGridViewRow dr in Rooms_dgv.Rows)
            {
                bool chckselect = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                if (chckselect)
                {
                    f = 1;
                }
            }
            if(f==0)
            {
                foreach (DataGridViewRow row in Rooms_dgv.SelectedRows)
                {
                    RoomNo_textbox.Text = row.Cells["Room_No"].Value.ToString();
                    Priority_combobox.Text = row.Cells["Priority"].Value.ToString();
                    A_series_textbox.Text = row.Cells["A_Series"].Value.ToString();
                    B_series_textbox.Text = row.Cells["B_Series"].Value.ToString();
                    break;
                }
            }
                    
        }
    }
}













