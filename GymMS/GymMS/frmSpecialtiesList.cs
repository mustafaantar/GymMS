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
    public partial class frmSpecialtiesList : Form
    {
        public frmSpecialtiesList()
        {
            InitializeComponent();
        }


        private void frmSpecialtiesList_Load(object sender, EventArgs e)
        {
            Search();
        }

        private void bn_search_Click(object sender, EventArgs e)
        {
            //search for specialies using filter
        }

      void Search()
        {
            //display all specialies 
            //clear grid
            dgv_data.Rows.Clear();

            //read list of specialies from the databaes
            List<Specialties> list = Specialties.ListData();

            //loop into the lists items
            foreach (Specialties s in list)
            {
                int rowIndex = dgv_data.Rows.Add(s.Id, s.SpecialtyName);

                // store the object in the row
                dgv_data.Rows[rowIndex].Tag = s;
            }
        }

        private void bn_add_Click(object sender, EventArgs e)
        {
            //open data form 
                (new frmSpecialtyData()).ShowDialog();

            //Read data again(Do refresh)
            Search();
        }

        private void dgv_data_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if no rows selected returns (do nothing)
            if (dgv_data.SelectedRows.Count == 0)
                return;

            //read selected object
            Specialties s = (Specialties)dgv_data.CurrentRow.Tag;

            //Open data form 
                new((Specialties)s).ShowDialog();

            //Read data again(Do refresh)
            Search();
        }
    }
}