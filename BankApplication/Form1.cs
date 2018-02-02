using BankApplication.BL;
using BankApplication.DataManagementService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankApplication
{
    public partial class Form1 : Form
    {
        private const string CONNECTION_STRING = "Data Source=VCHNILADPSCI-07;Initial Catalog=BankApplicationDemo;User ID=sa;Password=#infy123";
        private const string PROVIDER_NAME = "System.Data.SQLClient";
        public Form1()
        {
            InitializeComponent();
            BankApplication.frmAddCustomer.RefeshCustomerGridEvent += new frmAddCustomer.RefeshCustomerGridEventHandler(Form1_RefreshCustomerGrid);
        }

        void Form1_RefreshCustomerGrid(object sender, EventArgs e)
        {
            LoadCustomerData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
           
        }
        private void LoadCustomerData()
        {
            try
            {
                BusinessLogic blLoadCustomer = new BusinessLogic();
                int NoOfRecords;
                DataTable dtCust= blLoadCustomer.GetCustomerDetails(out NoOfRecords);
               dataGridView1.DataSource = dtCust;
                dataGridView1.Refresh();
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            button1.Enabled = true;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmAddCustomer addCust = new frmAddCustomer();
            addCust.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form Loaded Successfully Test again");
        }
    }
}
