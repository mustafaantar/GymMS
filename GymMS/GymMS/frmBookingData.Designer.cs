namespace GymMS
{
    partial class frmBookingData
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
            this.bn_save = new System.Windows.Forms.Button();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bn_close = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_member = new System.Windows.Forms.ComboBox();
            this.d_booking_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_trainer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(408, 92);
            this.bn_save.Name = "bn_save";
            this.bn_save.Size = new System.Drawing.Size(75, 23);
            this.bn_save.TabIndex = 4;
            this.bn_save.Text = "Save";
            this.bn_save.UseVisualStyleBackColor = true;
            this.bn_save.Click += new System.EventHandler(this.bn_save_Click);
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(87, 12);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(119, 20);
            this.tb_id.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ID:";
            // 
            // bn_close
            // 
            this.bn_close.Location = new System.Drawing.Point(16, 92);
            this.bn_close.Name = "bn_close";
            this.bn_close.Size = new System.Drawing.Size(75, 23);
            this.bn_close.TabIndex = 5;
            this.bn_close.Text = "Close";
            this.bn_close.UseVisualStyleBackColor = true;
            this.bn_close.Click += new System.EventHandler(this.bn_close_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Member:";
            // 
            // cb_member
            // 
            this.cb_member.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_member.FormattingEnabled = true;
            this.cb_member.Location = new System.Drawing.Point(88, 38);
            this.cb_member.Name = "cb_member";
            this.cb_member.Size = new System.Drawing.Size(207, 21);
            this.cb_member.TabIndex = 2;
            // 
            // d_booking_date
            // 
            this.d_booking_date.CustomFormat = "dd/MM/yyyy";
            this.d_booking_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d_booking_date.Location = new System.Drawing.Point(379, 39);
            this.d_booking_date.Name = "d_booking_date";
            this.d_booking_date.ShowUpDown = true;
            this.d_booking_date.Size = new System.Drawing.Size(104, 20);
            this.d_booking_date.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Booking date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Trainer:";
            // 
            // cb_trainer
            // 
            this.cb_trainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_trainer.FormattingEnabled = true;
            this.cb_trainer.Location = new System.Drawing.Point(87, 65);
            this.cb_trainer.Name = "cb_trainer";
            this.cb_trainer.Size = new System.Drawing.Size(207, 21);
            this.cb_trainer.TabIndex = 2;
            // 
            // frmBookingData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 125);
            this.Controls.Add(this.d_booking_date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_trainer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_member);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.bn_close);
            this.Controls.Add(this.bn_save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBookingData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking data";
            this.Load += new System.EventHandler(this.frmBookingData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bn_close;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_member;
        private System.Windows.Forms.DateTimePicker d_booking_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_trainer;
    }
}