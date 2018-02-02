using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DataManagementService.Entity
{
    /// <summary>
    /// Represents one record or row from table.
    /// </summary>
  
    public class Record
    {
     
        public Dictionary<string, string> Columns;
    }
}