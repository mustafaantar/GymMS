using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymDataAccess;
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
            subscription = new Subscription();
        }

        private void frmSubscriptionData_Load(object sender, EventArgs e)
        {

            if (this.subscription == null)//if form opened for adding return (do nothing)
                return;

            //assign object data into controls
            tb_id.Text = this.subscription.Id + "";
            for (int i = 0; i < cb_member.Items.Count; i++)
            { 
                if (((Member)cb_member.Items[i]).Id == this.subscription.Member.Id)
                {
                    cb_member.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cb_type.Items.Count; i++)
            {
                if ((int)cb_member.Items[i] == this.subscription.SubscriptionType)
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

        private void bn_close_Click(object sender, EventArgs e)
        {
            //close the form
            Close();
        }

        private void bn_save_Click(object sender, EventArgs e)
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

                //add the object data into the database
                this.subscription.AddToDB();

                //show success insert message
                MessageBox.Show("New subscription added successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Edit exists data object in the database

                //assign data from controls into the existing object
                this.subscription.Member = new Member(((Member)cb_member.SelectedItem).Id);
                this.subscription.StartDate = d_fromDate.Value;
                this.subscription.EndDate = d_toDate.Value;
                this.subscription.SubscriptionAmount = int.Parse(tb_amount.Text);
                this.subscription.PaidAmount = int.Parse(tb_paid_amount.Text);
                //add the object data into the database
                this.subscription.UpdateInDB();

                //show success insert message
                MessageBox.Show("Data updated successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //close the form
            Close();
        }
    }
}