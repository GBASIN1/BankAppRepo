using BankAppWeb.DataManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankAppWeb.BL;

namespace BankAppWeb
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CustDetail custDetail = new CustDetail();
            //Model.CustomerDetail  = new Model.CustomerDetail();
            custDetail.CustomerID = txtCutomerID.Text;
            custDetail.CustomerName = txtName.Text;
            custDetail.DOB = txtDOB.Text;
            custDetail.EmailAddress = txtEmail.Text;
            custDetail.AccountNumber = txtAccNumber.Text;
            if (chkMarried.Checked)
            {
                custDetail.MaritalStatus = "Married";
            }
            else
            {
                custDetail.MaritalStatus = "UnMarried";
            }

            BL.BusinessLogic busLogic = new BL.BusinessLogic();
            //bool bSuccess = busLogic.InsertCustomerData(custDetail);
             bool bSuccess = busLogic.AddCustomerDetails(custDetail);
            if (!bSuccess)
            {
                lblMsg.Text="Exception occured while adding Customer details";
            }
            else
            {
                Response.Redirect("GetCustomers.aspx");
            }
        }
    }
}