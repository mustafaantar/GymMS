using GymDataAccess;
using System;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmSubscriptionData : Form
    {
        //form variable member
        GymDataAccess.Subscription subscription;

        public frmSubscriptionData()
        {
            InitializeComponent();
        }

        public frmSubscriptionData(GymDataAccess.Subscription s)
        {
            InitializeComponent();

            this.subscription = s;
        }

        private void frmSubscriptionData_Load(object sender, EventArgs e)
        {
            try
            {
                //if form opened for adding return (do nothing)
                if (this.subscription == null)
                    return;

                //assign object data into controls
                tb_id.Text = this.subscription.Id + "";

                //fill member combo selection
                for (int i = 0; i < cb_member.Items.Count; i++)
                {
                    if (((Member)cb_member.Items[i]).Id == this.subscription.Member.Id)
                    {
                        cb_member.SelectedIndex = i;
                        break;
                    }
                }

                //fill subscription type combo selection
                for (int i = 0; i < cb_type.Items.Count; i++)
                {
                    if ((int)cb_type.Items[i] == this.subscription.SubscriptionType)
                    {
                        cb_type.SelectedIndex = i;
                        break;
                    }
                }

                d_fromDate.Value = this.subscription.StartDate;
                d_toDate.Value = this.subscription.EndDate;
                tb_amount.Text = this.subscription.SubscriptionAmount + "";
                tb_paid_amount.Text = this.subscription.PaidAmount + "";
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
                if (this.subscription == null)
                {
                    //create object and fill data then send it to the database
                    this.subscription = new GymDataAccess.Subscription();

                    //assign data from controls into the object
                    this.subscription.Member = new Member(((Member)cb_member.SelectedItem).Id);
                    this.subscription.StartDate = d_fromDate.Value;
                    this.subscription.EndDate = d_toDate.Value;
                    this.subscription.SubscriptionAmount = int.Parse(tb_amount.Text);
                    this.subscription.PaidAmount = int.Parse(tb_paid_amount.Text);

                    //add to database
                    this.subscription.AddToDB(GlobalVariables.LoginUser.Id);

                    //success message
                    MessageBox.Show("New subscription added successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //edit existing object
                    this.subscription.Member = new Member(((Member)cb_member.SelectedItem).Id);
                    this.subscription.StartDate = d_fromDate.Value;
                    this.subscription.EndDate = d_toDate.Value;
                    this.subscription.SubscriptionAmount = int.Parse(tb_amount.Text);
                    this.subscription.PaidAmount = int.Parse(tb_paid_amount.Text);

                    //update database
                    this.subscription.UpdateInDB();

                    //success message
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