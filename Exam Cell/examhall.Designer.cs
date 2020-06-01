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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotalCapacity_textbox = new System.Windows.Forms.TextBox();
            this.TotalRoom_textbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PreviousPriority_button = new System.Windows.Forms.Button();
            this.OrderPriority_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.B_series_textbox = new System.Windows.Forms.TextBox();
            this.A_series_textbox = new System.Windows.Forms.TextBox();
            this.RoomNo_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Rooms_dgv = new System.Windows.Forms.DataGridView();
            this.exam_Cell_Rooms = new Exam_Cell.Exam_Cell_Rooms();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomsTableAdapter = new Exam_Cell.Exam_Cell_RoomsTableAdapters.RoomsTableAdapter();
            this.Priority_combobox = new System.Windows.Forms.ComboBox();
            this.roomsTableAdapter1 = new Exam_Cell.Exam_Cell_RoomsTableAdapters.RoomsTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rooms_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_Cell_Rooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(17, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 91);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Exam_Cell.Properties.Resources.kmea_hd_logo_shabz_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(4, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Priority_combobox);
            this.panel2.Controls.Add(this.TotalCapacity_textbox);
            this.panel2.Controls.Add(this.TotalRoom_textbox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.PreviousPriority_button);
            this.panel2.Controls.Add(this.OrderPriority_button);
            this.panel2.Controls.Add(this.Save_button);
            this.panel2.Controls.Add(this.B_series_textbox);
            this.panel2.Controls.Add(this.A_series_textbox);
            this.panel2.Controls.Add(this.RoomNo_textbox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Rooms_dgv);
            this.panel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(21, 114);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 424);
            this.panel2.TabIndex = 1;
            // 
            // TotalCapacity_textbox
            // 
            this.TotalCapacity_textbox.Location = new System.Drawing.Point(131, 383);
            this.TotalCapacity_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.TotalCapacity_textbox.Name = "TotalCapacity_textbox";
            this.TotalCapacity_textbox.ReadOnly = true;
            this.TotalCapacity_textbox.Size = new System.Drawing.Size(132, 25);
            this.TotalCapacity_textbox.TabIndex = 15;
            // 
            // TotalRoom_textbox
            // 
            this.TotalRoom_textbox.Location = new System.Drawing.Point(131, 343);
            this.TotalRoom_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.TotalRoom_textbox.Name = "TotalRoom_textbox";
            this.TotalRoom_textbox.ReadOnly = true;
            this.TotalRoom_textbox.Size = new System.Drawing.Size(132, 25);
            this.TotalRoom_textbox.TabIndex = 14;
            this.TotalRoom_textbox.TextChanged += new System.EventHandler(this.TotalRoom_textbox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 386);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total Capacity :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 351);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total Room :";
            // 
            // PreviousPriority_button
            // 
            this.PreviousPriority_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PreviousPriority_button.Location = new System.Drawing.Point(39, 300);
            this.PreviousPriority_button.Margin = new System.Windows.Forms.Padding(4);
            this.PreviousPriority_button.Name = "PreviousPriority_button";
            this.PreviousPriority_button.Size = new System.Drawing.Size(176, 28);
            this.PreviousPriority_button.TabIndex = 11;
            this.PreviousPriority_button.Text = "Previous Priority";
            this.PreviousPriority_button.UseVisualStyleBackColor = true;
            this.PreviousPriority_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // OrderPriority_button
            // 
            this.OrderPriority_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OrderPriority_button.Location = new System.Drawing.Point(39, 265);
            this.OrderPriority_button.Margin = new System.Windows.Forms.Padding(4);
            this.OrderPriority_button.Name = "OrderPriority_button";
            this.OrderPriority_button.Size = new System.Drawing.Size(176, 28);
            this.OrderPriority_button.TabIndex = 10;
            this.OrderPriority_button.Text = "Order Priority";
            this.OrderPriority_button.UseVisualStyleBackColor = true;
            // 
            // Save_button
            // 
            this.Save_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Save_button.Location = new System.Drawing.Point(39, 229);
            this.Save_button.Margin = new System.Windows.Forms.Padding(4);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(176, 28);
            this.Save_button.TabIndex = 9;
            this.Save_button.Text = "Save";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // B_series_textbox
            // 
            this.B_series_textbox.Location = new System.Drawing.Point(4, 183);
            this.B_series_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.B_series_textbox.Name = "B_series_textbox";
            this.B_series_textbox.Size = new System.Drawing.Size(259, 25);
            this.B_series_textbox.TabIndex = 8;
            // 
            // A_series_textbox
            // 
            this.A_series_textbox.Location = new System.Drawing.Point(4, 135);
            this.A_series_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.A_series_textbox.Name = "A_series_textbox";
            this.A_series_textbox.Size = new System.Drawing.Size(259, 25);
            this.A_series_textbox.TabIndex = 7;
            // 
            // RoomNo_textbox
            // 
            this.RoomNo_textbox.Location = new System.Drawing.Point(4, 39);
            this.RoomNo_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.RoomNo_textbox.Name = "RoomNo_textbox";
            this.RoomNo_textbox.Size = new System.Drawing.Size(259, 25);
            this.RoomNo_textbox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "B Series";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "A Series";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Priority";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room No :";
            // 
            // Rooms_dgv
            // 
            this.Rooms_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Rooms_dgv.Location = new System.Drawing.Point(283, 1);
            this.Rooms_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.Rooms_dgv.Name = "Rooms_dgv";
            this.Rooms_dgv.Size = new System.Drawing.Size(735, 416);
            this.Rooms_dgv.TabIndex = 0;
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
            // Priority_combobox
            // 
            this.Priority_combobox.FormattingEnabled = true;
            this.Priority_combobox.Items.AddRange(new object[] {
            "-Select-",
            "High",
            "Low"});
            this.Priority_combobox.Location = new System.Drawing.Point(7, 89);
            this.Priority_combobox.Name = "Priority_combobox";
            this.Priority_combobox.Size = new System.Drawing.Size(256, 26);
            this.Priority_combobox.TabIndex = 16;
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
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "examhall";
            this.Text = "Exam Hall Settings";
            this.Load += new System.EventHandler(this.examhall_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rooms_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_Cell_Rooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button PreviousPriority_button;
        private System.Windows.Forms.Button OrderPriority_button;
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
    }
}