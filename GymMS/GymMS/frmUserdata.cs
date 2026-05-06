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
            //Fill user type list
            cb_type.Items.Add("Receiption");
            cb_type.Items.Add("Manager");
            cb_type.Items.Add("Accountant");
            cb_type.SelectedIndex = 0;//Default value
            if (this.user == null)//if form opened for adding return (do nothing)
                return;
            //assign object data into controls
            tb_id.Text = this.user.Id + "";
            tb_username.Text = this.user.Username;
            tb_password.Text = this.user.Password;
            cb_type.SelectedIndex = this.user.UserType;
        }

        private void bn_close_Click(object sender, EventArgs e)
        {
            //close the form
            Close();
        }

        private void bn_save_Click(object sender, EventArgs e)
        {
            if (this.user == null)
            {
                //create object and fill data then send it to the database
                GymDataAccess.Users u = new GymDataAccess.Users();

                //assign data from controls into the object
                u.Username = tb_username.Text;
                u.Password = tb_password.Text;
                u.UserType = cb_type.SelectedIndex;

                //add the object data into the database
                u.AddToDB();

                //show success insert message
                MessageBox.Show("New user added successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Edit exists data object in the database

                //assign data from controls into the existing object
                this.user.Username = tb_username.Text;
                this.user.Password = tb_password.Text;
                this.user.UserType = cb_type.SelectedIndex;

                //add the object data into the database
                this.user.UpdateInDB();

                //show success insert message
                MessageBox.Show("Data updated successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //close the form
            Close();
        }
    }
}