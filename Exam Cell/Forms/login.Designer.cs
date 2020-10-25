namespace Exam_Cell
{
    partial class loginpage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginpage));
            this.bgpanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Loginbuttn = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Pwdlabel = new System.Windows.Forms.Label();
            this.Usrlabel = new System.Windows.Forms.Label();
            this.bgpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgpanel
            // 
            this.bgpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.bgpanel.Controls.Add(this.pictureBox1);
            this.bgpanel.Controls.Add(this.panel1);
            this.bgpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgpanel.Location = new System.Drawing.Point(0, 0);
            this.bgpanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bgpanel.Name = "bgpanel";
            this.bgpanel.Size = new System.Drawing.Size(569, 501);
            this.bgpanel.TabIndex = 0;
            this.bgpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bgpanel_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Loginbuttn);
            this.panel1.Controls.Add(this.Username);
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.Pwdlabel);
            this.panel1.Controls.Add(this.Usrlabel);
            this.panel1.Location = new System.Drawing.Point(96, 174);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 290);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(107, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Exam Cell";
            // 
            // Loginbuttn
            // 
            this.Loginbuttn.BackColor = System.Drawing.Color.Transparent;
            this.Loginbuttn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.Loginbuttn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(40)))));
            this.Loginbuttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Loginbuttn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Loginbuttn.Location = new System.Drawing.Point(35, 212);
            this.Loginbuttn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Loginbuttn.Name = "Loginbuttn";
            this.Loginbuttn.Size = new System.Drawing.Size(279, 37);
            this.Loginbuttn.TabIndex = 2;
            this.Loginbuttn.Text = "Login";
            this.Loginbuttn.UseVisualStyleBackColor = false;
            this.Loginbuttn.Click += new System.EventHandler(this.loginbuttn_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(35, 102);
            this.Username.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(279, 22);
            this.Username.TabIndex = 1;
            this.Username.Text = "admin";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(35, 165);
            this.Password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(279, 22);
            this.Password.TabIndex = 1;
            this.Password.Text = "admin";
            this.Password.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // Pwdlabel
            // 
            this.Pwdlabel.AutoSize = true;
            this.Pwdlabel.Font = new System.Drawing.Font("Agency FB", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pwdlabel.ForeColor = System.Drawing.Color.White;
            this.Pwdlabel.Location = new System.Drawing.Point(31, 140);
            this.Pwdlabel.Name = "Pwdlabel";
            this.Pwdlabel.Size = new System.Drawing.Size(70, 24);
            this.Pwdlabel.TabIndex = 0;
            this.Pwdlabel.Text = "Password";
            // 
            // Usrlabel
            // 
            this.Usrlabel.AutoSize = true;
            this.Usrlabel.Font = new System.Drawing.Font("Agency FB", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usrlabel.ForeColor = System.Drawing.Color.White;
            this.Usrlabel.Location = new System.Drawing.Point(31, 78);
            this.Usrlabel.Name = "Usrlabel";
            this.Usrlabel.Size = new System.Drawing.Size(70, 24);
            this.Usrlabel.TabIndex = 0;
            this.Usrlabel.Text = "Username";
            this.Usrlabel.Click += new System.EventHandler(this.usrlabel_Click);
            // 
            // loginpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 501);
            this.Controls.Add(this.bgpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "loginpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.bgpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bgpanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label Pwdlabel;
        private System.Windows.Forms.Label Usrlabel;
        private System.Windows.Forms.Button Loginbuttn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

