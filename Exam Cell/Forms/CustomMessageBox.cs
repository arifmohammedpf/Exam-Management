using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Exam_Cell.Forms
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(148, 142, 153), Color.FromArgb(46, 20, 55), 280F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void CustomMessageBox_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        //COPY BELOW CODE TO CALL CUSTOM MESSAGE BOX !
        //CustomMessageBox msgbox = new CustomMessageBox();
        //msgbox.show("Message", "Title", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Error);
        //var result = msgbox.ReturnValue;

        public enum MessageBoxButtons
        {
            OK=0,YesNo=1
        };
        public enum MessageBoxIcon
        {
            Information = 0, Warning = 1, Error = 2, Question = 3
        };
        public string ReturnValue { get; set; }
        public void Show(string msg, string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            labelMessage.Text = "";
            labelTitle.Text = "";
            labelMessage.Text = msg;
            labelTitle.Text = title;

            if (MessageBoxButtons.OK==button)
            {
                btnOk.Visible = true;
                btnYes.Visible = false;
                btnNo.Visible = false;
            }
            else if (MessageBoxButtons.YesNo == button)
            {
                btnOk.Visible = false;
                btnYes.Visible = true;
                btnNo.Visible = true;
            }

            if (MessageBoxIcon.Error == icon)
            {
                pictureIcon.Image = SystemIcons.Error.ToBitmap();
            }
            else if (MessageBoxIcon.Information == icon)
            {
                pictureIcon.Image = SystemIcons.Information.ToBitmap();
            }
            else if (MessageBoxIcon.Warning == icon)
            {
                pictureIcon.Image = SystemIcons.Warning.ToBitmap();
            }
            else if (MessageBoxIcon.Question == icon)
            {
                pictureIcon.Image = SystemIcons.Question.ToBitmap();
            }

            this.ShowDialog();
        }
        
        private void BtnYes_Click(object sender, EventArgs e)
        {
            ReturnValue = "Yes";
            this.Hide();
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            ReturnValue = "No";
            this.Hide();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ReturnValue = "Ok";
            this.Hide();
        }        
    }
}