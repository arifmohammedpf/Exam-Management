using Exam_Cell.Forms;
using System;
using System.Windows.Forms;

namespace Exam_Cell
{
    public partial class Loginpage : Form
    {
        public Loginpage()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
                this.Opacity -= 0.025;
            else
            {
                timer.Stop();
                MenuForm ss = new MenuForm();
                ss.Show();
                this.Hide();
            }
        }

        private void TimerLoading_Tick(object sender, EventArgs e)
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
