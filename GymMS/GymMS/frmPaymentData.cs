using GymDataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            try
            {
                List<Subscription> list = Subscription.ListData(null, null, null, null);
                for (int i = 0; i < list.Count; i++)
                {
                    cb_subscription.Items.Add(list[i]);
                }

                if (list.Count != 0)
                    cb_subscription.SelectedIndex = 0;
                //if form opened for adding return (do nothing)
                if (this.payment == null)
                    return;

                //assign object data into controls
                tb_id.Text = this.payment.Id + "";

                for (int i = 0; i < cb_subscription.Items.Count; i++)
                {
                    if (((Subscription)cb_subscription.Items[i]).Id == this.payment.Subscription.Id)
                    {
                        cb_subscription.SelectedIndex = i;
                        break;
                    }
                }

                d_payment_date.Value = this.payment.PaymentDate;
                tb_amount.Text = this.payment.Amount + "";
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
                //Validate data
                GymDataValidation.CkechAmount(int.Parse(tb_amount.Text));
                GymDataValidation.CkechStartAndEndDate(DateTime.Now,d_payment_date.Value);

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
                    MessageBox.Show("New subscription added successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //edit existing object in database
                    this.payment.PaymentDate = d_payment_date.Value;
                    this.payment.Amount = int.Parse(tb_amount.Text);

                    //update object in database
                    this.payment.UpdateInDB();

                    //show success update message
                    MessageBox.Show("Data updated successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //close the form
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_paid_amount_TextChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}