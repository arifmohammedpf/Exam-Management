using System;
using System.Drawing;
using System.Windows.Forms;

namespace Exam_Cell.Forms
{
    public partial class MenuForm : Form
    {
        CustomMessageBox msgbox = new CustomMessageBox();
        public MenuForm()
        {
            InitializeComponent();
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
        
        private void Timer_Tick(object sender, EventArgs e)
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

        private void Menu_item_exit_Click(object sender, EventArgs e)
        {
            msgbox.Show("Do you really want to Exit Application ?     ", "Confirm Exit", CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Question);
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
       
        private void OpenForm(Form form)
        {
            bgPanel.Controls.Clear();
            bgPanel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
        public ToolStripMenuItem Temp_btn = null;
        private void ButtonColorChange(ToolStripMenuItem btn)
        {
            if (Temp_btn != null)
                Temp_btn.BackColor = Color.Brown;
            btn.BackColor = Color.Teal;
            Temp_btn = btn;
        }
        
        private void Menu_item_credits_Click(object sender, EventArgs e)
        {
            if (!credits_open)
            {
                credits = new Credits
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                credits_open = true;
            }
            OpenForm(credits);
            ButtonColorChange(menu_item_credits);
        }

        private void Menu_item_allotment_Click(object sender, EventArgs e)
        {
            if (!allotment_open)
            {
                allotment = new Allotment
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                allotment_open = true;
            }
            OpenForm(allotment);
            ButtonColorChange(menu_item_allotment);
        }

        private void Menu_item_timetable_Click(object sender, EventArgs e)
        {
            if (!timetable_open)
            {
                timetable = new formtimetable
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.None
                };
                timetable_open = true;
            }
            OpenForm(timetable);
            ButtonColorChange(menu_item_timetable);
        }

        private void Menu_item_candidateentry_Click(object sender, EventArgs e)
        {
            if (!candidateentry_open)
            {
                candidate_entry = new formti
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                candidateentry_open = true;
            }
            OpenForm(candidate_entry);
            ButtonColorChange(menu_item_candidateentry);
        }

        private void Menu_item_room_Click(object sender, EventArgs e)
        {
            if (!room_open)
            {
                room = new examhall
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                room_open = true;
            }
            OpenForm(room);
            ButtonColorChange(menu_item_room);
        }

        private void Menu_item_regstudmgmnt_Click(object sender, EventArgs e)
        {
            if (!regstudmgmnt_open)
            {
                registered_Students_Management = new Registered_Students_Management
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                regstudmgmnt_open = true;
            }
            OpenForm(registered_Students_Management);
            ButtonColorChange(menu_item_regstudmgmnt);
        }

        private void Menu_dropitem_marking_Click(object sender, EventArgs e)
        {
            if (!absenteesmarking_open)
            {
                absent_Marking = new Absent_Marking
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                absenteesmarking_open = true;
            }
            OpenForm(absent_Marking);
            ButtonColorChange(menu_dropitem_marking);
        }

        private void Menu_dropitem_statement_Click(object sender, EventArgs e)
        {
            if (!absenteesstatement_open)
            {
                absent_Statement = new Absent_Statement
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                absenteesstatement_open = true;
            }
            OpenForm(absent_Statement);
            ButtonColorChange(menu_dropitem_statement);
        }

        private void Menu_item_postponement_Click(object sender, EventArgs e)
        {
            if (!postponment_open)
            {
                postponement = new postponement
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                postponment_open = true;
            }
            OpenForm(postponement);
            ButtonColorChange(menu_item_postponement);
        }

        private void Menu_dropitem_student_Click(object sender, EventArgs e)
        {
            if (!studmgmnt_open)
            {
                student_Management = new Student_Management
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                studmgmnt_open = true;
            }
            OpenForm(student_Management);
            ButtonColorChange(menu_dropitem_student);
        }

        private void Menu_dropitem_classbranch_Click(object sender, EventArgs e)
        {
            if (!classbranchmgmnt_open)
            {
                classbranch_management = new Database_Management
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                classbranchmgmnt_open = true;
            }
            OpenForm(classbranch_management);
            ButtonColorChange(menu_dropitem_classbranch);
        }        
    }
}