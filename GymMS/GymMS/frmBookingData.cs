using GymDataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmBookingData : Form
    {
        //form variable member
        GymDataAccess.Booking booking;

        public frmBookingData()
        {
            InitializeComponent();
        }

        public frmBookingData(GymDataAccess.Booking booking)
        {
            InitializeComponent();
            this.booking = booking;
        }

        private void frmBookingData_Load(object sender, EventArgs e)
        {
            try
            {
                List<Person> list =  Person.ListMembersData(null);
                for (int i = 0; i < list.Count; i++)
                {
                    cb_member.Items.Add(list[i]);
                }

                if (list.Count != 0)
                    cb_member.SelectedIndex = 0;

                list = Person.ListTrainersData(null);
                for (int i = 0; i < list.Count; i++)
                {
                    cb_trainer.Items.Add(list[i]);
                }

                if (list.Count != 0)
                    cb_trainer.SelectedIndex = 0;

                //if form opened for adding return (do nothing)
                if (this.booking == null)
                    return;

                //assign object data into controls
                tb_id.Text = this.booking.Id + "";

                for (int i = 0; i < cb_member.Items.Count; i++)
                {
                    if (((Member)cb_member.Items[i]).Id == this.booking.Member.Id)
                    {
                        cb_member.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cb_trainer.Items.Count; i++)
                {
                    if (((Trainer)cb_trainer.Items[i]).Id == this.booking.Trainer.Id)
                    {
                        cb_trainer.SelectedIndex = i;
                        break;
                    }
                }

                d_booking_date.Value = this.booking.BookingDate;
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
                if (this.booking == null)
                {
                    //create object and fill data then send it to the database
                    this.booking = new GymDataAccess.Booking();

                    //assign data from controls into the object
                    this.booking.Member = new Member(((Member)cb_member.SelectedItem));
                    this.booking.Trainer = new Trainer(((Trainer)cb_trainer.SelectedItem));
                    this.booking.BookingDate = d_booking_date.Value;

                    //add the object data into the database
                    this.booking.AddToDB(GlobalVariables.LoginUser.Id);

                    //show success insert message
                    MessageBox.Show("New booking added successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //edit existing object in database
                    this.booking.Member = new Member(((Member)cb_member.SelectedItem));
                    this.booking.Trainer = new Trainer(((Trainer)cb_trainer.SelectedItem));
                    this.booking.BookingDate = d_booking_date.Value;

                    //update object in database
                    this.booking.UpdateInDB();

                    //show success update message
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