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
            //FIll members list
            List<GymDataAccess.Subscription> list = GymDataAccess.Subscription.ListData(null, null, null, null);

            cb_sub.Items.Add("-");

            //Set the first item as default selected item
            int index = 0;
            //check if there is existing data to be added to the member list
            for (int i = 0; i < list.Count; i++)
            {
                //Add member to comboBox
                cb_sub.Items.Add(list[i]);

                //if filterMemberId passed to the form then check if current item's id in list is equal to filterMemberId
                if (filter_subscriptionId.HasValue)
                    if (list[i].Id == filter_subscriptionId)
                        index = i;
            }

            cb_sub.SelectedIndex = index;
        }

        private void bn_search_Click(object sender, EventArgs e)
        {
            //search for subscriptions
            Search();
        }

        void Search()
        {
            //display all specialies 
            //clear grid
            dgv_data.Rows.Clear();

            //check filters
            int? subscriptionId = null;
            if (cb_sub.SelectedIndex == 0)
                subscriptionId = ((Subscription)cb_sub.SelectedItem).Id;
            DateTime? fromDate = null;
            if (f_fromDate.Checked)
                fromDate = f_fromDate.Value;
            DateTime? toDate = null;
            if (f_fromDate.Checked)
                toDate = f_toDate.Value;

            //read list of specialies from the databaes
            List<Payment> list = Payment.ListData(subscriptionId,
                fromDate,
                toDate);
            //loop into the lists items
            foreach (Payment p in list)
            {
                int rowIndex = dgv_data.Rows.Add(p.Id, 
                    p.Subscription.Member.FullName,
                    p.Subscription.Id,
                    p.PaymentDate,
                    p.Amount,
                    p.CreatedBy.Username,
                    p.CreationDate);

                // store the object in the row
                dgv_data.Rows[rowIndex].Tag = p;
            }
        }

        private void bn_add_Click(object sender, EventArgs e)
        {
            //open data form 
            (new frmSubscriptionData()).ShowDialog();

            //Read data again(Do refresh)
            Search();
        }

        private void dgv_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if no rows selected returns (do nothing)
            if (dgv_data.SelectedRows.Count == 0)
                return;

            //read selected object
            Payment p = (Payment)dgv_data.CurrentRow.Tag;

            //Open data form 
            (new frmPaymentData(p)).ShowDialog();

            //Read data again(Do refresh)
            Search();
        }
    }
}