namespace Exam_Cell
{
    partial class Registered_Students_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registered_Students_Management));
            this.Series_radiobtn = new System.Windows.Forms.RadioButton();
            this.Univrsty_radiobtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.DeleteAll_btn = new System.Windows.Forms.Button();
            this.AllotGroupbox = new System.Windows.Forms.GroupBox();
            this.AllotSeries_radiobtn = new System.Windows.Forms.RadioButton();
            this.AllotUniversty_radiobtn = new System.Windows.Forms.RadioButton();
            this.Branch_combobox = new System.Windows.Forms.ComboBox();
            this.Semester_combobox = new System.Windows.Forms.ComboBox();
            this.Regno_textbox = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Registered_dgv = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.AllotGroupbox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Registered_dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Series_radiobtn
            // 
            this.Series_radiobtn.AutoSize = true;
            this.Series_radiobtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Series_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Series_radiobtn.Location = new System.Drawing.Point(247, 34);
            this.Series_radiobtn.Name = "Series_radiobtn";
            this.Series_radiobtn.Size = new System.Drawing.Size(85, 26);
            this.Series_radiobtn.TabIndex = 1;
            this.Series_radiobtn.TabStop = true;
            this.Series_radiobtn.Text = "Series ";
            this.Series_radiobtn.UseVisualStyleBackColor = true;
            this.Series_radiobtn.CheckedChanged += new System.EventHandler(this.Series_radiobtn_CheckedChanged);
            // 
            // Univrsty_radiobtn
            // 
            this.Univrsty_radiobtn.AutoSize = true;
            this.Univrsty_radiobtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Univrsty_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Univrsty_radiobtn.Location = new System.Drawing.Point(41, 34);
            this.Univrsty_radiobtn.Name = "Univrsty_radiobtn";
            this.Univrsty_radiobtn.Size = new System.Drawing.Size(117, 26);
            this.Univrsty_radiobtn.TabIndex = 1;
            this.Univrsty_radiobtn.TabStop = true;
            this.Univrsty_radiobtn.Text = "University";
            this.Univrsty_radiobtn.UseVisualStyleBackColor = true;
            this.Univrsty_radiobtn.CheckedChanged += new System.EventHandler(this.Univrsty_radiobtn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.Series_radiobtn);
            this.groupBox1.Controls.Add(this.Univrsty_radiobtn);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(102, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registered Students";
            // 
            // Delete_btn
            // 
            this.Delete_btn.BackColor = System.Drawing.Color.Maroon;
            this.Delete_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_btn.FlatAppearance.BorderSize = 0;
            this.Delete_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Delete_btn.Location = new System.Drawing.Point(19, 190);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(132, 41);
            this.Delete_btn.TabIndex = 2;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // DeleteAll_btn
            // 
            this.DeleteAll_btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DeleteAll_btn.BackColor = System.Drawing.Color.Maroon;
            this.DeleteAll_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteAll_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteAll_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteAll_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAll_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DeleteAll_btn.Location = new System.Drawing.Point(887, 670);
            this.DeleteAll_btn.Name = "DeleteAll_btn";
            this.DeleteAll_btn.Size = new System.Drawing.Size(132, 38);
            this.DeleteAll_btn.TabIndex = 2;
            this.DeleteAll_btn.Text = "Delete All";
            this.DeleteAll_btn.UseVisualStyleBackColor = false;
            this.DeleteAll_btn.Click += new System.EventHandler(this.DeleteAll_btn_Click);
            // 
            // AllotGroupbox
            // 
            this.AllotGroupbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AllotGroupbox.Controls.Add(this.AllotSeries_radiobtn);
            this.AllotGroupbox.Controls.Add(this.AllotUniversty_radiobtn);
            this.AllotGroupbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllotGroupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AllotGroupbox.Location = new System.Drawing.Point(500, 12);
            this.AllotGroupbox.Name = "AllotGroupbox";
            this.AllotGroupbox.Size = new System.Drawing.Size(351, 85);
            this.AllotGroupbox.TabIndex = 4;
            this.AllotGroupbox.TabStop = false;
            this.AllotGroupbox.Text = "Allotted Students";
            // 
            // AllotSeries_radiobtn
            // 
            this.AllotSeries_radiobtn.AutoSize = true;
            this.AllotSeries_radiobtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllotSeries_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AllotSeries_radiobtn.Location = new System.Drawing.Point(235, 34);
            this.AllotSeries_radiobtn.Name = "AllotSeries_radiobtn";
            this.AllotSeries_radiobtn.Size = new System.Drawing.Size(85, 26);
            this.AllotSeries_radiobtn.TabIndex = 1;
            this.AllotSeries_radiobtn.TabStop = true;
            this.AllotSeries_radiobtn.Text = "Series ";
            this.AllotSeries_radiobtn.UseVisualStyleBackColor = true;
            this.AllotSeries_radiobtn.CheckedChanged += new System.EventHandler(this.AllotSeries_radiobtn_CheckedChanged);
            // 
            // AllotUniversty_radiobtn
            // 
            this.AllotUniversty_radiobtn.AutoSize = true;
            this.AllotUniversty_radiobtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllotUniversty_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AllotUniversty_radiobtn.Location = new System.Drawing.Point(48, 34);
            this.AllotUniversty_radiobtn.Name = "AllotUniversty_radiobtn";
            this.AllotUniversty_radiobtn.Size = new System.Drawing.Size(117, 26);
            this.AllotUniversty_radiobtn.TabIndex = 1;
            this.AllotUniversty_radiobtn.TabStop = true;
            this.AllotUniversty_radiobtn.Text = "University";
            this.AllotUniversty_radiobtn.UseVisualStyleBackColor = true;
            this.AllotUniversty_radiobtn.CheckedChanged += new System.EventHandler(this.AllotUniversty_radiobtn_CheckedChanged);
            // 
            // Branch_combobox
            // 
            this.Branch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Branch_combobox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Branch_combobox.FormattingEnabled = true;
            this.Branch_combobox.Location = new System.Drawing.Point(18, 86);
            this.Branch_combobox.Name = "Branch_combobox";
            this.Branch_combobox.Size = new System.Drawing.Size(354, 29);
            this.Branch_combobox.TabIndex = 6;
            this.Branch_combobox.SelectedIndexChanged += new System.EventHandler(this.Branch_combobox_SelectedIndexChanged);
            // 
            // Semester_combobox
            // 
            this.Semester_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Semester_combobox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Semester_combobox.FormattingEnabled = true;
            this.Semester_combobox.Items.AddRange(new object[] {
            "-Select Semester-",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.Semester_combobox.Location = new System.Drawing.Point(18, 134);
            this.Semester_combobox.Name = "Semester_combobox";
            this.Semester_combobox.Size = new System.Drawing.Size(354, 29);
            this.Semester_combobox.TabIndex = 6;
            this.Semester_combobox.SelectedIndexChanged += new System.EventHandler(this.Semester_combobox_SelectedIndexChanged);
            // 
            // Regno_textbox
            // 
            this.Regno_textbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Regno_textbox.Location = new System.Drawing.Point(18, 37);
            this.Regno_textbox.Name = "Regno_textbox";
            this.Regno_textbox.Size = new System.Drawing.Size(354, 30);
            this.Regno_textbox.TabIndex = 7;
            this.Regno_textbox.Tag = "";
            this.Regno_textbox.TextChanged += new System.EventHandler(this.Regno_textbox_TextChanged);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.Olive;
            this.ClearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearBtn.FlatAppearance.BorderSize = 0;
            this.ClearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearBtn.Location = new System.Drawing.Point(250, 190);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(122, 41);
            this.ClearBtn.TabIndex = 8;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Reg_No";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.Registered_dgv);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.DeleteAll_btn);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.AllotGroupbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 720);
            this.panel1.TabIndex = 11;
            // 
            // Registered_dgv
            // 
            this.Registered_dgv.AllowUserToAddRows = false;
            this.Registered_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Registered_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Registered_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Registered_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Registered_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Registered_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.Registered_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Registered_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Registered_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Registered_dgv.ColumnHeadersHeight = 40;
            this.Registered_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Registered_dgv.EnableHeadersVisualStyles = false;
            this.Registered_dgv.GridColor = System.Drawing.Color.SteelBlue;
            this.Registered_dgv.Location = new System.Drawing.Point(13, 140);
            this.Registered_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.Registered_dgv.Name = "Registered_dgv";
            this.Registered_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Registered_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.Registered_dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Registered_dgv.Size = new System.Drawing.Size(867, 576);
            this.Registered_dgv.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel2.Controls.Add(this.Delete_btn);
            this.panel2.Controls.Add(this.Branch_combobox);
            this.panel2.Controls.Add(this.Semester_combobox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Regno_textbox);
            this.panel2.Controls.Add(this.ClearBtn);
            this.panel2.Location = new System.Drawing.Point(887, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 248);
            this.panel2.TabIndex = 11;
            // 
            // Registered_Students_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registered_Students_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registered_Students_Management";
            this.Load += new System.EventHandler(this.Registered_Students_Management_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AllotGroupbox.ResumeLayout(false);
            this.AllotGroupbox.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Registered_dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton Series_radiobtn;
        private System.Windows.Forms.RadioButton Univrsty_radiobtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Button DeleteAll_btn;
        private System.Windows.Forms.GroupBox AllotGroupbox;
        private System.Windows.Forms.RadioButton AllotSeries_radiobtn;
        private System.Windows.Forms.RadioButton AllotUniversty_radiobtn;
        private System.Windows.Forms.ComboBox Branch_combobox;
        private System.Windows.Forms.ComboBox Semester_combobox;
        private System.Windows.Forms.TextBox Regno_textbox;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView Registered_dgv;
    }
}