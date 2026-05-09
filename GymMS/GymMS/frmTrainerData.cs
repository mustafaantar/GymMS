using GymDataAccess;
using System;
using System.Collections.Generic;
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
            try
            {
                //fill specialty comboBox
                List<GymDataAccess.Specialties> list = GymDataAccess.Specialties.ListData();
                for (int i = 0; i < list.Count; i++)
                {
                    cb_specialty.Items.Add(list[i]);
                }
                //if form opened for adding return (do nothing)
                if (this.trainer == null)
                {
                    cb_specialty.SelectedIndex = 0;
                    return;
                }

                //assign object data into controls
                tb_id.Text = this.trainer.Id + "";
                tb_fillname.Text = this.trainer.FullName;
                tb_phone.Text = this.trainer.PhoneNumber;
                tb_address.Text = this.trainer.Address;
                dateTimePicker1.Value = this.trainer.BirthDate;

                //select specialty in comboBox
                for (int i = 0; i < cb_specialty.Items.Count; i++)
                {
                    if (((Specialties)cb_specialty.Items[i]).Id == this.trainer.Specialty_id)
                    {
                        cb_specialty.SelectedIndex = i;
                        break;
                    }
                }
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

                    //add to database
                    this.trainer.AddToDB(GlobalVariables.LoginUser.Id);

                    //success message
                    MessageBox.Show("New trainer added successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //edit existing object
                    this.trainer.FullName = tb_fillname.Text;
                    this.trainer.PhoneNumber = tb_phone.Text;
                    this.trainer.Address = tb_address.Text;
                    this.trainer.BirthDate = dateTimePicker1.Value;
                    this.trainer.Specialty_id = ((Specialties)cb_specialty.SelectedItem).Id;

                    //update database
                    this.trainer.UpdateInDB();

                    //success message
                    MessageBox.Show("Data updated successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //close form
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}