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
            else
                member = new Member();
        }

        private void frmMemberData_Load(object sender, EventArgs e)
        {
           
            if (this.member == null)//if form opened for adding return (do nothing)
                return;
            //assign object data into controls
            tb_id.Text = this.member.Id + "";
            tb_username.Text = this.member.FullName;
        }

        private void bn_close_Click(object sender, EventArgs e)
        {
            //close the form
            Close();
        }

        private void bn_save_Click(object sender, EventArgs e)
        {
            if (this.member == null)
            {
                //create object and fill data then send it to the database
                this.member = new GymDataAccess.Member();

                //assign data from controls into the object
                this.member.FullName = tb_username.Text;

                //add the object data into the database
                this.member.AddToDB();

                //show success insert message
                MessageBox.Show("New user added successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Edit exists data object in the database

                //assign data from controls into the existing object
                this.member.FullName = tb_username.Text;

                //add the object data into the database
                this.member.UpdateInDB();

                //show success insert message
                MessageBox.Show("Data updated successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //close the form
            Close();
        }
    }
}