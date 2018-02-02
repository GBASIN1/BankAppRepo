using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataManagementService.Entity;
using DataManagementService;
using System.Data.Common;
using System.Web.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace DataManagementService
{
    public class DataManager
    {
        /// <summary>
        /// Gets the data from given table which passes given where clause condition. 
        /// </summary>
        /// <param name="tableSchema">The table schema. Table schema inclues table name, list of columns and where clause conditions</param>
        /// <returns></returns>
        public ResultSet GetDataFromTable(TableSchema tableSchema)
        {
            ResultSet tableData = new ResultSet();

            try
            {
                DBHandler dbHandler = new DBHandler();
                string connectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                string proiderName = WebConfigurationManager.AppSettings["DBProvider"].ToString();
                // Creating connection
               // File.AppendAllText(@"D:\Charmi\Test.txt", "ConnectionString: "  + connectionString + Environment.NewLine + "providerName: " +  proiderName);
                
                DbConnection dbConnection = dbHandler.CreateDbConnection(proiderName, connectionString);
                 
                dbConnection.Open();

                DbDataReader dataReader = null;

                // Generating query string
                string selectQuery = QueryGenerator.GenerateSelectQuery(tableSchema);

                if (!string.IsNullOrEmpty(selectQuery))
                {
                    DbCommand dbCommand = dbConnection.CreateCommand();
                    dbCommand.CommandText = selectQuery;
                    dbCommand.Connection = dbConnection;

                    dataReader = dbCommand.ExecuteReader();

                    List<Record> rows = ConvertToRecord(dataReader, tableSchema.ColumnNames);

                    tableData.Records = rows;
                    tableData.IsSuccess = true;
                    tableData.NumberOfRowsAffected = tableData.Records.Count;
                }
                else
                {
                    tableData.IsSuccess = false;
                    tableData.ErrorMessage = "Error while creating query string";
                }
                dbConnection.Close();

                return tableData;
            }
            catch (Exception ex)
            {

                tableData.IsSuccess = false;
                tableData.ErrorMessage = ex.Message;
                return tableData;
            }
        }

        /// <summary>
        /// Converts rows in DbDataReader to rocords.
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        /// <returns></returns>
        private List<Record> ConvertToRecord(DbDataReader dataReader, List<string> columnNames)
        {
            List<Record> listOfRecord = new List<Record>();

            while (dataReader.Read())
            {
                Record row = new Record();
                row.Columns = new Dictionary<string, string>();

                if (columnNames == null || columnNames.Count == 0)
                {
                    columnNames = new List<string>();

                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        columnNames.Add(dataReader.GetName(i));
                    }
                }

                foreach (string col in columnNames)
                {
                    row.Columns.Add(col, dataReader[col].ToString());
                }

                listOfRecord.Add(row);
            }

            return listOfRecord;
        }

        /// <summary>
        /// Updates the columns with given values which passes the given where clause condition.
        /// </summary>
        /// <param name="tableSchema">The table schema. This includes table name, list of columns and corresponding values to assign and where clause.</param>
        /// <returns>Returns number of rows updated.</returns>
        public ResultSet UpdateTable(Entity.TableSchema tableSchema)
        {
            ResultSet tableData = new ResultSet();
            try
            {
                DBHandler dbHandler = new DBHandler();

                // Creating connection
                DbConnection dbConnection = dbHandler.CreateDbConnection(tableSchema.ProviderName, tableSchema.ConnectionString);

                dbConnection.Open();

                // Generating query string
                string updateQuery = QueryGenerator.GenerateUpdateQuery(tableSchema);

                if (!string.IsNullOrEmpty(updateQuery))
                {
                    DbCommand dbCommand = dbConnection.CreateCommand();
                    dbCommand.CommandText = updateQuery;
                    dbCommand.Connection = dbConnection;

                    int rowsAffected = dbCommand.ExecuteNonQuery();

                    tableData.NumberOfRowsAffected = rowsAffected;
                    tableData.IsSuccess = true;
                }
                else
                {
                    tableData.IsSuccess = false;
                    tableData.ErrorMessage = "Error in generating query string.";
                }
                dbConnection.Close();

                return tableData;
            }
            catch (Exception ex)
            {
                tableData.IsSuccess = false;
                tableData.NumberOfRowsAffected = 0;
                tableData.ErrorMessage = ex.Message;
                return tableData;
            }
        }

        /// <summary>
        /// Inserts the into table.
        /// </summary>
        /// <param name="tableSchema">The table schema. This includes table name, colname list and correspodonding values to insert.</param>
        /// <returns></returns>
        public ResultSet InsertIntoTable(Entity.TableSchema tableSchema)
        {
            ResultSet tableData = new ResultSet();
            try
            {
                DBHandler dbHandler = new DBHandler();

                // Creating connection
                DbConnection dbConnection = dbHandler.CreateDbConnection(tableSchema.ProviderName, tableSchema.ConnectionString);

                dbConnection.Open();

                // Generating query string
                string insertQuery = QueryGenerator.GenerateInsertQuery(tableSchema);

                if (!string.IsNullOrEmpty(insertQuery))
                {
                    DbCommand dbCommand = dbConnection.CreateCommand();
                    dbCommand.CommandText = insertQuery;
                    dbCommand.Connection = dbConnection;

                    int rowsAffected = dbCommand.ExecuteNonQuery();

                    tableData.NumberOfRowsAffected = rowsAffected;
                    tableData.IsSuccess = true;
                }
                else
                {
                    tableData.IsSuccess = false;
                    tableData.ErrorMessage = "Error in generating query string.";
                }
                dbConnection.Close();

                return tableData;
            }
            catch (Exception ex)
            {
                tableData.IsSuccess = false;
                tableData.NumberOfRowsAffected = 0;
                tableData.ErrorMessage = ex.Message;
                return tableData;
            }
        }

        /// <summary>
        /// Deletes rows from table which matches the given condition.
        /// </summary>
        /// <param name="tableSchema">The table schema. This includes table name and condition which specifies which row to delete.</param>
        /// <returns></returns>
        public ResultSet DeleteFromTable(TableSchema tableSchema)
        {
            ResultSet tableData = new ResultSet();
            try
            {
                DBHandler dbHandler = new DBHandler();

                // Creating connection
                DbConnection dbConnection = dbHandler.CreateDbConnection(tableSchema.ProviderName, tableSchema.ConnectionString);

                dbConnection.Open();

                // Generating query string
                string deleteQuery = QueryGenerator.GenerateDeleteQuery(tableSchema);

                if (!string.IsNullOrEmpty(deleteQuery))
                {
                    DbCommand dbCommand = dbConnection.CreateCommand();
                    dbCommand.CommandText = deleteQuery;
                    dbCommand.Connection = dbConnection;

                    int rowsAffected = dbCommand.ExecuteNonQuery();

                    tableData.NumberOfRowsAffected = rowsAffected;
                    tableData.IsSuccess = true;
                }
                else
                {
                    tableData.IsSuccess = false;
                    tableData.ErrorMessage = "Error in generating query string.";
                }
                dbConnection.Close();

                return tableData;
            }
            catch (Exception ex)
            {
                tableData.IsSuccess = false;
                tableData.NumberOfRowsAffected = 0;
                tableData.ErrorMessage = ex.Message;
                return tableData;
            }
        }


        public bool AddCustomerDetail(CustDetail customerDetail)
        {
            try
            {
                DBHandler dbHandler = new DBHandler();
                string connectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                string proiderName = WebConfigurationManager.AppSettings["DBProvider"].ToString();
                // Creating connection
                // File.AppendAllText(@"D:\Charmi\Test.txt", "ConnectionString: "  + connectionString + Environment.NewLine + "providerName: " +  proiderName);
                SqlConnection sqlConn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.CustomerData ([CustID],[AccountNumber],[Name],[CustType],[DOB],[ApplicantMaritalStatus],[EmailAddress]) VALUES " +
                    "('" + customerDetail.CustomerID + "', '" + customerDetail.AccountNumber + "', '" + customerDetail.CustomerName + "', 'public' ,'" + customerDetail.DOB + "', '" + customerDetail.MaritalStatus + "', '" + customerDetail.EmailAddress + "' )", sqlConn);
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                sqlConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
