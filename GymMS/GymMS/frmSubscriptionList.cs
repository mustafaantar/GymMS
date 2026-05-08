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
    public partial class frmSubscriptionList : Form
    {
        public frmSubscriptionList()
        {
            InitializeComponent();
        }


        private void frmSubscriptionList_Load(object sender, EventArgs e)
        {
            //FIll members list
            List<GymDataAccess.Member> list = GymDataAccess.Person.ListMembersData(null);

            cb_member.Items.Add("-");
            //check if there is existing data to be added to the member list
            foreach (Member member in list)
                cb_member.Items.Add(member);

            //Set the first item as default selected item
            cb_member.SelectedIndex = 0;

            //Fill subscription type
            cb_type.Items.Add("-");
            cb_type.Items.Add("Weekly");
            cb_type.Items.Add("Monthly");
            cb_type.Items.Add("Yearly");
            
            //Set the first item as default selected item
            cb_type.SelectedIndex = 0;
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
            int? memberId = null;
            if (cb_member.SelectedIndex == 0)
                memberId = ((Member)cb_member.SelectedItem).Id;
            DateTime? fromDate = null;
            if (f_fromDate.Checked)
                fromDate = f_fromDate.Value;
            DateTime? toDate = null;
            if (f_fromDate.Checked)
                toDate = f_toDate.Value;

            int? type = null;
            if (cb_type.SelectedIndex == 0)
                type = cb_type.SelectedIndex;

            //read list of specialies from the databaes
            List<Subscription> list = Subscription.ListData(memberId,
                type,
                fromDate,
                toDate);
            //loop into the lists items
            foreach (Subscription s in list)
            {
                int rowIndex = dgv_data.Rows.Add(s.Id, s.MemberId.Id,
                    (s.SubscriptionType==1?"Weekly": s.SubscriptionType==2?"Monthly":"Yearly"),
                    s.SubscriptionAmount,
                    s.PaidAmount,
                    s.StartDate,
                    s.EndDate,
                    s.CreatedBy.Username.
                    s.creationDate);

                // store the object in the row
                dgv_data.Rows[rowIndex].Tag = s;
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
            Subscription s = (Subscription)dgv_data.CurrentRow.Tag;

            //Open data form 
            (new frmSubscriptionData(s)).ShowDialog();

            //Read data again(Do refresh)
            Search();
        }
    }
}