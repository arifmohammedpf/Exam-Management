namespace Exam_Cell
{
    partial class menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllExamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeleteClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeleteSubjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeleteStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timetableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidateEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postponementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allotmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyExamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 450);
            this.panel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.editToolStripMenuItem,
            this.timetableToolStripMenuItem,
            this.candidateEntryToolStripMenuItem,
            this.postponementToolStripMenuItem,
            this.roomToolStripMenuItem,
            this.allotmentToolStripMenuItem,
            this.modifyExamToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(888, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.backupToolStripMenuItem1,
            this.openFolderToolStripMenuItem,
            this.deleteAllExamToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.filesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.backupToolStripMenuItem.Text = "Restore";
            // 
            // backupToolStripMenuItem1
            // 
            this.backupToolStripMenuItem1.Name = "backupToolStripMenuItem1";
            this.backupToolStripMenuItem1.Size = new System.Drawing.Size(190, 26);
            this.backupToolStripMenuItem1.Text = "Backup";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            // 
            // deleteAllExamToolStripMenuItem
            // 
            this.deleteAllExamToolStripMenuItem.Name = "deleteAllExamToolStripMenuItem";
            this.deleteAllExamToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.deleteAllExamToolStripMenuItem.Text = "Delete All Exam";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDeleteClassToolStripMenuItem,
            this.addDeleteSubjectsToolStripMenuItem,
            this.addDeleteStudentToolStripMenuItem,
            this.findToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addDeleteClassToolStripMenuItem
            // 
            this.addDeleteClassToolStripMenuItem.Name = "addDeleteClassToolStripMenuItem";
            this.addDeleteClassToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.addDeleteClassToolStripMenuItem.Text = "Add/Delete Class";
            // 
            // addDeleteSubjectsToolStripMenuItem
            // 
            this.addDeleteSubjectsToolStripMenuItem.Name = "addDeleteSubjectsToolStripMenuItem";
            this.addDeleteSubjectsToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.addDeleteSubjectsToolStripMenuItem.Text = "Add/Delete Subject";
            // 
            // addDeleteStudentToolStripMenuItem
            // 
            this.addDeleteStudentToolStripMenuItem.Name = "addDeleteStudentToolStripMenuItem";
            this.addDeleteStudentToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.addDeleteStudentToolStripMenuItem.Text = "Add/Delete Student";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // timetableToolStripMenuItem
            // 
            this.timetableToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.timetableToolStripMenuItem.Name = "timetableToolStripMenuItem";
            this.timetableToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.timetableToolStripMenuItem.Text = "Timetable";
            this.timetableToolStripMenuItem.Click += new System.EventHandler(this.timetableToolStripMenuItem_Click);
            // 
            // candidateEntryToolStripMenuItem
            // 
            this.candidateEntryToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.candidateEntryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.candidateEntryToolStripMenuItem.Name = "candidateEntryToolStripMenuItem";
            this.candidateEntryToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.candidateEntryToolStripMenuItem.Text = "Candidate Entry";
            this.candidateEntryToolStripMenuItem.Click += new System.EventHandler(this.candidateEntryToolStripMenuItem_Click);
            // 
            // postponementToolStripMenuItem
            // 
            this.postponementToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.postponementToolStripMenuItem.Name = "postponementToolStripMenuItem";
            this.postponementToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.postponementToolStripMenuItem.Text = "Postponement";
            this.postponementToolStripMenuItem.Click += new System.EventHandler(this.postponementToolStripMenuItem_Click);
            // 
            // roomToolStripMenuItem
            // 
            this.roomToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            this.roomToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.roomToolStripMenuItem.Text = "Room";
            this.roomToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roomToolStripMenuItem.Click += new System.EventHandler(this.roomToolStripMenuItem_Click);
            // 
            // allotmentToolStripMenuItem
            // 
            this.allotmentToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.allotmentToolStripMenuItem.Name = "allotmentToolStripMenuItem";
            this.allotmentToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.allotmentToolStripMenuItem.Text = "Allotment";
            this.allotmentToolStripMenuItem.Click += new System.EventHandler(this.allotmentToolStripMenuItem_Click);
            // 
            // modifyExamToolStripMenuItem
            // 
            this.modifyExamToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.modifyExamToolStripMenuItem.Name = "modifyExamToolStripMenuItem";
            this.modifyExamToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.modifyExamToolStripMenuItem.Text = "Modify Exam";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllExamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeleteClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeleteSubjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeleteStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timetableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem candidateEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postponementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allotmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyExamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}