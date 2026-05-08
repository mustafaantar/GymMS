namespace GymMS
{
    partial class frmSubscriptionList
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
            this.sub_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creatrd_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creation_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_member = new System.Windows.Forms.ComboBox();
            this.f_fromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.f_toDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // bn_search
            // 
            this.bn_search.Location = new System.Drawing.Point(816, 9);
            this.bn_search.Name = "bn_search";
            this.bn_search.Size = new System.Drawing.Size(67, 23);
            this.bn_search.TabIndex = 12;
            this.bn_search.Text = "Search";
            this.bn_search.UseVisualStyleBackColor = true;
            this.bn_search.Click += new System.EventHandler(this.bn_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Member:";
            // 
            // bn_add
            // 
            this.bn_add.Location = new System.Drawing.Point(889, 8);
            this.bn_add.Name = "bn_add";
            this.bn_add.Size = new System.Drawing.Size(66, 23);
            this.bn_add.TabIndex = 9;
            this.bn_add.Text = "Add";
            this.bn_add.UseVisualStyleBackColor = true;
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Member,
            this.sub_type,
            this.Sub_amt,
            this.paid_amt,
            this.start_date,
            this.endDate,
            this.creatrd_by,
            this.creation_date});
            this.dgv_data.Location = new System.Drawing.Point(12, 39);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersWidth = 15;
            this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_data.Size = new System.Drawing.Size(943, 445);
            this.dgv_data.StandardTab = true;
            this.dgv_data.TabIndex = 8;
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
            this.Member.Width = 200;
            // 
            // sub_type
            // 
            this.sub_type.HeaderText = "Type";
            this.sub_type.Name = "sub_type";
            this.sub_type.ReadOnly = true;
            // 
            // Sub_amt
            // 
            this.Sub_amt.HeaderText = "Sub. amount";
            this.Sub_amt.Name = "Sub_amt";
            this.Sub_amt.ReadOnly = true;
            // 
            // paid_amt
            // 
            this.paid_amt.HeaderText = "Paid amount";
            this.paid_amt.Name = "paid_amt";
            this.paid_amt.ReadOnly = true;
            // 
            // start_date
            // 
            this.start_date.HeaderText = "Start date";
            this.start_date.Name = "start_date";
            this.start_date.ReadOnly = true;
            // 
            // endDate
            // 
            this.endDate.HeaderText = "End date";
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            // 
            // creatrd_by
            // 
            this.creatrd_by.HeaderText = "Creator";
            this.creatrd_by.Name = "creatrd_by";
            this.creatrd_by.ReadOnly = true;
            this.creatrd_by.Width = 75;
            // 
            // creation_date
            // 
            this.creation_date.HeaderText = "Creation Date";
            this.creation_date.Name = "creation_date";
            this.creation_date.ReadOnly = true;
            // 
            // cb_member
            // 
            this.cb_member.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_member.FormattingEnabled = true;
            this.cb_member.Location = new System.Drawing.Point(66, 11);
            this.cb_member.Name = "cb_member";
            this.cb_member.Size = new System.Drawing.Size(182, 21);
            this.cb_member.TabIndex = 13;
            // 
            // f_fromDate
            // 
            this.f_fromDate.CustomFormat = "dd/MM/yyyy";
            this.f_fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.f_fromDate.Location = new System.Drawing.Point(501, 12);
            this.f_fromDate.Name = "f_fromDate";
            this.f_fromDate.ShowCheckBox = true;
            this.f_fromDate.ShowUpDown = true;
            this.f_fromDate.Size = new System.Drawing.Size(104, 20);
            this.f_fromDate.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "From date:";
            // 
            // f_toDate
            // 
            this.f_toDate.CustomFormat = "dd/MM/yyyy";
            this.f_toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.f_toDate.Location = new System.Drawing.Point(664, 12);
            this.f_toDate.Name = "f_toDate";
            this.f_toDate.ShowCheckBox = true;
            this.f_toDate.ShowUpDown = true;
            this.f_toDate.Size = new System.Drawing.Size(104, 20);
            this.f_toDate.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "To date:";
            // 
            // cb_type
            // 
            this.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(319, 11);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(113, 21);
            this.cb_type.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Sub. Type:";
            // 
            // frmSubscriptionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 496);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.f_toDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.f_fromDate);
            this.Controls.Add(this.cb_member);
            this.Controls.Add(this.bn_search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bn_add);
            this.Controls.Add(this.dgv_data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubscriptionList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Specialties list";
            this.Load += new System.EventHandler(this.frmSubscriptionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bn_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bn_add;
        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sub_amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid_amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn creatrd_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn creation_date;
        private System.Windows.Forms.ComboBox cb_member;
        private System.Windows.Forms.DateTimePicker f_fromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker f_toDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label label4;
    }
}