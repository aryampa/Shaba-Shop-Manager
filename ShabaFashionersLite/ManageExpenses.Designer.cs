namespace ShabaFashionersLite
{
    partial class ManageExpenses
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
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExpID = new System.Windows.Forms.Label();
            this.dtPickerExpense = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveExp = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Items.AddRange(new object[] {
            "<Select Category>",
            "Food",
            "Transport",
            "Medical",
            "Business Administration",
            "Miscelleneous"});
            this.cbxCategory.Location = new System.Drawing.Point(105, 97);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(227, 21);
            this.cbxCategory.TabIndex = 0;
            this.cbxCategory.DropDownClosed += new System.EventHandler(this.cbxCategory_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(105, 144);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(227, 106);
            this.tbxDescription.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Expense ID:";
            // 
            // lblExpID
            // 
            this.lblExpID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpID.Location = new System.Drawing.Point(91, 9);
            this.lblExpID.Name = "lblExpID";
            this.lblExpID.Size = new System.Drawing.Size(238, 23);
            this.lblExpID.TabIndex = 4;
            this.lblExpID.Text = "EXP_01";
            // 
            // dtPickerExpense
            // 
            this.dtPickerExpense.Location = new System.Drawing.Point(94, 47);
            this.dtPickerExpense.Name = "dtPickerExpense";
            this.dtPickerExpense.Size = new System.Drawing.Size(238, 20);
            this.dtPickerExpense.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Category:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Description:";
            // 
            // btnSaveExp
            // 
            this.btnSaveExp.Location = new System.Drawing.Point(224, 340);
            this.btnSaveExp.Name = "btnSaveExp";
            this.btnSaveExp.Size = new System.Drawing.Size(108, 41);
            this.btnSaveExp.TabIndex = 8;
            this.btnSaveExp.Text = "Save && New";
            this.btnSaveExp.UseVisualStyleBackColor = true;
            this.btnSaveExp.Click += new System.EventHandler(this.btnSaveExp_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(105, 358);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // tbxAmount
            // 
            this.tbxAmount.BackColor = System.Drawing.Color.Black;
            this.tbxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxAmount.ForeColor = System.Drawing.Color.White;
            this.tbxAmount.Location = new System.Drawing.Point(105, 273);
            this.tbxAmount.Multiline = true;
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(224, 42);
            this.tbxAmount.TabIndex = 10;
            this.tbxAmount.Text = "0";
            this.tbxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxAmount.TextChanged += new System.EventHandler(this.tbxAmount_TextChanged);
            this.tbxAmount.Leave += new System.EventHandler(this.tbxAmount_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Amount:";
            // 
            // ManageExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 393);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveExp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtPickerExpense);
            this.Controls.Add(this.lblExpID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ManageExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expenses";
            this.Load += new System.EventHandler(this.ManageExpenses_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExpID;
        private System.Windows.Forms.DateTimePicker dtPickerExpense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveExp;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbxAmount;
        private System.Windows.Forms.Label label3;
    }
}