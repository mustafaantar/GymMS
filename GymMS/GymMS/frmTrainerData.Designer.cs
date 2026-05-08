namespace GymMS
{
    partial class frmTrainerData
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_phone = new System.Windows.Forms.TextBox();
            this.tb_fillname = new System.Windows.Forms.TextBox();
            this.bn_save = new System.Windows.Forms.Button();
            this.cb_specialty = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bn_close = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Phone:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Full name:";
            // 
            // tb_phone
            // 
            this.tb_phone.Location = new System.Drawing.Point(76, 91);
            this.tb_phone.Name = "tb_phone";
            this.tb_phone.Size = new System.Drawing.Size(119, 20);
            this.tb_phone.TabIndex = 5;
            // 
            // tb_fillname
            // 
            this.tb_fillname.Location = new System.Drawing.Point(76, 38);
            this.tb_fillname.Name = "tb_fillname";
            this.tb_fillname.Size = new System.Drawing.Size(308, 20);
            this.tb_fillname.TabIndex = 6;
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(309, 143);
            this.bn_save.Name = "bn_save";
            this.bn_save.Size = new System.Drawing.Size(75, 23);
            this.bn_save.TabIndex = 4;
            this.bn_save.Text = "Save";
            this.bn_save.UseVisualStyleBackColor = true;
            this.bn_save.Click += new System.EventHandler(this.bn_save_Click);
            // 
            // cb_specialty
            // 
            this.cb_specialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_specialty.FormattingEnabled = true;
            this.cb_specialty.Location = new System.Drawing.Point(76, 64);
            this.cb_specialty.Name = "cb_specialty";
            this.cb_specialty.Size = new System.Drawing.Size(119, 21);
            this.cb_specialty.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Specialty:";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(76, 12);
            this.tb_id.Name = "tb_id";
            this.tb_id.ReadOnly = true;
            this.tb_id.Size = new System.Drawing.Size(119, 20);
            this.tb_id.TabIndex = 6;
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
            this.bn_close.Location = new System.Drawing.Point(11, 143);
            this.bn_close.Name = "bn_close";
            this.bn_close.Size = new System.Drawing.Size(75, 23);
            this.bn_close.TabIndex = 4;
            this.bn_close.Text = "Close";
            this.bn_close.UseVisualStyleBackColor = true;
            this.bn_close.Click += new System.EventHandler(this.bn_close_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(288, 91);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Birth date:";
            // 
            // tb_address
            // 
            this.tb_address.Location = new System.Drawing.Point(76, 117);
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(308, 20);
            this.tb_address.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Address:";
            // 
            // frmTrainerData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 179);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cb_specialty);
            this.Controls.Add(this.label3);
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
            this.Name = "frmTrainerData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trainer data";
            this.Load += new System.EventHandler(this.frmTrainerData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_phone;
        private System.Windows.Forms.TextBox tb_fillname;
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.ComboBox cb_specialty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bn_close;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.Label label6;
    }
}