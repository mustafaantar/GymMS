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
            if (this.specialty == null)//if form opened for adding return (do nothing)
                return;

            //assign object data into controls
            tb_id.Text = this.specialty.Id + "";
            tb_username.Text = this.specialty.SpecialtyName;
        }

        private void bn_close_Click(object sender, EventArgs e)
        {
            //close the form
            Close();
        }

        private void bn_save_Click(object sender, EventArgs e)
        {
            if (this.specialty == null)
            {
                //create object and fill data then send it to the database
                GymDataAccess.Specialties s = new GymDataAccess.Specialties();

                //assign data from controls into the object
                s.SpecialtyName = tb_username.Text;

                //add the object data into the database
                s.AddToDB(GlobalVariables.LoginUser.Id);

                //show success insert message
                MessageBox.Show("New Specialty added successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Edit exists data object in the database

                //assign data from controls into the existing object
                this.specialty.SpecialtyName = tb_username.Text;

                //add the object data into the database
                this.specialty.UpdateInDB();

                //show success insert message
                MessageBox.Show("Data updated successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //close the form
            Close();
        }
    }
}