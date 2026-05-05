using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void bn_login_Click(object sender, EventArgs e)
        {
            //check username and password for login
            GymDataAccess.Users u = GymDataAccess.Users.Login(tb_username.Text, tb_password.Text);
            if (u != null)
            {
                GlobalVariables.InitailizeLoginUser(u);
                //show success login message
                MessageBox.Show("Welcome " + u.Username);

                //close the form
                Close();
            }
            else
                //display invalid data message
                MessageBox.Show("Invalid username or password, please try again!");
        }

        private void bn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
