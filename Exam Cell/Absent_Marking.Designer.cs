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
            this.Unv_radio = new System.Windows.Forms.RadioButton();
            this.Series_radio = new System.Windows.Forms.RadioButton();
            this.Panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.Search_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearData_btn = new System.Windows.Forms.Button();
            this.Absentees_btn = new System.Windows.Forms.Button();
            this.Room_combobox = new System.Windows.Forms.ComboBox();
            this.Session_combobox = new System.Windows.Forms.ComboBox();
            this.Date_combobox = new System.Windows.Forms.ComboBox();
            this.Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Unv_radio
            // 
            this.Unv_radio.AutoSize = true;
            this.Unv_radio.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unv_radio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Unv_radio.Location = new System.Drawing.Point(18, 43);
            this.Unv_radio.Name = "Unv_radio";
            this.Unv_radio.Size = new System.Drawing.Size(112, 28);
            this.Unv_radio.TabIndex = 6;
            this.Unv_radio.Text = "University";
            this.Unv_radio.UseVisualStyleBackColor = true;
            this.Unv_radio.CheckedChanged += new System.EventHandler(this.Unv_radio_CheckedChanged);
            // 
            // Series_radio
            // 
            this.Series_radio.AutoSize = true;
            this.Series_radio.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Series_radio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Series_radio.Location = new System.Drawing.Point(154, 43);
            this.Series_radio.Name = "Series_radio";
            this.Series_radio.Size = new System.Drawing.Size(83, 28);
            this.Series_radio.TabIndex = 6;
            this.Series_radio.Text = "Series";
            this.Series_radio.UseVisualStyleBackColor = true;
            this.Series_radio.CheckedChanged += new System.EventHandler(this.Series_radio_CheckedChanged);
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.panel1);
            this.Panel.Controls.Add(this.Search_btn);
            this.Panel.Controls.Add(this.label3);
            this.Panel.Controls.Add(this.label2);
            this.Panel.Controls.Add(this.label1);
            this.Panel.Controls.Add(this.ClearData_btn);
            this.Panel.Controls.Add(this.Absentees_btn);
            this.Panel.Controls.Add(this.Room_combobox);
            this.Panel.Controls.Add(this.Session_combobox);
            this.Panel.Controls.Add(this.Date_combobox);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1011, 678);
            this.Panel.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Dgv);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(450, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 672);
            this.panel1.TabIndex = 16;
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowTemplate.Height = 24;
            this.Dgv.Size = new System.Drawing.Size(558, 672);
            this.Dgv.TabIndex = 9;
            this.Dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeStatusEvent);
            // 
            // Search_btn
            // 
            this.Search_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_btn.Location = new System.Drawing.Point(114, 234);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(91, 37);
            this.Search_btn.TabIndex = 15;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(14, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Room No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(14, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Session";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Date";
            // 
            // ClearData_btn
            // 
            this.ClearData_btn.BackColor = System.Drawing.Color.Black;
            this.ClearData_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearData_btn.ForeColor = System.Drawing.Color.Red;
            this.ClearData_btn.Location = new System.Drawing.Point(322, 630);
            this.ClearData_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearData_btn.Name = "ClearData_btn";
            this.ClearData_btn.Size = new System.Drawing.Size(111, 37);
            this.ClearData_btn.TabIndex = 10;
            this.ClearData_btn.Text = "Clear Data";
            this.ClearData_btn.UseVisualStyleBackColor = false;
            this.ClearData_btn.Click += new System.EventHandler(this.ClearData_btn_Click);
            // 
            // Absentees_btn
            // 
            this.Absentees_btn.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Absentees_btn.Location = new System.Drawing.Point(114, 298);
            this.Absentees_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Absentees_btn.Name = "Absentees_btn";
            this.Absentees_btn.Size = new System.Drawing.Size(173, 52);
            this.Absentees_btn.TabIndex = 11;
            this.Absentees_btn.Text = "Enter Absentees";
            this.Absentees_btn.UseVisualStyleBackColor = true;
            this.Absentees_btn.Click += new System.EventHandler(this.Absentees_btn_Click);
            // 
            // Room_combobox
            // 
            this.Room_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Room_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Room_combobox.FormattingEnabled = true;
            this.Room_combobox.Location = new System.Drawing.Point(114, 187);
            this.Room_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Room_combobox.Name = "Room_combobox";
            this.Room_combobox.Size = new System.Drawing.Size(319, 32);
            this.Room_combobox.TabIndex = 7;
            // 
            // Session_combobox
            // 
            this.Session_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Session_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Session_combobox.FormattingEnabled = true;
            this.Session_combobox.Items.AddRange(new object[] {
            "-Select-",
            "Forenoon",
            "Afternoon"});
            this.Session_combobox.Location = new System.Drawing.Point(114, 148);
            this.Session_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Session_combobox.Name = "Session_combobox";
            this.Session_combobox.Size = new System.Drawing.Size(319, 32);
            this.Session_combobox.TabIndex = 8;
            // 
            // Date_combobox
            // 
            this.Date_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Date_combobox.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_combobox.FormattingEnabled = true;
            this.Date_combobox.Location = new System.Drawing.Point(114, 107);
            this.Date_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Date_combobox.Name = "Date_combobox";
            this.Date_combobox.Size = new System.Drawing.Size(319, 32);
            this.Date_combobox.TabIndex = 6;
            // 
            // Absent_Marking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1011, 678);
            this.Controls.Add(this.Series_radio);
            this.Controls.Add(this.Unv_radio);
            this.Controls.Add(this.Panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Absent_Marking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Absent_Marking";
            this.Load += new System.EventHandler(this.Absent_Marking_Load);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Unv_radio;
        private System.Windows.Forms.RadioButton Series_radio;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Absentees_btn;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.ComboBox Room_combobox;
        private System.Windows.Forms.ComboBox Session_combobox;
        private System.Windows.Forms.ComboBox Date_combobox;
        private System.Windows.Forms.Button ClearData_btn;
        private System.Windows.Forms.Panel panel1;
    }
}