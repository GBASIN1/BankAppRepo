using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApplication.NunitTest
{
    public class CustomerDetailsBL
    {
        public int GetNumberOfcustomer(string bankName)
        {
            if (bankName == "ICICI")
            {
                return 1000;
            }
            else
            {
                return 500;
            }
        }
    }
}
