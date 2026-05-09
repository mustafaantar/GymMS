using GymDataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmPeopleList : Form
    {
        public frmPeopleList()
        {
            InitializeComponent();

            cb_personType.Items.Add("Trainer");
            cb_personType.Items.Add("Member");
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            try
            {
                cb_personType.SelectedIndex = 0;

                //display all people
                Search(null);
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
                //search for users using filter
                Search(tb_search.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Search(string filter)
        {
            try
            {
                //clear grid
                dgv_data.Rows.Clear();

                //read list of users from the databaes
                List<Person> list = GymDataAccess.Person.ListData(tb_search.Text);

                //loop into the lists items
                foreach (Person p in list)
                {
                    int rowIndex = dgv_data.Rows.Add(
                        p.FullName,
                        p.PhoneNumber,
                        p.GetType().Name,
                        p.CreatedBy.Username,
                        p.CreationDate
                    );

                    // Store the object in the row
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
                //open data form to add new person into the database
                if (cb_personType.SelectedIndex == 0)

                    //display the form
                    (new frmTrainerData()).ShowDialog();
                else
                    (new frmMemberData()).ShowDialog();

                //Read data again(Do refresh)
                Search(tb_search.Text);
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
                //if no rows selected returns (do nothing)
                if (dgv_data.SelectedRows.Count == 0)
                    return;

                //read selected object
                Person p = (Person)dgv_data.CurrentRow.Tag;

                //Open data form depending on person type
                if (p is Member)
                {
                    //display data form
                    new frmMemberData((Member)p).ShowDialog();
                }
                else if (p is Trainer)
                {
                    //display data form
                    new frmTrainerData((Trainer)p).ShowDialog();
                }

                //Read data again(Do refresh)
                Search(tb_search.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}