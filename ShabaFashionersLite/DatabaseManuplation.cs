using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace ShabaFashionersLite
{
    class DatabaseManuplation
    {
        public OleDbConnection objConection;

        public OleDbCommand Select_CommandObj;
        public OleDbCommand Update_CommandObj;
        public OleDbCommand Insert_CommandObj;

        public OleDbCommandBuilder CommandBuilderObj;
        public OleDbDataAdapter DataAdapterObj;
        string Table_name;

        public DatabaseManuplation(string table_name, DataSet datasetObject, OleDbTransaction transacttionObj)
        {

            string SqlCommandStrg = "Select * FROM " + "[" + table_name + "]";
            Table_name = table_name;

            objConection = transacttionObj.Connection;

            Select_CommandObj = new OleDbCommand();
            Select_CommandObj.Connection = objConection;
            Select_CommandObj.CommandType = CommandType.Text;

            Update_CommandObj = new OleDbCommand();
            Update_CommandObj.Connection = transacttionObj.Connection;
            Update_CommandObj.CommandType = CommandType.Text;

            Insert_CommandObj = new OleDbCommand();
            Insert_CommandObj.Connection = transacttionObj.Connection;
            Insert_CommandObj.CommandType = CommandType.Text;



            DataAdapterObj = new OleDbDataAdapter();
            CommandBuilderObj = new OleDbCommandBuilder(DataAdapterObj);

            

           

            DataAdapterObj.SelectCommand = Select_CommandObj;
            DataAdapterObj.UpdateCommand = Update_CommandObj;
            DataAdapterObj.InsertCommand = Insert_CommandObj;
           

            DataAdapterObj.SelectCommand.CommandText = SqlCommandStrg;

            DataAdapterObj.MissingSchemaAction = MissingSchemaAction.AddWithKey;


            CommandBuilderObj.QuotePrefix = "[";
            CommandBuilderObj.QuoteSuffix = "]";

           // DataAdapterObj.InsertCommand = CommandBuilderObj.GetInsertCommand();


            DataAdapterObj.SelectCommand.Connection = transacttionObj.Connection;
            DataAdapterObj.InsertCommand.Connection = transacttionObj.Connection;
            DataAdapterObj.UpdateCommand.Connection = transacttionObj.Connection;
           // DataAdapterObj.DeleteCommand.Connection = transacttionObj.Connection;

            DataAdapterObj.SelectCommand.Transaction = transacttionObj;
           // DataAdapterObj.DeleteCommand.Transaction = transacttionObj;
            DataAdapterObj.UpdateCommand.Transaction = transacttionObj;
            DataAdapterObj.InsertCommand.Transaction = transacttionObj;

        

            DataAdapterObj.Fill(datasetObject, table_name);
        }

        public void UpdateOperation(Dictionary<string, string> newRow) {

            string updateString = "";
            
        }



    }
}
