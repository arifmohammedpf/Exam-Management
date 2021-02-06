using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_Cell.Forms
{
    public partial class ProgressForm : Form
    {
        public Action Worker { get; set; }
        public ProgressForm(Action worker)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(148, 142, 153), Color.FromArgb(46, 20, 55), 280F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
