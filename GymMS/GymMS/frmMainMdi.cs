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
    public partial class frmMainMdi : Form
    {
        public frmMainMdi()
        {
            InitializeComponent();
        }

        private void frmMainMdi_Load(object sender, EventArgs e)
        {
            //open login form
            frmLogin f = new frmLogin();
            f.ShowDialog();

            //if lot logged in then close application
            if (GlobalVariables.LoginUser == null)
                Close();

            //show/hide buttons depending on loggd user type

            switch(GlobalVariables.LoginUser.UserType)
            {
                case "R":
                bn_users.Hide();
                bn_payment.Hide();
                    break;
                case "A":
                    bn_people.Hide();

                    break;
            }

        }

        private void bn_people_Click(object sender, EventArgs e)
        {
            frmPeopleList f = new frmPeopleList();
            OpenForm(f);
        }

        void OpenForm(Form f)
        {
            f.ShowDialog();
        }

        private void bn_users_Click(object sender, EventArgs e)
        {
            frmUserList f = new frmUserList();
            OpenForm(f);
        }

        private void bn_sub_Click(object sender, EventArgs e)
        {
            frmSubscriptionList f = new frmSubscriptionList();
            OpenForm(f);
        }

        private void bn_payment_Click(object sender, EventArgs e)
        {
            frmPaymentList f = new frmPaymentList();
            OpenForm(f);
        }

        private void bn_booking_Click(object sender, EventArgs e)
        {

        }
    }
}
