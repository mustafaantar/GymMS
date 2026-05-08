namespace GymMS
{
    partial class frmSubscriptionData
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
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bn_close = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_member = new System.Windows.Forms.ComboBox();
            this.d_fromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.d_toDate = new System.Windows.Forms.DateTimePicker();
            this.tb_amount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_paid_amount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(331, 144);
            this.bn_save.Name = "bn_save";
            this.bn_save.Size = new System.Drawing.Size(75, 23);
            this.bn_save.TabIndex = 4;
            this.bn_save.Text = "Save";
            this.bn_save.UseVisualStyleBackColor = true;
            this.bn_save.Click += new System.EventHandler(this.bn_save_Click);
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(306, 38);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(100, 21);
            this.cb_type.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Type:";
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(106, 12);
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
            this.bn_close.Location = new System.Drawing.Point(12, 144);
            this.bn_close.Name = "bn_close";
            this.bn_close.Size = new System.Drawing.Size(75, 23);
            this.bn_close.TabIndex = 4;
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
            this.cb_member.Location = new System.Drawing.Point(107, 38);
            this.cb_member.Name = "cb_member";
            this.cb_member.Size = new System.Drawing.Size(119, 21);
            this.cb_member.TabIndex = 10;
            // 
            // d_fromDate
            // 
            this.d_fromDate.CustomFormat = "dd/MM/yyyy";
            this.d_fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d_fromDate.Location = new System.Drawing.Point(121, 65);
            this.d_fromDate.Name = "d_fromDate";
            this.d_fromDate.ShowCheckBox = true;
            this.d_fromDate.ShowUpDown = true;
            this.d_fromDate.Size = new System.Drawing.Size(104, 20);
            this.d_fromDate.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Subscription date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "End date:";
            // 
            // d_toDate
            // 
            this.d_toDate.CustomFormat = "dd/MM/yyyy";
            this.d_toDate.Enabled = false;
            this.d_toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d_toDate.Location = new System.Drawing.Point(318, 65);
            this.d_toDate.Name = "d_toDate";
            this.d_toDate.ShowUpDown = true;
            this.d_toDate.Size = new System.Drawing.Size(88, 20);
            this.d_toDate.TabIndex = 16;
            // 
            // tb_amount
            // 
            this.tb_amount.Location = new System.Drawing.Point(125, 91);
            this.tb_amount.Name = "tb_amount";
            this.tb_amount.Size = new System.Drawing.Size(100, 20);
            this.tb_amount.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Subscription amount:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Paid amount:";
            // 
            // tb_paid_amount
            // 
            this.tb_paid_amount.Location = new System.Drawing.Point(306, 91);
            this.tb_paid_amount.Name = "tb_paid_amount";
            this.tb_paid_amount.Size = new System.Drawing.Size(100, 20);
            this.tb_paid_amount.TabIndex = 17;
            // 
            // frmSubscriptionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 178);
            this.Controls.Add(this.tb_paid_amount);
            this.Controls.Add(this.tb_amount);
            this.Controls.Add(this.d_toDate);
            this.Controls.Add(this.d_fromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_member);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.bn_close);
            this.Controls.Add(this.bn_save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubscriptionData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subscription data";
            this.Load += new System.EventHandler(this.frmSubscriptionData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bn_close;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_member;
        private System.Windows.Forms.DateTimePicker d_fromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker d_toDate;
        private System.Windows.Forms.TextBox tb_amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_paid_amount;
    }
}