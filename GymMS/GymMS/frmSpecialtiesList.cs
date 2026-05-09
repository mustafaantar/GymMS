using GymDataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            try
            {
                Search();
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
                //search for specialties using filter (not implemented yet)
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

                //read list of specialties from database
                List<Specialties> list = Specialties.ListData();

                //loop into the list items
                foreach (Specialties s in list)
                {
                    int rowIndex = dgv_data.Rows.Add(
                        s.Id,
                        s.SpecialtyName
                    );

                    //store object in row
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
                //open data form
                (new frmSpecialtiesData()).ShowDialog();

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
                //if no rows selected return
                if (dgv_data.SelectedRows.Count == 0)
                    return;

                //read selected object
                Specialties s = (Specialties)dgv_data.CurrentRow.Tag;

                //open edit form
                (new frmSpecialtiesData(s)).ShowDialog();

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