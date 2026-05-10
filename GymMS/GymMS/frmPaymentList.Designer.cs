namespace GymMS
{
    partial class frmPaymentList
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
            this.bn_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bn_add = new System.Windows.Forms.Button();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creatoin_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_sub = new System.Windows.Forms.ComboBox();
            this.f_fromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.f_toDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // bn_search
            // 
            this.bn_search.Location = new System.Drawing.Point(610, 9);
            this.bn_search.Name = "bn_search";
            this.bn_search.Size = new System.Drawing.Size(67, 23);
            this.bn_search.TabIndex = 3;
            this.bn_search.Text = "Search";
            this.bn_search.UseVisualStyleBackColor = true;
            this.bn_search.Click += new System.EventHandler(this.bn_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Subscription:";
            // 
            // bn_add
            // 
            this.bn_add.Location = new System.Drawing.Point(838, 8);
            this.bn_add.Name = "bn_add";
            this.bn_add.Size = new System.Drawing.Size(66, 23);
            this.bn_add.TabIndex = 4;
            this.bn_add.Text = "Add";
            this.bn_add.UseVisualStyleBackColor = true;
            this.bn_add.Click += new System.EventHandler(this.bn_add_Click_1);
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Member,
            this.subscription,
            this.sub_date,
            this.payment_date,
            this.amount,
            this.created_by,
            this.creatoin_date});
            this.dgv_data.Location = new System.Drawing.Point(12, 39);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersWidth = 15;
            this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_data.Size = new System.Drawing.Size(892, 445);
            this.dgv_data.StandardTab = true;
            this.dgv_data.TabIndex = 5;
            this.dgv_data.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 50;
            // 
            // Member
            // 
            this.Member.HeaderText = "Member";
            this.Member.Name = "Member";
            this.Member.ReadOnly = true;
            this.Member.Width = 225;
            // 
            // subscription
            // 
            this.subscription.HeaderText = "Sub. No.";
            this.subscription.Name = "subscription";
            this.subscription.ReadOnly = true;
            // 
            // sub_date
            // 
            this.sub_date.HeaderText = "Sub. Date";
            this.sub_date.Name = "sub_date";
            this.sub_date.ReadOnly = true;
            // 
            // payment_date
            // 
            this.payment_date.HeaderText = "Payment date";
            this.payment_date.Name = "payment_date";
            this.payment_date.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // created_by
            // 
            this.created_by.HeaderText = "Created By";
            this.created_by.Name = "created_by";
            this.created_by.ReadOnly = true;
            // 
            // creatoin_date
            // 
            this.creatoin_date.HeaderText = "Creation date";
            this.creatoin_date.Name = "creatoin_date";
            this.creatoin_date.ReadOnly = true;
            // 
            // cb_sub
            // 
            this.cb_sub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sub.FormattingEnabled = true;
            this.cb_sub.Location = new System.Drawing.Point(86, 11);
            this.cb_sub.Name = "cb_sub";
            this.cb_sub.Size = new System.Drawing.Size(182, 21);
            this.cb_sub.TabIndex = 0;
            // 
            // f_fromDate
            // 
            this.f_fromDate.CustomFormat = "dd/MM/yyyy";
            this.f_fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.f_fromDate.Location = new System.Drawing.Point(337, 12);
            this.f_fromDate.Name = "f_fromDate";
            this.f_fromDate.ShowCheckBox = true;
            this.f_fromDate.ShowUpDown = true;
            this.f_fromDate.Size = new System.Drawing.Size(104, 20);
            this.f_fromDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "From date:";
            // 
            // f_toDate
            // 
            this.f_toDate.CustomFormat = "dd/MM/yyyy";
            this.f_toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.f_toDate.Location = new System.Drawing.Point(500, 12);
            this.f_toDate.Name = "f_toDate";
            this.f_toDate.ShowCheckBox = true;
            this.f_toDate.ShowUpDown = true;
            this.f_toDate.Size = new System.Drawing.Size(104, 20);
            this.f_toDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "To date:";
            // 
            // frmPaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 496);
            this.Controls.Add(this.f_toDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.f_fromDate);
            this.Controls.Add(this.cb_sub);
            this.Controls.Add(this.bn_search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bn_add);
            this.Controls.Add(this.dgv_data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaymentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payments list";
            this.Load += new System.EventHandler(this.frmPaymentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bn_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bn_add;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.ComboBox cb_sub;
        private System.Windows.Forms.DateTimePicker f_fromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker f_toDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn subscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn created_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn creatoin_date;
    }
}