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
    public partial class Menu_Form : Form
    {
        public Menu_Form()
        {
            InitializeComponent();
        }

       
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        

        private void CandidateEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formti ss = new formti();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TimetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formtimetable ss = new formtimetable();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PostponementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            postponement ss = new postponement();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        private void RoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            examhall ss = new examhall();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        private void AllotmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Allotment ss = new Allotment();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        private void RegStdntMangmntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registered_Students_Management ss = new Registered_Students_Management();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        

        private void Absent_Marking_Menu_Click(object sender, EventArgs e)
        {
            Absent_Marking ss = new Absent_Marking();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        private void Absent_Statement_Menu_Click(object sender, EventArgs e)
        {
            Absent_Statement ss = new Absent_Statement();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        private void StudentManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Management ss = new Student_Management();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }

        private void ClassBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database_Management ss = new Database_Management();
            ss.MdiParent = this;
            panel1.Controls.Add(ss);
            ss.Show();
            ss.BringToFront();
        }
    }
}
