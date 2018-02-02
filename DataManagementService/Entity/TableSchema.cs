using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;


namespace DataManagementService.Entity
{
    /// <summary>
    /// This class stores connection string, provider name, table name, column names and value list along with conditions which
    /// are 'where clauses' used select, update and delete query.
    /// </summary>

    public class TableSchema
    {
      
        public string ConnectionString;
       
        public string ProviderName;
      
        public string TableName;
      
        public List<string> ColumnNames;
       
        public List<string> Values;
      
        public List<Condition> Conditions;
       
    }
}