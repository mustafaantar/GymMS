namespace GymMS
{
    partial class frmPaymentData
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
            this.cb_subscription = new System.Windows.Forms.ComboBox();
            this.d_payment_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_amount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(483, 78);
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
            this.bn_close.Location = new System.Drawing.Point(16, 78);
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
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Subscription:";
            // 
            // cb_subscription
            // 
            this.cb_subscription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_subscription.FormattingEnabled = true;
            this.cb_subscription.Location = new System.Drawing.Point(88, 38);
            this.cb_subscription.Name = "cb_subscription";
            this.cb_subscription.Size = new System.Drawing.Size(207, 21);
            this.cb_subscription.TabIndex = 10;
            // 
            // d_payment_date
            // 
            this.d_payment_date.CustomFormat = "dd/MM/yyyy";
            this.d_payment_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.d_payment_date.Location = new System.Drawing.Point(454, 13);
            this.d_payment_date.Name = "d_payment_date";
            this.d_payment_date.ShowUpDown = true;
            this.d_payment_date.Size = new System.Drawing.Size(104, 20);
            this.d_payment_date.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Payment date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Payment Amount";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // tb_amount
            // 
            this.tb_amount.Location = new System.Drawing.Point(458, 38);
            this.tb_amount.Name = "tb_amount";
            this.tb_amount.Size = new System.Drawing.Size(100, 20);
            this.tb_amount.TabIndex = 17;
            this.tb_amount.TextChanged += new System.EventHandler(this.tb_paid_amount_TextChanged);
            // 
            // frmPaymentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 114);
            this.Controls.Add(this.tb_amount);
            this.Controls.Add(this.d_payment_date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_subscription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.bn_close);
            this.Controls.Add(this.bn_save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaymentData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment data";
            this.Load += new System.EventHandler(this.frmPaymentData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bn_close;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_subscription;
        private System.Windows.Forms.DateTimePicker d_payment_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_amount;
    }
}