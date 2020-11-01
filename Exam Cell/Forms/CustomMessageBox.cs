using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Cell.Forms
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
            
        }

        //COPY BELOW CODE TO CALL CUSTOM MESSAGE BOX !
        //CustomMessageBox msgbox = new CustomMessageBox();
        //msgbox.show("Message", "Title", CustomMessageBox.MessageBoxButton.YesNo, CustomMessageBox.MessageBoxIcon.Error);
        //var result = msgbox.ReturnValue;

        public enum MessageBoxButton
        {
            OK=0,YesNo=1
        };
        public enum MessageBoxIcon
        {
            Info = 0, Warning = 1, Error = 2, Question = 3
        };
        public string ReturnValue { get; set; }
        public void show(string msg, string title, MessageBoxButton button, MessageBoxIcon icon)
        {
            
            labelMessage.Text = "";
            labelTitle.Text = "";
            labelMessage.Text = msg;
            labelTitle.Text = title;

            if(MessageBoxButton.OK==button)
            {
                btnOk.Visible = true;
                btnYes.Visible = false;
                btnNo.Visible = false;
            }
            else if (MessageBoxButton.YesNo == button)
            {
                btnOk.Visible = false;
                btnYes.Visible = true;
                btnNo.Visible = true;
            }

            if (MessageBoxIcon.Error == icon)
            {
                pictureIcon.Image = SystemIcons.Error.ToBitmap();
            }
            else if (MessageBoxIcon.Info == icon)
            {
                pictureIcon.Image = SystemIcons.Information.ToBitmap();
            }
            else if (MessageBoxIcon.Warning == icon)
            {
                pictureIcon.Image = SystemIcons.Warning.ToBitmap();
            }

            this.ShowDialog();
        }
        
        private void btnYes_Click(object sender, EventArgs e)
        {
            ReturnValue = "YES";
            this.Hide();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            ReturnValue = "NO";
            this.Hide();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ReturnValue = "OK";
            this.Hide();
        }
    }
}
