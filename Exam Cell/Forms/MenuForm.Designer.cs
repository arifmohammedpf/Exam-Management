namespace Exam_Cell.Forms
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.MenuSidePanel = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.TtableForm_btn = new System.Windows.Forms.Button();
            this.CandEntryForm_btn = new System.Windows.Forms.Button();
            this.AllotmentForm_btn = new System.Windows.Forms.Button();
            this.RegStyMng_btn = new System.Windows.Forms.Button();
            this.RoomForm_btn = new System.Windows.Forms.Button();
            this.Absentees_btn = new System.Windows.Forms.Button();
            this.panelAbsentDropMenu = new System.Windows.Forms.Panel();
            this.AbsentStateForm_btn = new System.Windows.Forms.Button();
            this.AbsentMarkForm_btn = new System.Windows.Forms.Button();
            this.PostponeForm_btn = new System.Windows.Forms.Button();
            this.Dbm_btn = new System.Windows.Forms.Button();
            this.panelDbmDropMenu = new System.Windows.Forms.Panel();
            this.ClassbranchForm_btn = new System.Windows.Forms.Button();
            this.StudentForm_btn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            this.panelAbsentDropMenu.SuspendLayout();
            this.panelDbmDropMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(43)))), ((int)(((byte)(99)))));
            this.panelSideMenu.Controls.Add(this.Exit_btn);
            this.panelSideMenu.Controls.Add(this.CreditsBtn);
            this.panelSideMenu.Controls.Add(this.panelDbmDropMenu);
            this.panelSideMenu.Controls.Add(this.Dbm_btn);
            this.panelSideMenu.Controls.Add(this.PostponeForm_btn);
            this.panelSideMenu.Controls.Add(this.panelAbsentDropMenu);
            this.panelSideMenu.Controls.Add(this.Absentees_btn);
            this.panelSideMenu.Controls.Add(this.RoomForm_btn);
            this.panelSideMenu.Controls.Add(this.RegStyMng_btn);
            this.panelSideMenu.Controls.Add(this.AllotmentForm_btn);
            this.panelSideMenu.Controls.Add(this.CandEntryForm_btn);
            this.panelSideMenu.Controls.Add(this.MenuSidePanel);
            this.panelSideMenu.Controls.Add(this.TtableForm_btn);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Padding = new System.Windows.Forms.Padding(0, 40, 0, 40);
            this.panelSideMenu.Size = new System.Drawing.Size(245, 864);
            this.panelSideMenu.TabIndex = 0;
            // 
            // MenuSidePanel
            // 
            this.MenuSidePanel.BackColor = System.Drawing.Color.Lavender;
            this.MenuSidePanel.Location = new System.Drawing.Point(1, 126);
            this.MenuSidePanel.Name = "MenuSidePanel";
            this.MenuSidePanel.Size = new System.Drawing.Size(10, 70);
            this.MenuSidePanel.TabIndex = 13;
            // 
            // panelChildForm
            // 
            this.panelChildForm.AutoScroll = true;
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelChildForm.Controls.Add(this.label1);
            this.panelChildForm.Controls.Add(this.pictureBox1);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(245, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1675, 864);
            this.panelChildForm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(1235, 801);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "© 2020, Arif Mohammed, CSE 2016 Batch.";
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // TtableForm_btn
            // 
            this.TtableForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.TtableForm_btn.FlatAppearance.BorderSize = 0;
            this.TtableForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.TtableForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TtableForm_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.TtableForm_btn.Location = new System.Drawing.Point(0, 40);
            this.TtableForm_btn.Name = "TtableForm_btn";
            this.TtableForm_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.TtableForm_btn.Size = new System.Drawing.Size(224, 70);
            this.TtableForm_btn.TabIndex = 14;
            this.TtableForm_btn.Text = "Timetable";
            this.TtableForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TtableForm_btn.UseVisualStyleBackColor = true;
            this.TtableForm_btn.Click += new System.EventHandler(this.TtableForm_btn_Click);
            // 
            // CandEntryForm_btn
            // 
            this.CandEntryForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CandEntryForm_btn.FlatAppearance.BorderSize = 0;
            this.CandEntryForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.CandEntryForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CandEntryForm_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.CandEntryForm_btn.Location = new System.Drawing.Point(0, 110);
            this.CandEntryForm_btn.Name = "CandEntryForm_btn";
            this.CandEntryForm_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.CandEntryForm_btn.Size = new System.Drawing.Size(224, 70);
            this.CandEntryForm_btn.TabIndex = 15;
            this.CandEntryForm_btn.Text = "Candidate Entry";
            this.CandEntryForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CandEntryForm_btn.UseVisualStyleBackColor = true;
            this.CandEntryForm_btn.Click += new System.EventHandler(this.CandEntryForm_btn_Click);
            // 
            // AllotmentForm_btn
            // 
            this.AllotmentForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AllotmentForm_btn.FlatAppearance.BorderSize = 0;
            this.AllotmentForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.AllotmentForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AllotmentForm_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.AllotmentForm_btn.Location = new System.Drawing.Point(0, 180);
            this.AllotmentForm_btn.Name = "AllotmentForm_btn";
            this.AllotmentForm_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.AllotmentForm_btn.Size = new System.Drawing.Size(224, 70);
            this.AllotmentForm_btn.TabIndex = 16;
            this.AllotmentForm_btn.Text = "Allotment";
            this.AllotmentForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AllotmentForm_btn.UseVisualStyleBackColor = true;
            this.AllotmentForm_btn.Click += new System.EventHandler(this.AllotmentForm_btn_Click);
            // 
            // RegStyMng_btn
            // 
            this.RegStyMng_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RegStyMng_btn.FlatAppearance.BorderSize = 0;
            this.RegStyMng_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.RegStyMng_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegStyMng_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.RegStyMng_btn.Location = new System.Drawing.Point(0, 250);
            this.RegStyMng_btn.Name = "RegStyMng_btn";
            this.RegStyMng_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.RegStyMng_btn.Size = new System.Drawing.Size(224, 70);
            this.RegStyMng_btn.TabIndex = 17;
            this.RegStyMng_btn.Text = "Reg.Stu.Management";
            this.RegStyMng_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RegStyMng_btn.UseVisualStyleBackColor = true;
            this.RegStyMng_btn.Click += new System.EventHandler(this.RegStyMng_btn_Click);
            // 
            // RoomForm_btn
            // 
            this.RoomForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RoomForm_btn.FlatAppearance.BorderSize = 0;
            this.RoomForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.RoomForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RoomForm_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.RoomForm_btn.Location = new System.Drawing.Point(0, 320);
            this.RoomForm_btn.Name = "RoomForm_btn";
            this.RoomForm_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.RoomForm_btn.Size = new System.Drawing.Size(224, 70);
            this.RoomForm_btn.TabIndex = 18;
            this.RoomForm_btn.Text = "Room";
            this.RoomForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RoomForm_btn.UseVisualStyleBackColor = true;
            this.RoomForm_btn.Click += new System.EventHandler(this.RoomForm_btn_Click);
            // 
            // Absentees_btn
            // 
            this.Absentees_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Absentees_btn.FlatAppearance.BorderSize = 0;
            this.Absentees_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.Absentees_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Absentees_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.Absentees_btn.Location = new System.Drawing.Point(0, 390);
            this.Absentees_btn.Name = "Absentees_btn";
            this.Absentees_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.Absentees_btn.Size = new System.Drawing.Size(224, 70);
            this.Absentees_btn.TabIndex = 19;
            this.Absentees_btn.Text = "Absentees";
            this.Absentees_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Absentees_btn.UseVisualStyleBackColor = true;
            this.Absentees_btn.Click += new System.EventHandler(this.Absentees_btn_Click);
            // 
            // panelAbsentDropMenu
            // 
            this.panelAbsentDropMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelAbsentDropMenu.Controls.Add(this.AbsentStateForm_btn);
            this.panelAbsentDropMenu.Controls.Add(this.AbsentMarkForm_btn);
            this.panelAbsentDropMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAbsentDropMenu.Location = new System.Drawing.Point(0, 460);
            this.panelAbsentDropMenu.Name = "panelAbsentDropMenu";
            this.panelAbsentDropMenu.Size = new System.Drawing.Size(224, 140);
            this.panelAbsentDropMenu.TabIndex = 20;
            // 
            // AbsentStateForm_btn
            // 
            this.AbsentStateForm_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.AbsentStateForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AbsentStateForm_btn.FlatAppearance.BorderSize = 0;
            this.AbsentStateForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(87)))), ((int)(((byte)(153)))));
            this.AbsentStateForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AbsentStateForm_btn.ForeColor = System.Drawing.Color.LightGray;
            this.AbsentStateForm_btn.Location = new System.Drawing.Point(0, 70);
            this.AbsentStateForm_btn.Name = "AbsentStateForm_btn";
            this.AbsentStateForm_btn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.AbsentStateForm_btn.Size = new System.Drawing.Size(224, 70);
            this.AbsentStateForm_btn.TabIndex = 1;
            this.AbsentStateForm_btn.Text = "Absent Statement";
            this.AbsentStateForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AbsentStateForm_btn.UseVisualStyleBackColor = false;
            this.AbsentStateForm_btn.Click += new System.EventHandler(this.AbsentStateForm_btn_Click);
            // 
            // AbsentMarkForm_btn
            // 
            this.AbsentMarkForm_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.AbsentMarkForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AbsentMarkForm_btn.FlatAppearance.BorderSize = 0;
            this.AbsentMarkForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(87)))), ((int)(((byte)(153)))));
            this.AbsentMarkForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AbsentMarkForm_btn.ForeColor = System.Drawing.Color.LightGray;
            this.AbsentMarkForm_btn.Location = new System.Drawing.Point(0, 0);
            this.AbsentMarkForm_btn.Name = "AbsentMarkForm_btn";
            this.AbsentMarkForm_btn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.AbsentMarkForm_btn.Size = new System.Drawing.Size(224, 70);
            this.AbsentMarkForm_btn.TabIndex = 0;
            this.AbsentMarkForm_btn.Text = "Absent Marking";
            this.AbsentMarkForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AbsentMarkForm_btn.UseVisualStyleBackColor = false;
            this.AbsentMarkForm_btn.Click += new System.EventHandler(this.AbsentMarkForm_btn_Click);
            // 
            // PostponeForm_btn
            // 
            this.PostponeForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.PostponeForm_btn.FlatAppearance.BorderSize = 0;
            this.PostponeForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.PostponeForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PostponeForm_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.PostponeForm_btn.Location = new System.Drawing.Point(0, 600);
            this.PostponeForm_btn.Name = "PostponeForm_btn";
            this.PostponeForm_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.PostponeForm_btn.Size = new System.Drawing.Size(224, 70);
            this.PostponeForm_btn.TabIndex = 21;
            this.PostponeForm_btn.Text = "Postponement";
            this.PostponeForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PostponeForm_btn.UseVisualStyleBackColor = true;
            this.PostponeForm_btn.Click += new System.EventHandler(this.PostponeForm_btn_Click);
            // 
            // Dbm_btn
            // 
            this.Dbm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Dbm_btn.FlatAppearance.BorderSize = 0;
            this.Dbm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.Dbm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dbm_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.Dbm_btn.Location = new System.Drawing.Point(0, 670);
            this.Dbm_btn.Name = "Dbm_btn";
            this.Dbm_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.Dbm_btn.Size = new System.Drawing.Size(224, 70);
            this.Dbm_btn.TabIndex = 22;
            this.Dbm_btn.Text = "Database Management";
            this.Dbm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Dbm_btn.UseVisualStyleBackColor = true;
            this.Dbm_btn.Click += new System.EventHandler(this.Dbm_btn_Click);
            // 
            // panelDbmDropMenu
            // 
            this.panelDbmDropMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelDbmDropMenu.Controls.Add(this.ClassbranchForm_btn);
            this.panelDbmDropMenu.Controls.Add(this.StudentForm_btn);
            this.panelDbmDropMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDbmDropMenu.Location = new System.Drawing.Point(0, 740);
            this.panelDbmDropMenu.Name = "panelDbmDropMenu";
            this.panelDbmDropMenu.Size = new System.Drawing.Size(224, 140);
            this.panelDbmDropMenu.TabIndex = 23;
            // 
            // ClassbranchForm_btn
            // 
            this.ClassbranchForm_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClassbranchForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClassbranchForm_btn.FlatAppearance.BorderSize = 0;
            this.ClassbranchForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(87)))), ((int)(((byte)(153)))));
            this.ClassbranchForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClassbranchForm_btn.ForeColor = System.Drawing.Color.LightGray;
            this.ClassbranchForm_btn.Location = new System.Drawing.Point(0, 70);
            this.ClassbranchForm_btn.Name = "ClassbranchForm_btn";
            this.ClassbranchForm_btn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.ClassbranchForm_btn.Size = new System.Drawing.Size(224, 70);
            this.ClassbranchForm_btn.TabIndex = 1;
            this.ClassbranchForm_btn.Text = "Class/Branch";
            this.ClassbranchForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClassbranchForm_btn.UseVisualStyleBackColor = false;
            this.ClassbranchForm_btn.Click += new System.EventHandler(this.ClassbranchForm_btn_Click);
            // 
            // StudentForm_btn
            // 
            this.StudentForm_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.StudentForm_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.StudentForm_btn.FlatAppearance.BorderSize = 0;
            this.StudentForm_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(87)))), ((int)(((byte)(153)))));
            this.StudentForm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StudentForm_btn.ForeColor = System.Drawing.Color.LightGray;
            this.StudentForm_btn.Location = new System.Drawing.Point(0, 0);
            this.StudentForm_btn.Name = "StudentForm_btn";
            this.StudentForm_btn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.StudentForm_btn.Size = new System.Drawing.Size(224, 70);
            this.StudentForm_btn.TabIndex = 0;
            this.StudentForm_btn.Text = "Student";
            this.StudentForm_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StudentForm_btn.UseVisualStyleBackColor = false;
            this.StudentForm_btn.Click += new System.EventHandler(this.StudentForm_btn_Click);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.CreditsBtn.Location = new System.Drawing.Point(0, 880);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.CreditsBtn.Size = new System.Drawing.Size(224, 70);
            this.CreditsBtn.TabIndex = 24;
            this.CreditsBtn.Text = "Credits";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = true;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Exit_btn.FlatAppearance.BorderSize = 0;
            this.Exit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(125)))), ((int)(((byte)(182)))));
            this.Exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_btn.ForeColor = System.Drawing.Color.Gainsboro;
            this.Exit_btn.Location = new System.Drawing.Point(0, 950);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.Exit_btn.Size = new System.Drawing.Size(224, 70);
            this.Exit_btn.TabIndex = 25;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Exam_Cell.Properties.Resources.kmea_hd_logo_shabz_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1675, 864);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1920, 864);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);
            this.panelSideMenu.ResumeLayout(false);
            this.panelChildForm.ResumeLayout(false);
            this.panelChildForm.PerformLayout();
            this.panelAbsentDropMenu.ResumeLayout(false);
            this.panelDbmDropMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel MenuSidePanel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.Button CreditsBtn;
        private System.Windows.Forms.Panel panelDbmDropMenu;
        private System.Windows.Forms.Button ClassbranchForm_btn;
        private System.Windows.Forms.Button StudentForm_btn;
        private System.Windows.Forms.Button Dbm_btn;
        private System.Windows.Forms.Button PostponeForm_btn;
        private System.Windows.Forms.Panel panelAbsentDropMenu;
        private System.Windows.Forms.Button AbsentStateForm_btn;
        private System.Windows.Forms.Button AbsentMarkForm_btn;
        private System.Windows.Forms.Button Absentees_btn;
        private System.Windows.Forms.Button RoomForm_btn;
        private System.Windows.Forms.Button RegStyMng_btn;
        private System.Windows.Forms.Button AllotmentForm_btn;
        private System.Windows.Forms.Button CandEntryForm_btn;
        private System.Windows.Forms.Button TtableForm_btn;
    }
}