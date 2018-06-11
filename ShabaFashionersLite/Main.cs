using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ShabaFashionersLite
{
    public partial class Main : Form
    {
        Thread dateThread;
        public Main()
        {
            InitializeComponent();
        }


        //Delegates Declare HERE

        delegate void updateLableDelagate(Label lbl, string text);
        delegate void xupdateTextBoxDelegate(TextBox txtbx, string text, Boolean append);
        delegate void enableControlDelegate(Control control, Boolean flag);

        // Delegate Functions HERE

        private void updateLableFunction(Label lbl, string txt)
        {
            lbl.Text = txt;

        }

        private void enableControlFunction(Control ctrl, Boolean flag)
        {
            ctrl.Enabled = flag;
        }

        private void updateTextBoxFunction(TextBox txtbx, string txt, Boolean append)
        {
            if (append)
            {
                txtbx.AppendText(txt);
                txtbx.Update();
            }
            else
            {
                txtbx.Text = txt;
                txtbx.Update();
            }
        }

        // ThreadSafe Functions HERE

        public void threadSafeLableUpdate(Label lbl, string txt)
        {
            if (lbl.InvokeRequired)
            {
                updateLableDelagate d = new updateLableDelagate(updateLableFunction);
                this.Invoke(d, new object[] { lbl, txt });
            }
            else
            {
                lbl.Text = txt;
                lbl.Update();
            }
        }

        public void threadSafeEnableControl(Control ctrl, Boolean flag)
        {
            if (ctrl.InvokeRequired)
            {
                enableControlDelegate d = new enableControlDelegate(enableControlFunction);
                this.Invoke(d, new object[] { ctrl, flag });
            }
            else
            {
                ctrl.Enabled = flag;
            }
        }
        public void threadSafeTextBoxUpdate(TextBox txtbx, string txt, Boolean append)
        {
            if (txtbx.InvokeRequired)
            {
                // d = new updateTextBoxDelegate(updateTextBoxFuncupdateTextBoxDelegatetion);
                //this.Invoke(d, new object[] { txtbx, txt, append });
            }
            else
            {

                if (append)
                {
                    txtbx.AppendText(txt);
                    txtbx.Update();
                }
                else
                {
                    txtbx.Text = txt;
                    txtbx.Update();
                }
            }
        }

        private void updatDataLabel() {

            try
            {
                while (true)
                {
                    threadSafeLableUpdate(lblDateTime, DateTime.Now.ToString("dd MMMM, yyy   h:m:s"));
                }
            }

            catch (Exception ex) {
               // MessageBox.Show("Error Retrieving Date and Time" +" Restart application", "Data Time Error");
                
            }
        }

        private void btnRegisterNewItem_Click(object sender, EventArgs e)
        {
            AddNewItem addNewForm = new AddNewItem();
            addNewForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateThread = new Thread(new ThreadStart(updatDataLabel));
            dateThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (dateThread.IsAlive) dateThread.Abort();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dateThread.IsAlive) dateThread.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterSale regSale = new RegisterSale();
            regSale.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Purchases1 purchase = new Purchases1();
            purchase.ShowDialog();
        }

        private void btnManageDebt_Click(object sender, EventArgs e)
        {
            ManageDebtors debtorsDialog = new ManageDebtors();
            debtorsDialog.ShowDialog();
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            ManageExpenses expenses = new ManageExpenses();
            expenses.ShowDialog();
        }

        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupAndRestore bR = new BackupAndRestore();
            bR.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search srch = new Search();
            srch.ShowDialog();
        }

        
    }
}
