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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database_Management));
            this.Class_radiobtn = new System.Windows.Forms.RadioButton();
            this.Class_Managmnt_panel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Scheme_dgv = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.RadioButton_panel = new System.Windows.Forms.Panel();
            this.DefaultScheme_radiobtn = new System.Windows.Forms.RadioButton();
            this.exam_CellDataSet_Students = new Exam_Cell.Exam_CellDataSet_Students();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsTableAdapter = new Exam_Cell.Exam_CellDataSet_StudentsTableAdapters.StudentsTableAdapter();
            this.Class_Managmnt_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scheme_dgv)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.NewClassGroupbox.SuspendLayout();
            this.NewBranchGroupbox.SuspendLayout();
            this.NewCourseGroupbox.SuspendLayout();
            this.DefaultScheme_Panel.SuspendLayout();
            this.RadioButton_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSet_Students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Class_radiobtn
            // 
            this.Class_radiobtn.AutoSize = true;
            this.Class_radiobtn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Class_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Class_radiobtn.Location = new System.Drawing.Point(139, 19);
            this.Class_radiobtn.Name = "Class_radiobtn";
            this.Class_radiobtn.Size = new System.Drawing.Size(264, 30);
            this.Class_radiobtn.TabIndex = 6;
            this.Class_radiobtn.Text = "Class/Branch Management";
            this.Class_radiobtn.UseVisualStyleBackColor = true;
            this.Class_radiobtn.CheckedChanged += new System.EventHandler(this.Class_radiobtn_CheckedChanged);
            // 
            // Class_Managmnt_panel
            // 
            this.Class_Managmnt_panel.Controls.Add(this.panel2);
            this.Class_Managmnt_panel.Controls.Add(this.groupBox3);
            this.Class_Managmnt_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Class_Managmnt_panel.Location = new System.Drawing.Point(0, 64);
            this.Class_Managmnt_panel.Name = "Class_Managmnt_panel";
            this.Class_Managmnt_panel.Size = new System.Drawing.Size(1604, 673);
            this.Class_Managmnt_panel.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Scheme_dgv);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(627, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 658);
            this.panel2.TabIndex = 7;
            // 
            // Scheme_dgv
            // 
            this.Scheme_dgv.AllowUserToAddRows = false;
            this.Scheme_dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.Scheme_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Scheme_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Scheme_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Scheme_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scheme_dgv.Location = new System.Drawing.Point(0, 0);
            this.Scheme_dgv.Name = "Scheme_dgv";
            this.Scheme_dgv.RowTemplate.Height = 24;
            this.Scheme_dgv.Size = new System.Drawing.Size(898, 658);
            this.Scheme_dgv.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NewClassGroupbox);
            this.groupBox3.Controls.Add(this.NewBranchGroupbox);
            this.groupBox3.Controls.Add(this.NewCourseGroupbox);
            this.groupBox3.Controls.Add(this.Class_dgv_radiobtn);
            this.groupBox3.Controls.Add(this.Branch_dgv_radiobtn);
            this.groupBox3.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(19, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 658);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add/Update Branch";
            // 
            // NewClassGroupbox
            // 
            this.NewClassGroupbox.Controls.Add(this.NewClass_textbox);
            this.NewClassGroupbox.Controls.Add(this.NewClassSem_combobox);
            this.NewClassGroupbox.Controls.Add(this.NewClass_label);
            this.NewClassGroupbox.Controls.Add(this.label9);
            this.NewClassGroupbox.Controls.Add(this.AddNewClass_btn);
            this.NewClassGroupbox.Controls.Add(this.DeleteClass_btn);
            this.NewClassGroupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewClassGroupbox.Location = new System.Drawing.Point(11, 60);
            this.NewClassGroupbox.Name = "NewClassGroupbox";
            this.NewClassGroupbox.Size = new System.Drawing.Size(575, 153);
            this.NewClassGroupbox.TabIndex = 9;
            this.NewClassGroupbox.TabStop = false;
            this.NewClassGroupbox.Text = "New Class";
            // 
            // NewClass_textbox
            // 
            this.NewClass_textbox.Location = new System.Drawing.Point(109, 21);
            this.NewClass_textbox.Name = "NewClass_textbox";
            this.NewClass_textbox.Size = new System.Drawing.Size(447, 33);
            this.NewClass_textbox.TabIndex = 2;
            // 
            // NewClassSem_combobox
            // 
            this.NewClassSem_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.NewClassSem_combobox.Location = new System.Drawing.Point(109, 60);
            this.NewClassSem_combobox.Name = "NewClassSem_combobox";
            this.NewClassSem_combobox.Size = new System.Drawing.Size(447, 32);
            this.NewClassSem_combobox.TabIndex = 5;
            // 
            // NewClass_label
            // 
            this.NewClass_label.AutoSize = true;
            this.NewClass_label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewClass_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewClass_label.Location = new System.Drawing.Point(7, 29);
            this.NewClass_label.Name = "NewClass_label";
            this.NewClass_label.Size = new System.Drawing.Size(48, 23);
            this.NewClass_label.TabIndex = 3;
            this.NewClass_label.Text = "Class";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(7, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 23);
            this.label9.TabIndex = 3;
            this.label9.Text = "Semester";
            // 
            // AddNewClass_btn
            // 
            this.AddNewClass_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.AddNewClass_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddNewClass_btn.Location = new System.Drawing.Point(109, 98);
            this.AddNewClass_btn.Name = "AddNewClass_btn";
            this.AddNewClass_btn.Size = new System.Drawing.Size(140, 38);
            this.AddNewClass_btn.TabIndex = 0;
            this.AddNewClass_btn.Text = "Add New Class";
            this.AddNewClass_btn.UseVisualStyleBackColor = true;
            this.AddNewClass_btn.Click += new System.EventHandler(this.AddNewClass_btn_Click);
            // 
            // DeleteClass_btn
            // 
            this.DeleteClass_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.DeleteClass_btn.ForeColor = System.Drawing.Color.Red;
            this.DeleteClass_btn.Location = new System.Drawing.Point(416, 98);
            this.DeleteClass_btn.Name = "DeleteClass_btn";
            this.DeleteClass_btn.Size = new System.Drawing.Size(140, 38);
            this.DeleteClass_btn.TabIndex = 0;
            this.DeleteClass_btn.Text = "Delete Class";
            this.DeleteClass_btn.UseVisualStyleBackColor = true;
            this.DeleteClass_btn.Click += new System.EventHandler(this.DeleteClass_btn_Click);
            // 
            // NewBranchGroupbox
            // 
            this.NewBranchGroupbox.Controls.Add(this.NewBranch_textbox);
            this.NewBranchGroupbox.Controls.Add(this.label7);
            this.NewBranchGroupbox.Controls.Add(this.AddNewBranch_btn);
            this.NewBranchGroupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewBranchGroupbox.Location = new System.Drawing.Point(11, 234);
            this.NewBranchGroupbox.Name = "NewBranchGroupbox";
            this.NewBranchGroupbox.Size = new System.Drawing.Size(575, 113);
            this.NewBranchGroupbox.TabIndex = 8;
            this.NewBranchGroupbox.TabStop = false;
            this.NewBranchGroupbox.Text = "New Branch";
            // 
            // NewBranch_textbox
            // 
            this.NewBranch_textbox.Location = new System.Drawing.Point(109, 24);
            this.NewBranch_textbox.Name = "NewBranch_textbox";
            this.NewBranch_textbox.Size = new System.Drawing.Size(447, 33);
            this.NewBranch_textbox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(7, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "Branch";
            // 
            // AddNewBranch_btn
            // 
            this.AddNewBranch_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.AddNewBranch_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddNewBranch_btn.Location = new System.Drawing.Point(109, 63);
            this.AddNewBranch_btn.Name = "AddNewBranch_btn";
            this.AddNewBranch_btn.Size = new System.Drawing.Size(195, 34);
            this.AddNewBranch_btn.TabIndex = 0;
            this.AddNewBranch_btn.Text = "Add New Branch";
            this.AddNewBranch_btn.UseVisualStyleBackColor = true;
            this.AddNewBranch_btn.Click += new System.EventHandler(this.AddNewBranch_btn_Click);
            // 
            // NewCourseGroupbox
            // 
            this.NewCourseGroupbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            this.NewCourseGroupbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NewCourseGroupbox.Location = new System.Drawing.Point(11, 368);
            this.NewCourseGroupbox.Name = "NewCourseGroupbox";
            this.NewCourseGroupbox.Size = new System.Drawing.Size(576, 284);
            this.NewCourseGroupbox.TabIndex = 8;
            this.NewCourseGroupbox.TabStop = false;
            this.NewCourseGroupbox.Text = "New Course";
            // 
            // Course_textbox
            // 
            this.Course_textbox.Location = new System.Drawing.Point(109, 105);
            this.Course_textbox.Name = "Course_textbox";
            this.Course_textbox.Size = new System.Drawing.Size(447, 33);
            this.Course_textbox.TabIndex = 2;
            // 
            // UpdateBranch_combobox
            // 
            this.UpdateBranch_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UpdateBranch_combobox.FormattingEnabled = true;
            this.UpdateBranch_combobox.Location = new System.Drawing.Point(109, 29);
            this.UpdateBranch_combobox.Name = "UpdateBranch_combobox";
            this.UpdateBranch_combobox.Size = new System.Drawing.Size(447, 32);
            this.UpdateBranch_combobox.TabIndex = 5;
            this.UpdateBranch_combobox.SelectedIndexChanged += new System.EventHandler(this.UpdateBranch_combobox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(7, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 3;
            this.label8.Text = "Semester";
            // 
            // DeleteBranch_btn
            // 
            this.DeleteBranch_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.DeleteBranch_btn.ForeColor = System.Drawing.Color.Red;
            this.DeleteBranch_btn.Location = new System.Drawing.Point(405, 221);
            this.DeleteBranch_btn.Name = "DeleteBranch_btn";
            this.DeleteBranch_btn.Size = new System.Drawing.Size(151, 41);
            this.DeleteBranch_btn.TabIndex = 0;
            this.DeleteBranch_btn.Text = "Delete Branch";
            this.DeleteBranch_btn.UseVisualStyleBackColor = true;
            this.DeleteBranch_btn.Click += new System.EventHandler(this.DeleteBranch_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(7, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Branch";
            // 
            // Semester_combobox
            // 
            this.Semester_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.Semester_combobox.Location = new System.Drawing.Point(109, 68);
            this.Semester_combobox.Name = "Semester_combobox";
            this.Semester_combobox.Size = new System.Drawing.Size(447, 32);
            this.Semester_combobox.TabIndex = 5;
            this.Semester_combobox.SelectedIndexChanged += new System.EventHandler(this.Semester_combobox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(7, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Course";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(7, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 3;
            this.label10.Text = "Exam Code";
            // 
            // AddNewCourse_btn
            // 
            this.AddNewCourse_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.AddNewCourse_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddNewCourse_btn.Location = new System.Drawing.Point(59, 221);
            this.AddNewCourse_btn.Name = "AddNewCourse_btn";
            this.AddNewCourse_btn.Size = new System.Drawing.Size(183, 41);
            this.AddNewCourse_btn.TabIndex = 0;
            this.AddNewCourse_btn.Text = "Add New Course";
            this.AddNewCourse_btn.UseVisualStyleBackColor = true;
            this.AddNewCourse_btn.Click += new System.EventHandler(this.AddNewCourse_btn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(7, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 23);
            this.label11.TabIndex = 3;
            this.label11.Text = "A Code";
            // 
            // DeleteCourse_btn
            // 
            this.DeleteCourse_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F);
            this.DeleteCourse_btn.ForeColor = System.Drawing.Color.Red;
            this.DeleteCourse_btn.Location = new System.Drawing.Point(248, 221);
            this.DeleteCourse_btn.Name = "DeleteCourse_btn";
            this.DeleteCourse_btn.Size = new System.Drawing.Size(151, 41);
            this.DeleteCourse_btn.TabIndex = 0;
            this.DeleteCourse_btn.Text = "Delete Course";
            this.DeleteCourse_btn.UseVisualStyleBackColor = true;
            this.DeleteCourse_btn.Click += new System.EventHandler(this.DeleteCourse_btn_Click);
            // 
            // ACode_textbox
            // 
            this.ACode_textbox.Location = new System.Drawing.Point(109, 179);
            this.ACode_textbox.Name = "ACode_textbox";
            this.ACode_textbox.Size = new System.Drawing.Size(447, 33);
            this.ACode_textbox.TabIndex = 2;
            // 
            // Examcode_textbox
            // 
            this.Examcode_textbox.Location = new System.Drawing.Point(109, 141);
            this.Examcode_textbox.Name = "Examcode_textbox";
            this.Examcode_textbox.Size = new System.Drawing.Size(447, 33);
            this.Examcode_textbox.TabIndex = 2;
            // 
            // Class_dgv_radiobtn
            // 
            this.Class_dgv_radiobtn.AutoSize = true;
            this.Class_dgv_radiobtn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Class_dgv_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Class_dgv_radiobtn.Location = new System.Drawing.Point(115, 31);
            this.Class_dgv_radiobtn.Name = "Class_dgv_radiobtn";
            this.Class_dgv_radiobtn.Size = new System.Drawing.Size(123, 30);
            this.Class_dgv_radiobtn.TabIndex = 6;
            this.Class_dgv_radiobtn.Text = "Class View";
            this.Class_dgv_radiobtn.UseVisualStyleBackColor = true;
            this.Class_dgv_radiobtn.CheckedChanged += new System.EventHandler(this.Class_dgv_radiobtn_CheckedChanged);
            // 
            // Branch_dgv_radiobtn
            // 
            this.Branch_dgv_radiobtn.AutoSize = true;
            this.Branch_dgv_radiobtn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Branch_dgv_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Branch_dgv_radiobtn.Location = new System.Drawing.Point(287, 31);
            this.Branch_dgv_radiobtn.Name = "Branch_dgv_radiobtn";
            this.Branch_dgv_radiobtn.Size = new System.Drawing.Size(140, 30);
            this.Branch_dgv_radiobtn.TabIndex = 6;
            this.Branch_dgv_radiobtn.Text = "Branch View";
            this.Branch_dgv_radiobtn.UseVisualStyleBackColor = true;
            this.Branch_dgv_radiobtn.CheckedChanged += new System.EventHandler(this.Branch_dgv_radiobtn_CheckedChanged);
            // 
            // DefaultScheme_Panel
            // 
            this.DefaultScheme_Panel.Controls.Add(this.ChangeScheme_btn);
            this.DefaultScheme_Panel.Controls.Add(this.ChangeScheme_textbox);
            this.DefaultScheme_Panel.Controls.Add(this.Scheme_label);
            this.DefaultScheme_Panel.Location = new System.Drawing.Point(567, 225);
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
            // RadioButton_panel
            // 
            this.RadioButton_panel.Controls.Add(this.Class_radiobtn);
            this.RadioButton_panel.Controls.Add(this.DefaultScheme_radiobtn);
            this.RadioButton_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RadioButton_panel.Location = new System.Drawing.Point(0, 0);
            this.RadioButton_panel.Name = "RadioButton_panel";
            this.RadioButton_panel.Size = new System.Drawing.Size(1604, 64);
            this.RadioButton_panel.TabIndex = 9;
            // 
            // DefaultScheme_radiobtn
            // 
            this.DefaultScheme_radiobtn.AutoSize = true;
            this.DefaultScheme_radiobtn.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultScheme_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DefaultScheme_radiobtn.Location = new System.Drawing.Point(447, 19);
            this.DefaultScheme_radiobtn.Name = "DefaultScheme_radiobtn";
            this.DefaultScheme_radiobtn.Size = new System.Drawing.Size(174, 30);
            this.DefaultScheme_radiobtn.TabIndex = 6;
            this.DefaultScheme_radiobtn.Text = "Default Scheme";
            this.DefaultScheme_radiobtn.UseVisualStyleBackColor = true;
            this.DefaultScheme_radiobtn.CheckedChanged += new System.EventHandler(this.DefaultScheme_radiobtn_CheckedChanged);
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
            this.ClientSize = new System.Drawing.Size(1604, 737);
            this.Controls.Add(this.Class_Managmnt_panel);
            this.Controls.Add(this.RadioButton_panel);
            this.Controls.Add(this.DefaultScheme_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Database_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Management";
            this.Load += new System.EventHandler(this.Database_Management_Load);
            this.Class_Managmnt_panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Scheme_dgv)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.NewClassGroupbox.ResumeLayout(false);
            this.NewClassGroupbox.PerformLayout();
            this.NewBranchGroupbox.ResumeLayout(false);
            this.NewBranchGroupbox.PerformLayout();
            this.NewCourseGroupbox.ResumeLayout(false);
            this.NewCourseGroupbox.PerformLayout();
            this.DefaultScheme_Panel.ResumeLayout(false);
            this.DefaultScheme_Panel.PerformLayout();
            this.RadioButton_panel.ResumeLayout(false);
            this.RadioButton_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exam_CellDataSet_Students)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton Class_radiobtn;
        private System.Windows.Forms.Panel Class_Managmnt_panel;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.DataGridView Scheme_dgv;
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
        private System.Windows.Forms.RadioButton DefaultScheme_radiobtn;
        private Exam_CellDataSet_Students exam_CellDataSet_Students;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private Exam_CellDataSet_StudentsTableAdapters.StudentsTableAdapter studentsTableAdapter;
        private System.Windows.Forms.Panel panel2;
    }
}