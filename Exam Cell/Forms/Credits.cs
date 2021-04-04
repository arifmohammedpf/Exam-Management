using System;
using System.Drawing;
using System.Windows.Forms;

namespace Exam_Cell.Forms
{
    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = (MenuForm)Application.OpenForms["MenuForm"];
            if (menuForm.Temp_btn == menuForm.menu_item_credits)
                menuForm.Temp_btn = null;
            menuForm.menu_item_credits.BackColor = Color.FromArgb(48, 43, 99);
            menuForm.credits_open = false;
            this.Close();
        }
    }
}