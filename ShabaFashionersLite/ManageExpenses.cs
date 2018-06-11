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
    public partial class ManageExpenses : Form
    {
        public ManageExpenses()
        {
            InitializeComponent();
        }

        private void ManageExpenses_Load(object sender, EventArgs e)
        {
            try{
            
                DataObjectsInitializer.checkDatabaseConnection();
                DataRow IDRow = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabExp");
                lblExpID.Text = IDRow["Table Prefix"].ToString() + IDRow["Next ID Number"].ToString();

                cbxCategory.SelectedIndex = 0;
                tbxAmount.Text = "0";
                tbxAmount.BackColor = Color.Black;
                tbxDescription.Text = "";
                btnSaveExp.Enabled = false;

                



            }
            catch (Exception ex)
            {
                MessageBox.Show("Reason: " + ex.Message.ToString(), "Error Initalising Expense Module");
                this.Close();
            }
        }

        private void cbxCategory_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxCategory.SelectedItem.ToString() == "<Select Category>")
            {
                DataObjectsInitializer.checkDatabaseConnection();
                DataRow IDRow = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNmbers"].Rows.Find("TabExp");
                lblExpID.Text = IDRow["Table Prefix"].ToString() + IDRow["Next ID Number"].ToString();

                //cbxCategory.SelectedIndex = 0;
                tbxAmount.Text = "0";
                tbxAmount.BackColor = Color.Black;
                tbxDescription.Text = "";
                btnSaveExp.Enabled = false;
                tbxDescription.Enabled = false;
                tbxAmount.Enabled = false;
            }
            else {

                DataObjectsInitializer.checkDatabaseConnection();
                DataRow IDRow = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabExp");
                lblExpID.Text = IDRow["Table Prefix"].ToString() + IDRow["Next ID Number"].ToString();

                //cbxCategory.SelectedIndex = 0;
                tbxAmount.Text = "0";
                tbxAmount.BackColor = Color.Black;
                tbxDescription.Text = "";
                btnSaveExp.Enabled = false;
                tbxDescription.Enabled = true;
                tbxAmount.Enabled = true;

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

        private void tbxAmount_TextChanged(object sender, EventArgs e)
        {
            if (tbxAmount.Text != "")
            {
                if (StringIsAllDigits(tbxAmount.Text))
                {
                    if (long.Parse(tbxAmount.Text) > 0) btnSaveExp.Enabled = true;
                    else btnSaveExp.Enabled = false;

                    tbxAmount.BackColor = Color.Black;
                }
                else
                {
                    tbxAmount.BackColor = Color.Red;
                    
                }
            }
            
        }

        private void tbxAmount_Leave(object sender, EventArgs e)
        {
            if (tbxAmount.Text == "") tbxAmount.Text = "0";
        }

        private void btnSaveExp_Click(object sender, EventArgs e)
        {
            OleDbTransaction oledbTrans = null;
            try
            {
                oledbTrans = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

                Dictionary<String, Object> Dic2Use = new Dictionary<string, object> { };
                Dic2Use.Add("ExpenseID", lblExpID.Text);
                Dic2Use.Add("UserID", GlobalVariables.CurrentSessionID);
                Dic2Use.Add("Date", dtPickerExpense.Value.ToLocalTime().ToString());
                Dic2Use.Add("Expense Category", cbxCategory.SelectedItem.ToString());
                Dic2Use.Add("Description", tbxDescription.Text);
                Dic2Use.Add("Amount", tbxAmount.Text);

                new DataTableManager("Expenses", DatabaseConnectionObject.datasetObject_Global, oledbTrans, GlobalVariables.CurrentSessionID).CreateRow(Dic2Use,Dic2Use["ExpenseID"].ToString());

                Dic2Use.Clear();

                String NextIDNmber = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabExp")["Next ID Number"].ToString();
                NextIDNmber = (long.Parse(NextIDNmber) + 1).ToString();


                Dic2Use.Clear();
                Dic2Use.Add("Next ID Number", NextIDNmber);

                new DataTableManager("TableIDNumbers", DatabaseConnectionObject.datasetObject_Global, oledbTrans, GlobalVariables.CurrentSessionID).EditRow("TabExp", Dic2Use);


                oledbTrans.Commit();

                MessageBox.Show(lblExpID.Text + " Expense Sucessfully saved", "Sucess");

                DataObjectsInitializer.checkDatabaseConnection();
                DataRow IDRow = DatabaseConnectionObject.datasetObject_Global.Tables["TableIDNumbers"].Rows.Find("TabExp");
                lblExpID.Text = IDRow["Table Prefix"].ToString() + IDRow["Next ID Number"].ToString();

                cbxCategory.SelectedIndex = 0;
                tbxAmount.Text = "0";
                tbxDescription.Text = "";
                btnSaveExp.Enabled = false;



                

            }
            catch(Exception ex) {

                if (oledbTrans != null) oledbTrans.Rollback();

                MessageBox.Show("Reason: " + ex.Message.ToString(), "Error Saving Expenses");
            }
        }
    }
}
