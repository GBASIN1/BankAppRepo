using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.IO;

namespace DataManagementService
{
    public class DBHandler
    {
        public DbConnection CreateDbConnection(string providerName, string connectionString)
        {
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;

                }
                catch (DbException ex)
                {
                    File.AppendAllText(@"D:\ErrorLog.txt", "Exception " + ex.Message + Environment.NewLine + "StackeTrace:  " + ex.StackTrace);
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    
                }
                catch (Exception ex)
                {
                    File.AppendAllText(@"D:\ErrorLog.txt", "Exception " + ex.Message + Environment.NewLine + "StackeTrace:  " + ex.StackTrace);
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                   
                }
            }
            return connection;
        }

        /// <summary>
        /// Creates the db adapter.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <returns></returns>
        public DbDataAdapter CreateDbAdapter(string providerName)
        {
            DbDataAdapter adapter = null;
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                adapter = factory.CreateDataAdapter();
            }
            catch (DbException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return adapter;
        }

        /// <summary>
        /// Creates the db command builder.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <returns></returns>
        public DbCommandBuilder CreateDbCommandBuilder(string providerName)
        {
            DbCommandBuilder builder = null;
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                builder = factory.CreateCommandBuilder();
            }
            catch (DbException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return builder;
        }

        
    }
}
