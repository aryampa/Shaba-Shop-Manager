namespace ShabaFashionersLite
{
    partial class Search
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
            this.cbxColmns = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dbGridResults = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDetails = new System.Windows.Forms.TextBox();
            this.labe = new System.Windows.Forms.Label();
            this.tbxSearchText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTab = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridResults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Column To Look In:";
            // 
            // cbxColmns
            // 
            this.cbxColmns.FormattingEnabled = true;
            this.cbxColmns.Location = new System.Drawing.Point(13, 79);
            this.cbxColmns.Name = "cbxColmns";
            this.cbxColmns.Size = new System.Drawing.Size(208, 21);
            this.cbxColmns.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(530, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 38);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dbGridResults
            // 
            this.dbGridResults.AllowUserToAddRows = false;
            this.dbGridResults.AllowUserToDeleteRows = false;
            this.dbGridResults.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dbGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridResults.Location = new System.Drawing.Point(13, 124);
            this.dbGridResults.Name = "dbGridResults";
            this.dbGridResults.ReadOnly = true;
            this.dbGridResults.Size = new System.Drawing.Size(642, 183);
            this.dbGridResults.TabIndex = 3;
            this.dbGridResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbGridResults_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(293, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search Results:";
            // 
            // tbxDetails
            // 
            this.tbxDetails.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbxDetails.ForeColor = System.Drawing.Color.White;
            this.tbxDetails.Location = new System.Drawing.Point(13, 336);
            this.tbxDetails.Multiline = true;
            this.tbxDetails.Name = "tbxDetails";
            this.tbxDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDetails.Size = new System.Drawing.Size(642, 119);
            this.tbxDetails.TabIndex = 5;
            // 
            // labe
            // 
            this.labe.AutoSize = true;
            this.labe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labe.Location = new System.Drawing.Point(16, 316);
            this.labe.Name = "labe";
            this.labe.Size = new System.Drawing.Size(132, 13);
            this.labe.TabIndex = 6;
            this.labe.Text = "Selected Item Details:";
            // 
            // tbxSearchText
            // 
            this.tbxSearchText.Location = new System.Drawing.Point(270, 74);
            this.tbxSearchText.Name = "tbxSearchText";
            this.tbxSearchText.Size = new System.Drawing.Size(225, 20);
            this.tbxSearchText.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Search Text:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Select a Table:";
            // 
            // cbxTab
            // 
            this.cbxTab.FormattingEnabled = true;
            this.cbxTab.Items.AddRange(new object[] {
            "Sales",
            "Purchases",
            "Debtors",
            "DebtDetails",
            "Expenses"});
            this.cbxTab.Location = new System.Drawing.Point(138, 5);
            this.cbxTab.Name = "cbxTab";
            this.cbxTab.Size = new System.Drawing.Size(386, 21);
            this.cbxTab.TabIndex = 10;
            this.cbxTab.DropDownClosed += new System.EventHandler(this.cbxTab_DropDownClosed);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(660, 467);
            this.Controls.Add(this.cbxTab);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxSearchText);
            this.Controls.Add(this.labe);
            this.Controls.Add(this.tbxDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dbGridResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbxColmns);
            this.Controls.Add(this.label1);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxColmns;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dbGridResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDetails;
        private System.Windows.Forms.Label labe;
        private System.Windows.Forms.TextBox tbxSearchText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTab;

    }
}