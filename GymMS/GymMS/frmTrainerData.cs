using GymDataAccess;
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
    public partial class frmTrainerData : Form
    {
        //form variable member
        GymDataAccess.Trainer trainer;
        public frmTrainerData()
        {
            InitializeComponent();
        }

        public frmTrainerData(GymDataAccess.Person p)
        {
            InitializeComponent();
            if (p is Trainer)
                trainer = (Trainer)p;
        }

        private void frmTrainerData_Load(object sender, EventArgs e)
        {

            if (this.trainer == null)//if form opened for adding return (do nothing)
                return;
            //assign object data into controls
            tb_id.Text = this.trainer.Id + "";
            tb_fillname.Text = this.trainer.FullName;
            tb_phone.Text = this.trainer.PhoneNumber;
            tb_address.Text = this.trainer.Address;
            dateTimePicker1.Value = this.trainer.BirthDate;
            for (int i = 0; i < cb_specialty.Items.Count; i++)
                if (((Specialties)cb_specialty.Items[i]).Id == this.trainer.Specialty_id)
                {
                    cb_specialty.SelectedIndex = i;
                    break;
                }
        }

        private void bn_close_Click(object sender, EventArgs e)
        {
            //close the form
            Close();
        }

        private void bn_save_Click(object sender, EventArgs e)
        {
            if (this.trainer == null)
            {
                //create object and fill data then send it to the database
                this.trainer = new GymDataAccess.Trainer();

                //assign data from controls into the object
                this.trainer.FullName = tb_fillname.Text;
                this.trainer.PhoneNumber = tb_phone.Text;
                this.trainer.Address = tb_address.Text;
                this.trainer.BirthDate = dateTimePicker1.Value;
                this.trainer.Specialty_id = ((Specialties)cb_specialty.SelectedItem).Id;
                //add the object data into the database
                this.trainer.AddToDB(GlobalVariables.LoginUser.Id);

                //show success insert message
                MessageBox.Show("New user added successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Edit exists data object in the database

                //assign data from controls into the existing object
                this.trainer.FullName = tb_fillname.Text;
                this.trainer.PhoneNumber = tb_phone.Text;
                this.trainer.Address = tb_address.Text;
                this.trainer.BirthDate = dateTimePicker1.Value;
                this.trainer.Specialty_id = ((Specialties)cb_specialty.SelectedItem).Id;

                //add the object data into the database
                this.trainer.UpdateInDB();

                //show success insert message
                MessageBox.Show("Data updated successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //close the form
            Close();
        }
    }
}