using System;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmUserdata : Form
    {
        //form variable member
        GymDataAccess.Users user;

        public frmUserdata()
        {
            InitializeComponent();
        }

        public frmUserdata(GymDataAccess.Users user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void frmUserdata_Load(object sender, EventArgs e)
        {
            try
            {
                //fill user type list
                cb_type.Items.Add("Receiption");
                cb_type.Items.Add("Manager");
                cb_type.Items.Add("Accountant");

                cb_type.SelectedIndex = 0;

                //if form opened for adding return (do nothing)
                if (this.user == null)
                    return;

                //assign object data into controls
                tb_id.Text = this.user.Id + "";
                tb_username.Text = this.user.Username;
                tb_password.Text = this.user.Password;

                cb_type.SelectedIndex = cb_type.Items.IndexOf(this.user.UserType);
                cb_active.Checked = this.user.IsActive;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_close_Click(object sender, EventArgs e)
        {
            try
            {
                //close the form
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.user == null)
                {
                    //create object and fill data then send it to database
                    GymDataAccess.Users u = new GymDataAccess.Users();

                    //assign data from controls
                    u.Username = tb_username.Text;
                    u.Password = tb_password.Text;
                    u.UserType = cb_type.SelectedIndex == 0 ? "R"
                                 : cb_type.SelectedIndex == 1 ? "M" : "A";
                    u.IsActive = cb_active.Checked;

                    //insert
                    u.AddToDB(GlobalVariables.LoginUser.Id);

                    MessageBox.Show("New user added successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //update existing object
                    this.user.Username = tb_username.Text;
                    this.user.Password = tb_password.Text;
                    this.user.UserType = cb_type.SelectedIndex == 0 ? "R"
                                         : cb_type.SelectedIndex == 1 ? "M" : "A";
                    this.user.IsActive = cb_active.Checked;

                    //update DB
                    this.user.UpdateInDB();

                    MessageBox.Show("Data updated successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //close form
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}