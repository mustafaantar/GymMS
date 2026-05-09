using GymDataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            try
            {
                //fill members list
                List<GymDataAccess.Member> list =
                    GymDataAccess.Person.ListMembersData(null);

                cb_member.Items.Add("-");

                //add members to comboBox
                foreach (Member member in list)
                    cb_member.Items.Add(member);

                //default selection
                cb_member.SelectedIndex = 0;

                //fill subscription type
                cb_type.Items.Add("-");
                cb_type.Items.Add("Weekly");
                cb_type.Items.Add("Monthly");
                cb_type.Items.Add("Yearly");

                cb_type.SelectedIndex = 0;
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

                //filters
                int? memberId = null;
                if (cb_member.SelectedIndex > 0)
                    memberId = ((Member)cb_member.SelectedItem).Id;

                DateTime? fromDate = null;
                if (f_fromDate.Checked)
                    fromDate = f_fromDate.Value;

                DateTime? toDate = null;
                if (f_toDate.Checked)
                    toDate = f_toDate.Value;

                int? type = null;
                if (cb_type.SelectedIndex > 0)
                    type = cb_type.SelectedIndex;

                //read data
                List<Subscription> list = Subscription.ListData(
                    memberId,
                    type,
                    fromDate,
                    toDate
                );

                //fill grid
                foreach (Subscription s in list)
                {
                    int rowIndex = dgv_data.Rows.Add(
                        s.Id,
                        s.Member.Id,
                        (s.SubscriptionType == 1 ? "Weekly" :
                         s.SubscriptionType == 2 ? "Monthly" : "Yearly"),
                        s.SubscriptionAmount,
                        s.PaidAmount,
                        s.StartDate,
                        s.EndDate,
                        s.CreatedBy.Username,
                        s.CreationDate
                    );

                    //store object
                    dgv_data.Rows[rowIndex].Tag = s;
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
                //open add form
                (new frmSubscriptionData()).ShowDialog();

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

                //get selected object
                Subscription s = (Subscription)dgv_data.CurrentRow.Tag;

                //open edit form
                (new frmSubscriptionData(s)).ShowDialog();

                //refresh data
                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}