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

        private void Form1_Load(object sender, EventArgs e)
        {
            try{

                
                
            }
            catch(Exception ex){
                MessageBox.Show("Reason: "+ex.Message.ToString(), "Error Initalising Expense Module");
                this.Close();
            }
             
        }
    }
}
