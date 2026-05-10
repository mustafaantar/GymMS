namespace GymMS
{
    partial class frmMainMdi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bn_people = new System.Windows.Forms.Button();
            this.bn_users = new System.Windows.Forms.Button();
            this.bn_sub = new System.Windows.Forms.Button();
            this.bn_payment = new System.Windows.Forms.Button();
            this.bn_booking = new System.Windows.Forms.Button();
            this.bn_specialties = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bn_people
            // 
            this.bn_people.Location = new System.Drawing.Point(12, 12);
            this.bn_people.Name = "bn_people";
            this.bn_people.Size = new System.Drawing.Size(142, 50);
            this.bn_people.TabIndex = 1;
            this.bn_people.Text = "People management";
            this.bn_people.UseVisualStyleBackColor = true;
            this.bn_people.Click += new System.EventHandler(this.bn_people_Click);
            // 
            // bn_users
            // 
            this.bn_users.Location = new System.Drawing.Point(12, 68);
            this.bn_users.Name = "bn_users";
            this.bn_users.Size = new System.Drawing.Size(142, 50);
            this.bn_users.TabIndex = 1;
            this.bn_users.Text = "User management";
            this.bn_users.UseVisualStyleBackColor = true;
            this.bn_users.Click += new System.EventHandler(this.bn_users_Click);
            // 
            // bn_sub
            // 
            this.bn_sub.Location = new System.Drawing.Point(193, 12);
            this.bn_sub.Name = "bn_sub";
            this.bn_sub.Size = new System.Drawing.Size(142, 50);
            this.bn_sub.TabIndex = 1;
            this.bn_sub.Text = "Subscriptions";
            this.bn_sub.UseVisualStyleBackColor = true;
            this.bn_sub.Click += new System.EventHandler(this.bn_sub_Click);
            // 
            // bn_payment
            // 
            this.bn_payment.Location = new System.Drawing.Point(193, 68);
            this.bn_payment.Name = "bn_payment";
            this.bn_payment.Size = new System.Drawing.Size(142, 50);
            this.bn_payment.TabIndex = 1;
            this.bn_payment.Text = "Payments";
            this.bn_payment.UseVisualStyleBackColor = true;
            this.bn_payment.Click += new System.EventHandler(this.bn_payment_Click);
            // 
            // bn_booking
            // 
            this.bn_booking.Location = new System.Drawing.Point(380, 12);
            this.bn_booking.Name = "bn_booking";
            this.bn_booking.Size = new System.Drawing.Size(142, 50);
            this.bn_booking.TabIndex = 1;
            this.bn_booking.Text = "Booking";
            this.bn_booking.UseVisualStyleBackColor = true;
            this.bn_booking.Click += new System.EventHandler(this.bn_booking_Click);
            // 
            // bn_specialties
            // 
            this.bn_specialties.Location = new System.Drawing.Point(12, 124);
            this.bn_specialties.Name = "bn_specialties";
            this.bn_specialties.Size = new System.Drawing.Size(142, 50);
            this.bn_specialties.TabIndex = 3;
            this.bn_specialties.Text = "Specia;ties setup";
            this.bn_specialties.UseVisualStyleBackColor = true;
            this.bn_specialties.Click += new System.EventHandler(this.bn_specialties_Click);
            // 
            // frmMainMdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 494);
            this.Controls.Add(this.bn_specialties);
            this.Controls.Add(this.bn_booking);
            this.Controls.Add(this.bn_payment);
            this.Controls.Add(this.bn_sub);
            this.Controls.Add(this.bn_users);
            this.Controls.Add(this.bn_people);
            this.IsMdiContainer = true;
            this.Name = "frmMainMdi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gym Management System - GymMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainMdi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bn_people;
        private System.Windows.Forms.Button bn_users;
        private System.Windows.Forms.Button bn_sub;
        private System.Windows.Forms.Button bn_payment;
        private System.Windows.Forms.Button bn_booking;
        private System.Windows.Forms.Button bn_specialties;
    }
}