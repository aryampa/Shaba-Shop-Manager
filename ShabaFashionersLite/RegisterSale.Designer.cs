namespace ShabaFashionersLite
{
    partial class RegisterSale
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbxViewSales = new System.Windows.Forms.GroupBox();
            this.lblTotalCash = new System.Windows.Forms.Label();
            this.lblSelectedItem = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dbGrid = new System.Windows.Forms.DataGridView();
            this.dtPickerTo = new System.Windows.Forms.DateTimePicker();
            this.dtPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.cbxItemIDView = new System.Windows.Forms.ComboBox();
            this.rbtnRegisterSale = new System.Windows.Forms.RadioButton();
            this.gbxRegsale = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.tbxDiscount = new System.Windows.Forms.TextBox();
            this.ckBxDiscount = new System.Windows.Forms.CheckBox();
            this.tbxQuantity = new System.Windows.Forms.TextBox();
            this.cbxUnitID = new System.Windows.Forms.ComboBox();
            this.cbxItemID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnViewSales = new System.Windows.Forms.RadioButton();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.groupBox1.SuspendLayout();
            this.gbxViewSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            this.gbxRegsale.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbxViewSales);
            this.groupBox1.Controls.Add(this.rbtnRegisterSale);
            this.groupBox1.Controls.Add(this.gbxRegsale);
            this.groupBox1.Controls.Add(this.rbtnViewSales);
            this.groupBox1.Location = new System.Drawing.Point(13, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 596);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // gbxViewSales
            // 
            this.gbxViewSales.Controls.Add(this.lblTotalCash);
            this.gbxViewSales.Controls.Add(this.lblSelectedItem);
            this.gbxViewSales.Controls.Add(this.lblPeriod);
            this.gbxViewSales.Controls.Add(this.btnSearch);
            this.gbxViewSales.Controls.Add(this.btnPrint);
            this.gbxViewSales.Controls.Add(this.label);
            this.gbxViewSales.Controls.Add(this.label5);
            this.gbxViewSales.Controls.Add(this.label4);
            this.gbxViewSales.Controls.Add(this.dbGrid);
            this.gbxViewSales.Controls.Add(this.dtPickerTo);
            this.gbxViewSales.Controls.Add(this.dtPickerFrom);
            this.gbxViewSales.Controls.Add(this.cbxItemIDView);
            this.gbxViewSales.Location = new System.Drawing.Point(7, 289);
            this.gbxViewSales.Name = "gbxViewSales";
            this.gbxViewSales.Size = new System.Drawing.Size(571, 299);
            this.gbxViewSales.TabIndex = 4;
            this.gbxViewSales.TabStop = false;
            this.gbxViewSales.Enter += new System.EventHandler(this.gbxViewSales_Enter);
            // 
            // lblTotalCash
            // 
            this.lblTotalCash.AutoSize = true;
            this.lblTotalCash.Location = new System.Drawing.Point(10, 279);
            this.lblTotalCash.Name = "lblTotalCash";
            this.lblTotalCash.Size = new System.Drawing.Size(61, 13);
            this.lblTotalCash.TabIndex = 12;
            this.lblTotalCash.Text = "Total Cash:";
            // 
            // lblSelectedItem
            // 
            this.lblSelectedItem.AutoSize = true;
            this.lblSelectedItem.Location = new System.Drawing.Point(10, 259);
            this.lblSelectedItem.Name = "lblSelectedItem";
            this.lblSelectedItem.Size = new System.Drawing.Size(75, 13);
            this.lblSelectedItem.TabIndex = 11;
            this.lblSelectedItem.Text = "Selected Item:";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(10, 237);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(40, 13);
            this.lblPeriod.TabIndex = 10;
            this.lblPeriod.Text = "Period:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSearch.Location = new System.Drawing.Point(339, 261);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 31);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnPrint.Location = new System.Drawing.Point(461, 258);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 31);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(6, 13);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(51, 17);
            this.label.TabIndex = 6;
            this.label.Text = "Item ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(294, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(294, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "From:";
            // 
            // dbGrid
            // 
            this.dbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid.Location = new System.Drawing.Point(6, 73);
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.Size = new System.Drawing.Size(555, 161);
            this.dbGrid.TabIndex = 3;
            // 
            // dtPickerTo
            // 
            this.dtPickerTo.Location = new System.Drawing.Point(357, 46);
            this.dtPickerTo.Name = "dtPickerTo";
            this.dtPickerTo.Size = new System.Drawing.Size(200, 20);
            this.dtPickerTo.TabIndex = 2;
            // 
            // dtPickerFrom
            // 
            this.dtPickerFrom.Location = new System.Drawing.Point(353, 15);
            this.dtPickerFrom.Name = "dtPickerFrom";
            this.dtPickerFrom.Size = new System.Drawing.Size(200, 20);
            this.dtPickerFrom.TabIndex = 1;
            // 
            // cbxItemIDView
            // 
            this.cbxItemIDView.FormattingEnabled = true;
            this.cbxItemIDView.Location = new System.Drawing.Point(6, 32);
            this.cbxItemIDView.Name = "cbxItemIDView";
            this.cbxItemIDView.Size = new System.Drawing.Size(205, 21);
            this.cbxItemIDView.TabIndex = 0;
            this.cbxItemIDView.DropDownClosed += new System.EventHandler(this.cbxItemIDView_DropDownClosed);
            // 
            // rbtnRegisterSale
            // 
            this.rbtnRegisterSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbtnRegisterSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnRegisterSale.Location = new System.Drawing.Point(7, 10);
            this.rbtnRegisterSale.Name = "rbtnRegisterSale";
            this.rbtnRegisterSale.Size = new System.Drawing.Size(571, 29);
            this.rbtnRegisterSale.TabIndex = 1;
            this.rbtnRegisterSale.TabStop = true;
            this.rbtnRegisterSale.Text = "Register Sale";
            this.rbtnRegisterSale.UseVisualStyleBackColor = false;
            this.rbtnRegisterSale.CheckedChanged += new System.EventHandler(this.rbtnRegisterSale_CheckedChanged);
            // 
            // gbxRegsale
            // 
            this.gbxRegsale.Controls.Add(this.label7);
            this.gbxRegsale.Controls.Add(this.btnSave);
            this.gbxRegsale.Controls.Add(this.btnNew);
            this.gbxRegsale.Controls.Add(this.lblFinalPrice);
            this.gbxRegsale.Controls.Add(this.tbxDiscount);
            this.gbxRegsale.Controls.Add(this.ckBxDiscount);
            this.gbxRegsale.Controls.Add(this.tbxQuantity);
            this.gbxRegsale.Controls.Add(this.cbxUnitID);
            this.gbxRegsale.Controls.Add(this.cbxItemID);
            this.gbxRegsale.Controls.Add(this.label3);
            this.gbxRegsale.Controls.Add(this.label2);
            this.gbxRegsale.Controls.Add(this.label1);
            this.gbxRegsale.Location = new System.Drawing.Point(7, 45);
            this.gbxRegsale.Name = "gbxRegsale";
            this.gbxRegsale.Size = new System.Drawing.Size(571, 207);
            this.gbxRegsale.TabIndex = 3;
            this.gbxRegsale.TabStop = false;
            this.gbxRegsale.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(339, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Final Price";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnSave.Location = new System.Drawing.Point(434, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save and New";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnNew.Location = new System.Drawing.Point(339, 170);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "Clear";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFinalPrice.Font = new System.Drawing.Font("Castellar", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalPrice.ForeColor = System.Drawing.Color.Red;
            this.lblFinalPrice.Location = new System.Drawing.Point(339, 84);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(222, 62);
            this.lblFinalPrice.TabIndex = 8;
            this.lblFinalPrice.Text = "label4";
            this.lblFinalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxDiscount
            // 
            this.tbxDiscount.Enabled = false;
            this.tbxDiscount.Location = new System.Drawing.Point(339, 28);
            this.tbxDiscount.Name = "tbxDiscount";
            this.tbxDiscount.Size = new System.Drawing.Size(222, 20);
            this.tbxDiscount.TabIndex = 7;
            this.tbxDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxDiscount.Click += new System.EventHandler(this.tbxDiscount_Click);
            this.tbxDiscount.TextChanged += new System.EventHandler(this.tbxDiscount_TextChanged);
            // 
            // ckBxDiscount
            // 
            this.ckBxDiscount.AutoSize = true;
            this.ckBxDiscount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ckBxDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckBxDiscount.Location = new System.Drawing.Point(339, 10);
            this.ckBxDiscount.Name = "ckBxDiscount";
            this.ckBxDiscount.Size = new System.Drawing.Size(77, 19);
            this.ckBxDiscount.TabIndex = 6;
            this.ckBxDiscount.Text = "Discount:";
            this.ckBxDiscount.UseVisualStyleBackColor = false;
            this.ckBxDiscount.CheckStateChanged += new System.EventHandler(this.ckBxDiscount_CheckStateChanged);
            // 
            // tbxQuantity
            // 
            this.tbxQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.tbxQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxQuantity.ForeColor = System.Drawing.Color.Blue;
            this.tbxQuantity.Location = new System.Drawing.Point(11, 151);
            this.tbxQuantity.MaxLength = 5;
            this.tbxQuantity.Multiline = true;
            this.tbxQuantity.Name = "tbxQuantity";
            this.tbxQuantity.Size = new System.Drawing.Size(280, 47);
            this.tbxQuantity.TabIndex = 5;
            this.tbxQuantity.Text = "000000";
            this.tbxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxQuantity.Click += new System.EventHandler(this.tbxQuantity_Click);
            this.tbxQuantity.TextChanged += new System.EventHandler(this.tbxQuantity_TextChanged);
            // 
            // cbxUnitID
            // 
            this.cbxUnitID.FormattingEnabled = true;
            this.cbxUnitID.Location = new System.Drawing.Point(10, 84);
            this.cbxUnitID.Name = "cbxUnitID";
            this.cbxUnitID.Size = new System.Drawing.Size(280, 21);
            this.cbxUnitID.TabIndex = 4;
            this.cbxUnitID.DropDownClosed += new System.EventHandler(this.cbxUnitID_DropDownClosed);
            // 
            // cbxItemID
            // 
            this.cbxItemID.FormattingEnabled = true;
            this.cbxItemID.Location = new System.Drawing.Point(10, 28);
            this.cbxItemID.Name = "cbxItemID";
            this.cbxItemID.Size = new System.Drawing.Size(280, 21);
            this.cbxItemID.TabIndex = 3;
            this.cbxItemID.DropDownClosed += new System.EventHandler(this.cbxItemID_DropDownClosed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unit ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item ID:";
            // 
            // rbtnViewSales
            // 
            this.rbtnViewSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.rbtnViewSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnViewSales.Location = new System.Drawing.Point(7, 259);
            this.rbtnViewSales.Name = "rbtnViewSales";
            this.rbtnViewSales.Size = new System.Drawing.Size(571, 34);
            this.rbtnViewSales.TabIndex = 2;
            this.rbtnViewSales.TabStop = true;
            this.rbtnViewSales.Text = "View Sales";
            this.rbtnViewSales.UseVisualStyleBackColor = false;
            this.rbtnViewSales.CheckedChanged += new System.EventHandler(this.rbtnViewSales_CheckedChanged);
            this.rbtnViewSales.Click += new System.EventHandler(this.rbtnViewSales_Click);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDoc;
            this.printDialog.UseEXDialog = true;
            // 
            // RegisterSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 602);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegisterSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterSale";
            this.Load += new System.EventHandler(this.RegisterSale_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbxViewSales.ResumeLayout(false);
            this.gbxViewSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            this.gbxRegsale.ResumeLayout(false);
            this.gbxRegsale.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnViewSales;
        private System.Windows.Forms.RadioButton rbtnRegisterSale;
        private System.Windows.Forms.GroupBox gbxRegsale;
        private System.Windows.Forms.TextBox tbxQuantity;
        private System.Windows.Forms.ComboBox cbxUnitID;
        private System.Windows.Forms.ComboBox cbxItemID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.TextBox tbxDiscount;
        private System.Windows.Forms.CheckBox ckBxDiscount;
        private System.Windows.Forms.GroupBox gbxViewSales;
        private System.Windows.Forms.DataGridView dbGrid;
        private System.Windows.Forms.DateTimePicker dtPickerTo;
        private System.Windows.Forms.DateTimePicker dtPickerFrom;
        private System.Windows.Forms.ComboBox cbxItemIDView;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalCash;
        private System.Windows.Forms.Label lblSelectedItem;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDoc;
    }
}