using BankAppWeb.DataManagementService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BankAppWeb.BL
{
    public class BusinessLogic
    {
        
        public DataTable LoadCustomerData()
        {
            DataTable dTable = null;
            List<Record> recordList = null;
            try
            {
                DataManagementService.IDataManagementService dbManager = new DataManagementService.DataManagementServiceClient();
                //DataManagementLibrary.DataManager dbManager = new DataManagementLibrary.DataManager();
                //Added for
                TableSchema tSchema = new TableSchema();
                tSchema.ColumnNames = null;
                tSchema.Conditions = null;
                //tSchema.ProviderName = providername;
                //tSchema.ConnectionString = connectionstring;
                tSchema.TableName = "CustomerData";
                ResultSet rData = dbManager.GetDataFromTable(tSchema);
                if (rData.IsSuccess == false)
                {
                    //System.Windows.Forms.MessageBox.Show("Error in getting customer data: " + rData.ErrorMessage, "Get Customer Data");
                    throw new Exception("Error in getting customer data: " + rData.ErrorMessage);
                }
                else
                {
                    DataManagementLibrary.DataManagerHelper dmHelper = new DataManagementLibrary.DataManagerHelper();

                    recordList = rData.Records.ToList();
                    dTable = dmHelper.RecordsToDataTable(recordList, new List<string>() { "CustID", "AccountNumber", "CustType", "Name", "DOB" });
                }
                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

 

        public bool AddCustomerDetails(CustDetail custDetail)
        {
            try
            {
                DataManagementService.IDataManagementService dbManager = new DataManagementService.DataManagementServiceClient();

                bool bSuccessData = dbManager.AddCustomerDetail(custDetail);
                return bSuccessData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetCustomerDetails()
        {
            try
            {
                DataTable dTable = null;
                List<Record> recordList = null;
                DataManagementService.IDataManagementService dbManager = new DataManagementService.DataManagementServiceClient();
               
                ResultSet rData = dbManager.GetCustomerList();
                if (rData.IsSuccess == false)
                {
                    //System.Windows.Forms.MessageBox.Show("Error in getting customer data: " + rData.ErrorMessage, "Get Customer Data");
                    throw new Exception("Error in getting customer data: " + rData.ErrorMessage);
                }
                else
                {
                    DataManagementLibrary.DataManagerHelper dmHelper = new DataManagementLibrary.DataManagerHelper();

                    recordList = rData.Records.ToList();
                    dTable = dmHelper.RecordsToDataTable(recordList, new List<string>() { "CustID", "AccountNumber", "CustType", "Name", "DOB" });
                }
                return dTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertCustomerData(CustDetail customerDetail)
        {
            try
            {
                DataManagementService.IDataManagementService dbManager = new DataManagementService.DataManagementServiceClient();

                bool bSuccessData = dbManager.InsertCustomerData(customerDetail);
                return bSuccessData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool MinCustomerCountCheck(int noOfCustomer)
        {
            try
            {
                if (noOfCustomer > 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public bool MinBalanceCheck(decimal amount)
        {
            try
            {
                if (amount > 1000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
