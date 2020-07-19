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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ScheduledExam_dgv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.NewDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NewSession_combobox = new System.Windows.Forms.ComboBox();
            this.Postpone_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DateCheckbox = new System.Windows.Forms.CheckBox();
            this.Examcode_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Semester_combobox = new System.Windows.Forms.ComboBox();
            this.Branch_combobox = new System.Windows.Forms.ComboBox();
            this.examdetails = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Clear_button = new System.Windows.Forms.Button();
            this.exam_CellDataSetTimetable = new Exam_Cell.Exam_CellDataSetTimetable();
            this.timetableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timetableTableAdapter = new Exam_Cell.Exam_CellDataSetTimetableTableAdapters.TimetableTableAdapter();
            this.exam_CellTimeTableNew = new Exam_Cell.Exam_CellTimeTableNew();
            this.timetableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timetableTableAdapter1 = new Exam_Cell.Exam_CellTimeTableNewTableAdapters.TimetableTableAdapter();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduledExam_dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSetTimetable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellTimeTableNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Clear_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 677);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ScheduledExam_dgv);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(12, 316);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1119, 343);
            this.panel4.TabIndex = 7;
            // 
            // ScheduledExam_dgv
            // 
            this.ScheduledExam_dgv.AllowUserToAddRows = false;
            this.ScheduledExam_dgv.AllowUserToDeleteRows = false;
            this.ScheduledExam_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ScheduledExam_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScheduledExam_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduledExam_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScheduledExam_dgv.Location = new System.Drawing.Point(0, 0);
            this.ScheduledExam_dgv.Name = "ScheduledExam_dgv";
            this.ScheduledExam_dgv.Size = new System.Drawing.Size(1119, 343);
            this.ScheduledExam_dgv.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.NewDateTimePicker);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.NewSession_combobox);
            this.panel3.Controls.Add(this.Postpone_button);
            this.panel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(640, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 211);
            this.panel3.TabIndex = 6;
            // 
            // NewDateTimePicker
            // 
            this.NewDateTimePicker.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDateTimePicker.Location = new System.Drawing.Point(127, 42);
            this.NewDateTimePicker.Name = "NewDateTimePicker";
            this.NewDateTimePicker.Size = new System.Drawing.Size(334, 33);
            this.NewDateTimePicker.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "Postponement Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "New Session :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "New Date :";
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
            this.NewSession_combobox.Location = new System.Drawing.Point(127, 97);
            this.NewSession_combobox.Name = "NewSession_combobox";
            this.NewSession_combobox.Size = new System.Drawing.Size(334, 32);
            this.NewSession_combobox.TabIndex = 4;
            // 
            // Postpone_button
            // 
            this.Postpone_button.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Postpone_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Postpone_button.Location = new System.Drawing.Point(347, 137);
            this.Postpone_button.Name = "Postpone_button";
            this.Postpone_button.Size = new System.Drawing.Size(114, 38);
            this.Postpone_button.TabIndex = 2;
            this.Postpone_button.Text = "Postpone";
            this.Postpone_button.UseVisualStyleBackColor = true;
            this.Postpone_button.Click += new System.EventHandler(this.Postpone_button_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.DateCheckbox);
            this.panel2.Controls.Add(this.Examcode_textbox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.DateTimePicker);
            this.panel2.Controls.Add(this.Semester_combobox);
            this.panel2.Controls.Add(this.Branch_combobox);
            this.panel2.Controls.Add(this.examdetails);
            this.panel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(12, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 211);
            this.panel2.TabIndex = 1;
            // 
            // DateCheckbox
            // 
            this.DateCheckbox.AutoSize = true;
            this.DateCheckbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateCheckbox.Location = new System.Drawing.Point(470, 122);
            this.DateCheckbox.Name = "DateCheckbox";
            this.DateCheckbox.Size = new System.Drawing.Size(18, 17);
            this.DateCheckbox.TabIndex = 11;
            this.DateCheckbox.UseVisualStyleBackColor = true;
            this.DateCheckbox.CheckedChanged += new System.EventHandler(this.DateCheckbox_CheckedChanged);
            // 
            // Examcode_textbox
            // 
            this.Examcode_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examcode_textbox.Location = new System.Drawing.Point(121, 154);
            this.Examcode_textbox.Name = "Examcode_textbox";
            this.Examcode_textbox.Size = new System.Drawing.Size(339, 33);
            this.Examcode_textbox.TabIndex = 10;
            this.Examcode_textbox.TextChanged += new System.EventHandler(this.Examcode_textbox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Exam Code :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Semester :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Branch :";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.Location = new System.Drawing.Point(121, 113);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(339, 33);
            this.DateTimePicker.TabIndex = 5;
            this.DateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // Semester_combobox
            // 
            this.Semester_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Semester_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Semester_combobox.FormattingEnabled = true;
            this.Semester_combobox.Location = new System.Drawing.Point(121, 70);
            this.Semester_combobox.Name = "Semester_combobox";
            this.Semester_combobox.Size = new System.Drawing.Size(339, 32);
            this.Semester_combobox.TabIndex = 4;
            this.Semester_combobox.SelectedIndexChanged += new System.EventHandler(this.Semester_combobox_SelectedIndexChanged);
            // 
            // Branch_combobox
            // 
            this.Branch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Branch_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Branch_combobox.FormattingEnabled = true;
            this.Branch_combobox.Location = new System.Drawing.Point(121, 28);
            this.Branch_combobox.Name = "Branch_combobox";
            this.Branch_combobox.Size = new System.Drawing.Size(339, 32);
            this.Branch_combobox.TabIndex = 3;
            this.Branch_combobox.SelectedIndexChanged += new System.EventHandler(this.Branch_combobox_SelectedIndexChanged);
            // 
            // examdetails
            // 
            this.examdetails.AutoSize = true;
            this.examdetails.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examdetails.Location = new System.Drawing.Point(3, 0);
            this.examdetails.Name = "examdetails";
            this.examdetails.Size = new System.Drawing.Size(103, 18);
            this.examdetails.TabIndex = 0;
            this.examdetails.Text = "Exam Details ";
            this.examdetails.Click += new System.EventHandler(this.examdetails_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Exam_Cell.Properties.Resources.kmea_hd_logo_shabz_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1120, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Clear_button
            // 
            this.Clear_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Clear_button.Location = new System.Drawing.Point(524, 272);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(110, 38);
            this.Clear_button.TabIndex = 1;
            this.Clear_button.Text = "Clear";
            this.Clear_button.UseVisualStyleBackColor = true;
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
            // postponement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1145, 677);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "postponement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postponement";
            this.Load += new System.EventHandler(this.postponement_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduledExam_dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSetTimetable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellTimeTableNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label examdetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.ComboBox Semester_combobox;
        private System.Windows.Forms.ComboBox Branch_combobox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker NewDateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox NewSession_combobox;
        private System.Windows.Forms.Button Postpone_button;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.DataGridView ScheduledExam_dgv;
        private System.Windows.Forms.TextBox Examcode_textbox;
        private System.Windows.Forms.Label label4;
        private Exam_CellDataSetTimetable exam_CellDataSetTimetable;
        private System.Windows.Forms.BindingSource timetableBindingSource;
        private Exam_CellDataSetTimetableTableAdapters.TimetableTableAdapter timetableTableAdapter;
        private System.Windows.Forms.CheckBox DateCheckbox;
        private Exam_CellTimeTableNew exam_CellTimeTableNew;
        private System.Windows.Forms.BindingSource timetableBindingSource1;
        private Exam_CellTimeTableNewTableAdapters.TimetableTableAdapter timetableTableAdapter1;
        private System.Windows.Forms.Panel panel4;
    }
}