using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ShabaFashionersLite
{
    public partial class ManageDebtors : Form
    {
        List<string> CustomerList;
        Dictionary<string, string> CustomerDic;

        Boolean IsEditMode;

        Boolean IsAddOperation = false;
        public ManageDebtors()
        {
            InitializeComponent();
        }

        

      

        private void ManageDebtors_Load(object sender, EventArgs e)
        {
            rbtnEditDetails.Checked = true;
            gbxEditDebtDetails.Enabled = true;
            gbxUpdateDebt.Enabled = false;

            rbtnAddDebtor.Checked = true;
            gbxAddDebtors.Enabled = true;
            gbxEditDebtors.Enabled = false;
            
            

        }

        private void rbtnEditDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEditDetails.Checked)
            {
                gbxEditDebtDetails.Enabled = true;
                gbxUpdateDebt.Enabled = false;
            }
           
        }

        private void rbtnUpadateDebt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUpadateDebt.Checked) {
                gbxUpdateDebt.Enabled = true;
                gbxEditDebtDetails.Enabled = false;


                CustomerList = new List<string> { };
                CustomerDic = new Dictionary<string, string> { };

                CustomerList.Add("< Select Customer ID >");
                foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Debtors"].Rows)
                {
                    CustomerList.Add(dtRow["Debtor ID"].ToString() + " - " + dtRow["Name"].ToString());
                    CustomerDic.Add(dtRow["Debtor ID"].ToString() + " - " + dtRow["Name"].ToString(), dtRow["Debtor ID"].ToString());
                }

                cbxCustIDUpdate.DataSource = CustomerList;
                cbxCustIDUpdate.SelectedIndex = 0;

                btnSaveUpadate.Enabled = false;
                tbxAmount.Enabled = false;
                tbxAmount.Text = "0";

                lblAmountAfter.Text = "0";
                lblAmountBefore.Text = "0";

                tbxNotes.Text = "";

                ckbxPayment.Checked = false;
                

            }
        }

        private void rbtnAddDebtor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAddDebtor.Checked) {
                gbxAddDebtors.Enabled = true;
                gbxEditDebtors.Enabled = false;

                tbxCustNameadd.Text = "";
                tbxContNumadd.Text = "";
            }
        }

        private void rbtnEditDebtors_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEditDebtors.Checked) {
                gbxEditDebtors.Enabled = true;
                gbxAddDebtors.Enabled = false;

                CustomerList = new List<string> { };
                CustomerDic = new Dictionary<string, string> { };

                CustomerList.Add("< Select Customer ID >");
                foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Debtors"].Rows)
                {
                    CustomerList.Add(dtRow["Debtor ID"].ToString() + " - " + dtRow["Name"].ToString());
                    CustomerDic.Add(dtRow["Debtor ID"].ToString() + " - " + dtRow["Name"].ToString(), dtRow["Debtor ID"].ToString());
                }

                cbxCustID.DataSource = CustomerList;
                cbxCustID.SelectedIndex = 0;

                cbxAction.Items.Clear();
                cbxAction.Items.Add("< Select Action >");
                cbxAction.Items.Add("Edit Customer");
                cbxAction.Items.Add("Delete Customer");

                cbxAction.SelectedIndex = 0;

                tbxCustNameEdit.Enabled = false;
                tbxContEdit.Enabled = false;
                btnSaveEdit.Text = "Go!";
                btnSaveEdit.Enabled = false;

            }
        }

        private void btnSaveadd_Click(object sender, EventArgs e)
        {
            OleDbTransaction transactionObj=null;
            try
            {
                
                if (tbxCustNameadd .Text == "")
                {
                    tbxCustNameadd.BackColor = Color.Red;
                    tbxCustNameadd.Focus();
                    throw new Exception("Please Enter Customer Name");

                }

                if (tbxContNumadd.Text=="") {
                    tbxCustNameadd.BackColor = Color.Red;
                    tbxContNumadd.Focus();
                    throw new Exception("Please Provide a Customer Contact");
                }

                transactionObj = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

              //  DataObjectsInitializer DebtorsTableDataObj = new DataObjectsInitializer("Debtors", DatabaseConnectionObject.datasetObject_Global, transactionObj);

                string prefix = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabDebtors")["Table Prefix"].ToString();
                string num = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabDebtors")["Next ID Number"].ToString();

                Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };

                DataRow NewRow_Debtor = DatabaseConnectionObject.datasetObject_Global.Tables["Debtors"].NewRow();
                Dic2Use.Add("Debtor ID",prefix + num);
                Dic2Use.Add("Date Created",dtPickerAdd.Value);
                Dic2Use.Add("Name", tbxCustNameadd.Text);
                Dic2Use.Add("Contact",tbxContNumadd.Text);
                Dic2Use.Add("Debt Total", "0");

                new DataTableManager("Debtors", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).CreateRow(Dic2Use, Dic2Use["Debtor ID"].ToString());
                

                String NextIDNmber = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabDebtors")["Next ID Number"].ToString();
                NextIDNmber = (long.Parse(NextIDNmber) + 1).ToString();


                Dic2Use.Clear();
                Dic2Use.Add("Next ID Number", NextIDNmber);

                new DataTableManager("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).EditRow("TabDebtors", Dic2Use);

                transactionObj.Commit();
              

                MessageBox.Show("Customer Successfully Saved", "Success");

                tbxContNumadd.Text = "";
                tbxCustNameadd.Text = "";

            }
            catch (Exception ex) {
                if (transactionObj != null) transactionObj.Rollback();
                MessageBox.Show(ex.Message.ToString(),"Error Adding Customer");
            }
        }

        private void btnClearadd_Click(object sender, EventArgs e)
        {
            tbxContNumadd.Text = "";
            tbxCustNameadd.Text = "";
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            OleDbTransaction transObject = null; ;
            try
            {
                if (IsEditMode) {

                    transObject = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

                    if (tbxCustNameEdit.Text=="")
                    {
                        tbxCustNameEdit.BackColor = Color.Red;
                        tbxCustNameEdit.Focus();
                        throw new Exception("Please Enter Customer Name");

                    }

                    if (tbxContEdit.Text=="")
                    {
                        tbxContEdit.BackColor = Color.Red;
                        tbxContEdit.Focus();
                        throw new Exception("Please Provide a Customer Contact");
                    }

                    
                    Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };


                    Dic2Use.Add("Name",tbxCustNameEdit.Text);
                    
                    Dic2Use.Add("Contact",tbxContEdit.Text);

                    new DataTableManager("Debtors", DatabaseConnectionObject.datasetObject_Global, transObject, GlobalVariables.CurrentSessionID).EditRow(CustomerDic[cbxCustID.SelectedItem.ToString()], Dic2Use);

                   
                    transObject.Commit();

                    MessageBox.Show("Customer " + cbxCustID.SelectedItem.ToString() + " Editted Successsfully", "Success");

                    tbxContEdit.Enabled = false;
                    btnSaveEdit.Enabled = false;
                    btnSaveEdit.Text = "Go!";
                    tbxCustNameEdit.Enabled = false;
                }
                

            }
            catch (Exception ex)
            {
                if (transObject != null) transObject.Rollback();
                MessageBox.Show(ex.Message.ToString(), "Error Saving Edit");
            }
        }

        private void cbxCustID_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxCustID.SelectedItem.ToString() == "< Select Customer ID >")
            {
                cbxAction.Enabled = false;
                cbxAction.SelectedIndex = 0;
                tbxContEdit.Text = "";
                tbxCustNameEdit.Text = "";

                tbxCustNameEdit.Enabled = false;
                tbxCustNameEdit.Enabled = false;

                btnSaveEdit.Enabled = false;
                btnSaveEdit.Text = "Go!";
                btnSaveEdit.Enabled = false;
            }
            else {
                DataRow dtRowCust = DatabaseConnectionObject.datasetObject_Global.Tables["Debtors"].Rows.Find(CustomerDic[cbxCustID.SelectedItem.ToString()]);

                if (dtRowCust != null)
                {
                    btnSaveEdit.Text = "Go!";
                    btnSaveEdit.Enabled = false;
                    tbxCustNameEdit.Text = dtRowCust["Name"].ToString();
                    tbxContEdit.Text = dtRowCust["Contact"].ToString();
                    cbxAction.Enabled = true;
                    cbxAction.SelectedIndex = 0;
                }
                else {
                    MessageBox.Show("Customer With ID: " + cbxCustID.SelectedItem.ToString() + " was not found", "Customer Not Found");
                }
            }
        }

        private void cbxAction_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxAction.SelectedItem.ToString() == "Select Action")
            {

                //cbxAction.Enabled = false;
                //tbxContEdit.Text = "";
                // tbxCustNameEdit.Text = "";

                tbxCustNameEdit.Enabled = false;
                tbxCustNameEdit.Enabled = false;
                tbxContEdit.Enabled = false;

                btnSaveEdit.Enabled = false;

                btnSaveEdit.Text = "Go!";
            }
            else {

                if (cbxAction.SelectedItem.ToString() == "Edit Customer") {

                    btnSaveEdit.Text = "Save Edit";
                    btnSaveEdit.Enabled = true;
                    tbxContEdit.Enabled = true;
                    tbxCustNameEdit.Enabled = true;
                    IsEditMode = true;
                }

                //else if (cbxAction.SelectedItem.ToString() == "Delete Customer")
                //{

                //    // not implemented for security reasons

                //}
                else {
                    tbxCustNameEdit.Enabled = false;
                    tbxContEdit.Enabled = false;

                    btnSaveEdit.Enabled = false;

                    btnSaveEdit.Text = "Go!";
                }


            }
        }

        private void gbxUpdateDebt_Enter(object sender, EventArgs e)
        {

        }

        private void cbxCustIDUpdate_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxCustIDUpdate.SelectedItem.ToString() == "< Select Customer ID >")
            {

                btnSaveUpadate.Enabled = false;
                tbxAmount.Enabled = false;
                tbxAmount.Text = "0";

                lblAmountAfter.Text = "0";
                lblAmountBefore.Text = "0";

                tbxNotes.Text = "";

                ckbxPayment.Checked = false;
            }
            else {
                long balanceBefore = long.Parse(DatabaseConnectionObject.datasetObject_Global.Tables["Debtors"].Rows.Find(CustomerDic[cbxCustIDUpdate.SelectedItem.ToString()])["Debt Total"].ToString());
                

                btnSaveUpadate.Enabled = true;
                tbxAmount.Enabled = true;
                tbxAmount.Text = "0";

                lblAmountAfter.Text = "0";
                lblAmountBefore.Text =addComma( balanceBefore.ToString());
                lblAmountAfter.Text = lblAmountBefore.Text;

                tbxNotes.Text = "";

                ckbxPayment.Checked = false;
            }
        }

        private void ckbxPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxPayment.Checked)
            {
                if (tbxAmount.Text != "")
                {
                    if (StringIsAllDigits(tbxAmount.Text))
                    {
                        lblAmountAfter.Text = addComma((long.Parse(removeUnwantedCharacters( lblAmountBefore.Text, new char[]{','})) - long.Parse(tbxAmount.Text)).ToString());
                        tbxAmount.BackColor = Color.Black;
                    }
                    else
                    {
                        tbxAmount.BackColor = Color.Red;
                        lblAmountAfter.Text = lblAmountBefore.Text;
                    }
                }
                else lblAmountAfter.Text = lblAmountBefore.Text;

            }
            else
            {

                if (tbxAmount.Text != "")
                {
                    if (StringIsAllDigits(tbxAmount.Text))
                    {
                        lblAmountAfter.Text = addComma((long.Parse(removeUnwantedCharacters( lblAmountBefore.Text, new char[]{','})) + long.Parse(tbxAmount.Text)).ToString());
                        tbxAmount.BackColor = Color.Black;
                    }
                    else
                    {
                        tbxAmount.BackColor = Color.Red;
                        lblAmountAfter.Text = lblAmountBefore.Text;
                    }
                }
                else lblAmountAfter.Text = lblAmountBefore.Text;

            }
        }

        private void tbxAmount_TextChanged(object sender, EventArgs e)
        {

            if (ckbxPayment.Checked)
            {
                if (tbxAmount.Text != "")
                {
                    if (StringIsAllDigits(tbxAmount.Text))
                    {
                        lblAmountAfter.Text = addComma((long.Parse(removeUnwantedCharacters( lblAmountBefore.Text, new char[]{','})) - long.Parse(tbxAmount.Text)).ToString());
                        tbxAmount.BackColor = Color.Black;
                    }
                    else
                    {
                        tbxAmount.BackColor = Color.Red;
                        lblAmountAfter.Text = lblAmountBefore.Text;
                    }
                }
                else lblAmountAfter.Text = lblAmountBefore.Text;

            }
            else {

                if (tbxAmount.Text != "")
                {
                    if (StringIsAllDigits(tbxAmount.Text))
                    {
                        lblAmountAfter.Text = addComma((long.Parse(removeUnwantedCharacters( lblAmountBefore.Text, new char[]{','})) + long.Parse(tbxAmount.Text)).ToString());
                        tbxAmount.BackColor = Color.Black;
                    }
                    else
                    {
                        tbxAmount.BackColor = Color.Red;
                        lblAmountAfter.Text = lblAmountBefore.Text;
                    }
                }
                else lblAmountAfter.Text = lblAmountBefore.Text;

            }

            
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

        private void lblAmountAfter_TextChanged(object sender, EventArgs e)
        {
            if (long.Parse(removeUnwantedCharacters(lblAmountAfter.Text, new char[] { ',' })) < 0)
            {
                lblAmountAfter.BackColor = Color.Red;
            }
            else {
                lblAmountAfter.BackColor = Color.DarkGoldenrod;
            }
        }

        private void btnSaveUpadate_Click(object sender, EventArgs e)
        {
            OleDbTransaction oledbTrasction = null;

            try
            {
                if (tbxAmount.BackColor == Color.Red) {

                    throw new Exception("The amount you have entered has some INVALID characters. Check Input and Try Again");
                    tbxAmount.Focus();
                }

                if (lblAmountAfter.BackColor == Color.Red) {

                    throw new Exception("The Debtor cannot Pay more than he/She OWES. Please check you input and try again");
                    tbxAmount.Focus();

                }

                oledbTrasction = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();
                String Notes = "";

                if (tbxNotes.Text != "") Notes = tbxNotes.Text;

                String CustomerID = CustomerDic[cbxCustIDUpdate.SelectedItem.ToString()].ToString();
                Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };

                DataRow DebtorDetailsRow = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabDebtDetails");

                Dic2Use.Add("Entry ID", DebtorDetailsRow["Table Prefix"].ToString() + DebtorDetailsRow["Next ID Number"].ToString());
                Dic2Use.Add("Debtor ID", CustomerID);
                Dic2Use.Add("Date", dtPickerUpdate.Value.ToLocalTime().ToString());
                Dic2Use.Add("Is Debt Payment", ckbxPayment.Checked.ToString());
                Dic2Use.Add("Amount", tbxAmount.Text);
                Dic2Use.Add("Description", Notes);
                Dic2Use.Add("Debt Total Before", removeUnwantedCharacters(lblAmountBefore.Text, new char[] { ',' }));
                Dic2Use.Add("Debt Total After", removeUnwantedCharacters(lblAmountAfter.Text, new char[] { ','}));


                new DataTableManager("DebtDetails", DatabaseConnectionObject.datasetObject_Global, oledbTrasction, GlobalVariables.CurrentSessionID).CreateRow(Dic2Use, Dic2Use["Entry ID"].ToString());

                String NextIDNmber = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabDebtDetails")["Next ID Number"].ToString();
                NextIDNmber = (long.Parse(NextIDNmber) + 1).ToString();


                Dic2Use.Clear();
                Dic2Use.Add("Next ID Number", NextIDNmber);

                new DataTableManager("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, oledbTrasction, GlobalVariables.CurrentSessionID).EditRow("TabDebtDetails", Dic2Use);

                Dic2Use.Clear();

                Dic2Use.Add("Debt Total", removeUnwantedCharacters(lblAmountAfter.Text, new char[] { ',' }));

                new DataTableManager("Debtors", DatabaseConnectionObject.datasetObject_Global, oledbTrasction, GlobalVariables.CurrentSessionID).EditRow(CustomerID, Dic2Use);

                oledbTrasction.Commit();

                MessageBox.Show("Debtor: " + CustomerID + " Information as been Updated Sucessfully!", "SUcess!!");





            }
            catch (Exception ex) {
                if (oledbTrasction != null) oledbTrasction.Rollback();

                MessageBox.Show("Error Saving Updating Debtor Information."+Environment.NewLine+"Reason:"+ex.Message.ToString(), "Debtor Update not Saved");
            }//OleDbCommand 
        }
    }
}
