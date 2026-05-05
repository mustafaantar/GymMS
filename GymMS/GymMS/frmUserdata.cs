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
    }
}