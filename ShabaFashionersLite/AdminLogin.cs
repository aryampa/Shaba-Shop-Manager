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
    public partial class AdminLogin : Form
    {
        public Boolean loginOk;
       // DatabaseInterfaceClass dbObj;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
           // dbObj = new DatabaseInterfaceClass("System Users");

        }

        private void btnAdminOk_Click(object sender, EventArgs e)
        {
            try
            {
                string DecryptKey = "admin";

                byte[] keyBytes = Encoding.UTF8.GetBytes(DecryptKey);

                string keyBase64 = Convert.ToBase64String(keyBytes);

                DataRow adminRow = DatabaseConnectionObject.datasetObject_Global.Tables["System Users"].Rows.Find("admin");

                string decryptedAdmin = new EncAndDec(keyBase64).dencryptData(adminRow["Password"].ToString());

                if (tbxAdminPassword.Text == decryptedAdmin)
                {
                    loginOk = true;

                    //MessageBox.Show("SuccessFull!", "Login successfull");

                    this.Close();
                }

                else { MessageBox.Show("Invalid Password", "Error"); }
            }

            catch (Exception ex)
            {

                MessageBox.Show("Admin Login Error: " + ex.Message, "Error");

            }


        }
    }
}
