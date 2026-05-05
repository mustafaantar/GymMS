namespace GymMS
{
    partial class frmUserList
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
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.userId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bn_add = new System.Windows.Forms.Button();
            this.bn_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userId,
            this.username,
            this.password,
            this.userType});
            this.dgv_data.Location = new System.Drawing.Point(12, 38);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersWidth = 15;
            this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_data.Size = new System.Drawing.Size(568, 345);
            this.dgv_data.StandardTab = true;
            this.dgv_data.TabIndex = 0;
            this.dgv_data.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseDoubleClick);
            // 
            // userId
            // 
            this.userId.HeaderText = "User ID";
            this.userId.Name = "userId";
            this.userId.ReadOnly = true;
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.Width = 150;
            // 
            // password
            // 
            this.password.HeaderText = "Password";
            this.password.Name = "password";
            this.password.Width = 150;
            // 
            // userType
            // 
            this.userType.HeaderText = "User type";
            this.userType.Name = "userType";
            this.userType.Width = 150;
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(62, 12);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(130, 20);
            this.tb_search.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search:";
            // 
            // bn_add
            // 
            this.bn_add.Location = new System.Drawing.Point(475, 10);
            this.bn_add.Name = "bn_add";
            this.bn_add.Size = new System.Drawing.Size(105, 23);
            this.bn_add.TabIndex = 3;
            this.bn_add.Text = "Add";
            this.bn_add.UseVisualStyleBackColor = true;
            this.bn_add.Click += new System.EventHandler(this.bn_add_Click);
            // 
            // bn_search
            // 
            this.bn_search.Location = new System.Drawing.Point(198, 10);
            this.bn_search.Name = "bn_search";
            this.bn_search.Size = new System.Drawing.Size(67, 23);
            this.bn_search.TabIndex = 4;
            this.bn_search.Text = "Search";
            this.bn_search.UseVisualStyleBackColor = true;
            this.bn_search.Click += new System.EventHandler(this.bn_search_Click);
            // 
            // frmUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 391);
            this.Controls.Add(this.bn_search);
            this.Controls.Add(this.bn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.dgv_data);
            this.Name = "frmUserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User list";
            this.Load += new System.EventHandler(this.frmUserList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn userId;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn userType;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bn_add;
        private System.Windows.Forms.Button bn_search;
    }
}