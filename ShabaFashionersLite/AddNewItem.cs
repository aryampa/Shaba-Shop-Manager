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
    public partial class AddNewItem : Form
    {
        Boolean unitInEditMode;
        List<string> DeleteList;
        Dictionary<string, string> DeleteDictionary;

        List<string> UnitIDList;
        Dictionary<string, string> UnitIDDictionary;


       
        public AddNewItem()
        {
            InitializeComponent();

            
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void AddNewItem_Load(object sender, EventArgs e)
        {
            //rbtnAdd.Checked = true;
            //gBxNewItem.Enabled = true;


            //rbtnDelete.Checked = false;
            //gbxDeleteItem.Enabled = false;

            btnNewItem.Enabled = false;

            try
            {
                //ShabaLiteDataSet ds = new ShabaLiteDataSet();
                //DataRow dtr =  ds.Sales.NewRow();
                //ShabaLiteDataSet.SalesRow sr = ds.Sales.NewSalesRow();
                //sr.Item_ID = "000";
                //sr.Sale_ID = "0000";
                //sr.Quantity = "30";
                //sr.Unit_ID = "UNT_HAHA";
                //sr.Total_Price = "5000";

                //ds.Sales.Rows.Add(sr);

                

                //ShabaLiteDataSetTableAdapters.SalesTableAdapter sta = new ShabaLiteDataSetTableAdapters.SalesTableAdapter();
                //sta.Update(ds);
                
                //string ha = ds.Sales.Rows.Count.ToString();



                string prefix = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabItems")["Table Prefix"].ToString();
                string num = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabItems")["Next ID Number"].ToString();
                tbxItmID.Text = prefix + num;
                tbxNewItmDescrip.Text = "";
                tbxNewItmName.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Databse access error " + ex.Message.ToString());
                this.Close();
            }
            
            rbtnAdd.Checked = true;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void rbtnDelete_Click(object sender, EventArgs e)
        {
            rbtnDelete.Checked = true;
            rbtnAdd.Checked = false;
            rbtnEditItem.Checked = false;

            gbxDeleteItem.Enabled = true;
            gbxEditItem.Enabled = false;

            gBxNewItem.Enabled = false;

            List<string> ItemIdList = new List<string> { };
            DeleteDictionary = new Dictionary<string, string> { };

            foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Items"].Rows) { 
                ItemIdList.Add(dtRow["Item ID"].ToString()+" - "+dtRow["Item Name"].ToString());
                DeleteDictionary.Add(dtRow["Item ID"].ToString() + " - " + dtRow["Item Name"].ToString(), dtRow["Item ID"].ToString());
            }

            lstBxItmID.DataSource = ItemIdList;
            DeleteList = ItemIdList;

            btnDelete.Enabled = false;
        }

        private void rbtnAdd_Click(object sender, EventArgs e)
        {
            rbtnAdd.Checked = true;
            rbtnDelete.Checked = false;
            rbtnEditItem.Checked = false;

            gBxNewItem.Enabled = true;

            gbxDeleteItem.Enabled = false;
            gbxEditItem.Enabled = false;
        }

        private void btnCreateNew_Click_1(object sender, EventArgs e)
        {
            OleDbTransaction transactionObj = null;
            try
            {
                if (tbxNewItmName.Text == "") {
                    tbxNewItmName.BackColor = Color.Red;
                    tbxNewItmName.Focus();
                    throw new Exception("Please Provide a Name");
                    
                }

                if (tbxNewItmDescrip.Text=="") {
                    tbxNewItmDescrip.BackColor = Color.Red;
                    tbxNewItmDescrip.Focus();
                    throw new Exception("Please Provide a description for the new Item");
                }

                if (DatabaseConnectionObject.connectionObj_Global.State == ConnectionState.Closed) {
                    DatabaseConnectionObject.connectionObj_Global.Open();

                    DatabaseConnectionObject conObj = new DatabaseConnectionObject();
                    
                    if (!conObj.populate_DataSet())
                    {
                    throw new Exception("Error Populating  Dataset");
                    }
                    
                }

                transactionObj = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

                //DataObjectsInitializer NewItemDataObj = new DataObjectsInitializer("Items", DatabaseConnectionObject.datasetObject_Global, transactionObj);
                //DataObjectsInitializer IDtableObj = new DataObjectsInitializer("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, transactionObj);

                DataTableManager dbNewItems = new DataTableManager("Items", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID);
                DataTableManager dbIDTableNmbers = new DataTableManager("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID);

                String CurrentNextID_Nmber = dbIDTableNmbers.Search("Next ID Number", "TabItems", true, false).ToString();
                Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };
                Dic2Use.Add("Next ID Number", (long.Parse(CurrentNextID_Nmber) + 1).ToString());
                dbIDTableNmbers.EditRow("TabItems", Dic2Use);

                Dic2Use.Clear();

                Dic2Use.Add("Item ID", tbxItmID.Text);
                Dic2Use.Add("Item Name", tbxNewItmName.Text);
                Dic2Use.Add("Description", tbxNewItmDescrip.Text);

                dbNewItems.CreateRow(Dic2Use, tbxItmID.Text);


                
                transactionObj.Commit();

                MessageBox.Show("Item " + tbxNewItmName .Text+ " Successfully Created", "Success");

                btnCreateNew.Enabled = false;
                btnNewItem.Enabled = true;


            }
            catch (Exception ex) {
                if (transactionObj != null) transactionObj.Rollback();
                MessageBox.Show("Error Creating New Item"+ Environment.NewLine+" Message: "+ex.Message.ToString(), "Error");
            }
        }

        private void tbxNewItmName_TextChanged(object sender, EventArgs e)
        {
            tbxNewItmName.BackColor = Color.White;
        }

        private void tbxNewItmDescrip_TextChanged(object sender, EventArgs e)
        {
            tbxNewItmDescrip.BackColor = Color.White;
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            string prefix = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabItems")["Table Prefix"].ToString();
            string num = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabItems")["Next ID Number"].ToString();
            tbxItmID.Text = prefix + num;
            btnNewItem.Enabled = false;
            btnCreateNew.Enabled = true;
            tbxNewItmName.Text = "";
            tbxNewItmDescrip.Text = "";
        }

        private void rbtnEditItem_Click(object sender, EventArgs e)
        {
            gbxEditItem.Enabled = true;
            gbxDeleteItem.Enabled = false;
            gBxNewItem.Enabled = false;

            rbtnAdd.Checked = false;
            rbtnDelete.Checked = false;
            rbtnEditItem.Checked = true;

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

            UnitIdList.Add("< Add New Unit >");

            foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows)
            {
                UnitIdList.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString());
                UnitIDDictionary.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString(), dtRow["Unit ID"].ToString());
            }

            cbxUnitID.DataSource = UnitIdList;
            UnitIDList = UnitIdList;

            btnCreateUnit.Enabled = false;
            cbxUnitID.Enabled = false;


        }

        private void tbxItmIDDel_TextChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            string enteredText = tbxItmIDDel.Text;

            lstBxItmID.DataSource = DeleteList;

            if (tbxItmIDDel.Text == "") lstBxItmID.DataSource = DeleteList;
            else {
                if (lstBxItmID.Items.Count > 0) lstBxItmID.DataSource = null;

                foreach (string idString in DeleteList) { 
                    if(idString.ToLower().Contains(enteredText.ToLower())) lstBxItmID.Items.Add(idString);
                }
            }
        }

        private void lstBxItmID_Click(object sender, EventArgs e)
        {
            if (lstBxItmID.Items.Count == 0) btnDelete.Enabled = false;
            else {

                if (lstBxItmID.SelectedItem.ToString() != "") {
                    btnDelete.Enabled = true;

                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            OleDbTransaction transactionObj = null;

            try
            {
                
                DialogResult result = MessageBox.Show("Are You Sure you Want to Delete " + lstBxItmID.SelectedItem.ToString() + " ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == System.Windows.Forms.DialogResult.No)
                {
                }
                else if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    transactionObj = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

                    DataObjectsInitializer ItemsTableObj = new DataObjectsInitializer("Items", DatabaseConnectionObject.datasetObject_Global, transactionObj);
                    DataObjectsInitializer TableIDTableObj = new DataObjectsInitializer("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, transactionObj);


                    //DataRow Row2Delete = DatabaseConnectionObject.datasetObject_Global.Tables["Items"].Rows.Find(DeleteDictionary[lstBxItmID.SelectedItem.ToString()]);

                    new DataTableManager("Items", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Delete(DeleteDictionary[lstBxItmID.SelectedItem.ToString()]);

                    transactionObj.Commit();

                    MessageBox.Show("Item - " + lstBxItmID.SelectedItem.ToString() + " successfully deleted", "Success");

                    DeleteList.Remove(lstBxItmID.SelectedItem.ToString());

                    tbxItmID.Text = "";

                    btnDelete.Enabled = false;

                    lstBxItmID.DataSource = DeleteList;

                }

            }
            catch (Exception ex) {

                if (transactionObj != null) transactionObj.Rollback();
                MessageBox.Show("Error Deleting Item : " + ex.Message.ToString(), "Error Deleting Item");
            }
        }

        private void rbtnEditItem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxItemID_DropDownClosed(object sender, EventArgs e)
        {
            

            if (cbxItemID.SelectedItem.ToString() == "< Select Item ID >")
            {
                UnitIDList = new List<string> { };
                UnitIDDictionary = new Dictionary<string, string> { };
                UnitIDList.Add("< Add New Unit >");
                cbxUnitID.DataSource = UnitIDList;

                cbxUnitID.SelectedIndex = 0;

                
                cbxUnitID.Enabled = false;

                tbxUnitPrice.Text = "";
                tbxUnitName.Text = "";
                tbxUnitName.Enabled = false;
                tbxUnitPrice.Enabled = false;
                btnCreateUnit.Enabled = false;
                btnEdit.Enabled = false;

              
            }
            else {


                string selectedID = DeleteDictionary[cbxItemID.SelectedItem.ToString()].ToString ();
                cbxUnitID.Enabled = true;
   
                UnitIDList = new List<string> { };
                UnitIDDictionary = new Dictionary<string, string> { };
                
                UnitIDList.Add("< Add New Unit >");
                foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows) {

                    if (dtRow["Item ID"].ToString () == selectedID) {

                        UnitIDList.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString());
                        UnitIDDictionary.Add(dtRow["Unit ID"].ToString() + " - " + dtRow["Unit Name"].ToString(), dtRow["Unit ID"].ToString());
                    }
                }

                cbxUnitID.DataSource = UnitIDList;

                cbxUnitID.Enabled = true;

                //tbxUnitPrice.Text = "";
                //tbxUnitName.Text = "";
                //tbxUnitName.Enabled = true;
                //tbxUnitPrice.Enabled = true;
                //btnCreateUnit.Enabled = false;
                //btnEdit.Enabled = false;
            }
        }

        private void cbxUnitID_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxUnitID.SelectedItem.ToString() == "< Add New Unit >")
            {

                btnEdit.Enabled = false;
                tbxUnitName.Text = "";
                tbxUnitPrice.Text = "";

                tbxUnitName.Enabled = true;
                tbxUnitPrice.Enabled = true;

                btnCreateUnit.Text = "Create Unit";
                btnCreateUnit.Enabled = true;

                unitInEditMode = false;


            }
            else {
                unitInEditMode = true;
                btnCreateUnit.Enabled = true;
                btnCreateUnit.Text = "Save Edit";

                string selectedUnit = DeleteDictionary[cbxItemID.SelectedItem.ToString()];

                DataRow Row2Edit = DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows.Find(UnitIDDictionary[cbxUnitID.SelectedItem.ToString()]);

                if (Row2Edit != null)
                {
                    tbxUnitName.Text = Row2Edit["Unit Name"].ToString();
                    tbxUnitPrice.Text = Row2Edit["Unit Price"].ToString();
                }

                unitInEditMode = true;
                btnEdit.Enabled = true;
                btnCreateUnit.Enabled = false;

                tbxUnitName.Enabled = false;
                tbxUnitPrice.Enabled = false;
                
            }
        }

        private void btnCreateUnit_Click(object sender, EventArgs e)
        {
            OleDbTransaction transactionObj = null;
            try
            {
                if (!unitInEditMode)
                {
                    transactionObj = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

                    if (tbxUnitName.Text == "")
                    {
                        tbxUnitName.BackColor = Color.Red;
                        tbxUnitName.Focus();
                        throw new Exception("Please Provide a Unit Name");

                    }

                    if (tbxUnitPrice.Text == "")
                    {
                        tbxUnitPrice.BackColor = Color.Red;
                        tbxUnitPrice.Focus();
                        throw new Exception("Please Provide a Price for the new Unit");
                    }

                    if (tbxUnitPrice.BackColor == Color.Red) {
                        tbxUnitPrice.Focus();
                        throw new Exception("Only Digits are Accepted in Unit Price. Try Again");
                    }

                    string prefix = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabUnits")["Table Prefix"].ToString();
                    string num = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabUnits")["Next ID Number"].ToString();

                    DataTableManager DTM_Units = new DataTableManager( "Units", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID);

                   // DataObjectsInitializer UnitTableObj = new DataObjectsInitializer("Units", DatabaseConnectionObject.datasetObject_Global, transactionObj);

                    Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };
                    
                    //DataRow NewDTRow = DatabaseConnectionObject.datasetObject_Global.Tables["Units"].NewRow();

                    
                    Dic2Use.Add("Unit ID", prefix + num);
                    Dic2Use.Add("Unit Name", tbxUnitName.Text);
                    Dic2Use.Add("Item ID", DeleteDictionary[cbxItemID.SelectedItem.ToString()]);
                    Dic2Use.Add( "Unit Price",  tbxUnitPrice.Text);

                    DTM_Units.CreateRow(Dic2Use, Dic2Use["Unit ID"].ToString());

                    Dic2Use.Clear();


                    DataTableManager DTM_TABID = new DataTableManager("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID);

                    String CurrentNextID_Nmber = DTM_TABID.Search("Next ID Number", "TabUnits", true, false).ToString();
                 
                    Dic2Use.Add("Next ID Number", (long.Parse(CurrentNextID_Nmber) + 1).ToString());
                    DTM_TABID.EditRow("TabUnits", Dic2Use);


                  
                    transactionObj.Commit();

                    MessageBox.Show("Unit " + tbxUnitName.Text + " Successfully Created!", "Success");

                    btnCreateUnit.Enabled = false;
                    tbxUnitName.Text = "";
                    tbxUnitPrice.Text = "";

                    cbxItemID.SelectedIndex = 0;
                    cbxItemID.DataSource = DeleteList;

                    cbxItemID.SelectedIndex = 0;
                    cbxUnitID.Enabled = false;

                    btnEdit.Enabled = false;

                }
                else {

                    transactionObj = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

                    if (tbxUnitName.Text == "")
                    {
                        tbxUnitName.BackColor = Color.Red;
                        tbxUnitName.Focus();
                        throw new Exception("Please Provide a Unit Name");

                    }

                    if (tbxUnitPrice.Text == "")
                    {
                        tbxUnitPrice.BackColor = Color.Red;
                        tbxUnitPrice.Focus();
                        throw new Exception("Please Provide a Price for the new Unit");
                    }

                    if (tbxUnitPrice.BackColor == Color.Red)
                    {
                        tbxUnitPrice.Focus();
                        throw new Exception("Only Digits are Accepted in Unit Price. Try Again");
                    }

                    //DataObjectsInitializer UnitTableObj = new DataObjectsInitializer("Units", DatabaseConnectionObject.datasetObject_Global, transactionObj);
                    
                    //NewDTRow["Unit ID"] = (long.Parse(DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabUnits")["Next ID Number"].ToString()) + 1).ToString();
                   

                    DataTableManager DTM_UnitsEdit = new DataTableManager("Units", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID);
                    DataRow NewDTRow = DatabaseConnectionObject.datasetObject_Global.Tables["Units"].Rows.Find(UnitIDDictionary[cbxUnitID.SelectedItem.ToString()]);

                    Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };

                    Dic2Use.Add("Unit Name", tbxUnitName.Text);
                    
                    Dic2Use.Add("Unit Price", tbxUnitPrice.Text);

                    DTM_UnitsEdit.EditRow(UnitIDDictionary[cbxUnitID.SelectedItem.ToString()], Dic2Use);

                    
                    transactionObj.Commit();

                    MessageBox.Show("Unit " + tbxUnitName.Text + " Successfully Editted succfully", "Success");

                    //btnCreateUnit.Enabled = false;
                   // tbxUnitName.Text = "";
                   // tbxUnitPrice.Text = "";

                    tbxUnitPrice.Enabled = false;
                    tbxUnitName.Enabled = false;
                    btnCreateUnit.Enabled = false;
                    btnEdit.Enabled = true;
                }
            }

            catch (Exception ex) {
                if (transactionObj != null) {
                    transactionObj.Rollback();
                }
                MessageBox.Show("Error Modifying Units: " + ex.Message.ToString(), "Error Modifying Units");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tbxUnitName.Enabled = true;
            tbxUnitPrice.Enabled = true;
            btnCreateUnit.Enabled = true;
        }

        private bool StringIsAllDigits(string inputString) {

           // Boolean NonDigitFound = false;
            
            foreach (char letter in inputString) {
                if (!char.IsDigit(letter)) {
                   
                    return false;
                }
            }

            return true;
        }

        private void tbxUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (!StringIsAllDigits(tbxUnitPrice.Text))
            {
                tbxUnitPrice.BackColor = Color.Red;
            }
            else {
                tbxUnitPrice.BackColor = Color.White;
            }
        }

        private void cbxUnitID_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void gbxDeleteItem_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
