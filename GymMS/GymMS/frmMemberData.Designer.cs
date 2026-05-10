namespace GymMS
{
    partial class frmMemberData
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
            this.d_birth_Date = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_address = new System.Windows.Forms.TextBox();
            this.tb_phone = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_fillname = new System.Windows.Forms.TextBox();
            this.bn_close = new System.Windows.Forms.Button();
            this.bn_save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.d_end_date = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.d_start_date = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // d_birth_Date
            // 
            this.d_birth_Date.CustomFormat = "dd/MM/yyyy";
            this.d_birth_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d_birth_Date.Location = new System.Drawing.Point(288, 64);
            this.d_birth_Date.Name = "d_birth_Date";
            this.d_birth_Date.Size = new System.Drawing.Size(112, 20);
            this.d_birth_Date.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Birth date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Phone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Full name:";
            // 
            // tb_address
            // 
            this.tb_address.Location = new System.Drawing.Point(76, 116);
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(324, 20);
            this.tb_address.TabIndex = 6;
            // 
            // tb_phone
            // 
            this.tb_phone.Location = new System.Drawing.Point(76, 64);
            this.tb_phone.Name = "tb_phone";
            this.tb_phone.Size = new System.Drawing.Size(119, 20);
            this.tb_phone.TabIndex = 2;
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(76, 12);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(119, 20);
            this.tb_id.TabIndex = 0;
            // 
            // tb_fillname
            // 
            this.tb_fillname.Location = new System.Drawing.Point(76, 38);
            this.tb_fillname.Name = "tb_fillname";
            this.tb_fillname.Size = new System.Drawing.Size(324, 20);
            this.tb_fillname.TabIndex = 1;
            // 
            // bn_close
            // 
            this.bn_close.Location = new System.Drawing.Point(11, 142);
            this.bn_close.Name = "bn_close";
            this.bn_close.Size = new System.Drawing.Size(75, 23);
            this.bn_close.TabIndex = 7;
            this.bn_close.Text = "Close";
            this.bn_close.UseVisualStyleBackColor = true;
            this.bn_close.Click += new System.EventHandler(this.bn_close_Click_1);
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(309, 142);
            this.bn_save.Name = "bn_save";
            this.bn_save.Size = new System.Drawing.Size(75, 23);
            this.bn_save.TabIndex = 8;
            this.bn_save.Text = "Save";
            this.bn_save.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "End date:";
            // 
            // d_end_date
            // 
            this.d_end_date.CustomFormat = "dd/MM/yyyy";
            this.d_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d_end_date.Location = new System.Drawing.Point(288, 90);
            this.d_end_date.Name = "d_end_date";
            this.d_end_date.ShowCheckBox = true;
            this.d_end_date.Size = new System.Drawing.Size(112, 20);
            this.d_end_date.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Start date:";
            // 
            // d_start_date
            // 
            this.d_start_date.CustomFormat = "dd/MM/yyyy";
            this.d_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d_start_date.Location = new System.Drawing.Point(76, 90);
            this.d_start_date.Name = "d_start_date";
            this.d_start_date.Size = new System.Drawing.Size(96, 20);
            this.d_start_date.TabIndex = 4;
            // 
            // frmMemberData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 175);
            this.Controls.Add(this.d_start_date);
            this.Controls.Add(this.d_end_date);
            this.Controls.Add(this.d_birth_Date);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_address);
            this.Controls.Add(this.tb_phone);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.tb_fillname);
            this.Controls.Add(this.bn_close);
            this.Controls.Add(this.bn_save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMemberData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member data";
            this.Load += new System.EventHandler(this.frmMemberData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker d_birth_Date;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.TextBox tb_phone;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_fillname;
        private System.Windows.Forms.Button bn_close;
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker d_end_date;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker d_start_date;
    }
}