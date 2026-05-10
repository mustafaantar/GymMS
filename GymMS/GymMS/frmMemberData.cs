using GymDataAccess;
using System;
using System.Windows.Forms;

namespace GymMS
{
    public partial class frmMemberData : Form
    {
        //form variable member
        GymDataAccess.Member member;

        public frmMemberData()
        {
            InitializeComponent();
        }

        public frmMemberData(GymDataAccess.Person p)
        {
            InitializeComponent();

            if (p is Member)
                member = (Member)p;
        }

        private void frmMemberData_Load(object sender, EventArgs e)
        {
            try
            {
                //if form opened for adding return (do nothing)
                if (this.member == null)
                    return;

                //assign object data into controls
                tb_id.Text = this.member.Id + "";
                tb_fillname.Text = this.member.FullName;
                tb_phone.Text = this.member.PhoneNumber;
                tb_address.Text = this.member.Address;
                d_birth_Date.Value = this.member.BirthDate;
                d_start_date.Value = this.member.StartDate;

                if (this.member.EndDate.HasValue)
                {
                    d_end_date.Checked = true;
                    d_end_date.Value = this.member.EndDate.Value;
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
                //Validate data
                GymDataValidation.CkechPhoneNo(tb_phone.Text);
                GymDataValidation.CheckAge(d_birth_Date.Value);
                GymDataValidation.CkechStartAndEndDate(d_end_date.Value, d_start_date.Value);

                if (this.member == null)
                {
                    //create object and fill data then send it to the database
                    this.member = new GymDataAccess.Member();

                    //assign data from controls into the object
                    this.member.FullName = tb_fillname.Text;
                    this.member.PhoneNumber = tb_phone.Text;
                    this.member.Address = tb_address.Text;
                    this.member.BirthDate = d_birth_Date.Value;
                    this.member.StartDate = d_start_date.Value;

                    if (d_end_date.Checked)
                        this.member.EndDate = d_end_date.Value;
                    else
                        this.member.EndDate = null;

                    //add the object data into the database
                    this.member.AddToDB(GlobalVariables.LoginUser.Id);

                    //success message
                    MessageBox.Show("New user added successfully", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //assign data from controls into the existing object
                    this.member.FullName = tb_fillname.Text;
                    this.member.PhoneNumber = tb_phone.Text;
                    this.member.Address = tb_address.Text;
                    this.member.BirthDate = d_birth_Date.Value;
                    this.member.StartDate = d_start_date.Value;

                    if (d_end_date.Checked)
                        this.member.EndDate = d_end_date.Value;
                    else
                        this.member.EndDate = null;

                    //update object in database
                    this.member.UpdateInDB();

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

        private void bn_close_Click_1(object sender, EventArgs e)
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
    }
}