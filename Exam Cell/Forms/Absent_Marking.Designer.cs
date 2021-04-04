namespace Exam_Cell
{
    partial class Absent_Marking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Absent_Marking));
            this.Panel = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Series_radio = new System.Windows.Forms.RadioButton();
            this.Unv_radio = new System.Windows.Forms.RadioButton();
            this.Search_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearData_btn = new System.Windows.Forms.Button();
            this.Absentees_btn = new System.Windows.Forms.Button();
            this.Room_combobox = new System.Windows.Forms.ComboBox();
            this.Session_combobox = new System.Windows.Forms.ComboBox();
            this.Date_combobox = new System.Windows.Forms.ComboBox();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.AutoScroll = true;
            this.Panel.BackColor = System.Drawing.Color.Transparent;
            this.Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel.Controls.Add(this.closeBtn);
            this.Panel.Controls.Add(this.panel1);
            this.Panel.Controls.Add(this.Dgv);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1280, 720);
            this.Panel.TabIndex = 7;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeBtn.Location = new System.Drawing.Point(1233, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(35, 35);
            this.closeBtn.TabIndex = 18;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.Search_btn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ClearData_btn);
            this.panel1.Controls.Add(this.Absentees_btn);
            this.panel1.Controls.Add(this.Room_combobox);
            this.panel1.Controls.Add(this.Session_combobox);
            this.panel1.Controls.Add(this.Date_combobox);
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 675);
            this.panel1.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.Series_radio);
            this.groupBox3.Controls.Add(this.Unv_radio);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(97, 69);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(376, 79);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Exam";
            // 
            // Series_radio
            // 
            this.Series_radio.AutoSize = true;
            this.Series_radio.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Series_radio.Location = new System.Drawing.Point(240, 30);
            this.Series_radio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Series_radio.Name = "Series_radio";
            this.Series_radio.Size = new System.Drawing.Size(80, 26);
            this.Series_radio.TabIndex = 20;
            this.Series_radio.Text = "Series";
            this.Series_radio.UseVisualStyleBackColor = true;
            this.Series_radio.CheckedChanged += new System.EventHandler(this.Series_radio_CheckedChanged);
            // 
            // Unv_radio
            // 
            this.Unv_radio.AutoSize = true;
            this.Unv_radio.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unv_radio.Location = new System.Drawing.Point(36, 30);
            this.Unv_radio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Unv_radio.Name = "Unv_radio";
            this.Unv_radio.Size = new System.Drawing.Size(117, 26);
            this.Unv_radio.TabIndex = 19;
            this.Unv_radio.Text = "University";
            this.Unv_radio.UseVisualStyleBackColor = true;
            this.Unv_radio.CheckedChanged += new System.EventHandler(this.Unv_radio_CheckedChanged);
            // 
            // Search_btn
            // 
            this.Search_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Search_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.Search_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Search_btn.FlatAppearance.BorderSize = 0;
            this.Search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Search_btn.Location = new System.Drawing.Point(170, 383);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(91, 37);
            this.Search_btn.TabIndex = 47;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = false;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(64, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 22);
            this.label3.TabIndex = 44;
            this.label3.Text = "Room No";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(64, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 22);
            this.label2.TabIndex = 45;
            this.label2.Text = "Session";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(64, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 22);
            this.label1.TabIndex = 46;
            this.label1.Text = "Date";
            // 
            // ClearData_btn
            // 
            this.ClearData_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearData_btn.BackColor = System.Drawing.Color.Maroon;
            this.ClearData_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearData_btn.FlatAppearance.BorderSize = 0;
            this.ClearData_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClearData_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearData_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearData_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearData_btn.Location = new System.Drawing.Point(419, 638);
            this.ClearData_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearData_btn.Name = "ClearData_btn";
            this.ClearData_btn.Size = new System.Drawing.Size(132, 37);
            this.ClearData_btn.TabIndex = 42;
            this.ClearData_btn.Text = "Clear Data";
            this.ClearData_btn.UseVisualStyleBackColor = false;
            this.ClearData_btn.Click += new System.EventHandler(this.ClearData_btn_Click);
            // 
            // Absentees_btn
            // 
            this.Absentees_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Absentees_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.Absentees_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Absentees_btn.FlatAppearance.BorderSize = 0;
            this.Absentees_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Absentees_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Absentees_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Absentees_btn.Location = new System.Drawing.Point(170, 449);
            this.Absentees_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Absentees_btn.Name = "Absentees_btn";
            this.Absentees_btn.Size = new System.Drawing.Size(190, 52);
            this.Absentees_btn.TabIndex = 43;
            this.Absentees_btn.Text = "Enter Absentees";
            this.Absentees_btn.UseVisualStyleBackColor = false;
            this.Absentees_btn.Click += new System.EventHandler(this.Absentees_btn_Click);
            // 
            // Room_combobox
            // 
            this.Room_combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Room_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Room_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Room_combobox.FormattingEnabled = true;
            this.Room_combobox.Location = new System.Drawing.Point(170, 316);
            this.Room_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Room_combobox.Name = "Room_combobox";
            this.Room_combobox.Size = new System.Drawing.Size(319, 32);
            this.Room_combobox.TabIndex = 40;
            // 
            // Session_combobox
            // 
            this.Session_combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Session_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Session_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Session_combobox.FormattingEnabled = true;
            this.Session_combobox.Items.AddRange(new object[] {
            "-Select-",
            "Forenoon",
            "Afternoon"});
            this.Session_combobox.Location = new System.Drawing.Point(170, 262);
            this.Session_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Session_combobox.Name = "Session_combobox";
            this.Session_combobox.Size = new System.Drawing.Size(319, 32);
            this.Session_combobox.TabIndex = 41;
            // 
            // Date_combobox
            // 
            this.Date_combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Date_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Date_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_combobox.FormattingEnabled = true;
            this.Date_combobox.Location = new System.Drawing.Point(170, 208);
            this.Date_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Date_combobox.Name = "Date_combobox";
            this.Date_combobox.Size = new System.Drawing.Size(319, 32);
            this.Date_combobox.TabIndex = 39;
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.Dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.ColumnHeadersHeight = 30;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv.EnableHeadersVisualStyles = false;
            this.Dgv.GridColor = System.Drawing.Color.SteelBlue;
            this.Dgv.Location = new System.Drawing.Point(565, 42);
            this.Dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.Dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.RowTemplate.Height = 24;
            this.Dgv.Size = new System.Drawing.Size(703, 675);
            this.Dgv.TabIndex = 16;
            this.Dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeStatusEvent);
            // 
            // Absent_Marking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Absent_Marking";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Absent_Marking";
            this.Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton Series_radio;
        private System.Windows.Forms.RadioButton Unv_radio;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ClearData_btn;
        private System.Windows.Forms.Button Absentees_btn;
        private System.Windows.Forms.ComboBox Room_combobox;
        private System.Windows.Forms.ComboBox Session_combobox;
        private System.Windows.Forms.ComboBox Date_combobox;
        private System.Windows.Forms.Button closeBtn;
    }
}