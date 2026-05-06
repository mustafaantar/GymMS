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
            cb_personType.SelectedIndex = 0;
            //display all people
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
            List<Person> list = new List<Person>();// GymDataAccess.Person.ListData(filter);

            //loop into the lists items
            foreach (Person p in list)
            {
                int rowIndex = dgv_data.Rows.Add(
                    p.Id,
                    p.FullName,
                    p.PhoneNumber,
                    p.GetType().Name
                );

                // Store the object in the row
                dgv_data.Rows[rowIndex].Tag = p;
            }
        }

        private void bn_add_Click(object sender, EventArgs e)
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

        private void dgv_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if no rows selected returns (do nothing)
            if (dgv_data.SelectedRows.Count == 0)
                return;

            int id = (int)dgv_data.SelectedRows[0].Cells[0].FormattedValue;

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
    }
}