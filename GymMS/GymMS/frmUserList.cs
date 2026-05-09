using GymDataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmUserList : Form
    {
        public frmUserList()
        {
            InitializeComponent();
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            try
            {
                //display all users
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

                //read list of users from database
                List<Users> list = GymDataAccess.Users.ListData(filter);

                //loop into list items
                foreach (Users u in list)
                {
                    int rowIndex = dgv_data.Rows.Add(
                        u.Id,
                        u.Username,
                        u.Password,
                        u.UserType
                    );

                    //store object in row
                    dgv_data.Rows[rowIndex].Tag = u;
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
                //open data form
                (new frmUserdata()).ShowDialog();

                //refresh data
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
                //if no row selected return
                if (dgv_data.SelectedRows.Count == 0)
                    return;

                //read selected object
                Users u = (Users)dgv_data.CurrentRow.Tag;

                //open edit form
                new frmUserdata(u).ShowDialog();

                //refresh data
                Search(tb_search.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}