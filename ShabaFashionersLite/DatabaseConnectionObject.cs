using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data ;
using System.Windows.Forms;
using System.IO;

namespace ShabaFashionersLite
{
    class DatabaseConnectionObject
    {

        static String DatabasePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\ShabaLite.mdb";
        public static OleDbConnection connectionObj_Global = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=aryampa;Data Source=" + DatabasePath);
        public static DataSet datasetObject_Global = new DataSet();
        public static Dictionary<string, OleDbDataAdapter> DataTableAdaptor_Dic = new Dictionary<string, OleDbDataAdapter> { };
        public static Dictionary<string, OleDbCommandBuilder> CommandBuilder_Dic = new Dictionary<string, OleDbCommandBuilder> { };

        public DatabaseConnectionObject() { }

        public Boolean populate_DataSet()
        {

            List<string> listOfTableNames = new List<string> {"Items", "DebtDetails", "Debtors", "Users", "Sales", "Purchases", "TableIDNumbers","Units","Settings","SessionData","BackUpSessions","Expenses" };


            datasetObject_Global.Clear();
           


            foreach (string Table_Name in listOfTableNames)
            {

                DataObjectsInitializer DataObject = new DataObjectsInitializer(Table_Name, datasetObject_Global, connectionObj_Global);
             

               // MessageBox.Show("Dataset Now has : " + datasetObject_Global.Tables.Count.ToString() + " tables!!");
            }


            return true;
        }
           
    }
}
