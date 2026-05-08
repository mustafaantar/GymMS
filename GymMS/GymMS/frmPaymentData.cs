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
    public partial class frmPaymentData : Form
    {
        //form variable member
        GymDataAccess.Payment payment;
        public frmPaymentData()
        {
            InitializeComponent();
        }

        public frmPaymentData(GymDataAccess.Payment payment)
        {
            InitializeComponent();
            this.payment = payment;
        }

        private void frmPaymentData_Load(object sender, EventArgs e)
        {

            if (this.payment == null)//if form opened for adding return (do nothing)
                return;

            //assign object data into controls
            tb_id.Text = this.payment.Id + "";
            for (int i = 0; i < cb_subscription.Items.Count; i++)
            { 
                if (((Member)cb_subscription.Items[i]).Id == this.payment.Subscription.Id)
                {
                    cb_subscription.SelectedIndex = i;
                    break;
                }
            }

            d_payment_date.Value = this.payment.PaymentDate;
            tb_amount.Text = this.payment.Amount + "";
        }

        private void bn_close_Click(object sender, EventArgs e)
        {
            //close the form
            Close();
        }

        private void bn_save_Click(object sender, EventArgs e)
        {
            if (this.payment == null)
            {
                //create object and fill data then send it to the database
                this.payment = new GymDataAccess.Payment();

                //assign data from controls into the object
                this.payment.Subscription = new Subscription(((Subscription)cb_subscription.SelectedItem).Id);
                this.payment.PaymentDate = d_payment_date.Value;
                this.payment.Amount = int.Parse(tb_amount.Text);

                //add the object data into the database
                this.payment.AddToDB(GlobalVariables.LoginUser.Id);

                //show success insert message
                MessageBox.Show("New subscription added successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Edit exists data object in the database

                //assign data from controls into the existing object
                this.payment.PaymentDate = d_payment_date.Value;
                this.payment.Amount = int.Parse(tb_amount.Text);
                //add the object data into the database
                this.payment.UpdateInDB();

                //show success insert message
                MessageBox.Show("Data updated successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //close the form
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tb_paid_amount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}