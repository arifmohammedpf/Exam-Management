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
    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
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
