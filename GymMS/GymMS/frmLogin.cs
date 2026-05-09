using System;
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
            try
            {
                //check username and password for login
                GymDataAccess.Users u = GymDataAccess.Users.Login(tb_username.Text, tb_password.Text);

                //if login success
                if (u != null)
                {
                    GlobalVariables.InitailizeLoginUser(u);

                    //show success login message
                    MessageBox.Show("Welcome " + u.Username);

                    //close the form
                    Close();
                }
                else
                {
                    //display invalid data message
                    MessageBox.Show("Invalid username or password, please try again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}