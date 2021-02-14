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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_item_timetable = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_candidateentry = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_room = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_regstudmgmnt = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_allotment = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_absentees = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dropitem_marking = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dropitem_statement = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_postponement = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_databasemgmnt = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dropitem_student = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dropitem_classbranch = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_credits = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_item_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(43)))), ((int)(((byte)(99)))));
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_item_timetable,
            this.menu_item_candidateentry,
            this.menu_item_room,
            this.menu_item_regstudmgmnt,
            this.menu_item_allotment,
            this.menu_item_absentees,
            this.menu_item_postponement,
            this.menu_item_databasemgmnt,
            this.menu_item_credits,
            this.menu_item_exit});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(1920, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
            // 
            // menu_item_timetable
            // 
            this.menu_item_timetable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_timetable.Name = "menu_item_timetable";
            this.menu_item_timetable.Padding = new System.Windows.Forms.Padding(10);
            this.menu_item_timetable.Size = new System.Drawing.Size(122, 46);
            this.menu_item_timetable.Text = "Timetable";
            this.menu_item_timetable.Click += new System.EventHandler(this.menu_item_timetable_Click);
            // 
            // menu_item_candidateentry
            // 
            this.menu_item_candidateentry.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_candidateentry.Name = "menu_item_candidateentry";
            this.menu_item_candidateentry.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menu_item_candidateentry.Size = new System.Drawing.Size(186, 46);
            this.menu_item_candidateentry.Text = "Candidate Entry";
            this.menu_item_candidateentry.Click += new System.EventHandler(this.menu_item_candidateentry_Click);
            // 
            // menu_item_room
            // 
            this.menu_item_room.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_room.Name = "menu_item_room";
            this.menu_item_room.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menu_item_room.Size = new System.Drawing.Size(87, 46);
            this.menu_item_room.Text = "Room";
            this.menu_item_room.Click += new System.EventHandler(this.menu_item_room_Click);
            // 
            // menu_item_regstudmgmnt
            // 
            this.menu_item_regstudmgmnt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_regstudmgmnt.Name = "menu_item_regstudmgmnt";
            this.menu_item_regstudmgmnt.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menu_item_regstudmgmnt.Size = new System.Drawing.Size(250, 46);
            this.menu_item_regstudmgmnt.Text = "Reg Stud Management";
            this.menu_item_regstudmgmnt.Click += new System.EventHandler(this.menu_item_regstudmgmnt_Click);
            // 
            // menu_item_allotment
            // 
            this.menu_item_allotment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_allotment.Name = "menu_item_allotment";
            this.menu_item_allotment.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menu_item_allotment.Size = new System.Drawing.Size(122, 46);
            this.menu_item_allotment.Text = "Allotment";
            this.menu_item_allotment.Click += new System.EventHandler(this.menu_item_allotment_Click);
            // 
            // menu_item_absentees
            // 
            this.menu_item_absentees.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_dropitem_marking,
            this.menu_dropitem_statement});
            this.menu_item_absentees.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_absentees.Name = "menu_item_absentees";
            this.menu_item_absentees.Size = new System.Drawing.Size(119, 46);
            this.menu_item_absentees.Text = "Absentees";
            // 
            // menu_dropitem_marking
            // 
            this.menu_dropitem_marking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(43)))), ((int)(((byte)(99)))));
            this.menu_dropitem_marking.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_dropitem_marking.Name = "menu_dropitem_marking";
            this.menu_dropitem_marking.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.menu_dropitem_marking.Size = new System.Drawing.Size(216, 44);
            this.menu_dropitem_marking.Text = "Marking";
            this.menu_dropitem_marking.Click += new System.EventHandler(this.menu_dropitem_marking_Click);
            // 
            // menu_dropitem_statement
            // 
            this.menu_dropitem_statement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(43)))), ((int)(((byte)(99)))));
            this.menu_dropitem_statement.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_dropitem_statement.Name = "menu_dropitem_statement";
            this.menu_dropitem_statement.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.menu_dropitem_statement.Size = new System.Drawing.Size(216, 44);
            this.menu_dropitem_statement.Text = "Statement";
            this.menu_dropitem_statement.Click += new System.EventHandler(this.menu_dropitem_statement_Click);
            // 
            // menu_item_postponement
            // 
            this.menu_item_postponement.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_postponement.Name = "menu_item_postponement";
            this.menu_item_postponement.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menu_item_postponement.Size = new System.Drawing.Size(168, 46);
            this.menu_item_postponement.Text = "Postponement";
            this.menu_item_postponement.Click += new System.EventHandler(this.menu_item_postponement_Click);
            // 
            // menu_item_databasemgmnt
            // 
            this.menu_item_databasemgmnt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_dropitem_student,
            this.menu_dropitem_classbranch});
            this.menu_item_databasemgmnt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_databasemgmnt.Name = "menu_item_databasemgmnt";
            this.menu_item_databasemgmnt.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menu_item_databasemgmnt.Size = new System.Drawing.Size(259, 46);
            this.menu_item_databasemgmnt.Text = "Database Management";
            // 
            // menu_dropitem_student
            // 
            this.menu_dropitem_student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(43)))), ((int)(((byte)(99)))));
            this.menu_dropitem_student.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_dropitem_student.Name = "menu_dropitem_student";
            this.menu_dropitem_student.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.menu_dropitem_student.Size = new System.Drawing.Size(216, 44);
            this.menu_dropitem_student.Text = "Student ";
            this.menu_dropitem_student.Click += new System.EventHandler(this.menu_dropitem_student_Click);
            // 
            // menu_dropitem_classbranch
            // 
            this.menu_dropitem_classbranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(43)))), ((int)(((byte)(99)))));
            this.menu_dropitem_classbranch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_dropitem_classbranch.Name = "menu_dropitem_classbranch";
            this.menu_dropitem_classbranch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.menu_dropitem_classbranch.Size = new System.Drawing.Size(216, 44);
            this.menu_dropitem_classbranch.Text = "Class/Branch";
            this.menu_dropitem_classbranch.Click += new System.EventHandler(this.menu_dropitem_classbranch_Click);
            // 
            // menu_item_credits
            // 
            this.menu_item_credits.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_credits.Name = "menu_item_credits";
            this.menu_item_credits.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menu_item_credits.Size = new System.Drawing.Size(97, 46);
            this.menu_item_credits.Text = "Credits";
            this.menu_item_credits.Click += new System.EventHandler(this.menu_item_credits_Click);
            // 
            // menu_item_exit
            // 
            this.menu_item_exit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu_item_exit.Name = "menu_item_exit";
            this.menu_item_exit.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.menu_item_exit.Size = new System.Drawing.Size(73, 46);
            this.menu_item_exit.Text = "Exit";
            this.menu_item_exit.Click += new System.EventHandler(this.menu_item_exit_Click);
            // 
            // bgPanel
            // 
            this.bgPanel.BackColor = System.Drawing.Color.Transparent;
            this.bgPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgPanel.Location = new System.Drawing.Point(0, 46);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(1920, 818);
            this.bgPanel.TabIndex = 2;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.BackgroundImage = global::Exam_Cell.Properties.Resources.kmea_hd_logo_shabz_WHITE;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 864);
            this.Controls.Add(this.bgPanel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_item_exit;
        private System.Windows.Forms.Panel bgPanel;
        public System.Windows.Forms.ToolStripMenuItem menu_item_timetable;
        public System.Windows.Forms.ToolStripMenuItem menu_item_candidateentry;
        public System.Windows.Forms.ToolStripMenuItem menu_item_room;
        public System.Windows.Forms.ToolStripMenuItem menu_item_allotment;
        public System.Windows.Forms.ToolStripMenuItem menu_item_absentees;
        public System.Windows.Forms.ToolStripMenuItem menu_dropitem_marking;
        public System.Windows.Forms.ToolStripMenuItem menu_item_regstudmgmnt;
        public System.Windows.Forms.ToolStripMenuItem menu_dropitem_statement;
        public System.Windows.Forms.ToolStripMenuItem menu_item_postponement;
        public System.Windows.Forms.ToolStripMenuItem menu_item_databasemgmnt;
        public System.Windows.Forms.ToolStripMenuItem menu_item_credits;
        public System.Windows.Forms.ToolStripMenuItem menu_dropitem_student;
        public System.Windows.Forms.ToolStripMenuItem menu_dropitem_classbranch;
    }
}