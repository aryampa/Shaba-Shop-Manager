using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShabaFashionersLite
{
    public partial class Purchases1 : Form
    {

        List<string> DeleteList;
        Dictionary<string, string> DeleteDictionary;

        List<string> UnitIDList;
        Dictionary<string, string> UnitIDDictionary;

        public Purchases1()
        {
            InitializeComponent();

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


            tbxQuantity.Enabled = false;


            tbxSupplierName.Enabled = false;
            tbxSuppliersContact.Enabled = false;
            tbxUnitPrice.Enabled = false;
            tbxUnitPrice.Text = "0";

            tbxQuantity.Enabled = false;
            tbxQuantity.Text = "0";

            btnClear.Enabled = false;
            btnSave.Enabled = false;
            lblFinalPrice.Text = "0";

            btnSave.Enabled = false;

        }

        private void Purchases1_Load(object sender, EventArgs e)
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


            tbxQuantity.Enabled = false;
            tbxQuantity.Text = "000000";

            tbxSupplierName.Enabled = false;
            tbxUnitPrice.Enabled = false;
            tbxUnitPrice.Text = "0";

            tbxQuantity.Enabled = false;
            tbxQuantity.Text = "0";

            btnClear.Enabled = false;
            btnSave.Enabled = false;
            lblFinalPrice.Text = "0";

            btnSave.Enabled = false;

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

                btnSave.Enabled = false;
                cbxUnitID.Enabled = false;


                tbxQuantity.Enabled = false;


                tbxSupplierName.Enabled = false;
                tbxSuppliersContact.Enabled = false;
                tbxUnitPrice.Enabled = false;
                tbxUnitPrice.Text = "0";

                tbxQuantity.Enabled = false;
                tbxQuantity.Text = "0";

                btnClear.Enabled = false;
                btnSave.Enabled = false;
                lblFinalPrice.Text = "0";

                btnSave.Enabled = false;


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

                        UnitIDList.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString());
                        UnitIDDictionary.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString(), dtRow["Unit ID"].ToString());
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



                tbxQuantity.Enabled = false;


                tbxSupplierName.Enabled = false;
                tbxSuppliersContact.Enabled = false;
                tbxUnitPrice.Enabled = false;
                tbxUnitPrice.Text = "0";

                tbxQuantity.Enabled = false;
                tbxQuantity.Text = "0";

                btnClear.Enabled = false;
                btnSave.Enabled = false;
                lblFinalPrice.Text = "0";

                btnSave.Enabled = false;

            }
            else
            {

                //btnSave.Enabled = true;


                tbxQuantity.Enabled = false;


                tbxSupplierName.Enabled = true;
                tbxSuppliersContact.Enabled = true;
                tbxUnitPrice.Enabled = true;
                tbxUnitPrice.Text = "0";

                tbxQuantity.Enabled = false;
                tbxQuantity.Text = "0";

                btnClear.Enabled = true;
               // btnSave.Enabled = true;
                lblFinalPrice.Text = "0";


                string selectedUnit = DeleteDictionary[cbxItemID.SelectedItem.ToString()];

            }
        }

        private void tbxUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbxUnitPrice.Text != "")
            {
                if (StringIsAllDigits(tbxUnitPrice.Text))
                {
                    //lblFinalPrice.Text = addComma((long.Parse(UnitPrice) * long.Parse(tbxQuantity.Text)).ToString());
                    tbxUnitPrice.BackColor = Color.White;
                    tbxQuantity.Enabled = true;
                }
                else
                {
                    tbxUnitPrice.BackColor = Color.Red;
                    tbxQuantity.Enabled = false;
                    //lblFinalPrice.Text = "Error!!";
                }
            }
            else //lblFinalPrice.Text = "0";
                tbxQuantity.Enabled = false;

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

        private string addComma(string inputString)
        {

            int totalStringLength = inputString.Length;
            int count = 0;
            string FinalString = "";
            string TempString = "";
            string string2Return = "";

            for (int i = totalStringLength - 1; i >= 0; i--)
            {
                count++;

                if (count == 3)
                {
                    TempString = TempString + inputString[i].ToString();
                    FinalString = FinalString + TempString + ",";
                    count = 0;
                    TempString = "";
                }
                else
                {
                    TempString = TempString + inputString[i].ToString();
                }
            }

            if (count != 0) FinalString = FinalString + TempString;

            for (int i2 = FinalString.Length - 1; i2 >= 0; i2--)
            {
                string2Return = string2Return + FinalString[i2].ToString();
            }

            return string2Return.TrimStart(new char[] { ',' });

        }

        private void tbxQuantity_Click(object sender, EventArgs e)
        {
            if (!tbxQuantity.Enabled)
            {
                MessageBox.Show("Please Set the Unit Price First and Try again", "Unit Price Not Set");
            }
        }

        private void tbxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (tbxQuantity.Text != "")
            {
                if (StringIsAllDigits(tbxQuantity.Text))
                {
                    lblFinalPrice.Text = addComma((long.Parse(tbxUnitPrice.Text) * long.Parse(tbxQuantity.Text)).ToString());
                    tbxQuantity.BackColor = Color.White;
                    //tbxQuantity.Enabled = true;
                }
                else
                {
                    tbxQuantity.BackColor = Color.Red;
                    //tbxQuantity.Enabled = false;
                    //lblFinalPrice.Text = "Error!!";
                }
            }
            else lblFinalPrice.Text = "0";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OleDbTransaction transObj = null;
            string DiscountInput;
            try
            {

                if (tbxQuantity.Text == "0")
                {
                    tbxQuantity.BackColor = Color.Red;
                    tbxQuantity.Focus();
                    throw new Exception("Please Enter Item Quantity");

                }

                if (tbxQuantity.BackColor == Color.Red)
                {
                    tbxQuantity.Focus();
                    throw new Exception("Only Digits are allowed for Quantity. Try again");
                }

                if (tbxUnitPrice.Text == "0")
                {
                    tbxUnitPrice.BackColor = Color.Red;
                    tbxUnitPrice.Focus();
                    throw new Exception("Please Set Unit Price");

                }




                transObj = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

               // DataObjectsInitializer PurchaseTableDataObj = new DataObjectsInitializer("Purchases", DatabaseConnectionObject.datasetObject_Global, transObj);

                string prefix = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabPurchases")["Table Prefix"].ToString();
                string num = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabPurchases")["Next ID Number"].ToString();
                string SelectedUnit = UnitIDDictionary[cbxUnitID.SelectedItem.ToString()];
                //string unitPrice = DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows.Find(SelectedUnit)["Unit Price"].ToString();

                Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };

                string finalPrice = removeUnwantedCharacters(lblFinalPrice.Text, new char[] { ',' });
                //DataRow NewRow_sales = DatabaseConnectionObject.datasetObject_Global.Tables["Purchases"].NewRow();
                
                Dic2Use.Add ("PurchaseID",prefix + num);
                Dic2Use.Add ("Supplier Contact",tbxSuppliersContact.Text);
                Dic2Use.Add ("Item ID", DeleteDictionary[cbxItemID.SelectedItem.ToString()]);
                Dic2Use.Add ("Date", new DateTimeUtility().ToEpochFormat(DateTime.Now.ToLocalTime()));
                Dic2Use.Add ("Unit ID/ Unit Price",cbxUnitID.SelectedItem.ToString() + "/" + tbxUnitPrice.Text);
                Dic2Use.Add ("Quantity",tbxQuantity.Text);
                Dic2Use.Add ("Supplier Name",tbxSupplierName.Text);
                Dic2Use.Add ("Cost",finalPrice);

                new DataTableManager("Purchases", DatabaseConnectionObject.datasetObject_Global, transObj, GlobalVariables.CurrentSessionID).CreateRow(Dic2Use, Dic2Use["PurchaseID"].ToString());



                String NextIDNmber = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabPurchases")["Next ID Number"].ToString();
                NextIDNmber = (long.Parse(NextIDNmber) + 1).ToString();


                Dic2Use.Clear();
                Dic2Use.Add("Next ID Number", NextIDNmber);

                new DataTableManager("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, transObj, GlobalVariables.CurrentSessionID).EditRow("TabPurchases", Dic2Use);




                transObj.Commit();

                MessageBox.Show("Purchase Successfully Saved", "Success");

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

                

                cbxUnitID.DataSource = UnitIdList;
                UnitIDList = UnitIdList;

                btnSave.Enabled = false;
                cbxUnitID.Enabled = false;


                tbxQuantity.Enabled = false;


                tbxSupplierName.Enabled = false;
                tbxSuppliersContact.Enabled = false;
                tbxUnitPrice.Enabled = false;
                tbxUnitPrice.Text = "0";

                tbxQuantity.Enabled = false;
                tbxQuantity.Text = "0";

                btnClear.Enabled = false;
                btnSave.Enabled = false;
                lblFinalPrice.Text = "0";

                btnSave.Enabled = false;


            }
            catch (Exception ex)
            {
                if (transObj != null) transObj.Rollback();
                MessageBox.Show("Error Saving Sale. " + ex.Message.ToString(), "Error Occured");
            }

        }




        private void lblFinalPrice_TextChanged(object sender, EventArgs e)
        {
            if (lblFinalPrice.Text == "0")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private string removeUnwantedCharacters(string inputString, char[] unwantedChars)
        {
            string string2Return = "";

            inputString = inputString.Trim();


            foreach (char letter in inputString)
            {
                if (!unwantedChars.Contains(letter)) string2Return = string2Return + letter.ToString();
            }

            return string2Return;
        }

        private void btnClear_Click(object sender, EventArgs e)
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



            cbxUnitID.DataSource = UnitIdList;
            UnitIDList = UnitIdList;

            btnSave.Enabled = false;
            cbxUnitID.Enabled = false;


            tbxQuantity.Enabled = false;


            tbxSupplierName.Enabled = false;
            tbxSuppliersContact.Enabled = false;
            tbxUnitPrice.Enabled = false;
            tbxUnitPrice.Text = "0";

            tbxQuantity.Enabled = false;
            tbxQuantity.Text = "0";

            btnClear.Enabled = false;
            btnSave.Enabled = false;
            lblFinalPrice.Text = "0";

            btnSave.Enabled = false;
        }
    }

}
