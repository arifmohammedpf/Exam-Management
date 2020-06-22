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
            this.Date_combobox = new System.Windows.Forms.ComboBox();
            this.Session_combobox = new System.Windows.Forms.ComboBox();
            this.Room_combobox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Absentees_btn = new System.Windows.Forms.Button();
            this.Statement_form_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Date_combobox
            // 
            this.Date_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Date_combobox.FormattingEnabled = true;
            this.Date_combobox.Location = new System.Drawing.Point(445, 328);
            this.Date_combobox.Name = "Date_combobox";
            this.Date_combobox.Size = new System.Drawing.Size(121, 24);
            this.Date_combobox.TabIndex = 0;
            // 
            // Session_combobox
            // 
            this.Session_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Session_combobox.FormattingEnabled = true;
            this.Session_combobox.Location = new System.Drawing.Point(445, 358);
            this.Session_combobox.Name = "Session_combobox";
            this.Session_combobox.Size = new System.Drawing.Size(121, 24);
            this.Session_combobox.TabIndex = 1;
            // 
            // Room_combobox
            // 
            this.Room_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Room_combobox.FormattingEnabled = true;
            this.Room_combobox.Location = new System.Drawing.Point(445, 388);
            this.Room_combobox.Name = "Room_combobox";
            this.Room_combobox.Size = new System.Drawing.Size(121, 24);
            this.Room_combobox.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(63, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(272, 167);
            this.dataGridView1.TabIndex = 2;
            // 
            // Absentees_btn
            // 
            this.Absentees_btn.Location = new System.Drawing.Point(445, 109);
            this.Absentees_btn.Name = "Absentees_btn";
            this.Absentees_btn.Size = new System.Drawing.Size(142, 47);
            this.Absentees_btn.TabIndex = 3;
            this.Absentees_btn.Text = "Enter Absentees";
            this.Absentees_btn.UseVisualStyleBackColor = true;
            // 
            // Statement_form_btn
            // 
            this.Statement_form_btn.Location = new System.Drawing.Point(514, 196);
            this.Statement_form_btn.Name = "Statement_form_btn";
            this.Statement_form_btn.Size = new System.Drawing.Size(142, 47);
            this.Statement_form_btn.TabIndex = 3;
            this.Statement_form_btn.Text = "Statement";
            this.Statement_form_btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(370, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(370, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Session";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(370, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Room No";
            // 
            // Absent_Marking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(900, 678);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Statement_form_btn);
            this.Controls.Add(this.Absentees_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Room_combobox);
            this.Controls.Add(this.Session_combobox);
            this.Controls.Add(this.Date_combobox);
            this.Name = "Absent_Marking";
            this.Text = "Absent_Marking";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Date_combobox;
        private System.Windows.Forms.ComboBox Session_combobox;
        private System.Windows.Forms.ComboBox Room_combobox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Absentees_btn;
        private System.Windows.Forms.Button Statement_form_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}