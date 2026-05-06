namespace GymMS
{
    partial class frmSpecialtiesList
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
            this.bn_add = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialty_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.specialty_name});
            this.dgv_data.Location = new System.Drawing.Point(12, 38);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersWidth = 15;
            this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_data.Size = new System.Drawing.Size(268, 301);
            this.dgv_data.StandardTab = true;
            this.dgv_data.TabIndex = 0;
            this.dgv_data.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_data_CellMouseDoubleClick);
            // 
            // bn_add
            // 
            this.bn_add.Location = new System.Drawing.Point(214, 10);
            this.bn_add.Name = "bn_add";
            this.bn_add.Size = new System.Drawing.Size(66, 23);
            this.bn_add.TabIndex = 3;
            this.bn_add.Text = "Add";
            this.bn_add.UseVisualStyleBackColor = true;
            this.bn_add.Click += new System.EventHandler(this.bn_add_Click);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // specialty_name
            // 
            this.specialty_name.HeaderText = "Specialty name";
            this.specialty_name.Name = "specialty_name";
            this.specialty_name.Width = 150;
            // 
            // frmSpecialtiesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 347);
            this.Controls.Add(this.bn_add);
            this.Controls.Add(this.dgv_data);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpecialtiesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Specialties list";
            this.Load += new System.EventHandler(this.frmSpecialtiesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.Button bn_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn specialty_name;
    }
}