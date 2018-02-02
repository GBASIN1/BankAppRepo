using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataManagementService.Entity;
using System.Data;
using System.Data.Common;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace DataManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class DataManagementService : IDataManagementService
    {
        private DataManager datamanger = new DataManager();
        public ResultSet GetDataFromTable(TableSchema tableSchema)
        {
            return datamanger.GetDataFromTable(tableSchema);
        }

        public bool AddCustomerDetail(CustDetail customerDetail)
        {
            return datamanger.AddCustomerDetail(customerDetail);
        }

        public ResultSet GetCustomerDetails(out int NoOfRecords)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            CustDetail custDetials = new CustDetail();
             int recordsCount = 0;
            ResultSet resultSet = new ResultSet();
            // Provide the query string with a parameter placeholder. 
            string queryString = "SELECT CustID, AccountNumber, CustType,Name,DOB from dbo.CustomerData ";
            DataTable dtCust = new DataTable();
            List<Record> listOfRecord = new List<Record>();
            List<string> columnNames = null;
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString,connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    recordsCount++;
                    Record row = new Record();
                    row.Columns = new Dictionary<string, string>();

                    if (columnNames == null || columnNames.Count == 0)
                    {
                        columnNames = new List<string>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            columnNames.Add(reader.GetName(i));
                        }
                    }

                    foreach (string col in columnNames)
                    {
                        row.Columns.Add(col, reader[col].ToString());
                    }

                    listOfRecord.Add(row);
                }
            }
            resultSet.Records = listOfRecord;
            resultSet.IsSuccess = true;
            NoOfRecords = recordsCount;
            return resultSet;
        }

        public bool InsertCustomerData(CustDetail customerDetail)
        {
            bool bSuceess;
            string connectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string commandText = "INSERT INTO CustomerData(CustID,AccountNumber, CustType,Name,DOB,EmailAddress,ApplicantMaritalStatus)Values(@CustID,@AccountNumber, @CustType,@Name,@DOB,@EmailAddress,@MaritalStatus)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                customerDetail.DOB = DateTime.Now.ToString();
                command.Parameters.AddWithValue("@CustID", customerDetail.CustomerID);
                command.Parameters.AddWithValue("@AccountNumber", customerDetail.AccountNumber);
                command.Parameters.AddWithValue("@CustType", "public");
                command.Parameters.AddWithValue("@Name", customerDetail.CustomerName);
                command.Parameters.AddWithValue("@DOB", customerDetail.DOB);
                command.Parameters.AddWithValue("@EmailAddress", customerDetail.EmailAddress);
                command.Parameters.AddWithValue("@MaritalStatus", customerDetail.MaritalStatus);
                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        bSuceess = true;
                    }
                    else
                    {
                        bSuceess = false;
                    }
                }
                catch (Exception ex)
                {
                    bSuceess = false;
                }
            }
            return bSuceess;
         
        }

        public ResultSet GetCustomerDetails()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            CustDetail custDetials = new CustDetail();
            int recordsCount = 0;
            ResultSet resultSet = new ResultSet();
            // Provide the query string with a parameter placeholder. 
            string queryString = "SELECT CustID, AccountNumber, CustType,Name,DOB from dbo.CustomerData ";
            DataTable dtCust = new DataTable();
            List<Record> listOfRecord = new List<Record>();
            List<string> columnNames = null;
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    recordsCount++;
                    Record row = new Record();
                    row.Columns = new Dictionary<string, string>();

                    if (columnNames == null || columnNames.Count == 0)
                    {
                        columnNames = new List<string>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            columnNames.Add(reader.GetName(i));
                        }
                    }

                    foreach (string col in columnNames)
                    {
                        row.Columns.Add(col, reader[col].ToString());
                    }

                    listOfRecord.Add(row);
                }
            }
            resultSet.Records = listOfRecord;
            resultSet.IsSuccess = true;
           return resultSet;
        }
    }
}
