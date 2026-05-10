namespace GymMS
{
    partial class frmPeopleList
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
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birth_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.person_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bn_add = new System.Windows.Forms.Button();
            this.bn_search = new System.Windows.Forms.Button();
            this.cb_personType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullname,
            this.phone_number,
            this.birth_date,
            this.created_by,
            this.person_type});
            this.dgv_data.Location = new System.Drawing.Point(12, 38);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersWidth = 15;
            this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_data.Size = new System.Drawing.Size(668, 433);
            this.dgv_data.StandardTab = true;
            this.dgv_data.TabIndex = 4;
            this.dgv_data.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseDoubleClick);
            // 
            // fullname
            // 
            this.fullname.HeaderText = "Full name";
            this.fullname.Name = "fullname";
            this.fullname.Width = 200;
            // 
            // phone_number
            // 
            this.phone_number.HeaderText = "Phone number";
            this.phone_number.Name = "phone_number";
            this.phone_number.Width = 125;
            // 
            // birth_date
            // 
            this.birth_date.HeaderText = "Birth date";
            this.birth_date.Name = "birth_date";
            // 
            // created_by
            // 
            this.created_by.HeaderText = "Created by";
            this.created_by.Name = "created_by";
            // 
            // person_type
            // 
            this.person_type.HeaderText = "Person type";
            this.person_type.Name = "person_type";
            this.person_type.Width = 125;
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(62, 12);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(130, 20);
            this.tb_search.TabIndex = 0;
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
            this.bn_add.Location = new System.Drawing.Point(612, 10);
            this.bn_add.Name = "bn_add";
            this.bn_add.Size = new System.Drawing.Size(66, 23);
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
            this.bn_search.TabIndex = 1;
            this.bn_search.Text = "Search";
            this.bn_search.UseVisualStyleBackColor = true;
            this.bn_search.Click += new System.EventHandler(this.bn_search_Click);
            // 
            // cb_personType
            // 
            this.cb_personType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_personType.FormattingEnabled = true;
            this.cb_personType.Location = new System.Drawing.Point(485, 12);
            this.cb_personType.Name = "cb_personType";
            this.cb_personType.Size = new System.Drawing.Size(121, 21);
            this.cb_personType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Add new:";
            // 
            // frmPeopleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 483);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_personType);
            this.Controls.Add(this.bn_search);
            this.Controls.Add(this.bn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.dgv_data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPeopleList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People Management";
            this.Load += new System.EventHandler(this.frmUserList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bn_add;
        private System.Windows.Forms.Button bn_search;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn birth_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn created_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn person_type;
        private System.Windows.Forms.ComboBox cb_personType;
        private System.Windows.Forms.Label label2;
    }
}