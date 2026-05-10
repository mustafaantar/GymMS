using System;
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
            try
            {
                //open login form
                frmLogin f = new frmLogin();
                f.ShowDialog();

                //if not logged in then close application
                if (GlobalVariables.LoginUser == null)
                {
                    Close();
                    return;
                }

                //show/hide buttons depending on logged user type
                switch (GlobalVariables.LoginUser.UserType[0].ToString())
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_people_Click(object sender, EventArgs e)
        {
            try
            {
                frmPeopleList f = new frmPeopleList();
                OpenForm(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void OpenForm(Form f)
        {
            try
            {
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_users_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserList f = new frmUserList();
                OpenForm(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_sub_Click(object sender, EventArgs e)
        {
            try
            {
                frmSubscriptionList f = new frmSubscriptionList();
                OpenForm(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_payment_Click(object sender, EventArgs e)
        {
            try
            {
                frmPaymentList f = new frmPaymentList();
                OpenForm(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_booking_Click(object sender, EventArgs e)
        {
            try
            {
                frmBookingList f = new frmBookingList();
                OpenForm(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_specialties_Click(object sender, EventArgs e)
        {
            try
            {
                frmSpecialtiesList f = new frmSpecialtiesList();
                OpenForm(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}