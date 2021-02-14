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
            //CustomDesign();
        }
        public class TestColorTable : ProfessionalColorTable
        {
            public override Color MenuBorder  //added for changing the menu border
            {
                get { return Color.FromArgb(44, 62, 80); }
            }

            public override Color MenuItemBorder  //added for changing the menu items hover border
            {
                get { return Color.FromArgb(44, 62, 80); }
            }

            public override Color ToolStripDropDownBackground  //added for changing the menu dropdown border
            {
                get { return Color.FromArgb(44, 62, 80); }
            }

            //added for changing the menu items hover
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.FromArgb(21, 87, 153); }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(21, 87, 153); }
            }

            //added for changing the menu items clicked state
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.FromArgb(102, 125, 182); }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.FromArgb(102, 125, 182); }
            }

            //added for changing the menu dropdown items hover
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(21, 87, 153); }
            }



        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
        }


        //private Form activeForm = null;
        //Control Temp_btn=null;
        //private void MoveSidePanel(Control btn)
        //{
        //    if(Temp_btn!=null)
        //        Temp_btn.BackColor = Color.FromArgb(48, 43, 99);
        //    btn.BackColor = Color.Teal;
        //    Temp_btn = btn;
        //}
        //private void CustomDesign()
        //{
        //    panelAbsentDropMenu.Visible = false;
        //    panelDbmDropMenu.Visible = false;
        //    MenuSidePanel.Visible = false;
        //}

        //private void HideDropMenu()
        //{
        //    if (panelAbsentDropMenu.Visible == true)
        //        panelAbsentDropMenu.Visible = false;
        //    if (panelDbmDropMenu.Visible == true)
        //        panelDbmDropMenu.Visible = false;
        //}
        //private void ShowDropMenu(Panel dropMenu)
        //{
        //    if(dropMenu.Visible==false)
        //    {
        //        HideDropMenu();
        //        dropMenu.Visible = true;
        //    }
        //    else
        //    {
        //        dropMenu.Visible = false;
        //    }
        //}

        //private void Dbm_btn_Click(object sender, EventArgs e)
        //{
        //    ShowDropMenu(panelDbmDropMenu);
        //}

        //private void StudentForm_btn_Click(object sender, EventArgs e)
        //{
        //    MoveSidePanel(Dbm_btn);
        //    OpenChildForm(new Student_Management());
        //    HideDropMenu();
        //}

        //private void ClassbranchForm_btn_Click(object sender, EventArgs e)
        //{
        //    MoveSidePanel(Dbm_btn);
        //    OpenChildForm(new Database_Management());
        //    HideDropMenu();
        //}

        //private void AbsentMarkForm_btn_Click(object sender, EventArgs e)
        //{
        //    MoveSidePanel(Absentees_btn);
        //    OpenChildForm(new Absent_Marking());
        //    HideDropMenu();
        //}

        //private void AbsentStateForm_btn_Click(object sender, EventArgs e)
        //{
        //    MoveSidePanel(Absentees_btn);
        //    OpenChildForm(new Absent_Statement());
        //    HideDropMenu();
        //}

        //private void Absentees_btn_Click(object sender, EventArgs e)
        //{
        //    ShowDropMenu(panelAbsentDropMenu);
        //}


        //private void OpenChildForm(Form childForm)
        //{
        //    if (activeForm != null)
        //        activeForm.Close();
        //    activeForm = childForm;
        //    childForm.TopLevel = false;
        //    childForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    panelChildForm.Controls.Add(childForm);
        //    panelChildForm.Tag = childForm;
        //    childForm.BringToFront();
        //    childForm.Show();
        //}

        //private void CandEntryForm_btn_Click(object sender, EventArgs e)
        //{
        //    HideDropMenu();
        //    MoveSidePanel(CandEntryForm_btn);
        //    OpenChildForm(new formti());
        //}

        //private void RoomForm_btn_Click(object sender, EventArgs e)
        //{
        //    HideDropMenu();
        //    MoveSidePanel(RoomForm_btn);
        //    OpenChildForm(new examhall());
        //}

        //private void RegStyMng_btn_Click(object sender, EventArgs e)
        //{
        //    HideDropMenu();
        //    MoveSidePanel(RegStyMng_btn);
        //    OpenChildForm(new Registered_Students_Management());
        //}

        //private void TtableForm_btn_Click(object sender, EventArgs e)
        //{
        //    HideDropMenu();
        //    MoveSidePanel(TtableForm_btn);
        //    OpenChildForm(new formtimetable());
        //}

        //private void AllotmentForm_btn_Click(object sender, EventArgs e)
        //{
        //    HideDropMenu();
        //    MoveSidePanel(AllotmentForm_btn);
        //    OpenChildForm(new Allotment());
        //}

        //private void PostponeForm_btn_Click(object sender, EventArgs e)
        //{
        //    HideDropMenu();
        //    MoveSidePanel(PostponeForm_btn);
        //    OpenChildForm(new postponement());
        //}        

        //private void CreditsBtn_Click(object sender, EventArgs e)
        //{
        //    HideDropMenu();
        //    MoveSidePanel(CreditsBtn);
        //    OpenChildForm(new Credits());
        //}

        //private void Exit_btn_Click(object sender, EventArgs e)
        //{
        //    msgbox.show("Do you really want to Exit Application ?     ", "Confirm Exit", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
        //    var result = msgbox.ReturnValue;
        //    if (result=="Yes")
        //    {
        //        timer.Start();
        //    }
        //}

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

        private void menu_item_exit_Click(object sender, EventArgs e)
        {
            msgbox.show("Do you really want to Exit Application ?     ", "Confirm Exit", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
            var result = msgbox.ReturnValue;
            if (result == "Yes")
            {
                timer.Start();
            }
        }

        Credits credits;
        Allotment allotment ;
        formtimetable timetable ;
        Student_Management student_Management ;
        Registered_Students_Management registered_Students_Management ;
        postponement postponement ;
        examhall room ;
        Database_Management classbranch_management ;
        formti candidate_entry ;
        Absent_Statement absent_Statement ;
        Absent_Marking absent_Marking ;

        public bool timetable_open = false, candidateentry_open = false, room_open = false, regstudmgmnt_open = false, allotment_open = false, absenteesmarking_open = false, absenteesstatement_open = false, postponment_open = false, studmgmnt_open = false, classbranchmgmnt_open = false, credits_open = false;
       
        private void openForm(Form form)
        {
            bgPanel.Controls.Clear();
            bgPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        public ToolStripMenuItem Temp_btn = null;
        private void buttonColorChange(ToolStripMenuItem btn)
        {
            if (Temp_btn != null)
                Temp_btn.BackColor = Color.Brown;
            btn.BackColor = Color.Teal;
            Temp_btn = btn;
        }
        
        private void menu_item_credits_Click(object sender, EventArgs e)
        {
            if (!credits_open)
            {
                credits = new Credits();
                //credits.MdiParent = this;
                credits.TopLevel = false;
                credits.Dock = DockStyle.Fill;
                credits_open = true;
            }
            openForm(credits);
            buttonColorChange(menu_item_credits);
        }

        private void menu_item_allotment_Click(object sender, EventArgs e)
        {
            if (!allotment_open)
            {
                allotment = new Allotment();
                //allotment.MdiParent = this;
                allotment.TopLevel = false;
                allotment.Dock = DockStyle.Fill;
                allotment_open = true;
            }
            openForm(allotment);
            buttonColorChange(menu_item_allotment);
        }

        private void menu_item_timetable_Click(object sender, EventArgs e)
        {
            if (!timetable_open)
            {
                timetable = new formtimetable();
                //timetable.MdiParent = this;
                timetable.TopLevel = false;
                timetable.Dock = DockStyle.Fill;
                timetable.FormBorderStyle = FormBorderStyle.None;
                timetable_open = true;
            }
            openForm(timetable);
            buttonColorChange(menu_item_timetable);
        }

        private void menu_item_candidateentry_Click(object sender, EventArgs e)
        {
            if (!candidateentry_open)
            {
                candidate_entry = new formti();
                //candidate_entry.MdiParent = this;
                candidate_entry.TopLevel = false;
                candidate_entry.Dock = DockStyle.Fill;
                candidateentry_open = true;
            }
            openForm(candidate_entry);
            buttonColorChange(menu_item_candidateentry);
        }

        private void menu_item_room_Click(object sender, EventArgs e)
        {
            if (!room_open)
            {
                room = new examhall();
                //room.MdiParent = this;
                room.TopLevel = false;
                room.Dock = DockStyle.Fill;
                room_open = true;
            }
            openForm(room);
            buttonColorChange(menu_item_room);
        }

        private void menu_item_regstudmgmnt_Click(object sender, EventArgs e)
        {
            if (!regstudmgmnt_open)
            {
                registered_Students_Management = new Registered_Students_Management();
                //registered_Students_Management.MdiParent = this;
                registered_Students_Management.TopLevel = false;
                registered_Students_Management.Dock = DockStyle.Fill;
                regstudmgmnt_open = true;
            }
            openForm(registered_Students_Management);
            buttonColorChange(menu_item_regstudmgmnt);
        }

        private void menu_dropitem_marking_Click(object sender, EventArgs e)
        {
            if (!absenteesmarking_open)
            {
                absent_Marking = new Absent_Marking();
                //absent_Marking.MdiParent = this;
                absent_Marking.TopLevel = false;
                absent_Marking.Dock = DockStyle.Fill;
                absenteesmarking_open = true;
            }
            openForm(absent_Marking);
            buttonColorChange(menu_dropitem_marking);
        }

        private void menu_dropitem_statement_Click(object sender, EventArgs e)
        {
            if (!absenteesstatement_open)
            {
                absent_Statement = new Absent_Statement();
                //absent_Statement.MdiParent = this;
                absent_Statement.TopLevel = false;
                absent_Statement.Dock = DockStyle.Fill;
                absenteesstatement_open = true;
            }
            openForm(absent_Statement);
            buttonColorChange(menu_dropitem_statement);
        }

        private void menu_item_postponement_Click(object sender, EventArgs e)
        {
            if (!postponment_open)
            {
                postponement = new postponement();
                //postponement.MdiParent = this;
                postponement.TopLevel = false;
                postponement.Dock = DockStyle.Fill;
                postponment_open = true;
            }
            openForm(postponement);
            buttonColorChange(menu_item_postponement);
        }

        private void menu_dropitem_student_Click(object sender, EventArgs e)
        {
            if (!studmgmnt_open)
            {
                student_Management = new Student_Management();
                //student_Management.MdiParent = this;
                student_Management.TopLevel = false;
                student_Management.Dock = DockStyle.Fill;
                studmgmnt_open = true;
            }
            openForm(student_Management);
            buttonColorChange(menu_dropitem_student);
        }

        private void menu_dropitem_classbranch_Click(object sender, EventArgs e)
        {
            if (!classbranchmgmnt_open)
            {
                classbranch_management = new Database_Management();
                //classbranch_management.MdiParent = this;
                classbranch_management.TopLevel = false;
                classbranch_management.Dock = DockStyle.Fill;
                classbranchmgmnt_open = true;
            }
            openForm(classbranch_management);
            buttonColorChange(menu_dropitem_classbranch);
        }        
    }
}
