namespace Exam_Cell
{
    partial class Registered_Students_Management
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
            this.Registered_dgv = new System.Windows.Forms.DataGridView();
            this.Series_radiobtn = new System.Windows.Forms.RadioButton();
            this.Univrsty_radiobtn = new System.Windows.Forms.RadioButton();
            this.Update_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.DeleteAll_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Registered_dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Registered_dgv
            // 
            this.Registered_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Registered_dgv.Location = new System.Drawing.Point(23, 109);
            this.Registered_dgv.Name = "Registered_dgv";
            this.Registered_dgv.RowTemplate.Height = 24;
            this.Registered_dgv.Size = new System.Drawing.Size(621, 423);
            this.Registered_dgv.TabIndex = 0;
            // 
            // Series_radiobtn
            // 
            this.Series_radiobtn.AutoSize = true;
            this.Series_radiobtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Series_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Series_radiobtn.Location = new System.Drawing.Point(180, 31);
            this.Series_radiobtn.Name = "Series_radiobtn";
            this.Series_radiobtn.Size = new System.Drawing.Size(83, 24);
            this.Series_radiobtn.TabIndex = 1;
            this.Series_radiobtn.TabStop = true;
            this.Series_radiobtn.Text = "Series ";
            this.Series_radiobtn.UseVisualStyleBackColor = true;
            this.Series_radiobtn.CheckedChanged += new System.EventHandler(this.Series_radiobtn_CheckedChanged);
            // 
            // Univrsty_radiobtn
            // 
            this.Univrsty_radiobtn.AutoSize = true;
            this.Univrsty_radiobtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Univrsty_radiobtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Univrsty_radiobtn.Location = new System.Drawing.Point(18, 31);
            this.Univrsty_radiobtn.Name = "Univrsty_radiobtn";
            this.Univrsty_radiobtn.Size = new System.Drawing.Size(104, 24);
            this.Univrsty_radiobtn.TabIndex = 1;
            this.Univrsty_radiobtn.TabStop = true;
            this.Univrsty_radiobtn.Text = "University";
            this.Univrsty_radiobtn.UseVisualStyleBackColor = true;
            this.Univrsty_radiobtn.CheckedChanged += new System.EventHandler(this.Univrsty_radiobtn_CheckedChanged);
            // 
            // Update_btn
            // 
            this.Update_btn.Location = new System.Drawing.Point(661, 232);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(122, 35);
            this.Update_btn.TabIndex = 2;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Series_radiobtn);
            this.groupBox1.Controls.Add(this.Univrsty_radiobtn);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(23, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 73);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Exam";
            // 
            // Delete_btn
            // 
            this.Delete_btn.Location = new System.Drawing.Point(661, 285);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(122, 35);
            this.Delete_btn.TabIndex = 2;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            // 
            // DeleteAll_btn
            // 
            this.DeleteAll_btn.Location = new System.Drawing.Point(661, 339);
            this.DeleteAll_btn.Name = "DeleteAll_btn";
            this.DeleteAll_btn.Size = new System.Drawing.Size(122, 35);
            this.DeleteAll_btn.TabIndex = 2;
            this.DeleteAll_btn.Text = "Delete All";
            this.DeleteAll_btn.UseVisualStyleBackColor = true;
            this.DeleteAll_btn.Click += new System.EventHandler(this.DeleteAll_btn_Click);
            // 
            // Registered_Students_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(822, 544);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DeleteAll_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Registered_dgv);
            this.Name = "Registered_Students_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registered_Students_Management";
            this.Load += new System.EventHandler(this.Registered_Students_Management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Registered_dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Registered_dgv;
        private System.Windows.Forms.RadioButton Series_radiobtn;
        private System.Windows.Forms.RadioButton Univrsty_radiobtn;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Button DeleteAll_btn;
    }
}