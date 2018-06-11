namespace ShabaFashionersLite
{
    partial class BackupAndRestore
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
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblTotalEntries = new System.Windows.Forms.Label();
            this.lblCurrBackpSession = new System.Windows.Forms.Label();
            this.tabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage1);
            this.tabCtrl.Location = new System.Drawing.Point(0, 1);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(343, 170);
            this.tabCtrl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnBackup);
            this.tabPage1.Controls.Add(this.lblTotalEntries);
            this.tabPage1.Controls.Add(this.lblCurrBackpSession);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(335, 144);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BackUp";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(78, 91);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(143, 35);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "BackUp Now";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // lblTotalEntries
            // 
            this.lblTotalEntries.AutoSize = true;
            this.lblTotalEntries.Location = new System.Drawing.Point(8, 46);
            this.lblTotalEntries.Name = "lblTotalEntries";
            this.lblTotalEntries.Size = new System.Drawing.Size(35, 13);
            this.lblTotalEntries.TabIndex = 1;
            this.lblTotalEntries.Text = "label2";
            // 
            // lblCurrBackpSession
            // 
            this.lblCurrBackpSession.AutoSize = true;
            this.lblCurrBackpSession.Location = new System.Drawing.Point(8, 13);
            this.lblCurrBackpSession.Name = "lblCurrBackpSession";
            this.lblCurrBackpSession.Size = new System.Drawing.Size(35, 13);
            this.lblCurrBackpSession.TabIndex = 0;
            this.lblCurrBackpSession.Text = "label1";
            // 
            // BackupAndRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 176);
            this.Controls.Add(this.tabCtrl);
            this.Name = "BackupAndRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackupAndRestore";
            this.Load += new System.EventHandler(this.BackupAndRestore_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblTotalEntries;
        private System.Windows.Forms.Label lblCurrBackpSession;

    }
}