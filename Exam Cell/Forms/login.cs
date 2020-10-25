using Exam_Cell.Forms;
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
    public partial class loginpage : Form
    {
        public loginpage()
        {
            InitializeComponent();
            
        }

        private void bgpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void usrlabel_Click(object sender, EventArgs e)
        {

        }

        private void loginbuttn_Click(object sender, EventArgs e)
        {
            if(Username.Text=="admin"&&Password.Text=="admin")
            {
                this.Hide();
                MenuForm ss = new MenuForm();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password","Alert",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }
    }
}
