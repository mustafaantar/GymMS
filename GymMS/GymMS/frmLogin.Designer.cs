namespace GymMS
{
    partial class frmLogin
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
            this.bn_login = new System.Windows.Forms.Button();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bn_login
            // 
            this.bn_login.Location = new System.Drawing.Point(201, 12);
            this.bn_login.Name = "bn_login";
            this.bn_login.Size = new System.Drawing.Size(75, 23);
            this.bn_login.TabIndex = 0;
            this.bn_login.Text = "Login";
            this.bn_login.UseVisualStyleBackColor = true;
            this.bn_login.Click += new System.EventHandler(this.bn_login_Click);
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(76, 12);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(119, 20);
            this.tb_username.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(76, 44);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(119, 20);
            this.tb_password.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // bn_exit
            // 
            this.bn_exit.Location = new System.Drawing.Point(201, 41);
            this.bn_exit.Name = "bn_exit";
            this.bn_exit.Size = new System.Drawing.Size(75, 23);
            this.bn_exit.TabIndex = 0;
            this.bn_exit.Text = "Exit";
            this.bn_exit.UseVisualStyleBackColor = true;
            this.bn_exit.Click += new System.EventHandler(this.bn_exit_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 73);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.bn_exit);
            this.Controls.Add(this.bn_login);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bn_login;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bn_exit;
    }
}