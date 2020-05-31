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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

       
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        

        private void candidateEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formti ss = new formti();
            ss.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formtimetable ss = new formtimetable();
            ss.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void postponementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            postponement ss = new postponement();
            ss.Show();
        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            examhall ss = new examhall();
            ss.Show();
        }
    }
}
