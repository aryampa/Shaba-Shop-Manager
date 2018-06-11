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
using System.Net;

namespace ShabaFashionersLite
{
    public partial class BackupAndRestore : Form
    {
        public BackupAndRestore()
        {
            InitializeComponent();
        }

        private void BackupAndRestore_Load(object sender, EventArgs e)
        {
            try
            {
                DataObjectsInitializer.checkDatabaseConnection();
                lblCurrBackpSession.Text = "Current Session ID: "+ GlobalVariables.CurrentSessionID;
                lblTotalEntries.Text = "Total Backup Rows: "+DatabaseConnectionObject.datasetObject_Global.Tables["BackupSessions"].Rows.Count.ToString();

                if (DatabaseConnectionObject.datasetObject_Global.Tables["BackupSessions"].Rows.Count == 0) btnBackup.Enabled = false;


            }
            catch (Exception ex) {
                MessageBox.Show("Reason: " + ex.Message.ToString(), "Error Initalising Backup");
                this.Close();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            FileStream fsBackup = null;
            StreamWriter sWriter = null;
            string EncKey = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin1"));

            



             string BackupfilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\files\\Backupfile.bkp";
            
            StringBuilder sb = new StringBuilder();

            try
            {

                sb.Clear();

                sb.AppendLine("<BACKUP");
                sb.AppendLine("         <SESSION_ID>|" + GlobalVariables.CurrentSessionID + "|</SESSION_ID>");
                sb.AppendLine("         <BACKUP_DATE>|" + DateTime.Now.ToLocalTime().ToString() + "|<BACKUP_DATE>");
                sb.AppendLine("         <DATA>");

                DataRow[] BackupRows = new DataRow[DatabaseConnectionObject.datasetObject_Global.Tables["Backupsessions"].Rows.Count];
                DatabaseConnectionObject. datasetObject_Global.Tables["Backupsessions"].Rows.CopyTo(BackupRows, 0);

                for (int i = 0; i < BackupRows.Length; i++)
                {

                    String Source_TableName = BackupRows[i]["TableName"].ToString();
                    DataTable table = DatabaseConnectionObject.datasetObject_Global.Tables[Source_TableName];
                    String Action = BackupRows[i]["Action"].ToString();
                    String RowID = BackupRows[i]["ItemID"].ToString();
                    String TransactionDate = BackupRows[i]["TransactionDate"].ToString();
                    DataColumn[] CurrentTableColums = new DataColumn[] { };

                    DataRow Source_TableRow = null;
                    if (Action == "DELETE") { Source_TableRow = table.NewRow(); }
                    else Source_TableRow = DatabaseConnectionObject.datasetObject_Global.Tables[Source_TableName].Rows.Find(RowID);

                    if (Source_TableRow == null) throw new Exception("Backup CANNOT continue because ROW with ID: >> " + RowID + " << In Table: >> " + Source_TableName + " << was NOT FOUND! Contact Database Administrator");

                    String sb_Line = "              DATE:" + new DateTimeUtility().ToEpochFormat(DateTime.Now.ToLocalTime()) + "|TRANSACTION_DATE:" + TransactionDate + "|TABLE_NAME:" + Source_TableName + "|ROW_ID:" + RowID + "|ACTION:" + Action + "|DATE:[";
                    //table.Columns.CopyTo(CurrentTableColums, 0);

                    String DataLine = "";

                    switch (Action)
                    {

                        case "CREATE":

                            foreach (DataColumn dtCol in table.Columns)
                            {
                                DataLine = DataLine + dtCol.ColumnName + "=" + Source_TableRow[dtCol.ColumnName].ToString() + ",";
                            }

                            break;

                        case "EDIT":
                            foreach (DataColumn dtCol in table.Columns)
                            {
                                DataLine = DataLine + dtCol.ColumnName + "=" + Source_TableRow[dtCol.ColumnName].ToString() + ",";
                            }
                            break;

                        case "DELETE":

                            DataLine = DataLine + " ";

                            break;

                        default:

                            throw new Exception("Action: " + Action + " Not Recognised!");




                    }

                    sb_Line = sb_Line + DataLine.TrimEnd(new char[] { ',' }) + "]";


                    sb.AppendLine(new EncAndDec(EncKey).encryptData(sb_Line));


                }

                sb.AppendLine("         </DATA>");
                sb.AppendLine("</BACKUP>");

                String EncryptedPass = new EncAndDec(EncKey).encryptData("admin");
                String EncryptedData = new EncAndDec(EncKey).encryptData(sb.ToString());

                ServiceRef.ShabaLiteServiceClient webClient = new ServiceRef.ShabaLiteServiceClient();
                
                ServiceRef.ResponseMessage respMess = (ServiceRef.ResponseMessage) webClient.BackupData(EncryptedPass + "|" + EncryptedData);

                if (respMess.Status == "0" && respMess.Status!=null)
                {
                    // To Implement: clear backp table......
                    // ....also updates relevent rows in settings table
                    TextWriter txt = File.CreateText(BackupfilePath);
                    txt.Write(sb.ToString());
                    txt.Close();

                    MessageBox.Show("BackUp as SccessFull!", "SUcess!");
                }
                else {
                    throw new Exception("Server Error: "+respMess.ErrorMessage);
                }


            }
            catch (Exception ex) {

                if (fsBackup != null) fsBackup.Close();
                MessageBox.Show("Reason: " + ex.Message.ToString(), "Error Backing up");
            }
        }

        private void btnViewBK_Click(object sender, EventArgs e)
        {
            tabCtrl.SelectedIndex = 1;
        }
    }
}
