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
    public partial class Search : Form
    {
        // MainForm mainFormS;
        private int current_row_index;



        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            cbxTab.SelectedIndex = 0;

            cbxColmns.Items.Clear();

            foreach (DataColumn dtCol in DatabaseConnectionObject.datasetObject_Global.Tables["Sales"].Columns)
            {
                cbxColmns.Items.Add(dtCol.ColumnName);
            }

            tbxSearchText.Text = "";
           // btnSearch.Enabled = false;

            if (cbxColmns.Items.Count > 0) {
                cbxColmns.SelectedIndex = 0;
            }
            




        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int found_counter = 0;
            tbxDetails.Text = "";
            DataTable dtTable = new DataTable();

            foreach (DataColumn dtCol in DatabaseConnectionObject.datasetObject_Global.Tables[cbxTab.SelectedItem.ToString()].Columns)
            {

                dtTable.Columns.Add(dtCol.ColumnName);
            }

            if (tbxSearchText.Text == "")
            {

                foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables[cbxTab.SelectedItem.ToString()].Rows)
                {

                    DataRow dtRow_Temp = dtTable.NewRow();

                    foreach (DataColumn dtCol2 in dtTable.Columns)
                    {
                        dtRow_Temp[dtCol2.ColumnName] = dtRow[dtCol2.ColumnName];
                    }

                    dtTable.Rows.Add(dtRow_Temp);

                    found_counter++;
                }

            }
            else {
                foreach (DataRow dtRow in DatabaseConnectionObject.datasetObject_Global.Tables[cbxTab.SelectedItem.ToString()].Rows)
                {
                    if (dtRow[cbxColmns.SelectedItem.ToString()].ToString().ToLower().Contains(tbxSearchText.Text.ToLower()))
                    {

                        DataRow dtRow_Temp = dtTable.NewRow();

                        foreach (DataColumn dtCol2 in dtTable.Columns)
                        {
                            dtRow_Temp[dtCol2.ColumnName] = dtRow[dtCol2.ColumnName];
                        }

                        dtTable.Rows.Add(dtRow_Temp);

                        found_counter++;



                    }
                }

            }



            dbGridResults.DataSource = dtTable;

            if (found_counter == 0)
            {

                MessageBox.Show("Sorry No Match Found For \" " + tbxSearchText.Text + "  \"in Column " + cbxColmns.SelectedItem.ToString(), "No Match Found");
            }

        }

        private void dbGridResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            current_row_index = dbGridResults.CurrentCell.RowIndex;

            StringBuilder sBuilder = new StringBuilder();

            foreach (DataColumn dtCol in DatabaseConnectionObject.datasetObject_Global.Tables[cbxTab.SelectedItem.ToString()].Columns) {

                sBuilder.AppendLine(dtCol.ColumnName+": " + dbGridResults.CurrentRow.Cells[dtCol.ColumnName].Value.ToString());
                sBuilder.AppendLine("------------");
            }
            
            tbxDetails.Text = sBuilder.ToString();




        }

        private void cbxTab_DropDownClosed(object sender, EventArgs e)
        {

            cbxColmns.Items.Clear();
            foreach (DataColumn dtCol in DatabaseConnectionObject.datasetObject_Global.Tables[cbxTab.SelectedItem.ToString()].Columns)
            {

                cbxColmns.Items.Add(dtCol.ColumnName);
            }

            cbxColmns.SelectedIndex = 0;
        }
    }
}