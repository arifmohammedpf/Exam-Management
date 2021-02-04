namespace Exam_Cell
{
    partial class Database_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database_Management));
            this.Class_Managmnt_panel = new System.Windows.Forms.Panel();
            this.Scheme_dgv = new System.Windows.Forms.DataGridView();
            this.RadioButton_panel = new System.Windows.Forms.Panel();
            this.Class_radiobtn = new System.Windows.Forms.RadioButton();
            this.DefaultScheme_radiobtn = new System.Windows.Forms.RadioButton();
            this.groupBoxContents = new System.Windows.Forms.GroupBox();
            this.NewClassGroupbox = new System.Windows.Forms.GroupBox();
            this.NewClass_textbox = new System.Windows.Forms.TextBox();
            this.NewClassSem_combobox = new System.Windows.Forms.ComboBox();
            this.NewClass_label = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AddNewClass_btn = new System.Windows.Forms.Button();
            this.DeleteClass_btn = new System.Windows.Forms.Button();
            this.NewBranchGroupbox = new System.Windows.Forms.GroupBox();
            this.NewBranch_textbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddNewBranch_btn = new System.Windows.Forms.Button();
            this.NewCourseGroupbox = new System.Windows.Forms.GroupBox();
            this.Course_textbox = new System.Windows.Forms.TextBox();
            this.UpdateBranch_combobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DeleteBranch_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Semester_combobox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AddNewCourse_btn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.DeleteCourse_btn = new System.Windows.Forms.Button();
            this.ACode_textbox = new System.Windows.Forms.TextBox();
            this.Examcode_textbox = new System.Windows.Forms.TextBox();
            this.Class_dgv_radiobtn = new System.Windows.Forms.RadioButton();
            this.Branch_dgv_radiobtn = new System.Windows.Forms.RadioButton();
            this.DefaultScheme_Panel = new System.Windows.Forms.Panel();
            this.ChangeScheme_btn = new System.Windows.Forms.Button();
            this.ChangeScheme_textbox = new System.Windows.Forms.TextBox();
            this.Scheme_label = new System.Windows.Forms.Label();
            this.exam_CellDataSet_Students = new Exam_Cell.Exam_CellDataSet_Students();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsTableAdapter = new Exam_Cell.Exam_CellDataSet_StudentsTableAdapters.StudentsTableAdapter();
            this.Class_Managmnt_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scheme_dgv)).BeginInit();
            this.RadioButton_panel.SuspendLayout();
            this.groupBoxContents.SuspendLayout();
            this.NewClassGroupbox.SuspendLayout();
            this.NewBranchGroupbox.SuspendLayout();
            this.NewCourseGroupbox.SuspendLayout();
            this.DefaultScheme_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSet_Students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Class_Managmnt_panel
            // 
            this.Class_Managmnt_panel.AutoScroll = true;
            this.Class_Managmnt_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.Class_Managmnt_panel.Controls.Add(this.Scheme_dgv);
            this.Class_Managmnt_panel.Controls.Add(this.RadioButton_panel);
            this.Class_Managmnt_panel.Controls.Add(this.groupBoxContents);
            this.Class_Managmnt_panel.Controls.Add(this.DefaultScheme_Panel);
            this.Class_Managmnt_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Class_Managmnt_panel.Location = new System.Drawing.Point(0, 0);
            this.Class_Managmnt_panel.Name = "Class_Managmnt_panel";
            this.Class_Managmnt_panel.Size = new System.Drawing.Size(1280, 720);
            this.Class_Managmnt_panel.TabIndex = 7;
            // 
            // Scheme_dgv
            // 
            this.Scheme_dgv.AllowUserToAddRows = false;
            this.Scheme_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Scheme_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Scheme_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Scheme_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Scheme_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Scheme_dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(50)))));
            this.Scheme_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Scheme_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Scheme_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Scheme_dgv.ColumnHeadersHeight = 40;
            this.Scheme_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Scheme_dgv.EnableHeadersVisualStyles = false;
            this.Scheme_dgv.GridColor = System.Drawing.Color.SteelBlue;
            this.Scheme_dgv.Location = new System.Drawing.Point(577, 54);
            this.Scheme_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.Scheme_dgv.Name = "Scheme_dgv";
            this.Scheme_dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Scheme_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.Scheme_dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Scheme_dgv.Size = new System.Drawing.Size(690, 662);
            this.Scheme_dgv.TabIndex = 11;
            // 
            // RadioButton_panel
            // 
            this.RadioButton_panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RadioButton_panel.Controls.Add(this.Class_radiobtn);
            this.RadioButton_panel.Controls.Add(this.DefaultScheme_radiobtn);
            this.RadioButton_panel.Location = new System.Drawing.Point(232, 3);
            this.RadioButton_panel.Name = "RadioButton_panel";
            this.RadioButton_panel.Size = new System.Drawing.Size(509, 47);
            this.RadioButton_panel.TabIndex = 9;
            // 
            // Class_radiobtn
            // 
            this.Class_radiobtn.AutoSize = true;
            this.Class_radiobtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Class_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Class_radiobtn.Location = new System.Drawing.Point(16, 9);
            this.Class_radiobtn.Name = "Class_radiobtn";
            this.Class_radiobtn.Size = new System.Drawing.Size(283, 26);
            this.Class_radiobtn.TabIndex = 6;
            this.Class_radiobtn.Text = "Class/Branch Management";
            this.Class_radiobtn.UseVisualStyleBackColor = true;
            this.Class_radiobtn.CheckedChanged += new System.EventHandler(this.Class_radiobtn_CheckedChanged);
            // 
            // DefaultScheme_radiobtn
            // 
            this.DefaultScheme_radiobtn.AutoSize = true;
            this.DefaultScheme_radiobtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultScheme_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DefaultScheme_radiobtn.Location = new System.Drawing.Point(324, 9);
            this.DefaultScheme_radiobtn.Name = "DefaultScheme_radiobtn";
            this.DefaultScheme_radiobtn.Size = new System.Drawing.Size(177, 26);
            this.DefaultScheme_radiobtn.TabIndex = 6;
            this.DefaultScheme_radiobtn.Text = "Default Scheme";
            this.DefaultScheme_radiobtn.UseVisualStyleBackColor = true;
            this.DefaultScheme_radiobtn.CheckedChanged += new System.EventHandler(this.DefaultScheme_radiobtn_CheckedChanged);
            // 
            // groupBoxContents
            // 
            this.groupBoxContents.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBoxContents.Controls.Add(this.NewClassGroupbox);
            this.groupBoxContents.Controls.Add(this.NewBranchGroupbox);
            this.groupBoxContents.Controls.Add(this.NewCourseGroupbox);
            this.groupBoxContents.Controls.Add(this.Class_dgv_radiobtn);
            this.groupBoxContents.Controls.Add(this.Branch_dgv_radiobtn);
            this.groupBoxContents.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxContents.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxContents.Location = new System.Drawing.Point(3, 41);
            this.groupBoxContents.Name = "groupBoxContents";
            this.groupBoxContents.Size = new System.Drawing.Size(567, 676);
            this.groupBoxContents.TabIndex = 6;
            this.groupBoxContents.TabStop = false;
            // 
            // NewClassGroupbox
            // 
            this.NewClassGroupbox.Controls.Add(this.NewClass_textbox);
            this.NewClassGroupbox.Controls.Add(this.NewClassSem_combobox);
            this.NewClassGroupbox.Controls.Add(this.NewClass_label);
            this.NewClassGroupbox.Controls.Add(this.label9);
            this.NewClassGroupbox.Controls.Add(this.AddNewClass_btn);
            this.NewClassGroupbox.Controls.Add(this.DeleteClass_btn);
            this.NewClassGroupbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewClassGroupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewClassGroupbox.Location = new System.Drawing.Point(11, 46);
            this.NewClassGroupbox.Name = "NewClassGroupbox";
            this.NewClassGroupbox.Size = new System.Drawing.Size(544, 147);
            this.NewClassGroupbox.TabIndex = 9;
            this.NewClassGroupbox.TabStop = false;
            this.NewClassGroupbox.Text = "New Class";
            // 
            // NewClass_textbox
            // 
            this.NewClass_textbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewClass_textbox.Location = new System.Drawing.Point(143, 23);
            this.NewClass_textbox.Name = "NewClass_textbox";
            this.NewClass_textbox.Size = new System.Drawing.Size(385, 30);
            this.NewClass_textbox.TabIndex = 2;
            // 
            // NewClassSem_combobox
            // 
            this.NewClassSem_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NewClassSem_combobox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewClassSem_combobox.FormattingEnabled = true;
            this.NewClassSem_combobox.Items.AddRange(new object[] {
            "-Select-",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.NewClassSem_combobox.Location = new System.Drawing.Point(143, 59);
            this.NewClassSem_combobox.Name = "NewClassSem_combobox";
            this.NewClassSem_combobox.Size = new System.Drawing.Size(385, 29);
            this.NewClassSem_combobox.TabIndex = 5;
            // 
            // NewClass_label
            // 
            this.NewClass_label.AutoSize = true;
            this.NewClass_label.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewClass_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewClass_label.Location = new System.Drawing.Point(9, 29);
            this.NewClass_label.Name = "NewClass_label";
            this.NewClass_label.Size = new System.Drawing.Size(55, 22);
            this.NewClass_label.TabIndex = 3;
            this.NewClass_label.Text = "Class";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(9, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 22);
            this.label9.TabIndex = 3;
            this.label9.Text = "Semester";
            // 
            // AddNewClass_btn
            // 
            this.AddNewClass_btn.BackColor = System.Drawing.Color.DarkGreen;
            this.AddNewClass_btn.FlatAppearance.BorderSize = 0;
            this.AddNewClass_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.AddNewClass_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewClass_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewClass_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddNewClass_btn.Location = new System.Drawing.Point(143, 97);
            this.AddNewClass_btn.Name = "AddNewClass_btn";
            this.AddNewClass_btn.Size = new System.Drawing.Size(176, 38);
            this.AddNewClass_btn.TabIndex = 0;
            this.AddNewClass_btn.Text = "Add New Class";
            this.AddNewClass_btn.UseVisualStyleBackColor = false;
            this.AddNewClass_btn.Click += new System.EventHandler(this.AddNewClass_btn_Click);
            // 
            // DeleteClass_btn
            // 
            this.DeleteClass_btn.BackColor = System.Drawing.Color.Maroon;
            this.DeleteClass_btn.FlatAppearance.BorderSize = 0;
            this.DeleteClass_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteClass_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteClass_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteClass_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DeleteClass_btn.Location = new System.Drawing.Point(352, 97);
            this.DeleteClass_btn.Name = "DeleteClass_btn";
            this.DeleteClass_btn.Size = new System.Drawing.Size(176, 38);
            this.DeleteClass_btn.TabIndex = 0;
            this.DeleteClass_btn.Text = "Delete Class";
            this.DeleteClass_btn.UseVisualStyleBackColor = false;
            this.DeleteClass_btn.Click += new System.EventHandler(this.DeleteClass_btn_Click);
            // 
            // NewBranchGroupbox
            // 
            this.NewBranchGroupbox.Controls.Add(this.NewBranch_textbox);
            this.NewBranchGroupbox.Controls.Add(this.label7);
            this.NewBranchGroupbox.Controls.Add(this.AddNewBranch_btn);
            this.NewBranchGroupbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBranchGroupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewBranchGroupbox.Location = new System.Drawing.Point(11, 237);
            this.NewBranchGroupbox.Name = "NewBranchGroupbox";
            this.NewBranchGroupbox.Size = new System.Drawing.Size(544, 114);
            this.NewBranchGroupbox.TabIndex = 8;
            this.NewBranchGroupbox.TabStop = false;
            this.NewBranchGroupbox.Text = "New Branch";
            // 
            // NewBranch_textbox
            // 
            this.NewBranch_textbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewBranch_textbox.Location = new System.Drawing.Point(143, 31);
            this.NewBranch_textbox.Name = "NewBranch_textbox";
            this.NewBranch_textbox.Size = new System.Drawing.Size(385, 30);
            this.NewBranch_textbox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(7, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 22);
            this.label7.TabIndex = 3;
            this.label7.Text = "Branch";
            // 
            // AddNewBranch_btn
            // 
            this.AddNewBranch_btn.BackColor = System.Drawing.Color.DarkGreen;
            this.AddNewBranch_btn.FlatAppearance.BorderSize = 0;
            this.AddNewBranch_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.AddNewBranch_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewBranch_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewBranch_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddNewBranch_btn.Location = new System.Drawing.Point(329, 67);
            this.AddNewBranch_btn.Name = "AddNewBranch_btn";
            this.AddNewBranch_btn.Size = new System.Drawing.Size(199, 38);
            this.AddNewBranch_btn.TabIndex = 0;
            this.AddNewBranch_btn.Text = "Add New Branch";
            this.AddNewBranch_btn.UseVisualStyleBackColor = false;
            this.AddNewBranch_btn.Click += new System.EventHandler(this.AddNewBranch_btn_Click);
            // 
            // NewCourseGroupbox
            // 
            this.NewCourseGroupbox.BackColor = System.Drawing.Color.Transparent;
            this.NewCourseGroupbox.Controls.Add(this.Course_textbox);
            this.NewCourseGroupbox.Controls.Add(this.UpdateBranch_combobox);
            this.NewCourseGroupbox.Controls.Add(this.label8);
            this.NewCourseGroupbox.Controls.Add(this.DeleteBranch_btn);
            this.NewCourseGroupbox.Controls.Add(this.label5);
            this.NewCourseGroupbox.Controls.Add(this.Semester_combobox);
            this.NewCourseGroupbox.Controls.Add(this.label6);
            this.NewCourseGroupbox.Controls.Add(this.label10);
            this.NewCourseGroupbox.Controls.Add(this.AddNewCourse_btn);
            this.NewCourseGroupbox.Controls.Add(this.label11);
            this.NewCourseGroupbox.Controls.Add(this.DeleteCourse_btn);
            this.NewCourseGroupbox.Controls.Add(this.ACode_textbox);
            this.NewCourseGroupbox.Controls.Add(this.Examcode_textbox);
            this.NewCourseGroupbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCourseGroupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewCourseGroupbox.Location = new System.Drawing.Point(11, 348);
            this.NewCourseGroupbox.Name = "NewCourseGroupbox";
            this.NewCourseGroupbox.Size = new System.Drawing.Size(544, 319);
            this.NewCourseGroupbox.TabIndex = 8;
            this.NewCourseGroupbox.TabStop = false;
            this.NewCourseGroupbox.Text = "New Course";
            // 
            // Course_textbox
            // 
            this.Course_textbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Course_textbox.Location = new System.Drawing.Point(143, 115);
            this.Course_textbox.Name = "Course_textbox";
            this.Course_textbox.Size = new System.Drawing.Size(385, 30);
            this.Course_textbox.TabIndex = 2;
            // 
            // UpdateBranch_combobox
            // 
            this.UpdateBranch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateBranch_combobox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBranch_combobox.FormattingEnabled = true;
            this.UpdateBranch_combobox.Location = new System.Drawing.Point(143, 35);
            this.UpdateBranch_combobox.Name = "UpdateBranch_combobox";
            this.UpdateBranch_combobox.Size = new System.Drawing.Size(385, 29);
            this.UpdateBranch_combobox.TabIndex = 5;
            this.UpdateBranch_combobox.SelectedIndexChanged += new System.EventHandler(this.UpdateBranch_combobox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(7, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 22);
            this.label8.TabIndex = 3;
            this.label8.Text = "Semester";
            // 
            // DeleteBranch_btn
            // 
            this.DeleteBranch_btn.BackColor = System.Drawing.Color.Maroon;
            this.DeleteBranch_btn.FlatAppearance.BorderSize = 0;
            this.DeleteBranch_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteBranch_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBranch_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBranch_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DeleteBranch_btn.Location = new System.Drawing.Point(143, 273);
            this.DeleteBranch_btn.Name = "DeleteBranch_btn";
            this.DeleteBranch_btn.Size = new System.Drawing.Size(176, 38);
            this.DeleteBranch_btn.TabIndex = 0;
            this.DeleteBranch_btn.Text = "Delete Branch";
            this.DeleteBranch_btn.UseVisualStyleBackColor = false;
            this.DeleteBranch_btn.Click += new System.EventHandler(this.DeleteBranch_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(7, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Branch";
            // 
            // Semester_combobox
            // 
            this.Semester_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Semester_combobox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Semester_combobox.FormattingEnabled = true;
            this.Semester_combobox.Items.AddRange(new object[] {
            "-Select-",
            "1 And 2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.Semester_combobox.Location = new System.Drawing.Point(143, 76);
            this.Semester_combobox.Name = "Semester_combobox";
            this.Semester_combobox.Size = new System.Drawing.Size(385, 29);
            this.Semester_combobox.TabIndex = 5;
            this.Semester_combobox.SelectedIndexChanged += new System.EventHandler(this.Semester_combobox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(7, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Course";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(7, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 22);
            this.label10.TabIndex = 3;
            this.label10.Text = "Exam Code";
            // 
            // AddNewCourse_btn
            // 
            this.AddNewCourse_btn.BackColor = System.Drawing.Color.DarkGreen;
            this.AddNewCourse_btn.FlatAppearance.BorderSize = 0;
            this.AddNewCourse_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.AddNewCourse_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewCourse_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewCourse_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddNewCourse_btn.Location = new System.Drawing.Point(352, 229);
            this.AddNewCourse_btn.Name = "AddNewCourse_btn";
            this.AddNewCourse_btn.Size = new System.Drawing.Size(176, 38);
            this.AddNewCourse_btn.TabIndex = 0;
            this.AddNewCourse_btn.Text = "Add New Course";
            this.AddNewCourse_btn.UseVisualStyleBackColor = false;
            this.AddNewCourse_btn.Click += new System.EventHandler(this.AddNewCourse_btn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(7, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 22);
            this.label11.TabIndex = 3;
            this.label11.Text = "A Code";
            // 
            // DeleteCourse_btn
            // 
            this.DeleteCourse_btn.BackColor = System.Drawing.Color.SaddleBrown;
            this.DeleteCourse_btn.FlatAppearance.BorderSize = 0;
            this.DeleteCourse_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteCourse_btn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCourse_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DeleteCourse_btn.Location = new System.Drawing.Point(143, 229);
            this.DeleteCourse_btn.Name = "DeleteCourse_btn";
            this.DeleteCourse_btn.Size = new System.Drawing.Size(176, 38);
            this.DeleteCourse_btn.TabIndex = 0;
            this.DeleteCourse_btn.Text = "Delete Course";
            this.DeleteCourse_btn.UseVisualStyleBackColor = false;
            this.DeleteCourse_btn.Click += new System.EventHandler(this.DeleteCourse_btn_Click);
            // 
            // ACode_textbox
            // 
            this.ACode_textbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACode_textbox.Location = new System.Drawing.Point(143, 193);
            this.ACode_textbox.Name = "ACode_textbox";
            this.ACode_textbox.Size = new System.Drawing.Size(385, 30);
            this.ACode_textbox.TabIndex = 2;
            // 
            // Examcode_textbox
            // 
            this.Examcode_textbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Examcode_textbox.Location = new System.Drawing.Point(143, 154);
            this.Examcode_textbox.Name = "Examcode_textbox";
            this.Examcode_textbox.Size = new System.Drawing.Size(385, 30);
            this.Examcode_textbox.TabIndex = 2;
            // 
            // Class_dgv_radiobtn
            // 
            this.Class_dgv_radiobtn.AutoSize = true;
            this.Class_dgv_radiobtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Class_dgv_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Class_dgv_radiobtn.Location = new System.Drawing.Point(220, 19);
            this.Class_dgv_radiobtn.Name = "Class_dgv_radiobtn";
            this.Class_dgv_radiobtn.Size = new System.Drawing.Size(127, 26);
            this.Class_dgv_radiobtn.TabIndex = 6;
            this.Class_dgv_radiobtn.Text = "Class View";
            this.Class_dgv_radiobtn.UseVisualStyleBackColor = true;
            this.Class_dgv_radiobtn.CheckedChanged += new System.EventHandler(this.Class_dgv_radiobtn_CheckedChanged);
            // 
            // Branch_dgv_radiobtn
            // 
            this.Branch_dgv_radiobtn.AutoSize = true;
            this.Branch_dgv_radiobtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Branch_dgv_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Branch_dgv_radiobtn.Location = new System.Drawing.Point(209, 213);
            this.Branch_dgv_radiobtn.Name = "Branch_dgv_radiobtn";
            this.Branch_dgv_radiobtn.Size = new System.Drawing.Size(148, 26);
            this.Branch_dgv_radiobtn.TabIndex = 6;
            this.Branch_dgv_radiobtn.Text = "Branch View";
            this.Branch_dgv_radiobtn.UseVisualStyleBackColor = true;
            this.Branch_dgv_radiobtn.CheckedChanged += new System.EventHandler(this.Branch_dgv_radiobtn_CheckedChanged);
            // 
            // DefaultScheme_Panel
            // 
            this.DefaultScheme_Panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DefaultScheme_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.DefaultScheme_Panel.Controls.Add(this.ChangeScheme_btn);
            this.DefaultScheme_Panel.Controls.Add(this.ChangeScheme_textbox);
            this.DefaultScheme_Panel.Controls.Add(this.Scheme_label);
            this.DefaultScheme_Panel.Location = new System.Drawing.Point(719, 219);
            this.DefaultScheme_Panel.Name = "DefaultScheme_Panel";
            this.DefaultScheme_Panel.Size = new System.Drawing.Size(386, 350);
            this.DefaultScheme_Panel.TabIndex = 8;
            // 
            // ChangeScheme_btn
            // 
            this.ChangeScheme_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeScheme_btn.Location = new System.Drawing.Point(109, 145);
            this.ChangeScheme_btn.Name = "ChangeScheme_btn";
            this.ChangeScheme_btn.Size = new System.Drawing.Size(173, 37);
            this.ChangeScheme_btn.TabIndex = 2;
            this.ChangeScheme_btn.Text = "Change Scheme";
            this.ChangeScheme_btn.UseVisualStyleBackColor = true;
            this.ChangeScheme_btn.Click += new System.EventHandler(this.ChangeScheme_btn_Click);
            // 
            // ChangeScheme_textbox
            // 
            this.ChangeScheme_textbox.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.ChangeScheme_textbox.Location = new System.Drawing.Point(81, 104);
            this.ChangeScheme_textbox.Name = "ChangeScheme_textbox";
            this.ChangeScheme_textbox.Size = new System.Drawing.Size(229, 33);
            this.ChangeScheme_textbox.TabIndex = 1;
            // 
            // Scheme_label
            // 
            this.Scheme_label.AutoSize = true;
            this.Scheme_label.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scheme_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Scheme_label.Location = new System.Drawing.Point(104, 206);
            this.Scheme_label.Name = "Scheme_label";
            this.Scheme_label.Size = new System.Drawing.Size(0, 39);
            this.Scheme_label.TabIndex = 0;
            // 
            // exam_CellDataSet_Students
            // 
            this.exam_CellDataSet_Students.DataSetName = "Exam_CellDataSet_Students";
            this.exam_CellDataSet_Students.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            this.studentsBindingSource.DataSource = this.exam_CellDataSet_Students;
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // Database_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.Class_Managmnt_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Database_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Management";
            this.Load += new System.EventHandler(this.Database_Management_Load);
            this.Class_Managmnt_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Scheme_dgv)).EndInit();
            this.RadioButton_panel.ResumeLayout(false);
            this.RadioButton_panel.PerformLayout();
            this.groupBoxContents.ResumeLayout(false);
            this.groupBoxContents.PerformLayout();
            this.NewClassGroupbox.ResumeLayout(false);
            this.NewClassGroupbox.PerformLayout();
            this.NewBranchGroupbox.ResumeLayout(false);
            this.NewBranchGroupbox.PerformLayout();
            this.NewCourseGroupbox.ResumeLayout(false);
            this.NewCourseGroupbox.PerformLayout();
            this.DefaultScheme_Panel.ResumeLayout(false);
            this.DefaultScheme_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSet_Students)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Class_Managmnt_panel;
        private System.Windows.Forms.GroupBox groupBoxContents;
        private System.Windows.Forms.ComboBox Semester_combobox;
        private System.Windows.Forms.TextBox NewBranch_textbox;
        private System.Windows.Forms.TextBox Course_textbox;
        private System.Windows.Forms.Button AddNewCourse_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox UpdateBranch_combobox;
        private System.Windows.Forms.Button DeleteBranch_btn;
        private System.Windows.Forms.Button AddNewBranch_btn;
        private System.Windows.Forms.Button DeleteCourse_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton Class_dgv_radiobtn;
        private System.Windows.Forms.RadioButton Branch_dgv_radiobtn;
        private System.Windows.Forms.TextBox Examcode_textbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox NewBranchGroupbox;
        private System.Windows.Forms.GroupBox NewCourseGroupbox;
        private System.Windows.Forms.TextBox ACode_textbox;
        private System.Windows.Forms.GroupBox NewClassGroupbox;
        private System.Windows.Forms.TextBox NewClass_textbox;
        private System.Windows.Forms.Label NewClass_label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button AddNewClass_btn;
        private System.Windows.Forms.Button DeleteClass_btn;
        private System.Windows.Forms.ComboBox NewClassSem_combobox;
        private System.Windows.Forms.Panel DefaultScheme_Panel;
        private System.Windows.Forms.Button ChangeScheme_btn;
        private System.Windows.Forms.TextBox ChangeScheme_textbox;
        private System.Windows.Forms.Label Scheme_label;
        private System.Windows.Forms.Panel RadioButton_panel;
        private Exam_CellDataSet_Students exam_CellDataSet_Students;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private Exam_CellDataSet_StudentsTableAdapters.StudentsTableAdapter studentsTableAdapter;
        private System.Windows.Forms.RadioButton Class_radiobtn;
        private System.Windows.Forms.RadioButton DefaultScheme_radiobtn;
        private System.Windows.Forms.DataGridView Scheme_dgv;
    }
}