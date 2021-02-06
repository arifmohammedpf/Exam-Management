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
        CustomMessageBox msgbox = new CustomMessageBox();
        public MenuForm()
        {
            InitializeComponent();
            CustomDesign();
        }

        private Form activeForm = null;
        Control Temp_btn=null;
        private void MoveSidePanel(Control btn)
        {
            if(Temp_btn!=null)
                Temp_btn.BackColor = Color.FromArgb(11, 7, 17);
            btn.BackColor = Color.Teal;
            Temp_btn = btn;
        }
        private void CustomDesign()
        {
            panelAbsentDropMenu.Visible = false;
            panelDbmDropMenu.Visible = false;
            MenuSidePanel.Visible = false;
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
            MoveSidePanel(Dbm_btn);
            OpenChildForm(new Student_Management());
            HideDropMenu();
        }

        private void ClassbranchForm_btn_Click(object sender, EventArgs e)
        {
            MoveSidePanel(Dbm_btn);
            OpenChildForm(new Database_Management());
            HideDropMenu();
        }

        private void AbsentMarkForm_btn_Click(object sender, EventArgs e)
        {
            MoveSidePanel(Absentees_btn);
            OpenChildForm(new Absent_Marking());
            HideDropMenu();
        }

        private void AbsentStateForm_btn_Click(object sender, EventArgs e)
        {
            MoveSidePanel(Absentees_btn);
            OpenChildForm(new Absent_Statement());
            HideDropMenu();
        }

        private void Absentees_btn_Click(object sender, EventArgs e)
        {
            ShowDropMenu(panelAbsentDropMenu);
        }

        
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void CandEntryForm_btn_Click(object sender, EventArgs e)
        {
            HideDropMenu();
            MoveSidePanel(CandEntryForm_btn);
            OpenChildForm(new formti());
        }

        private void RoomForm_btn_Click(object sender, EventArgs e)
        {
            HideDropMenu();
            MoveSidePanel(RoomForm_btn);
            OpenChildForm(new examhall());
        }

        private void RegStyMng_btn_Click(object sender, EventArgs e)
        {
            HideDropMenu();
            MoveSidePanel(RegStyMng_btn);
            OpenChildForm(new Registered_Students_Management());
        }

        private void TtableForm_btn_Click(object sender, EventArgs e)
        {
            HideDropMenu();
            MoveSidePanel(TtableForm_btn);
            OpenChildForm(new formtimetable());
        }

        private void AllotmentForm_btn_Click(object sender, EventArgs e)
        {
            HideDropMenu();
            MoveSidePanel(AllotmentForm_btn);
            OpenChildForm(new Allotment());
        }

        private void PostponeForm_btn_Click(object sender, EventArgs e)
        {
            HideDropMenu();
            MoveSidePanel(PostponeForm_btn);
            OpenChildForm(new postponement());
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            msgbox.show("Do you really want to Exit Application ?     ", "Confirm Exit", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            if (result=="Yes")
            {
                timer.Start();
            }
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
                Application.Exit();
            }
        }

        private void CreditsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
