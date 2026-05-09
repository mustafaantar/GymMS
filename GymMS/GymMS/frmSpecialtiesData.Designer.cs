namespace GymMS
{
    partial class frmSpecialtiesData
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.bn_save = new System.Windows.Forms.Button();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Specialty:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(76, 38);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(119, 20);
            this.tb_name.TabIndex = 6;
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(121, 64);
            this.bn_save.Name = "bn_save";
            this.bn_save.Size = new System.Drawing.Size(75, 23);
            this.bn_save.TabIndex = 4;
            this.bn_save.Text = "Save";
            this.bn_save.UseVisualStyleBackColor = true;
            this.bn_save.Click += new System.EventHandler(this.bn_save_Click);
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
            this.bn_close.Location = new System.Drawing.Point(12, 64);
            this.bn_close.Name = "bn_close";
            this.bn_close.Size = new System.Drawing.Size(75, 23);
            this.bn_close.TabIndex = 4;
            this.bn_close.Text = "Close";
            this.bn_close.UseVisualStyleBackColor = true;
            this.bn_close.Click += new System.EventHandler(this.bn_close_Click);
            // 
            // frmSpecialtiesData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 97);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.bn_close);
            this.Controls.Add(this.bn_save);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpecialtiesData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Specialty data";
            this.Load += new System.EventHandler(this.frmSpecialtiesData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bn_close;
    }
}