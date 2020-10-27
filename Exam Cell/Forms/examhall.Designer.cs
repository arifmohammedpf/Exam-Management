namespace Exam_Cell
{
    partial class examhall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(examhall));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RoomNo_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Priority_combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalCapacity_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalRoom_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.A_series_textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.B_series_textbox = new System.Windows.Forms.TextBox();
            this.UpdatePriority_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.Rooms_dgv = new System.Windows.Forms.DataGridView();
            this.exam_Cell_Rooms = new Exam_Cell.Exam_Cell_Rooms();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomsTableAdapter = new Exam_Cell.Exam_Cell_RoomsTableAdapters.RoomsTableAdapter();
            this.roomsTableAdapter1 = new Exam_Cell.Exam_Cell_RoomsTableAdapters.RoomsTableAdapter();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rooms_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_Cell_Rooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.Rooms_dgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1277, 739);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.RoomNo_textbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Priority_combobox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TotalCapacity_textbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TotalRoom_textbox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.A_series_textbox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.B_series_textbox);
            this.panel1.Controls.Add(this.UpdatePriority_button);
            this.panel1.Controls.Add(this.Save_button);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 714);
            this.panel1.TabIndex = 18;
            // 
            // RoomNo_textbox
            // 
            this.RoomNo_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomNo_textbox.Location = new System.Drawing.Point(120, 114);
            this.RoomNo_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.RoomNo_textbox.Name = "RoomNo_textbox";
            this.RoomNo_textbox.Size = new System.Drawing.Size(310, 33);
            this.RoomNo_textbox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(120, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room No :";
            // 
            // Priority_combobox
            // 
            this.Priority_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Priority_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Priority_combobox.FormattingEnabled = true;
            this.Priority_combobox.Items.AddRange(new object[] {
            "-Select-",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.Priority_combobox.Location = new System.Drawing.Point(120, 182);
            this.Priority_combobox.Name = "Priority_combobox";
            this.Priority_combobox.Size = new System.Drawing.Size(307, 32);
            this.Priority_combobox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(120, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Priority";
            // 
            // TotalCapacity_textbox
            // 
            this.TotalCapacity_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCapacity_textbox.Location = new System.Drawing.Point(284, 665);
            this.TotalCapacity_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.TotalCapacity_textbox.Name = "TotalCapacity_textbox";
            this.TotalCapacity_textbox.ReadOnly = true;
            this.TotalCapacity_textbox.Size = new System.Drawing.Size(232, 33);
            this.TotalCapacity_textbox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(120, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "A Series";
            // 
            // TotalRoom_textbox
            // 
            this.TotalRoom_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalRoom_textbox.Location = new System.Drawing.Point(284, 614);
            this.TotalRoom_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.TotalRoom_textbox.Name = "TotalRoom_textbox";
            this.TotalRoom_textbox.ReadOnly = true;
            this.TotalRoom_textbox.Size = new System.Drawing.Size(232, 33);
            this.TotalRoom_textbox.TabIndex = 14;
            this.TotalRoom_textbox.TextChanged += new System.EventHandler(this.TotalRoom_textbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(120, 291);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "B Series";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(116, 673);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total Capacity :";
            // 
            // A_series_textbox
            // 
            this.A_series_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A_series_textbox.Location = new System.Drawing.Point(120, 248);
            this.A_series_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.A_series_textbox.Name = "A_series_textbox";
            this.A_series_textbox.Size = new System.Drawing.Size(310, 33);
            this.A_series_textbox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(116, 622);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total Room :";
            // 
            // B_series_textbox
            // 
            this.B_series_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_series_textbox.Location = new System.Drawing.Point(120, 317);
            this.B_series_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.B_series_textbox.Name = "B_series_textbox";
            this.B_series_textbox.Size = new System.Drawing.Size(310, 33);
            this.B_series_textbox.TabIndex = 8;
            // 
            // UpdatePriority_button
            // 
            this.UpdatePriority_button.BackColor = System.Drawing.Color.Olive;
            this.UpdatePriority_button.FlatAppearance.BorderSize = 0;
            this.UpdatePriority_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.UpdatePriority_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdatePriority_button.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePriority_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UpdatePriority_button.Location = new System.Drawing.Point(117, 437);
            this.UpdatePriority_button.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePriority_button.Name = "UpdatePriority_button";
            this.UpdatePriority_button.Size = new System.Drawing.Size(316, 44);
            this.UpdatePriority_button.TabIndex = 11;
            this.UpdatePriority_button.Text = "Update Selected Priority";
            this.UpdatePriority_button.UseVisualStyleBackColor = false;
            this.UpdatePriority_button.Click += new System.EventHandler(this.UpdatePriority_button_Click);
            // 
            // Save_button
            // 
            this.Save_button.BackColor = System.Drawing.Color.DarkGreen;
            this.Save_button.FlatAppearance.BorderSize = 0;
            this.Save_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.Save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_button.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Save_button.Location = new System.Drawing.Point(174, 375);
            this.Save_button.Margin = new System.Windows.Forms.Padding(4);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(202, 44);
            this.Save_button.TabIndex = 9;
            this.Save_button.Text = "Save";
            this.Save_button.UseVisualStyleBackColor = false;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // Rooms_dgv
            // 
            this.Rooms_dgv.AllowUserToAddRows = false;
            this.Rooms_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Rooms_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Rooms_dgv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Rooms_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Rooms_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Rooms_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.Rooms_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rooms_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Rooms_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Rooms_dgv.ColumnHeadersHeight = 40;
            this.Rooms_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Rooms_dgv.EnableHeadersVisualStyles = false;
            this.Rooms_dgv.GridColor = System.Drawing.Color.SteelBlue;
            this.Rooms_dgv.Location = new System.Drawing.Point(599, 11);
            this.Rooms_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.Rooms_dgv.Name = "Rooms_dgv";
            this.Rooms_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Rooms_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.Rooms_dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Rooms_dgv.Size = new System.Drawing.Size(531, 713);
            this.Rooms_dgv.TabIndex = 17;
            this.Rooms_dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Rooms_dgv_CellEndEdit);
            this.Rooms_dgv.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Rooms_dgv_CellMouseUp);
            this.Rooms_dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Rooms_dgv_RowHeaderMouseClick);
            // 
            // exam_Cell_Rooms
            // 
            this.exam_Cell_Rooms.DataSetName = "Exam_Cell_Rooms";
            this.exam_Cell_Rooms.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roomsBindingSource
            // 
            this.roomsBindingSource.DataMember = "Rooms";
            this.roomsBindingSource.DataSource = this.exam_Cell_Rooms;
            // 
            // roomsTableAdapter
            // 
            this.roomsTableAdapter.ClearBeforeFill = true;
            // 
            // roomsTableAdapter1
            // 
            this.roomsTableAdapter1.ClearBeforeFill = true;
            // 
            // examhall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1277, 739);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "examhall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam Hall Settings";
            this.Load += new System.EventHandler(this.examhall_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rooms_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_Cell_Rooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button UpdatePriority_button;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.TextBox B_series_textbox;
        private System.Windows.Forms.TextBox A_series_textbox;
        private System.Windows.Forms.TextBox RoomNo_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TotalCapacity_textbox;
        private System.Windows.Forms.TextBox TotalRoom_textbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Exam_Cell_Rooms exam_Cell_Rooms;
        private System.Windows.Forms.BindingSource roomsBindingSource;
        private Exam_Cell_RoomsTableAdapters.RoomsTableAdapter roomsTableAdapter;
        private System.Windows.Forms.ComboBox Priority_combobox;
        private Exam_Cell_RoomsTableAdapters.RoomsTableAdapter roomsTableAdapter1;
        private System.Windows.Forms.DataGridView Rooms_dgv;
        private System.Windows.Forms.Panel panel1;
    }
}