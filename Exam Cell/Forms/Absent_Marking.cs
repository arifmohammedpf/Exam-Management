﻿using System;
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
    public partial class Absent_Marking : Form
    {
        Connection con = new Connection();
        public Absent_Marking()
        {
            InitializeComponent();
        }

        private void Unv_radio_CheckedChanged(object sender, EventArgs e)
        {
            DateComboboxFill();
            RoomNoComboboxFill();
            Session_combobox.SelectedIndex = 0;
            Dgv.DataSource = null;

        }

        private void Series_radio_CheckedChanged(object sender, EventArgs e)
        {
            DateComboboxFill();
            RoomNoComboboxFill();
            Session_combobox.SelectedIndex = 0;
            Dgv.DataSource = null;
        }

        void DateComboboxFill()
        {
            SqlCommand comm = new SqlCommand("select distinct Date from Timetable order by Date", con.ActiveCon());
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
        
        void RoomNoComboboxFill()
        {
            SqlCommand comm = new SqlCommand("select Room_No from Rooms order by Room_No", con.ActiveCon());
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataTable table = new DataTable();
            adapter.Fill(table);
            //for -select-
            DataRow top = table.NewRow();
            top[0] = "-Select-";
            table.Rows.InsertAt(top, 0);

            Room_combobox.DisplayMember = "Room_No";
            Room_combobox.ValueMember = "Room_No";
            Room_combobox.DataSource = table;
        }
        
        private void Search_btn_Click(object sender, EventArgs e)
        {
            if(Series_radio.Checked)
            {
                SqlCommand command = new SqlCommand("select Seat,Reg_no,Name,Class,Course,Exam_Code from Series_Alloted Where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                command.Parameters.AddWithValue("@Date", Date_combobox.Text);
                command.Parameters.AddWithValue("@Session", Session_combobox.Text);
                command.Parameters.AddWithValue("@Room_No", Room_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);                
                table.Columns.Add("Status", typeof(string)).SetOrdinal(3);
                foreach (DataRow drow in table.Rows)
                {
                    drow["Status"] = "Present";
                }
                Dgv.DataSource = null;
                Dgv.DataSource = table;
            }
            else if(Unv_radio.Checked)
            {
                SqlCommand comm = new SqlCommand("select Seat,Reg_no,Name,Branch,Exam_Code,Course from University_Alloted Where Date=@Date and Session=@Session and Room_No=@Room_No order by Seat", con.ActiveCon());
                comm.Parameters.AddWithValue("@Date", Date_combobox.Text);
                comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                comm.Parameters.AddWithValue("@Room_No", Room_combobox.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.Columns.Add("Status", typeof(string)).SetOrdinal(3);
                foreach(DataRow drow in table.Rows)
                {
                    drow["Status"] = "Present";
                }                
                Dgv.DataSource = null;
                Dgv.DataSource = table;
            }
        }

        private void ChangeStatusEvent(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value is string value && value == "Present")
                {
                    cell.Value = "Absent";
                    cell.Style.ForeColor = Color.Red;                    
                }
                else if (cell.Value is string value2 && value2 == "Absent")
                {
                    cell.Value = "Present";
                    cell.Style.ForeColor = Color.Black;
                }
            }
        }

        private void Absentees_btn_Click(object sender, EventArgs e)
        {
            if (Dgv.Rows.Count != 0)
            {                
                SqlCommand command = new SqlCommand("Select Count(*) from Absentees where Date=@Date and Session=@Session and Room_No=@Room_No ", con.ActiveCon());
                command.Parameters.AddWithValue("@Date", Date_combobox.Text);
                command.Parameters.AddWithValue("@Session", Session_combobox.Text);
                command.Parameters.AddWithValue("@Room_No", Room_combobox.Text);
                int checkdt = (int)command.ExecuteScalar();
                if (checkdt== 0)
                {
                    foreach (DataGridViewRow row in Dgv.Rows)
                    {
                        SqlCommand comm = new SqlCommand("insert into Absentees(Reg_no,Name,Status,Branch,Exam_Code,Course,Date,Session,Room_No)Values(" + " @Reg_no,@Name,@Status,@Branch,@Exam_Code,@Course,@Date,@Session,@Room_No)", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Reg_no", row.Cells["Reg_no"].Value);
                            comm.Parameters.AddWithValue("@Name", row.Cells["Name"].Value);
                            comm.Parameters.AddWithValue("@Status", row.Cells["Status"].Value);
                            if (Unv_radio.Checked)
                                comm.Parameters.AddWithValue("@Branch", row.Cells["Branch"].Value);
                            else
                                comm.Parameters.AddWithValue("@Branch", row.Cells["Class"].Value);
                            comm.Parameters.AddWithValue("@Exam_Code", row.Cells["Exam_Code"].Value);
                            comm.Parameters.AddWithValue("@Course", row.Cells["Course"].Value);
                            comm.Parameters.AddWithValue("@Date", Date_combobox.Text);
                            comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                            comm.Parameters.AddWithValue("@Room_No", Room_combobox.Text);
                            comm.ExecuteNonQuery();
                    }
                    MessageBox.Show("Insert Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach(DataGridViewRow row in Dgv.Rows)
                    {
                        SqlCommand comm = new SqlCommand("update Absentees Set Status=@Status where Reg_no=@Reg_no and Name=@Name and Date=@Date and Session=@Session and Room_No=@Room_No", con.ActiveCon());
                        comm.Parameters.AddWithValue("@Reg_no", row.Cells["Reg_no"].Value);
                        comm.Parameters.AddWithValue("@Name", row.Cells["Name"].Value);
                        comm.Parameters.AddWithValue("@Status", row.Cells["Status"].Value);                        
                        comm.Parameters.AddWithValue("@Date", Date_combobox.Text);
                        comm.Parameters.AddWithValue("@Session", Session_combobox.Text);
                        comm.Parameters.AddWithValue("@Room_No", Room_combobox.Text);
                        comm.ExecuteNonQuery();
                    }
                    MessageBox.Show("Update Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Nothing to Save", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //private void Statement_form_btn_Click(object sender, EventArgs e)
        //{
        //    Absent_Statement ss = new Absent_Statement();
        //    ss.MdiParent = this;
        //    Panel.Controls.Add(ss);
        //    this.WindowState = FormWindowState.Maximized;
        //    ss.Show();            
        //}

        // we need clear data so in absentStatement old dates and records wont show
        private void ClearData_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete all previously entered data ? ", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result==DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("Delete Absentees", con.ActiveCon());
                command.ExecuteNonQuery();
                MessageBox.Show("Data Cleared", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}