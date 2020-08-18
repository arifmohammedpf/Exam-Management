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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(examhall));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Rooms_dgv = new System.Windows.Forms.DataGridView();
            this.Priority_combobox = new System.Windows.Forms.ComboBox();
            this.TotalCapacity_textbox = new System.Windows.Forms.TextBox();
            this.TotalRoom_textbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.UpdatePriority_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.B_series_textbox = new System.Windows.Forms.TextBox();
            this.A_series_textbox = new System.Windows.Forms.TextBox();
            this.RoomNo_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exam_Cell_Rooms = new Exam_Cell.Exam_Cell_Rooms();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomsTableAdapter = new Exam_Cell.Exam_Cell_RoomsTableAdapters.RoomsTableAdapter();
            this.roomsTableAdapter1 = new Exam_Cell.Exam_Cell_RoomsTableAdapters.RoomsTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rooms_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_Cell_Rooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 91);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Exam_Cell.Properties.Resources.kmea_hd_logo_shabz_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1034, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.Priority_combobox);
            this.panel2.Controls.Add(this.TotalCapacity_textbox);
            this.panel2.Controls.Add(this.TotalRoom_textbox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.UpdatePriority_button);
            this.panel2.Controls.Add(this.Save_button);
            this.panel2.Controls.Add(this.B_series_textbox);
            this.panel2.Controls.Add(this.A_series_textbox);
            this.panel2.Controls.Add(this.RoomNo_textbox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 577);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Rooms_dgv);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(406, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(617, 560);
            this.panel3.TabIndex = 17;
            // 
            // Rooms_dgv
            // 
            this.Rooms_dgv.AllowUserToAddRows = false;
            this.Rooms_dgv.AllowUserToDeleteRows = false;
            this.Rooms_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Rooms_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Rooms_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rooms_dgv.Location = new System.Drawing.Point(0, 0);
            this.Rooms_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.Rooms_dgv.Name = "Rooms_dgv";
            this.Rooms_dgv.Size = new System.Drawing.Size(617, 560);
            this.Rooms_dgv.TabIndex = 0;
            this.Rooms_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Rooms_dgv_CellClick);
            this.Rooms_dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Rooms_dgv_CellEndEdit);
            this.Rooms_dgv.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Rooms_dgv_CellMouseUp);
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
            this.Priority_combobox.Location = new System.Drawing.Point(21, 93);
            this.Priority_combobox.Name = "Priority_combobox";
            this.Priority_combobox.Size = new System.Drawing.Size(307, 32);
            this.Priority_combobox.TabIndex = 16;
            // 
            // TotalCapacity_textbox
            // 
            this.TotalCapacity_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalCapacity_textbox.Location = new System.Drawing.Point(249, 529);
            this.TotalCapacity_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.TotalCapacity_textbox.Name = "TotalCapacity_textbox";
            this.TotalCapacity_textbox.ReadOnly = true;
            this.TotalCapacity_textbox.Size = new System.Drawing.Size(132, 33);
            this.TotalCapacity_textbox.TabIndex = 15;
            // 
            // TotalRoom_textbox
            // 
            this.TotalRoom_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalRoom_textbox.Location = new System.Drawing.Point(249, 478);
            this.TotalRoom_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.TotalRoom_textbox.Name = "TotalRoom_textbox";
            this.TotalRoom_textbox.ReadOnly = true;
            this.TotalRoom_textbox.Size = new System.Drawing.Size(132, 33);
            this.TotalRoom_textbox.TabIndex = 14;
            this.TotalRoom_textbox.TextChanged += new System.EventHandler(this.TotalRoom_textbox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 537);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total Capacity :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 486);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total Room :";
            // 
            // UpdatePriority_button
            // 
            this.UpdatePriority_button.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePriority_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UpdatePriority_button.Location = new System.Drawing.Point(26, 285);
            this.UpdatePriority_button.Margin = new System.Windows.Forms.Padding(4);
            this.UpdatePriority_button.Name = "UpdatePriority_button";
            this.UpdatePriority_button.Size = new System.Drawing.Size(251, 44);
            this.UpdatePriority_button.TabIndex = 11;
            this.UpdatePriority_button.Text = "Update Selected Priority";
            this.UpdatePriority_button.UseVisualStyleBackColor = true;
            this.UpdatePriority_button.Click += new System.EventHandler(this.UpdatePriority_button_Click);
            // 
            // Save_button
            // 
            this.Save_button.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Save_button.Location = new System.Drawing.Point(50, 242);
            this.Save_button.Margin = new System.Windows.Forms.Padding(4);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(202, 37);
            this.Save_button.TabIndex = 9;
            this.Save_button.Text = "Save";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // B_series_textbox
            // 
            this.B_series_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_series_textbox.Location = new System.Drawing.Point(18, 201);
            this.B_series_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.B_series_textbox.Name = "B_series_textbox";
            this.B_series_textbox.Size = new System.Drawing.Size(310, 33);
            this.B_series_textbox.TabIndex = 8;
            // 
            // A_series_textbox
            // 
            this.A_series_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A_series_textbox.Location = new System.Drawing.Point(18, 146);
            this.A_series_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.A_series_textbox.Name = "A_series_textbox";
            this.A_series_textbox.Size = new System.Drawing.Size(310, 33);
            this.A_series_textbox.TabIndex = 7;
            // 
            // RoomNo_textbox
            // 
            this.RoomNo_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomNo_textbox.Location = new System.Drawing.Point(18, 38);
            this.RoomNo_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.RoomNo_textbox.Name = "RoomNo_textbox";
            this.RoomNo_textbox.Size = new System.Drawing.Size(310, 33);
            this.RoomNo_textbox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "B Series";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "A Series";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Priority";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room No :";
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
            this.ClientSize = new System.Drawing.Size(1034, 668);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "examhall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam Hall Settings";
            this.Load += new System.EventHandler(this.examhall_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Rooms_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_Cell_Rooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.DataGridView Rooms_dgv;
        private System.Windows.Forms.TextBox TotalCapacity_textbox;
        private System.Windows.Forms.TextBox TotalRoom_textbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Exam_Cell_Rooms exam_Cell_Rooms;
        private System.Windows.Forms.BindingSource roomsBindingSource;
        private Exam_Cell_RoomsTableAdapters.RoomsTableAdapter roomsTableAdapter;
        private System.Windows.Forms.ComboBox Priority_combobox;
        private Exam_Cell_RoomsTableAdapters.RoomsTableAdapter roomsTableAdapter1;
        private System.Windows.Forms.Panel panel3;
    }
}