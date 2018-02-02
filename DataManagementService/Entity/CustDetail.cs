using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DataManagementService.Entity
{
    public class CustDetail
    {
        public DataTable dtCustomer { get; set; }

        public string CustomerID { get; set; }

        public string AccountNumber { get; set; }

        public string CustomerName { get; set; }

        public string DOB { get; set; }

        public string MaritalStatus { get; set; }

        public string EmailAddress { get; set; }
    }
}