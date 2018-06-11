using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace ShabaFashionersLite
{
    public partial class RegisterSale : Form
    {
        string UnitPrice = null;
        Boolean unitInEditMode;
        List<string> DeleteList;
        Dictionary<string, string> DeleteDictionary;

        List<string> UnitIDList;
        Dictionary<string, string> UnitIDDictionary;

        public RegisterSale()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        

        private void RegisterSale_Load(object sender, EventArgs e)
        {
            List<string> ItemIdList = new List<string> { };
                DeleteDictionary = new Dictionary<string, string> { };

                ItemIdList.Add("< Select Item ID >");
                foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Items"].Rows)
                {
                    ItemIdList.Add(dtRow["Item ID"].ToString() + " - " + dtRow["Item Name"].ToString());
                    DeleteDictionary.Add(dtRow["Item ID"].ToString() + " - " + dtRow["Item Name"].ToString(), dtRow["Item ID"].ToString());
                }

                cbxItemID.DataSource = ItemIdList;
                DeleteList = ItemIdList;

                List<string> UnitIdList = new List<string> { };
                UnitIDDictionary = new Dictionary<string, string> { };

                UnitIdList.Add("< Select Item Unit >");

                //foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows)
                //{
                //    UnitIdList.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString());
                //    UnitIDDictionary.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString(), dtRow["Unit ID"].ToString());
                //}

                cbxUnitID.DataSource = UnitIdList;
                UnitIDList = UnitIdList;

                btnSave.Enabled = false;
                cbxUnitID.Enabled = false;

                gbxViewSales.Enabled = false;

                ckBxDiscount.Checked = false;
                tbxDiscount.Enabled = false;

                tbxQuantity.Enabled = false;
                tbxQuantity.Text = "000000";

                btnSave.Enabled = false;
                btnNew.Enabled = false;
                

        }

        private void rbtnRegisterSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRegisterSale.Checked) { 
                gbxRegsale.Enabled = true;
                gbxViewSales.Enabled = false;
    
            }
        }

        private void rbtnViewSales_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnViewSales.Checked) {
                gbxViewSales.Enabled = true;
                gbxRegsale.Enabled = false;
            }
        }

        private void cbxItemID_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxItemID.SelectedItem.ToString() == "< Select Item ID >")
            {
                UnitIDList = new List<string> { };
                UnitIDDictionary = new Dictionary<string, string> { };
               UnitIDList.Add("< Select Item Unit >");
                cbxUnitID.DataSource = UnitIDList;

                cbxUnitID.SelectedIndex = 0;


                cbxUnitID.Enabled = false;

                tbxDiscount.Text = "0";
                tbxQuantity.Text = "000000";

                tbxQuantity.Enabled = false;
                tbxDiscount.Enabled = false;
                btnNew.Enabled = false;
                btnSave.Enabled = false;
                lblFinalPrice.Text = "0";


            }
            else
            {


                string selectedID = DeleteDictionary[cbxItemID.SelectedItem.ToString()].ToString();
                cbxUnitID.Enabled = true;

                UnitIDList = new List<string> { };
                UnitIDDictionary = new Dictionary<string, string> { };

               UnitIDList.Add("< Select Item Unit >");
                foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows)
                {

                    if (dtRow["Item ID"].ToString() == selectedID)
                    {

                        UnitIDList.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString()+" (At "+dtRow["Unit Price"].ToString()+" EACH.)");
                        UnitIDDictionary.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString() + " (At " + dtRow["Unit Price"].ToString() + " EACH.)", dtRow["Unit ID"].ToString());
                    }
                }

                cbxUnitID.DataSource = UnitIDList;

                cbxUnitID.Enabled = true;

      
            }
        }

        private void cbxUnitID_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxUnitID.SelectedItem.ToString() == "< Select Item Unit >")
            {

                btnSave.Enabled = false;
                tbxDiscount.Text = "0";
                tbxQuantity.Text = "000000";

                tbxQuantity.Enabled = false;
                tbxDiscount.Enabled = false;

                btnNew.Enabled = false;
           
            }
            else
            {
               
                btnSave.Enabled = true;
                tbxDiscount.Text = "0";
                tbxQuantity.Text = "000000";

                tbxQuantity.Enabled = true;
                tbxDiscount.Enabled = false;


                string selectedUnit = DeleteDictionary[cbxItemID.SelectedItem.ToString()];

                DataRow Row2Edit = DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows.Find(UnitIDDictionary[cbxUnitID.SelectedItem.ToString()]);

                if (Row2Edit != null)
                {
                    UnitPrice = Row2Edit["Unit Price"].ToString();



                }


            }
        }

        private void tbxQuantity_Click(object sender, EventArgs e)
        {
            tbxQuantity.Text = "";
        }

        private bool StringIsAllDigits(string inputString)
        {

            // Boolean NonDigitFound = false;

            foreach (char letter in inputString)
            {
                if (!char.IsDigit(letter))
                {

                    return false;
                }
            }

            return true;
        }

        private void tbxQuantity_TextChanged(object sender, EventArgs e)
        {

            if (tbxQuantity.Text != "")
            {
                if (StringIsAllDigits(tbxQuantity.Text))
                {
                    lblFinalPrice.Text = addComma( (long.Parse(UnitPrice) * long.Parse(tbxQuantity.Text)).ToString());
                    tbxQuantity.BackColor = Color.White;
                }
                else
                {
                    tbxQuantity.BackColor = Color.Red;
                    lblFinalPrice.Text = "Error!!";
                }
            }
            else lblFinalPrice.Text = "0";

        }

        private string addComma(string inputString) {

            int totalStringLength = inputString.Length;
            int count = 0;
            string FinalString = "";
            string TempString = "";
            string string2Return = "";

            for (int i = totalStringLength - 1; i >= 0; i--) {
                count++;

                if (count == 3)
                {
                    TempString = TempString + inputString[i].ToString();
                    FinalString = FinalString + TempString + ",";
                    count = 0;
                    TempString = "";
                }
                else { 
                    TempString = TempString+  inputString[i].ToString();
                }
            }

            if (count != 0) FinalString = FinalString + TempString;

            for (int i2 = FinalString.Length - 1; i2 >= 0; i2--)
            {
                string2Return = string2Return + FinalString[i2].ToString();
            }

            return string2Return.TrimStart(new char[]{','});
            
        }

        private string removeUnwantedCharacters(string inputString, char[] unwantedChars) {
            string string2Return = "";

            inputString = inputString.Trim();
           

            foreach (char letter in inputString) {
                if (!unwantedChars.Contains(letter)) string2Return = string2Return + letter.ToString();
            }

            return string2Return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OleDbTransaction transObj = null;
            string DiscountInput;
            try
            {
                
                if (tbxQuantity.Text == "000000")
                {
                    tbxQuantity.BackColor = Color.Red;
                    tbxQuantity.Focus();
                    throw new Exception("Please Enter Item Quantity");

                }

                if (tbxQuantity.BackColor == Color.Red) {
                    tbxQuantity.Focus();
                    throw new Exception("Only Digits are allowed for Quantity. Try again");
                }

                if (ckBxDiscount.Checked)
                {

                    if (tbxDiscount.Text == "")
                    {
                        tbxDiscount.BackColor = Color.Red;
                        throw new Exception("Please provide a discount and try again");
                    }

                    if (tbxDiscount.BackColor == Color.Red)
                    {
                        tbxDiscount.BackColor = Color.Red;
                        tbxDiscount.Focus();
                        throw new Exception("Only Digits are allowed for Discount ");
                    }

                    if ((long.Parse(removeUnwantedCharacters(lblFinalPrice.Text, new char[] { ',' })) - long.Parse(tbxDiscount.Text)) < 0)
                    {
                        throw new Exception("Dicount [" + tbxDiscount.Text + " ] cannot be greated that the Final Price [" + lblFinalPrice.Text + "] . Please check your Discount Input and try again");
                    }

                    DiscountInput = tbxDiscount.Text;
                }
                else {
                    DiscountInput = "0";
                }


                transObj = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

               

                string prefix = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabSales")["Table Prefix"].ToString();
                string num = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabSales")["Next ID Number"].ToString();
                string SelectedUnit = UnitIDDictionary[cbxUnitID.SelectedItem.ToString()];
                string unitPrice = DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows.Find(SelectedUnit)["Unit Price"].ToString();
                string finalPrice = removeUnwantedCharacters(lblFinalPrice.Text, new char[] {','});

                Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };

                DataRow NewRow_sales = DatabaseConnectionObject.datasetObject_Global.Tables["Sales"].NewRow();
                Dic2Use.Add( "Sale ID" ,prefix + num);
                Dic2Use.Add( "User ID" ,GlobalVariables.currentuserID);
                Dic2Use.Add( "Item ID",  DeleteDictionary [cbxItemID.SelectedItem.ToString()]);
                Dic2Use.Add( "Date",new DateTimeUtility().ToEpochFormat(DateTime.Now.ToLocalTime()));
                Dic2Use.Add( "Unit ID/Unit Price",SelectedUnit + "/" + unitPrice);
                Dic2Use.Add( "Quantity",tbxQuantity.Text);
                Dic2Use.Add( "Discount",tbxDiscount.Text);
                Dic2Use.Add( "Total Price",(long.Parse(finalPrice) - long.Parse(tbxDiscount.Text)).ToString());

                new DataTableManager("Sales", DatabaseConnectionObject.datasetObject_Global, transObj, GlobalVariables.CurrentSessionID).CreateRow(Dic2Use, Dic2Use["Sale ID"].ToString());

              
                String NextIDNmber = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabSales")["Next ID Number"].ToString();
                NextIDNmber = (long.Parse(NextIDNmber) + 1).ToString();

        
                Dic2Use.Clear();
                Dic2Use.Add("Next ID Number", NextIDNmber);

                new DataTableManager("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, transObj, GlobalVariables.CurrentSessionID).EditRow("TabSales", Dic2Use);


                transObj.Commit();

                MessageBox.Show("Sale Successfully Saved", "Success");

                List<string> ItemIdList = new List<string> { };
                DeleteDictionary = new Dictionary<string, string> { };

                ItemIdList.Add("< Select Item ID >");
                foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Items"].Rows)
                {
                    ItemIdList.Add(dtRow["Item ID"].ToString() + " - " + dtRow["Item Name"].ToString());
                    DeleteDictionary.Add(dtRow["Item ID"].ToString() + " - " + dtRow["Item Name"].ToString(), dtRow["Item ID"].ToString());
                }

                cbxItemID.DataSource = ItemIdList;
                DeleteList = ItemIdList;

                List<string> UnitIdList = new List<string> { };
                UnitIDDictionary = new Dictionary<string, string> { };

                UnitIdList.Add("< Select Item Unit >");

                //foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows)
                //{
                //    UnitIdList.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString());
                //    UnitIDDictionary.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString(), dtRow["Unit ID"].ToString());
                //}

                cbxUnitID.DataSource = UnitIdList;
                UnitIDList = UnitIdList;

                btnSave.Enabled = false;
                cbxUnitID.Enabled = false;

                gbxViewSales.Enabled = false;

                ckBxDiscount.Checked = false;
                tbxDiscount.Enabled = false;

                tbxQuantity.Enabled = false;
                tbxQuantity.Text = "000000";

                btnSave.Enabled = false;
                btnNew.Enabled = false;

                
            }
            catch (Exception ex) {
                if (transObj != null) transObj.Rollback();
                MessageBox.Show("Error Saving Sale. " + ex.Message.ToString(), "Error Occured");
            }
        }

        private void ckBxDiscount_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckBxDiscount.Checked) tbxDiscount.Enabled = true;
            else tbxDiscount.Enabled = false;
        }

        private void tbxDiscount_Click(object sender, EventArgs e)
        {
            tbxDiscount.Text = "";
        }

        private void tbxDiscount_TextChanged(object sender, EventArgs e)
        {
            if (tbxDiscount.Text != "")
            {
                if (StringIsAllDigits(tbxDiscount.Text))
                {
                    //lblFinalPrice.Text = addComma((long.Parse(UnitPrice) * long.Parse(tbxQuantity.Text)).ToString());
                    tbxDiscount.BackColor = Color.White;
                }
                else
                {
                    tbxDiscount.BackColor = Color.Red;
                    //lblFinalPrice.Text = "Error!!";
                }
            }
            //else lblFinalPrice.Text = "0";

        }

        private void rbtnViewSales_Click(object sender, EventArgs e)
        {
            List<string> ItemIdList = new List<string> { };
            DeleteDictionary = new Dictionary<string, string> { };

            ItemIdList.Add("< Select Item ID >");
            ItemIdList.Add("All Items");
            foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Items"].Rows)
            {
                ItemIdList.Add(dtRow["Item ID"].ToString() + " - " + dtRow["Item Name"].ToString());
                DeleteDictionary.Add(dtRow["Item ID"].ToString() + " - " + dtRow["Item Name"].ToString(), dtRow["Item ID"].ToString());
            }

            cbxItemIDView.DataSource = ItemIdList;
            DeleteList = ItemIdList;
            btnSearch.Enabled = false;
            btnPrint.Enabled = false;
        }

        private Boolean checkForGreater(DateTime inputDate, DateTime targetDate){
            Boolean ok = false;

            if (inputDate.Year > targetDate.Year) return true;
            if (inputDate.Year == targetDate.Year) ok = true;

            if (ok && inputDate.Month > targetDate.Month) return true;
            if (ok && inputDate.Month == targetDate.Month) ok = true;
            else ok = false;

            if (ok && inputDate.Day >= targetDate.Day) ok = true;
            else ok = false;

            return ok;
        }

        private Boolean checkForLess(DateTime inputDate, DateTime targetDate) {

            Boolean ok = false;

            if (inputDate.Year < targetDate.Year) return true;
            if (inputDate.Year == targetDate.Year) ok = true;

            if (ok && inputDate.Month < targetDate.Month) return true;
            if (ok && inputDate.Month == targetDate.Month) ok = true;
            else ok = false;

            if (ok && inputDate.Day <= targetDate.Day) ok = true;
            else ok = false;

            return ok;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkForGreater(dtPickerTo.Value, dtPickerFrom.Value)) throw new Exception("FROM Date [" + dtPickerFrom.Value.Date.ToString() + "] Should Not Be greater than [TO] Date [" + dtPickerTo.Value.Date.ToString() + "]");

                DataTable dtTable = new System.Data.DataTable();

                foreach (DataColumn dtCol in DatabaseConnectionObject.datasetObject_Global.Tables["Sales"].Columns) { 
                    dtTable.Columns.Add(dtCol.ColumnName);
                }
                long totalCash = 0;
                if (cbxItemIDView.SelectedItem.ToString() == "All Items")
                {
                    foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Sales"].Rows)
                    {

                            if (checkForGreater((DateTime)dtRow["Date"], dtPickerFrom.Value) && checkForLess((DateTime)dtRow["Date"], dtPickerTo.Value))
                            {
                                DataRow dtTableRow = dtTable.NewRow();

                                foreach (DataColumn dtcoll in DatabaseConnectionObject.datasetObject_Global.Tables["Sales"].Columns)
                                {
                                    dtTableRow[dtcoll.ColumnName] = dtRow[dtcoll.ColumnName];
                                }

                                dtTable.Rows.Add(dtTableRow);
                                totalCash = totalCash + long.Parse(dtRow["Total Price"].ToString());

                            }

                        
                    }
                }
                else {

                    foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Sales"].Rows)
                    {

                        if (dtRow["Item ID"].ToString() == DeleteDictionary[cbxItemIDView.SelectedItem.ToString()])
                        {
                            if (checkForGreater((DateTime)dtRow["Date"], dtPickerFrom.Value) && checkForLess((DateTime)dtRow["Date"], dtPickerTo.Value))
                            {
                                DataRow dtTableRow = dtTable.NewRow();

                                foreach (DataColumn dtcoll in DatabaseConnectionObject.datasetObject_Global.Tables["Sales"].Columns)
                                {
                                    dtTableRow[dtcoll.ColumnName] = dtRow[dtcoll.ColumnName];
                                }

                                dtTable.Rows.Add(dtTableRow);
                                totalCash = totalCash + long.Parse(dtRow["Total Price"].ToString());

                            }
                        }
                    }
                }

                lblTotalCash.Text = "Total Cash: " + addComma(totalCash.ToString());
                lblSelectedItem.Text ="Selected Item: " +cbxItemIDView.SelectedItem.ToString();
                lblPeriod.Text = "Period: From "+dtPickerFrom.Value.ToString("dd-MM,yyy")+" TO "+dtPickerTo.Value.ToString("dd MMM,yyy");

                dbGrid.DataSource = dtTable;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Search Error");
            }
        }

        private void gbxViewSales_Enter(object sender, EventArgs e)
        {

        }

        private void cbxItemIDView_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxItemIDView.SelectedItem.ToString() == "< Select Item ID >")
            {
                btnPrint.Enabled = false;
                btnSearch.Enabled = false;

                lblPeriod.Text = "";
                lblSelectedItem.Text = "";
                lblTotalCash.Text = "";

            }
            else {
                btnSearch.Enabled = true;
                btnPrint.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            printDialog.ShowDialog();

            
        }

        
    }
}
