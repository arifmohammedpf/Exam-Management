using Exam_Cell.Forms;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Exam_Cell
{
    public partial class examhall : Form
    {
        Connection con = new Connection();
        CustomMessageBox msgbox = new CustomMessageBox();
        public examhall()
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
            DataTable table_scheme = new DataTable();
        void RoomsdgvFill()
        {
            try
            {
            headerchkbox.Checked = false;
            SQLiteCommand command = new SQLiteCommand("select * from Rooms order by Priority", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table_scheme);
            Rooms_dgv.DataSource = table_scheme;
                BranchPriorityDgv.DataSource = table_scheme;
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
        CheckBox headerchkbox = new CheckBox();
        private void examhall_Load(object sender, EventArgs e)
        {
            // below code added to timer
            //RoomsdgvFill();
            //FillCapacity();
            //Priority_combobox.SelectedIndex = 0;

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
            //Locate Header Cell to place checkbox in correct position
            Point HeaderCellLocation = this.Rooms_dgv.GetCellDisplayRectangle(0, -1, true).Location;
            //place headercheckbox to the location
            headerchkbox.Location = new Point(HeaderCellLocation.X + 8 , HeaderCellLocation.Y + 13);
            headerchkbox.BackColor = Color.FromArgb(64, 0, 0);
            headerchkbox.Size = new Size(18, 18);
            //add checkbox into dgv
            Rooms_dgv.Controls.Add(headerchkbox);
        }

        private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        {
            Headerchckboxclick((CheckBox)sender);
        }

        //headerchckbox click event
        private void Headerchckboxclick(CheckBox Hcheckbox)
        {
            foreach (DataGridViewRow row in Rooms_dgv.Rows)
                ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

            Rooms_dgv.RefreshEdit();
            Fill_checked_capacity();
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
            msgbox.show("Click Yes to Save   ", "Confirm", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Warning);
            var result = msgbox.ReturnValue;
            if (result=="Yes")
            {
                if (Priority_combobox.SelectedIndex != 0)
                {
                    int flag = 0;
                    if (Rooms_dgv.RowCount.ToString() != "0" && RoomNo_textbox.Text != "")
                    {
                        foreach (DataGridViewRow dr in Rooms_dgv.Rows)
                        {
                            if (RoomNo_textbox.Text.Equals(dr.Cells["Room_No"].Value.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                flag = 1;
                            }

                        }
                        if (flag == 1)
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
                        msgbox.show("Enter Room     ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    msgbox.show("Select Priority    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                }
            }
        }

        void SqlInsertCommand()
        {
            try
            {
            if (int.TryParse(A_series_textbox.Text, out int a) && int.TryParse(B_series_textbox.Text, out int b))
            {
                SQLiteCommand comm = new SQLiteCommand("Insert into Rooms(Room_No,Priority,A_Series,B_Series)Values(" + "@RoomNo,@Priority,@A_series,@B_series)", con.ActiveCon());
                comm.Parameters.AddWithValue("@RoomNo", RoomNo_textbox.Text);
                comm.Parameters.AddWithValue("@Priority", Priority_combobox.SelectedItem);
                comm.Parameters.AddWithValue("@A_series", a);
                comm.Parameters.AddWithValue("@B_series", b);
                comm.ExecuteNonQuery();
                msgbox.show("New Room Saved    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                Cleardata();
            }
            else
            {
                msgbox.show("A & B Series must be Numbers     ","Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error); 
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

        void SqlUpdateCommand()
        {
            try
            {
            if (int.TryParse(A_series_textbox.Text, out int a) && int.TryParse(B_series_textbox.Text, out int b))
            {
                SQLiteCommand comm = new SQLiteCommand("Update Rooms set Priority=@Priority,A_Series=@A_series,B_Series=@B_series where Room_No=@RoomNo", con.ActiveCon());
                comm.Parameters.AddWithValue("@RoomNo", RoomNo_textbox.Text);
                comm.Parameters.AddWithValue("@Priority", Priority_combobox.SelectedItem);
                comm.Parameters.AddWithValue("@A_series", a);
                comm.Parameters.AddWithValue("@B_series", b);
                comm.ExecuteNonQuery();
                msgbox.show(RoomNo_textbox.Text + " Updated     ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                Cleardata();
            }
            else
            {
                msgbox.show("A & B Series must be Numbers    ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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

        void Cleardata()
        {
            RoomNo_textbox.ResetText();
            Priority_combobox.SelectedIndex = 0;
            A_series_textbox.ResetText();
            B_series_textbox.ResetText();
            RoomsdgvFill();
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

                    
            

        


        ////////update capacity textbox when checkbox is clicked...
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
        ////////...
       
        private void UpdatePriority_button_Click(object sender, EventArgs e)
        {
            try
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
                        SQLiteCommand comm = new SQLiteCommand("Update Rooms set Priority=@Priority where Room_No=@Room_No", con.ActiveCon());
                        comm.Parameters.AddWithValue("@Room_No", dr.Cells["Room_No"].Value);
                        comm.Parameters.AddWithValue("@Priority", Priority_combobox.SelectedItem);
                        comm.ExecuteNonQuery();                        
                    }
                }
                if(f==0)
                    msgbox.show("No Selection made   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                else
                    msgbox.show("Selected Priority Updated   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
                Cleardata();
            }
            else
                msgbox.show("Select A Priority   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
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

        // auto fill boxes
        private void Rooms_dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            if (f == 0)
            {
                foreach (DataGridViewRow row in Rooms_dgv.SelectedRows)
                {
                    RoomNo_textbox.Text = row.Cells["Room_No"].Value.ToString();
                    Priority_combobox.SelectedItem = row.Cells["Priority"].Value.ToString();
                    A_series_textbox.Text = row.Cells["A_Series"].Value.ToString();
                    B_series_textbox.Text = row.Cells["B_Series"].Value.ToString();
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            RoomsdgvFill();
            FillCapacity();
            Priority_combobox.SelectedIndex = 0;
        }
        
        private void closeBtn_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = (MenuForm)Application.OpenForms["MenuForm"];
            if (menuForm.Temp_btn == menuForm.menu_item_room)
                menuForm.Temp_btn = null;
            menuForm.menu_item_room.BackColor = Color.FromArgb(48, 43, 99);
            menuForm.room_open = false;
            this.Close();
        }

        //Drag Drop Feature
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void BranchPriorityDgv_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)                
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = BranchPriorityDgv.DoDragDrop(BranchPriorityDgv.Rows[rowIndexFromMouseDown],DragDropEffects.Move);
                }
            }
        }
        private void BranchPriorityDgv_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = BranchPriorityDgv.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred.
                // The DragSize indicates the size that the mouse can move
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }
        private void BranchPriorityDgv_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void BranchPriorityDgv_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be
            // converted to client coordinates.
            Point clientPoint = BranchPriorityDgv.PointToClient(new Point(e.X, e.Y));
            
            // Get the row index of the item the mouse is below.
            rowIndexOfItemUnderMouseToDrop = BranchPriorityDgv.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            
            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                // find the row to move in the datasource:
                DataRow oldrow = ((DataRowView)rowToMove.DataBoundItem).Row;
                // clone it:
                DataRow newrow = table_scheme.NewRow();
                newrow.ItemArray = oldrow.ItemArray;

                table_scheme.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop);
                table_scheme.Rows.Remove(oldrow);

                //loop through dgv and set priority manually
                int set_priority = 1;
                foreach(DataGridViewRow row in BranchPriorityDgv.Rows)
                {
                    row.Cells["Priority"].Value = set_priority;
                    set_priority++;
                }

                //if (rowToMove.Index < 0)
                //{
                //    return;
                //}
                //if (rowIndexFromMouseDown < rowIndexOfItemUnderMouseToDrop)
                //{
                //    table_scheme.Rows.Remove(oldrow);
                //    table_scheme.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop-1);
                //}
                //else if (rowIndexFromMouseDown > rowIndexOfItemUnderMouseToDrop)
                //{
                //    table_scheme.Rows.Remove(oldrow);
                //    table_scheme.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop);
                //}
            }
        }   
    }
}