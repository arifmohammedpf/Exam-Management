namespace Exam_Cell
{
    partial class postponement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(postponement));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NewDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.Postpone_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.NewSession_combobox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DateCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Examcode_textbox = new System.Windows.Forms.TextBox();
            this.Branch_combobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Semester_combobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Clear_button = new System.Windows.Forms.Button();
            this.exam_CellDataSetTimetable = new Exam_Cell.Exam_CellDataSetTimetable();
            this.timetableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timetableTableAdapter = new Exam_Cell.Exam_CellDataSetTimetableTableAdapters.TimetableTableAdapter();
            this.exam_CellTimeTableNew = new Exam_Cell.Exam_CellTimeTableNew();
            this.timetableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timetableTableAdapter1 = new Exam_Cell.Exam_CellTimeTableNewTableAdapters.TimetableTableAdapter();
            this.ScheduledExam_dgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSetTimetable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellTimeTableNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduledExam_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ScheduledExam_dgv);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Clear_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 677);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.NewDateTimePicker);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Postpone_button);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.NewSession_combobox);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(705, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 268);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Postponement Settings";
            // 
            // NewDateTimePicker
            // 
            this.NewDateTimePicker.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDateTimePicker.Location = new System.Drawing.Point(228, 75);
            this.NewDateTimePicker.Name = "NewDateTimePicker";
            this.NewDateTimePicker.Size = new System.Drawing.Size(334, 30);
            this.NewDateTimePicker.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "New Date :";
            // 
            // Postpone_button
            // 
            this.Postpone_button.BackColor = System.Drawing.Color.DarkGreen;
            this.Postpone_button.FlatAppearance.BorderSize = 0;
            this.Postpone_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.Postpone_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Postpone_button.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Postpone_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Postpone_button.Location = new System.Drawing.Point(429, 183);
            this.Postpone_button.Name = "Postpone_button";
            this.Postpone_button.Size = new System.Drawing.Size(133, 43);
            this.Postpone_button.TabIndex = 2;
            this.Postpone_button.Text = "Postpone";
            this.Postpone_button.UseVisualStyleBackColor = false;
            this.Postpone_button.Click += new System.EventHandler(this.Postpone_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "New Session :";
            // 
            // NewSession_combobox
            // 
            this.NewSession_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewSession_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSession_combobox.FormattingEnabled = true;
            this.NewSession_combobox.Items.AddRange(new object[] {
            "-Optional-",
            "Forenoon",
            "Afternoon"});
            this.NewSession_combobox.Location = new System.Drawing.Point(228, 130);
            this.NewSession_combobox.Name = "NewSession_combobox";
            this.NewSession_combobox.Size = new System.Drawing.Size(334, 32);
            this.NewSession_combobox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.DateCheckbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Examcode_textbox);
            this.groupBox1.Controls.Add(this.Branch_combobox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Semester_combobox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DateTimePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 268);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exam Details";
            // 
            // DateCheckbox
            // 
            this.DateCheckbox.AutoSize = true;
            this.DateCheckbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateCheckbox.Location = new System.Drawing.Point(524, 151);
            this.DateCheckbox.Name = "DateCheckbox";
            this.DateCheckbox.Size = new System.Drawing.Size(18, 17);
            this.DateCheckbox.TabIndex = 11;
            this.DateCheckbox.UseVisualStyleBackColor = true;
            this.DateCheckbox.CheckedChanged += new System.EventHandler(this.DateCheckbox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Branch :";
            // 
            // Examcode_textbox
            // 
            this.Examcode_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examcode_textbox.Location = new System.Drawing.Point(175, 183);
            this.Examcode_textbox.Name = "Examcode_textbox";
            this.Examcode_textbox.Size = new System.Drawing.Size(339, 33);
            this.Examcode_textbox.TabIndex = 10;
            this.Examcode_textbox.TextChanged += new System.EventHandler(this.Examcode_textbox_TextChanged);
            // 
            // Branch_combobox
            // 
            this.Branch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Branch_combobox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Branch_combobox.FormattingEnabled = true;
            this.Branch_combobox.Location = new System.Drawing.Point(175, 57);
            this.Branch_combobox.Name = "Branch_combobox";
            this.Branch_combobox.Size = new System.Drawing.Size(339, 29);
            this.Branch_combobox.TabIndex = 3;
            this.Branch_combobox.SelectedIndexChanged += new System.EventHandler(this.Branch_combobox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Exam Code :";
            // 
            // Semester_combobox
            // 
            this.Semester_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Semester_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Semester_combobox.FormattingEnabled = true;
            this.Semester_combobox.Location = new System.Drawing.Point(175, 99);
            this.Semester_combobox.Name = "Semester_combobox";
            this.Semester_combobox.Size = new System.Drawing.Size(339, 32);
            this.Semester_combobox.TabIndex = 4;
            this.Semester_combobox.SelectedIndexChanged += new System.EventHandler(this.Semester_combobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date :";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.Location = new System.Drawing.Point(175, 142);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(339, 30);
            this.DateTimePicker.TabIndex = 5;
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Semester :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Clear_button
            // 
            this.Clear_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Clear_button.BackColor = System.Drawing.Color.Maroon;
            this.Clear_button.FlatAppearance.BorderSize = 0;
            this.Clear_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Clear_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_button.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Clear_button.Location = new System.Drawing.Point(585, 241);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(114, 38);
            this.Clear_button.TabIndex = 1;
            this.Clear_button.Text = "Clear";
            this.Clear_button.UseVisualStyleBackColor = false;
            this.Clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // exam_CellDataSetTimetable
            // 
            this.exam_CellDataSetTimetable.DataSetName = "Exam_CellDataSetTimetable";
            this.exam_CellDataSetTimetable.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timetableBindingSource
            // 
            this.timetableBindingSource.DataMember = "Timetable";
            this.timetableBindingSource.DataSource = this.exam_CellDataSetTimetable;
            // 
            // timetableTableAdapter
            // 
            this.timetableTableAdapter.ClearBeforeFill = true;
            // 
            // exam_CellTimeTableNew
            // 
            this.exam_CellTimeTableNew.DataSetName = "Exam_CellTimeTableNew";
            this.exam_CellTimeTableNew.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timetableBindingSource1
            // 
            this.timetableBindingSource1.DataMember = "Timetable";
            this.timetableBindingSource1.DataSource = this.exam_CellTimeTableNew;
            // 
            // timetableTableAdapter1
            // 
            this.timetableTableAdapter1.ClearBeforeFill = true;
            // 
            // ScheduledExam_dgv
            // 
            this.ScheduledExam_dgv.AllowUserToAddRows = false;
            this.ScheduledExam_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.ScheduledExam_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ScheduledExam_dgv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScheduledExam_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ScheduledExam_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ScheduledExam_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.ScheduledExam_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScheduledExam_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScheduledExam_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ScheduledExam_dgv.ColumnHeadersHeight = 40;
            this.ScheduledExam_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ScheduledExam_dgv.EnableHeadersVisualStyles = false;
            this.ScheduledExam_dgv.GridColor = System.Drawing.Color.SteelBlue;
            this.ScheduledExam_dgv.Location = new System.Drawing.Point(11, 285);
            this.ScheduledExam_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.ScheduledExam_dgv.Name = "ScheduledExam_dgv";
            this.ScheduledExam_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScheduledExam_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.ScheduledExam_dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ScheduledExam_dgv.Size = new System.Drawing.Size(1291, 387);
            this.ScheduledExam_dgv.TabIndex = 10;
            // 
            // postponement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1318, 677);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "postponement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postponement";
            this.Load += new System.EventHandler(this.postponement_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSetTimetable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellTimeTableNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduledExam_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.ComboBox Semester_combobox;
        private System.Windows.Forms.ComboBox Branch_combobox;
        private System.Windows.Forms.DateTimePicker NewDateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox NewSession_combobox;
        private System.Windows.Forms.Button Postpone_button;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.TextBox Examcode_textbox;
        private System.Windows.Forms.Label label4;
        private Exam_CellDataSetTimetable exam_CellDataSetTimetable;
        private System.Windows.Forms.BindingSource timetableBindingSource;
        private Exam_CellDataSetTimetableTableAdapters.TimetableTableAdapter timetableTableAdapter;
        private System.Windows.Forms.CheckBox DateCheckbox;
        private Exam_CellTimeTableNew exam_CellTimeTableNew;
        private System.Windows.Forms.BindingSource timetableBindingSource1;
        private Exam_CellTimeTableNewTableAdapters.TimetableTableAdapter timetableTableAdapter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ScheduledExam_dgv;
    }
}