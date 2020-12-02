using Exam_Cell.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Cell
{
    public partial class loginpage : Form
    {
        public loginpage()
        {
            InitializeComponent();
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timer.Stop();
                MenuForm ss = new MenuForm();
                ss.Show();
                this.Hide();
            }
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            panelLoader.Width += 6;
            if (panelLoader.Width >= 710)
            {
                timerLoading.Stop();
                timer.Start();
            }
        }
    }
}
