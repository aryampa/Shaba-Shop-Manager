using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace ShabaFashionersLite
{
    class DataTableManager 
    {
        DataObjectsInitializer dbObject;
        DataObjectsInitializer dbSessionObject;
        String TableNam;
        
        public DataTableManager(String TableName, DataSet datasetObject, OleDbTransaction transacttionObj, String BackupSessionID)
        {
            dbObject = new DataObjectsInitializer(TableName, datasetObject, transacttionObj, BackupSessionID);
            dbSessionObject = new DataObjectsInitializer("BackUpSessions", datasetObject, transacttionObj, BackupSessionID);
            TableNam = TableName;


        }

        public void Delete(String RowID) {

            DataRow Row2Delete = DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Rows.Find(RowID);
            Row2Delete.Delete();

            dbObject.DataAdapterObj.DeleteCommand = dbObject.CommandBuilderObj.GetDeleteCommand();
            dbObject.DataAdapterObj.Update(DatabaseConnectionObject.datasetObject_Global, TableNam);

           updateSessionTable(GlobalVariables.CurrentSessionID, new DateTimeUtility().ToEpochFormat(DateTime.Now), TableNam, RowID, "DELETE");

        }

        public Object Search(String Column_Name, String Query,  Boolean isPrimaryKey, Boolean ReturnEntireRow)  {
            if (isPrimaryKey)
            {

                DataRow dtRow = DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Rows.Find(Query);
                if (dtRow == null) throw new Exception("No Row Found with specified Primary Key");
                if (ReturnEntireRow) return dtRow;
                else
                {
                    return dtRow[Column_Name];
                }

            }
            else {
                if (ReturnEntireRow)
                {
                    DataTable dtTable2Retrn = new DataTable();

                    foreach (DataColumn dtCol in DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Columns)
                    {
                        dtTable2Retrn.Columns.Add(dtCol.ColumnName);
                    }

                    foreach (DataRow dtRow4List in DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Rows)
                    {

                        if (dtRow4List[Column_Name].ToString().ToLower().Contains(Query.ToLower()))
                        {

                            DataRow dtRow_New = dtTable2Retrn.NewRow();

                            foreach (DataColumn dtCol in DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Columns)
                            {

                                dtRow_New[dtCol.ColumnName] = dtRow4List[dtCol.ColumnName];

                            }

                            dtTable2Retrn.Rows.Add(dtRow_New);

                        }
                    }

                    return dtTable2Retrn;

                }

                else { // Donot retrn Rows

                    Boolean containsQuery = false;

                    foreach (DataRow dtRow4List in DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Rows)
                    {

                        if (dtRow4List[Column_Name].ToString().ToLower().Contains(Query.ToLower()))
                        {

                            containsQuery = true;
                            break;

                        }
                    }

                    return containsQuery;
                }

            }
        }

        public void CreateRow(Dictionary<String,Object> Col_Value_Map, String PrimaryKey) {

            DataRow NewRow_items = DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].NewRow();

            foreach (KeyValuePair<String, Object> k_V in Col_Value_Map) {

                NewRow_items[k_V.Key] = k_V.Value;
            }
            

            DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Rows.Add(NewRow_items);

            dbObject.DataAdapterObj.InsertCommand = dbObject.CommandBuilderObj.GetInsertCommand();
            //NewItemDataObj.Update_CommandObj.CommandText = NewItemDataObj
            dbObject.DataAdapterObj.Update(DatabaseConnectionObject.datasetObject_Global, TableNam);

            
            updateSessionTable(GlobalVariables.CurrentSessionID, new DateTimeUtility().ToEpochFormat(DateTime.Now), TableNam,PrimaryKey , "CREATE");

            
        }

        public void EditRow(String PrimaryKey, Dictionary<String, Object> Col_Value_Map)
        {
            DataRow NewDTRow = DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Rows.Find(PrimaryKey);
            if( NewDTRow ==null) throw new Exception("Row with Specified Primary Key [*"+PrimaryKey+"*] Not Found");
            
           foreach (KeyValuePair<String, Object> k_V in Col_Value_Map) {

                NewDTRow[k_V.Key] = k_V.Value;
            }

            //DatabaseConnectionObject.datasetObject_Global.Tables[TableNam].Rows.Add(NewDTRow);
           dbObject.DataAdapterObj.UpdateCommand = dbObject.CommandBuilderObj.GetUpdateCommand();
           dbObject.DataAdapterObj.Update(DatabaseConnectionObject.datasetObject_Global, TableNam);

           updateSessionTable(GlobalVariables.CurrentSessionID, new DateTimeUtility().ToEpochFormat(DateTime.Now), TableNam, PrimaryKey, "EDIT");
        }

        public void updateSessionTable(String SessionID, String TransactionDate, String TableName, String RowItemID, String Action) {

            DataRow NewTransactionRow = DatabaseConnectionObject.datasetObject_Global.Tables["BackUpSessions"].NewRow();

            NewTransactionRow["Session ID"] = SessionID;
            NewTransactionRow["TransactionDate"] = TransactionDate;
            NewTransactionRow["TableName"] = TableName;
            NewTransactionRow["ItemID"] = RowItemID;
            NewTransactionRow["Action"] = Action;

            DatabaseConnectionObject.datasetObject_Global.Tables["BackUpSessions"].Rows.Add(NewTransactionRow);
           dbSessionObject .DataAdapterObj.InsertCommand = dbSessionObject.CommandBuilderObj.GetInsertCommand();
           dbSessionObject.DataAdapterObj.Update(DatabaseConnectionObject.datasetObject_Global, "BackUpSessions");
            
            
        }
    }
}
