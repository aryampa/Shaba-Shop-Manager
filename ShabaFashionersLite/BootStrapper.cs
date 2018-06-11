using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ShabaFashionersLite
{
    class BootStrapper
    {
        public BootStrapper() {

            try
            {
                

                DatabaseConnectionObject.connectionObj_Global = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=aryampa;Data Source=E:\\PROGRAMMING STAFF\\VISUAL STUDIO PROJECTS\\DATABASE\\ShabaFinalDb.mdb");
                DatabaseConnectionObject . datasetObject_Global = new DataSet();

                DatabaseConnectionObject.connectionObj_Global.Open();

                DatabaseConnectionObject databaseConnObj = new DatabaseConnectionObject();

                Boolean populationResults = databaseConnObj.populate_DataSet();

                if (populationResults) MessageBox.Show("Success!!!!!");

                //ManageItems ManageItemsForm = new ManageItems();
                //ManageItemsForm.ShowDialog();


            }

            catch (Exception ex) {

                MessageBox.Show("Startup Error: [**" + ex.Message.ToString() + "**]", "Startup Error!");

                Application.Exit();

            }
        }
    }
}
