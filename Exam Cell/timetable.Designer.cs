namespace Exam_Cell
{
    partial class formtimetable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formtimetable));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Undo_btn = new System.Windows.Forms.Button();
            this.Add_btn = new System.Windows.Forms.Button();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.Examcode_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Semester_combobox = new System.Windows.Forms.ComboBox();
            this.Branch_combobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Session_combobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Course_Select_dgv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Datepick_box = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Branchwise_radio = new System.Windows.Forms.RadioButton();
            this.Datewise_radio = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.SheduledBranch = new System.Windows.Forms.ComboBox();
            this.SheduledExamcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Timetableview_dgv = new System.Windows.Forms.DataGridView();
            this.timetableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exam_CellDataSetTimetable = new Exam_Cell.Exam_CellDataSetTimetable();
            this.exam_CellScheme = new Exam_Cell.Exam_CellScheme();
            this.schemeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schemeTableAdapter = new Exam_Cell.Exam_CellSchemeTableAdapters.SchemeTableAdapter();
            this.timetableTableAdapter = new Exam_Cell.Exam_CellDataSetTimetableTableAdapters.TimetableTableAdapter();
            this.exam_CellTimeTableNew = new Exam_Cell.Exam_CellTimeTableNew();
            this.timetableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timetableTableAdapter1 = new Exam_Cell.Exam_CellTimeTableNewTableAdapters.TimetableTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Course_Select_dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Timetableview_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSetTimetable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellScheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellTimeTableNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Undo_btn);
            this.panel1.Controls.Add(this.Add_btn);
            this.panel1.Controls.Add(this.Clear_btn);
            this.panel1.Controls.Add(this.Examcode_box);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Semester_combobox);
            this.panel1.Controls.Add(this.Branch_combobox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DateTimePicker);
            this.panel1.Controls.Add(this.Session_combobox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 477);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Exam_Cell.Properties.Resources.kmea_hd_logo_shabz_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(-4003, -27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 62);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Undo_btn
            // 
            this.Undo_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.Undo_btn.ForeColor = System.Drawing.Color.Black;
            this.Undo_btn.Location = new System.Drawing.Point(396, 372);
            this.Undo_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Undo_btn.Name = "Undo_btn";
            this.Undo_btn.Size = new System.Drawing.Size(100, 40);
            this.Undo_btn.TabIndex = 14;
            this.Undo_btn.Text = "Undo";
            this.Undo_btn.UseVisualStyleBackColor = true;
            this.Undo_btn.Click += new System.EventHandler(this.Undo_btn_Click);
            // 
            // Add_btn
            // 
            this.Add_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.Add_btn.ForeColor = System.Drawing.Color.Black;
            this.Add_btn.Location = new System.Drawing.Point(394, 317);
            this.Add_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(100, 40);
            this.Add_btn.TabIndex = 13;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F);
            this.Clear_btn.ForeColor = System.Drawing.Color.Black;
            this.Clear_btn.Location = new System.Drawing.Point(229, 317);
            this.Clear_btn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(100, 40);
            this.Clear_btn.TabIndex = 10;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Examcode_box
            // 
            this.Examcode_box.Location = new System.Drawing.Point(143, 266);
            this.Examcode_box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Examcode_box.Name = "Examcode_box";
            this.Examcode_box.Size = new System.Drawing.Size(353, 33);
            this.Examcode_box.TabIndex = 9;
            this.Examcode_box.TextChanged += new System.EventHandler(this.Examcode_box_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 268);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Exam Code :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 229);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Semester :";
            // 
            // Semester_combobox
            // 
            this.Semester_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Semester_combobox.FormattingEnabled = true;
            this.Semester_combobox.Location = new System.Drawing.Point(143, 228);
            this.Semester_combobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Semester_combobox.Name = "Semester_combobox";
            this.Semester_combobox.Size = new System.Drawing.Size(353, 32);
            this.Semester_combobox.TabIndex = 6;
            this.Semester_combobox.SelectedIndexChanged += new System.EventHandler(this.Semester_combobox_SelectedIndexChanged);
            // 
            // Branch_combobox
            // 
            this.Branch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Branch_combobox.FormattingEnabled = true;
            this.Branch_combobox.Location = new System.Drawing.Point(143, 190);
            this.Branch_combobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Branch_combobox.Name = "Branch_combobox";
            this.Branch_combobox.Size = new System.Drawing.Size(353, 32);
            this.Branch_combobox.TabIndex = 5;
            this.Branch_combobox.SelectedIndexChanged += new System.EventHandler(this.Branch_combobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Branch :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Session :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Checked = false;
            this.DateTimePicker.Location = new System.Drawing.Point(143, 66);
            this.DateTimePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(353, 33);
            this.DateTimePicker.TabIndex = 2;
            // 
            // Session_combobox
            // 
            this.Session_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Session_combobox.FormattingEnabled = true;
            this.Session_combobox.Items.AddRange(new object[] {
            "-Select-",
            "Forenoon",
            "Afternoon"});
            this.Session_combobox.Location = new System.Drawing.Point(143, 112);
            this.Session_combobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Session_combobox.Name = "Session_combobox";
            this.Session_combobox.Size = new System.Drawing.Size(353, 32);
            this.Session_combobox.TabIndex = 1;
            this.Session_combobox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Course_Select_dgv);
            this.panel2.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(567, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1250, 476);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Course_Select_dgv
            // 
            this.Course_Select_dgv.AllowUserToAddRows = false;
            this.Course_Select_dgv.AllowUserToDeleteRows = false;
            this.Course_Select_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Course_Select_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Course_Select_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Course_Select_dgv.Location = new System.Drawing.Point(0, 0);
            this.Course_Select_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.Course_Select_dgv.Name = "Course_Select_dgv";
            this.Course_Select_dgv.Size = new System.Drawing.Size(1250, 476);
            this.Course_Select_dgv.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Datepick_box);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.Branchwise_radio);
            this.panel3.Controls.Add(this.Datewise_radio);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.SheduledBranch);
            this.panel3.Controls.Add(this.SheduledExamcode);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(1124, 592);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(654, 159);
            this.panel3.TabIndex = 1;
            // 
            // Datepick_box
            // 
            this.Datepick_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Datepick_box.Enabled = false;
            this.Datepick_box.FormattingEnabled = true;
            this.Datepick_box.Location = new System.Drawing.Point(299, 22);
            this.Datepick_box.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Datepick_box.Name = "Datepick_box";
            this.Datepick_box.Size = new System.Drawing.Size(342, 32);
            this.Datepick_box.TabIndex = 5;
            this.Datepick_box.SelectedIndexChanged += new System.EventHandler(this.Datepick_box_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(240, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Date :";
            // 
            // Branchwise_radio
            // 
            this.Branchwise_radio.AutoSize = true;
            this.Branchwise_radio.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Branchwise_radio.Location = new System.Drawing.Point(20, 80);
            this.Branchwise_radio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Branchwise_radio.Name = "Branchwise_radio";
            this.Branchwise_radio.Size = new System.Drawing.Size(142, 30);
            this.Branchwise_radio.TabIndex = 3;
            this.Branchwise_radio.TabStop = true;
            this.Branchwise_radio.Text = "Branch Wise";
            this.Branchwise_radio.UseVisualStyleBackColor = true;
            this.Branchwise_radio.CheckedChanged += new System.EventHandler(this.Branchwise_radio_CheckedChanged);
            // 
            // Datewise_radio
            // 
            this.Datewise_radio.AutoSize = true;
            this.Datewise_radio.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datewise_radio.Location = new System.Drawing.Point(20, 32);
            this.Datewise_radio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Datewise_radio.Name = "Datewise_radio";
            this.Datewise_radio.Size = new System.Drawing.Size(123, 30);
            this.Datewise_radio.TabIndex = 2;
            this.Datewise_radio.TabStop = true;
            this.Datewise_radio.Text = "Date Wise";
            this.Datewise_radio.UseVisualStyleBackColor = true;
            this.Datewise_radio.CheckedChanged += new System.EventHandler(this.Datewise_radio_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Scheduled Exam";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // SheduledBranch
            // 
            this.SheduledBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SheduledBranch.Enabled = false;
            this.SheduledBranch.FormattingEnabled = true;
            this.SheduledBranch.Location = new System.Drawing.Point(299, 71);
            this.SheduledBranch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SheduledBranch.Name = "SheduledBranch";
            this.SheduledBranch.Size = new System.Drawing.Size(342, 32);
            this.SheduledBranch.TabIndex = 5;
            this.SheduledBranch.SelectedIndexChanged += new System.EventHandler(this.SheduledBranch_SelectedIndexChanged);
            // 
            // SheduledExamcode
            // 
            this.SheduledExamcode.Enabled = false;
            this.SheduledExamcode.Location = new System.Drawing.Point(299, 110);
            this.SheduledExamcode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SheduledExamcode.Name = "SheduledExamcode";
            this.SheduledExamcode.Size = new System.Drawing.Size(342, 33);
            this.SheduledExamcode.TabIndex = 9;
            this.SheduledExamcode.TextChanged += new System.EventHandler(this.SheduledExamcode_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(195, 115);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 18);
            this.label9.TabIndex = 8;
            this.label9.Text = "Exam Code :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(224, 77);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "Branch :";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Timetableview_dgv);
            this.panel5.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(16, 499);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1100, 380);
            this.panel5.TabIndex = 3;
            // 
            // Timetableview_dgv
            // 
            this.Timetableview_dgv.AllowUserToAddRows = false;
            this.Timetableview_dgv.AllowUserToDeleteRows = false;
            this.Timetableview_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Timetableview_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Timetableview_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Timetableview_dgv.Location = new System.Drawing.Point(0, 0);
            this.Timetableview_dgv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Timetableview_dgv.Name = "Timetableview_dgv";
            this.Timetableview_dgv.ReadOnly = true;
            this.Timetableview_dgv.Size = new System.Drawing.Size(1100, 380);
            this.Timetableview_dgv.TabIndex = 0;
            // 
            // timetableBindingSource
            // 
            this.timetableBindingSource.DataMember = "Timetable";
            this.timetableBindingSource.DataSource = this.exam_CellDataSetTimetable;
            // 
            // exam_CellDataSetTimetable
            // 
            this.exam_CellDataSetTimetable.DataSetName = "Exam_CellDataSetTimetable";
            this.exam_CellDataSetTimetable.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // exam_CellScheme
            // 
            this.exam_CellScheme.DataSetName = "Exam_CellScheme";
            this.exam_CellScheme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // schemeBindingSource
            // 
            this.schemeBindingSource.DataMember = "Scheme";
            this.schemeBindingSource.DataSource = this.exam_CellScheme;
            // 
            // schemeTableAdapter
            // 
            this.schemeTableAdapter.ClearBeforeFill = true;
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
            // formtimetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1741, 703);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formtimetable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimeTable";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formtimetable_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Course_Select_dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Timetableview_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSetTimetable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellScheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellTimeTableNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.ComboBox Session_combobox;
        private System.Windows.Forms.ComboBox Semester_combobox;
        private System.Windows.Forms.ComboBox Branch_combobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Undo_btn;
        private System.Windows.Forms.Button Add_btn;
        private System.Windows.Forms.Button Clear_btn;
        private System.Windows.Forms.TextBox Examcode_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView Course_Select_dgv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox Datepick_box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton Branchwise_radio;
        private System.Windows.Forms.RadioButton Datewise_radio;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView Timetableview_dgv;
        private Exam_CellScheme exam_CellScheme;
        private System.Windows.Forms.BindingSource schemeBindingSource;
        private Exam_CellSchemeTableAdapters.SchemeTableAdapter schemeTableAdapter;
        private Exam_CellDataSetTimetable exam_CellDataSetTimetable;
        private System.Windows.Forms.BindingSource timetableBindingSource;
        private Exam_CellDataSetTimetableTableAdapters.TimetableTableAdapter timetableTableAdapter;
        private System.Windows.Forms.ComboBox SheduledBranch;
        private System.Windows.Forms.TextBox SheduledExamcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Exam_CellTimeTableNew exam_CellTimeTableNew;
        private System.Windows.Forms.BindingSource timetableBindingSource1;
        private Exam_CellTimeTableNewTableAdapters.TimetableTableAdapter timetableTableAdapter1;
    }
}