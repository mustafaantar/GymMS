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
    public partial class frmUserList : Form
    {
        public frmUserList()
        {
            InitializeComponent();
        }


        private void frmUserList_Load(object sender, EventArgs e)
        {
            //display all users 
            Search(null);
        }

        private void bn_search_Click(object sender, EventArgs e)
        {
            //search for users using filter
            Search(tb_search.Text);
        }

        void Search(string filter)
        {


            //clear grid
            dgv_data.Rows.Clear();

            //read list of users from the databaes
            List<Users> list = GymDataAccess.Users.ListData(filter);

            //loop into the lists items
            foreach (Users u in list)
            {
                int rowIndex = dgv_data.Rows.Add(
                    u.Id,
                    u.Username,
                    u.Password,
                    u.UserType
                );

                // store the object in the row
                dgv_data.Rows[rowIndex].Tag = u;
            }
        }

        private void bn_add_Click(object sender, EventArgs e)
        {
            //open data form 
                (new frmUserdata()).ShowDialog();

            //Read data again(Do refresh)
            Search(tb_search.Text);
        }

        private void dgv_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if no rows selected returns (do nothing)
            if (dgv_data.SelectedRows.Count == 0)
                return;

            //read selected object
            Users u = (Users)dgv_data.CurrentRow.Tag;

            //Open data form 
                new frmUserdata((Users)u).ShowDialog();

            //Read data again(Do refresh)
            Search(tb_search.Text);
        }
    }
}