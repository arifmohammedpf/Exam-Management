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
        DataTable table_roomPriority = new DataTable();
        void RoomsdgvFill()
        {
            try
            {
            //headerchkbox.Checked = false;
            SQLiteCommand command = new SQLiteCommand("select * from Rooms order by Priority", con.ActiveCon());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            adapter.Fill(table_roomPriority);
            Rooms_dgv.DataSource = table_roomPriority;                
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

        DataTable table_branchPriority = new DataTable();
        void BranchdgvFill()
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand("select * from Branch_Priority order by Priority", con.ActiveCon());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(table_branchPriority);
                BranchPriorityDgv.DataSource = table_branchPriority;
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
        //CheckBox headerchkbox = new CheckBox();
        private void examhall_Load(object sender, EventArgs e)
        {
            // below code added to timer
            //RoomsdgvFill();
            //FillCapacity();
            //Priority_combobox.SelectedIndex = 0;

            //Checkbox Column
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.Width = 30;
            checkbox.Name = "CheckboxColumn";
            Rooms_dgv.Columns.Insert(0, checkbox);

            //HeaderCheckBox
            //AddHeaderchckbox(); //header checkbox added to candidate dgv
            //headerchkbox.MouseClick += new MouseEventHandler(Headerchckbox_Mouseclick);
        }

        //void AddHeaderchckbox()
        //{
        //    //Locate Header Cell to place checkbox in correct position
        //    Point HeaderCellLocation = this.Rooms_dgv.GetCellDisplayRectangle(0, -1, true).Location;
        //    //place headercheckbox to the location
        //    headerchkbox.Location = new Point(HeaderCellLocation.X + 8 , HeaderCellLocation.Y + 13);
        //    headerchkbox.BackColor = Color.FromArgb(64, 0, 0);
        //    headerchkbox.Size = new Size(18, 18);
        //    //add checkbox into dgv
        //    Rooms_dgv.Controls.Add(headerchkbox);
        //}

        //private void Headerchckbox_Mouseclick(object sender, MouseEventArgs e)
        //{
        //    Headerchckboxclick((CheckBox)sender);
        //}

        ////headerchckbox click event
        //private void Headerchckboxclick(CheckBox Hcheckbox)
        //{
        //    foreach (DataGridViewRow row in Rooms_dgv.Rows)
        //        ((DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"]).Value = Hcheckbox.Checked;

        //    Rooms_dgv.RefreshEdit();
        //    Fill_checked_capacity();
        //}

        void FillCapacity()
        {
            try
            {
                int a, b, result_a = 0, result_b = 0;
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
            catch (Exception) { }
            
        }
        
        private void Save_button_Click(object sender, EventArgs e)
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
        private void DeleteRoom_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Do you really want to delete selected Rooms ?   ", "Confirm Deletion", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Warning);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
            {
                try
                {
                    int f = 0;
                    foreach (DataGridViewRow dr in Rooms_dgv.Rows)
                    {
                        bool chckselect = Convert.ToBoolean(dr.Cells["CheckboxColumn"].Value);
                        if (chckselect)
                        {
                            f = 1;
                            SQLiteCommand comm = new SQLiteCommand("Delete from Rooms where Priority=@Priority and Room_No=@Room_No", con.ActiveCon());
                            comm.Parameters.AddWithValue("@Room_No", dr.Cells["Room_No"].Value);
                            comm.Parameters.AddWithValue("@Priority", dr.Cells["Priority"].Value);
                            comm.ExecuteNonQuery();
                        }
                    }
                    if (f == 0)
                        msgbox.show("No Room selected to delete   ", "Error", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Error);
                    else
                    {
                        Cleardata();
                        msgbox.show("Selected Rooms deleted   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
                Cleardata();
                msgbox.show(RoomNo_textbox+" is created    ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
                Cleardata();
                msgbox.show(RoomNo_textbox.Text + " Updated     ", "Update Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
            BranchdgvFill();
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

        private void UpdateRoomPriority_btn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in Rooms_dgv.Rows)
                {
                    SQLiteCommand comm = new SQLiteCommand("Update Rooms set Priority=@Priority where Room_No=@Room_No", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Room_No", dr.Cells["Room_No"].Value);
                    comm.Parameters.AddWithValue("@Priority", dr.Cells["Priority"].Value);
                    comm.ExecuteNonQuery();
                }
                Cleardata();
                msgbox.show("Room Priority Updated   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
        private void UpdateBranchPriority_btn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in BranchPriorityDgv.Rows)
                {
                    SQLiteCommand comm = new SQLiteCommand("Update Branch_Priority set Priority=@Priority where Branch=@Branch", con.ActiveCon());
                    comm.Parameters.AddWithValue("@Branch", dr.Cells["Branch"].Value);
                    comm.Parameters.AddWithValue("@Priority", dr.Cells["Priority"].Value);
                    comm.ExecuteNonQuery();
                }
                Cleardata();
                msgbox.show("Branch Priority Updated   ", "Success", CustomMessageBox.MessageBoxButtons.OK, CustomMessageBox.MessageBoxIcon.Information);
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
            foreach (DataGridViewRow row in Rooms_dgv.SelectedRows)
            {
                RoomNo_textbox.Text = row.Cells["Room_No"].Value.ToString();
                Priority_combobox.SelectedItem = row.Cells["Priority"].Value.ToString();
                A_series_textbox.Text = row.Cells["A_Series"].Value.ToString();
                B_series_textbox.Text = row.Cells["B_Series"].Value.ToString();
                break;
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            RoomsdgvFill();
            BranchdgvFill();
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

        //Drag Drop Feature of Room Priority DGV
        private Rectangle dragBoxFromMouseDown_Room;
        private int rowIndexFromMouseDown_Room;
        private int rowIndexOfItemUnderMouseToDrop_Room = 0;
        private void Rooms_dgv_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown_Room != Rectangle.Empty && !dragBoxFromMouseDown_Room.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = Rooms_dgv.DoDragDrop(Rooms_dgv.Rows[rowIndexFromMouseDown_Room], DragDropEffects.Move);
                }
            }
        }
        private void Rooms_dgv_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown_Room = Rooms_dgv.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown_Room != -1)
            {
                // Remember the point where the mouse down occurred.
                // The DragSize indicates the size that the mouse can move
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown_Room = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown_Room = Rectangle.Empty;
            }
        }
        private void Rooms_dgv_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            //autoScroll
            if (e.Y <= PointToScreen(new Point(Rooms_dgv.Location.X, Rooms_dgv.Location.Y)).Y + 50)
                if (Rooms_dgv.FirstDisplayedScrollingRowIndex != 0)
                {
                    Rooms_dgv.FirstDisplayedScrollingRowIndex -= 1;
                }
            if (e.Y >= PointToScreen(new Point(Rooms_dgv.Location.X + Rooms_dgv.Width, Rooms_dgv.Location.Y + Rooms_dgv.Height)).Y - 5)
                Rooms_dgv.FirstDisplayedScrollingRowIndex += 1;
        }
        private void Rooms_dgv_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // The mouse locations are relative to the screen, so they must be
                // converted to client coordinates.
                Point clientPoint = Rooms_dgv.PointToClient(new Point(e.X, e.Y));

                // Get the row index of the item the mouse is below.
                rowIndexOfItemUnderMouseToDrop_Room = Rooms_dgv.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move)
                {
                    if (rowIndexOfItemUnderMouseToDrop_Room != -1)
                    {
                        DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                        // find the row to move in the datasource:
                        DataRow oldrow = ((DataRowView)rowToMove.DataBoundItem).Row;
                        // clone it:
                        DataRow newrow = table_roomPriority.NewRow();
                        newrow.ItemArray = oldrow.ItemArray;

                        table_roomPriority.Rows.Remove(oldrow);
                        table_roomPriority.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop_Room);

                        //if (rowToMove.Index < 0)
                        //{
                        //    return;
                        //}
                        //if (rowIndexFromMouseDown_Room < rowIndexOfItemUnderMouseToDrop_Room)
                        //{
                        //    table_roomPriority.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop_Room - 1);
                        //    table_roomPriority.Rows.Remove(oldrow);
                        //}
                        //else if (rowIndexFromMouseDown_Room > rowIndexOfItemUnderMouseToDrop_Room)
                        //{
                        //    table_roomPriority.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop_Room);
                        //    table_roomPriority.Rows.Remove(oldrow);
                        //}

                        //loop through dgv and set priority manually
                        int set_priority = 1;
                        foreach (DataGridViewRow row in Rooms_dgv.Rows)
                        {
                            row.Cells["Priority"].Value = set_priority;
                            set_priority++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        //Drag Drop Feature of Branch Priority DGV
        private Rectangle dragBoxFromMouseDown_Branch;
        private int rowIndexFromMouseDown_Branch;
        private int rowIndexOfItemUnderMouseToDrop_Branch = 0;
        private void BranchPriorityDgv_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown_Branch != Rectangle.Empty && !dragBoxFromMouseDown_Branch.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                   
                    DragDropEffects dropEffect = BranchPriorityDgv.DoDragDrop(BranchPriorityDgv.Rows[rowIndexFromMouseDown_Branch], DragDropEffects.Move);
                }
            }
        }
        private void BranchPriorityDgv_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown_Branch = BranchPriorityDgv.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown_Branch != -1)
            {
                // Remember the point where the mouse down occurred.
                // The DragSize indicates the size that the mouse can move
                // before a drag event should be started.               
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown_Branch = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown_Branch = Rectangle.Empty;
            }
        }
        private void BranchPriorityDgv_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            try
            {
                //autoScroll
                if (e.Y <= PointToScreen(new Point(BranchPriorityDgv.Location.X, BranchPriorityDgv.Location.Y)).Y + 50)
                    BranchPriorityDgv.FirstDisplayedScrollingRowIndex -= 1;

                if (e.Y >= PointToScreen(new Point(BranchPriorityDgv.Location.X + BranchPriorityDgv.Width, BranchPriorityDgv.Location.Y + BranchPriorityDgv.Height)).Y - 50)
                    BranchPriorityDgv.FirstDisplayedScrollingRowIndex += 1;
            }
            catch(Exception)
            {
                
            }
        }
        private void BranchPriorityDgv_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // The mouse locations are relative to the screen, so they must be
                // converted to client coordinates.
                Point clientPoint = BranchPriorityDgv.PointToClient(new Point(e.X, e.Y));

                // Get the row index of the item the mouse is below.
                rowIndexOfItemUnderMouseToDrop_Branch = BranchPriorityDgv.HitTest(clientPoint.X, clientPoint.Y).RowIndex;                

                // If the drag operation was a move then remove and insert the row.
                if (e.Effect == DragDropEffects.Move)
                {
                    if (rowIndexOfItemUnderMouseToDrop_Branch != -1)
                    {
                        DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                        // find the row to move in the datasource:
                        DataRow oldrow = ((DataRowView)rowToMove.DataBoundItem).Row;
                        // clone it:
                        DataRow newrow = table_branchPriority.NewRow();
                        newrow.ItemArray = oldrow.ItemArray;

                        table_branchPriority.Rows.Remove(oldrow);
                        table_branchPriority.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop_Branch);

                        //loop through dgv and set priority manually
                        int set_priority = 1;
                        foreach (DataGridViewRow row in BranchPriorityDgv.Rows)
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
                        //    table_branchPriority.Rows.Remove(oldrow);
                        //    table_branchPriority.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop-1);
                        //}
                        //else if (rowIndexFromMouseDown > rowIndexOfItemUnderMouseToDrop)
                        //{
                        //    table_branchPriority.Rows.Remove(oldrow);
                        //    table_branchPriority.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        
    }
}