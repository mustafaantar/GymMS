using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<GymDataAccess.Users> list = GymDataAccess.Users.ListData(filter);
            
            //loop into the lists items
            for (int i = 0; i < list.Count; i++)
                //add data to the grid
                dgv_data.Rows.Add(list[i].Id, list[i].Username, list[i].Password, list[i].UserType);
        }

        private void bn_add_Click(object sender, EventArgs e)
        {
            //open data form to add new user into the database
            frmUserdata f = new frmUserdata();

            //display the form
            f.ShowDialog();

            //Read data again(Do refresh)
            Search(tb_search.Text);
            Search(tb_search.Text);
        }

        private void dgv_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if no rows selected returns (do nothing)
            if (dgv_data.SelectedRows.Count == 0)
                return;

            //read selected id
            int id = (int)dgv_data.SelectedRows[0].Cells["user_id"].FormattedValue;

            //read object data from database
            GymDataAccess.Users u = new GymDataAccess.Users(id);

            //sender the object to data form
            frmUserdata f = new frmUserdata(u);

            //display data form
            f.ShowDialog();

            //Read data again(Do refresh)
            Search(tb_search.Text);

        }
    }
}