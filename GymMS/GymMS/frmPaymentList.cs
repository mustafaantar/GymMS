using GymDataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmPaymentList : Form
    {
        public frmPaymentList()
        {
            InitializeComponent();
        }

        public frmPaymentList(int filter_subscriptionId)
        {
            InitializeComponent();
            this.filter_subscriptionId = filter_subscriptionId;
        }

        int? filter_subscriptionId;

        private void frmPaymentList_Load(object sender, EventArgs e)
        {
            try
            {
                //fill subscriptions list
                List<GymDataAccess.Member> list = GymDataAccess.Person .ListMembersData(null);

                cb_sub.Items.Add("-");

                int index = 0;

                //add items to comboBox
                for (int i = 0; i < list.Count; i++)
                {
                    cb_sub.Items.Add(list[i]);

                    //set selected item if filter exists
                    if (filter_subscriptionId.HasValue)
                        if (list[i].Id == filter_subscriptionId)
                            index = i;
                }

                cb_sub.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_search_Click(object sender, EventArgs e)
        {
            try
            {
                //search for payments
                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Search()
        {
            try
            {
                //clear grid
                dgv_data.Rows.Clear();

                //check filters
                int? subscriptionId = null;

                if (cb_sub.SelectedIndex > 0)
                    subscriptionId = ((Subscription)cb_sub.SelectedItem).Id;

                DateTime? fromDate = null;
                if (f_fromDate.Checked)
                    fromDate = f_fromDate.Value;

                DateTime? toDate = null;
                if (f_toDate.Checked)
                    toDate = f_toDate.Value;

                //read data from database
                List<Payment> list = Payment.ListData(subscriptionId, fromDate, toDate);

                //fill grid
                foreach (Payment p in list)
                {
                    int rowIndex = dgv_data.Rows.Add(
                        p.Id,
                        p.Subscription.Member.FullName,
                        p.Subscription.Id,
                        p.PaymentDate,
                        p.Amount,
                        p.CreatedBy.Username,
                        p.CreationDate
                    );

                    //store object in row
                    dgv_data.Rows[rowIndex].Tag = p;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_add_Click(object sender, EventArgs e)
        {
            try
            {
                //open payment form (NOT subscription form)
                (new frmPaymentData()).ShowDialog();

                //refresh data
                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //if no selection return
                if (dgv_data.SelectedRows.Count == 0)
                    return;

                //get selected payment object
                Payment p = (Payment)dgv_data.CurrentRow.Tag;

                //open edit form
                (new frmPaymentData(p)).ShowDialog();

                //refresh grid
                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}