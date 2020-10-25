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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            CustomDesign();
        }

        private void CustomDesign()
        {
            panelAbsentDropMenu.Visible = false;
            panelDbmDropMenu.Visible = false;
        }

        private void HideDropMenu()
        {
            if (panelAbsentDropMenu.Visible == true)
                panelAbsentDropMenu.Visible = false;
            if (panelDbmDropMenu.Visible == true)
                panelDbmDropMenu.Visible = false;
        }
        private void ShowDropMenu(Panel dropMenu)
        {
            if(dropMenu.Visible==false)
            {
                HideDropMenu();
                dropMenu.Visible = true;
            }
            else
            {
                dropMenu.Visible = false;
            }
        }

        private void Dbm_btn_Click(object sender, EventArgs e)
        {
            ShowDropMenu(panelDbmDropMenu);
        }

        private void StudentForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Student_Management());
            HideDropMenu();
        }

        private void ClassbranchForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Database_Management());
            HideDropMenu();
        }

        private void AbsentMarkForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Absent_Marking());
            HideDropMenu();
        }

        private void AbsentStateForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Absent_Statement());
            HideDropMenu();
        }

        private void Absentees_btn_Click(object sender, EventArgs e)
        {
            ShowDropMenu(panelAbsentDropMenu);
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void CandEntryForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new formti());
        }

        private void RoomForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new examhall());
        }

        private void RegStyMng_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Registered_Students_Management());
        }

        private void TtableForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new formtimetable());
        }

        private void AllotmentForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Allotment());
        }

        private void PostponeForm_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new postponement());
        }
    }
}
