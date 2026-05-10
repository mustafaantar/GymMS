using GymDataAccess;
using GymDataAccess.GymDataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmBookingList : Form
    {
        public frmBookingList()
        {
            InitializeComponent();
        }

        private void frmBookingList_Load(object sender, EventArgs e)
        {
            try
            {
                //fill members list
                List<GymDataAccess.Person> list = GymDataAccess.Person.ListMembersData(null);

                cb_member.Items.Add("-");

                int index = 0;

                //add items to comboBox
                for (int i = 0; i < list.Count; i++)
                {
                    cb_member.Items.Add(list[i]);
                }

                if (cb_member.Items.Count != 0)
                    cb_member.SelectedIndex = index;


                //fill trainers list
                list = GymDataAccess.Person.ListTrainersData(null);

                cb_trainer.Items.Add("-");

                //add items to comboBox
                for (int i = 0; i < list.Count; i++)
                {
                    cb_trainer.Items.Add(list[i]);
                }

                if (cb_trainer.Items.Count != 0)
                    cb_trainer.SelectedIndex = index;
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
                int? memberId = null;

                if (cb_member.SelectedIndex > 0)
                    memberId = ((Member)cb_member.SelectedItem).Id;

                int? trainerId = null;

                if (cb_trainer.SelectedIndex > 0)
                    trainerId = ((Trainer)cb_member.SelectedItem).Id;

                DateTime? fromDate = null;
                if (f_fromDate.Checked)
                    fromDate = f_fromDate.Value;

                DateTime? toDate = null;
                if (f_toDate.Checked)
                    toDate = f_toDate.Value;

                //read data from database
                List<Booking> list = Booking.ListData(memberId,trainerId, fromDate, toDate);

                //fill grid
                foreach (Booking p in list)
                {
                    int rowIndex = dgv_data.Rows.Add(
                        p.Id,
                        p.Member.FullName,
                        p.Trainer.FullName,
                        p.BookingDate,
                        p.CreatedBy.Username,
                        p.CreationDate);

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
                (new frmBookingData()).ShowDialog();

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
                Booking p = (Booking)dgv_data.CurrentRow.Tag;

                //open edit form
                (new frmBookingData(p)).ShowDialog();

                //refresh grid
                Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_add_Click_1(object sender, EventArgs e)
        {
            frmBookingData f = new frmBookingData();
            f.ShowDialog();
            Search();
        }
    }
}