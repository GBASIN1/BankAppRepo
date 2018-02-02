using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace DataManagementService.Entity
{
    /// <summary>
    /// This class stores the result to return.
    /// </summary>
   
    public class ResultSet
    {
      
        public bool IsSuccess;
    
        public string ErrorMessage;
      
        public List<Record> Records;
       
        public int NumberOfRowsAffected;
    }
}