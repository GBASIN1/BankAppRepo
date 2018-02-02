using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BankApplication.DataManagementService;

namespace BankApplication
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }
        public delegate void RefeshCustomerGridEventHandler(object sender, EventArgs e);
        public static event RefeshCustomerGridEventHandler RefeshCustomerGridEvent;
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustDetail custDetail = new CustDetail();
            //Model.CustomerDetail  = new Model.CustomerDetail();
            custDetail.CustomerID = txtCustId.Text;
            custDetail.CustomerName = txtCustName.Text;
            custDetail.DOB = txtDOB.Text;
            custDetail.EmailAddress = txtEmail.Text;
            custDetail.AccountNumber = txtAccNumber.Text;
            if (chkIsMarried.Checked)
            {
                custDetail.MaritalStatus = "Married";
            }
            else
            {
                custDetail.MaritalStatus = "UnMarried";
            }

            BL.BusinessLogic busLogic = new BL.BusinessLogic();
            bool bSuccess = busLogic.InsertCustomerData(custDetail);
          // bool bSuccess = busLogic.AddCustomerDetails(custDetail);
           if (!bSuccess)
           {
               MessageBox.Show("Exception occured while adding Customer details");
           }
           else
           {
               lblValidationMessage.Visible = true;
               lblValidationMessage.Text = "Customer " + txtCustName.Text + " added successfully.";
               txtAccNumber.Text = "";
               txtCustId.Text = "";
               txtCustName.Text = "";
               txtDOB.Text = "";
               txtEmail.Text = "";
               chkIsMarried.Checked = false;
               if (RefeshCustomerGridEvent != null)
               {
                   RefeshCustomerGridEvent(this, null);
               }
           }
        }

        
    }
}
