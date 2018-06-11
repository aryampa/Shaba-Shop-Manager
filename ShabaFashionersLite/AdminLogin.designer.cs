namespace ShabaFashionersLite
{
    partial class AdminLogin
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
            this.gBoxAdminLog = new System.Windows.Forms.GroupBox();
            this.lnkChangeAdmin = new System.Windows.Forms.LinkLabel();
            this.btnAdminOk = new System.Windows.Forms.Button();
            this.tbxAdminPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxAdminLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxAdminLog
            // 
            this.gBoxAdminLog.Controls.Add(this.lnkChangeAdmin);
            this.gBoxAdminLog.Controls.Add(this.btnAdminOk);
            this.gBoxAdminLog.Controls.Add(this.tbxAdminPassword);
            this.gBoxAdminLog.Controls.Add(this.label1);
            this.gBoxAdminLog.Location = new System.Drawing.Point(12, 12);
            this.gBoxAdminLog.Name = "gBoxAdminLog";
            this.gBoxAdminLog.Size = new System.Drawing.Size(243, 72);
            this.gBoxAdminLog.TabIndex = 1;
            this.gBoxAdminLog.TabStop = false;
            this.gBoxAdminLog.Text = "Admin Login";
            // 
            // lnkChangeAdmin
            // 
            this.lnkChangeAdmin.AutoSize = true;
            this.lnkChangeAdmin.Location = new System.Drawing.Point(10, 53);
            this.lnkChangeAdmin.Name = "lnkChangeAdmin";
            this.lnkChangeAdmin.Size = new System.Drawing.Size(120, 13);
            this.lnkChangeAdmin.TabIndex = 4;
            this.lnkChangeAdmin.TabStop = true;
            this.lnkChangeAdmin.Text = "Change Admin Pasword";
            // 
            // btnAdminOk
            // 
            this.btnAdminOk.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdminOk.Location = new System.Drawing.Point(135, 46);
            this.btnAdminOk.Name = "btnAdminOk";
            this.btnAdminOk.Size = new System.Drawing.Size(101, 23);
            this.btnAdminOk.TabIndex = 3;
            this.btnAdminOk.Text = "Ok";
            this.btnAdminOk.UseVisualStyleBackColor = false;
            this.btnAdminOk.Click += new System.EventHandler(this.btnAdminOk_Click);
            // 
            // tbxAdminPassword
            // 
            this.tbxAdminPassword.Location = new System.Drawing.Point(92, 20);
            this.tbxAdminPassword.Name = "tbxAdminPassword";
            this.tbxAdminPassword.Size = new System.Drawing.Size(144, 20);
            this.tbxAdminPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Password:";
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(284, 95);
            this.Controls.Add(this.gBoxAdminLog);
            this.MaximizeBox = false;
            this.Name = "AdminLogin";
            this.Text = "AdminLogin";
            this.Load += new System.EventHandler(this.AdminLogin_Load);
            this.gBoxAdminLog.ResumeLayout(false);
            this.gBoxAdminLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxAdminLog;
        private System.Windows.Forms.LinkLabel lnkChangeAdmin;
        private System.Windows.Forms.Button btnAdminOk;
        private System.Windows.Forms.TextBox tbxAdminPassword;
        private System.Windows.Forms.Label label1;
    }
}