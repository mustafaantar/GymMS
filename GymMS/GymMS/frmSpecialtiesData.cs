using System;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmSpecialtiesData : Form
    {
        //form variable member
        GymDataAccess.Specialties specialty;

        public frmSpecialtiesData()
        {
            InitializeComponent();
        }

        public frmSpecialtiesData(GymDataAccess.Specialties Specialty)
        {
            InitializeComponent();
            this.specialty = Specialty;
        }

        private void frmSpecialtiesData_Load(object sender, EventArgs e)
        {
            try
            {
                //if form opened for adding return (do nothing)
                if (this.specialty == null)
                    return;

                //assign object data into controls
                tb_id.Text = this.specialty.Id + "";
                tb_name.Text = this.specialty.SpecialtyName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_close_Click(object sender, EventArgs e)
        {
            try
            {
                //close the form
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.specialty == null)
                {
                    //create object and fill data then send it to the database
                    GymDataAccess.Specialties s = new GymDataAccess.Specialties();

                    //assign data from controls into the object
                    s.SpecialtyName = tb_name.Text;

                    //add the object data into the database
                    s.AddToDB(GlobalVariables.LoginUser.Id);

                    //success message
                    MessageBox.Show("New Specialty added successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //assign data from controls into the existing object
                    this.specialty.SpecialtyName = tb_name.Text;

                    //update object in database
                    this.specialty.UpdateInDB();

                    //success message
                    MessageBox.Show("Data updated successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //close the form
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}