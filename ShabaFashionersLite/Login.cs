using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using ChreneLib.Controls.TextBoxes;
using System.Data;
using System.Data.OleDb;

namespace ShabaFashionersLite
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();


        }

        private void Login_Load(object sender, EventArgs e)
        {

            String DatabasePath = Path.GetDirectoryName( Application.ExecutablePath )+ "\\ShabaLite.mdb";
            OleDbTransaction transactionObj=null;
       
            try
            {

                DatabaseConnectionObject.connectionObj_Global = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=aryampa;Data Source=" + DatabasePath);
                DatabaseConnectionObject.datasetObject_Global = new DataSet();

                DatabaseConnectionObject.connectionObj_Global.Open();

                DatabaseConnectionObject databaseConnObj = new DatabaseConnectionObject();

                Boolean populationResults = databaseConnObj.populate_DataSet();

                if (populationResults) {

                    transactionObj = DatabaseConnectionObject.connectionObj_Global.BeginTransaction();

                    //DataObjectsInitializer SettingsDataObj = new DataObjectsInitializer("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj,"");
                    GlobalVariables.CurrentSessionID = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "CurrentSessionID", true, false).ToString();
                    GlobalVariables.FirstBackupPerformed = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "FirstBackupPerformed", true, false).ToString();
                    GlobalVariables.LastBackupDate = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "LastBackupDate", true, false).ToString();
                    GlobalVariables.LastBackupID = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "LastBackupID", true, false).ToString();
                    GlobalVariables.LastBackupSuccess = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "LastBackupSuccess", true, false).ToString();

                    if (GlobalVariables.FirstBackupPerformed == "NO") {
                       DialogResult backupNowQestion =  MessageBox.Show("Initial Backup of Data has never been performed. Click YES to Perform the Backp Now or NO to Exit the application", "Backup Not Done", MessageBoxButtons.YesNo);

                       if (backupNowQestion == DialogResult.Yes)// Perform Inital Backup
                       {
                           DateTime CurrentDate = DateTime.Now;
                           
                          DataTableManager DTM_Settings     = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, "");

                          DataTableManager DTM_SessionData = new DataTableManager("SessionData", DatabaseConnectionObject.datasetObject_Global, transactionObj, "");

                          Dictionary<String, Object> dicSessionData = new Dictionary<string, object> { };
                          dicSessionData.Add("Session ID",new DateTimeUtility().ToEpochFormat(CurrentDate) );
                          dicSessionData.Add("Date Created", new DateTimeUtility().ToEpochFormat(CurrentDate));
                          dicSessionData.Add("Date Backedup", new DateTimeUtility().ToEpochFormat(CurrentDate));

                          DTM_SessionData.CreateRow(dicSessionData, dicSessionData["Session ID"].ToString());

                          Dictionary<String, Object> EditDic = new Dictionary<string, object> { };
                           EditDic.Add("Setting Value", "YES");

                           DTM_Settings.EditRow("FirstBackupPerformed", EditDic);

                           EditDic.Clear();
                           
                           EditDic.Add("Setting Value",new DateTimeUtility().ToEpochFormat(CurrentDate));

                           DTM_Settings.EditRow("LastBackupDate", EditDic);

                           EditDic.Clear();

                           EditDic.Add("Setting Value", new DateTimeUtility().ToEpochFormat(CurrentDate));

                           DTM_Settings.EditRow("CurrentSessionID", EditDic);

                           EditDic.Clear();

                           EditDic.Add("Setting Value", new DateTimeUtility().ToEpochFormat(CurrentDate));

                           DTM_Settings.EditRow("LastBackupID", EditDic);

                           EditDic.Clear();

                           EditDic.Add("Setting Value", "YES");

                           DTM_Settings.EditRow("LastBackupSuccess", EditDic);

                           transactionObj.Commit();



                         MessageBox.Show("Success! Intial Backup Performed", "Sucess!");

                         GlobalVariables.CurrentSessionID = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "CurrentSessionID", true, false).ToString();
                         GlobalVariables.FirstBackupPerformed = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "FirstBackupPerformed", true, false).ToString();
                         GlobalVariables.LastBackupDate = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "LastBackupDate", true, false).ToString();
                         GlobalVariables.LastBackupID = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "LastBackupID", true, false).ToString();
                         GlobalVariables.LastBackupSuccess = new DataTableManager("Settings", DatabaseConnectionObject.datasetObject_Global, transactionObj, GlobalVariables.CurrentSessionID).Search("Setting Value", "LastBackupSuccess", true, false).ToString();


                       }
                       else {
                           throw new Exception("Application Will Exit Because Intial Backup Was not Performed.");
                       }
                    }
                   
                    
                    

                    
                  //  MessageBox.Show("Success!!!!!"); 
                }


            }

            catch (Exception ex)
            {
                if (transactionObj != null) transactionObj.Rollback();
                MessageBox.Show("Startup Error: [**" + ex.Message.ToString() + "**]", "Startup Error!");

                Application.Exit();

            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           // ManageItems ManageItemsForm = new ManageItems();

            Boolean loginOk = false;
            lblError.Text = "";

            if (tbxUsername.Text == "") { 
                lblError.Text = "Please Provide a UserName";
                tbxUsername.Focus();
            }
            else if (tbxPassword.Text == "")
            {
                lblError.Text = "Please Enter Your Password";
                tbxPassword.Focus();
            }

            else
            {

                DataRow dtRow = DatabaseConnectionObject.datasetObject_Global.Tables["Users"].Rows.Find(tbxUsername.Text);

                if (dtRow == null)
                {
                    loginOk = false;

                }
                else
                {

                    if (new EncAndDec(tbxPassword.Text).dencryptData(dtRow["UserPassword"].ToString()) == tbxUsername.Text) loginOk = true;
                    else loginOk = false;
                }

                if (loginOk)
                {
                    lblError.Text = "";

                    Main mainForm = new Main();
                    this.Hide();

                    mainForm.ShowDialog();

                    if (DatabaseConnectionObject.connectionObj_Global.State == ConnectionState.Open) DatabaseConnectionObject.connectionObj_Global.Close();
                    Application.Exit();
                }
                else
                {

                    lblError.Text = "Invalid UserName or Password. Try Again";
                }
            }


        }
    }
}
