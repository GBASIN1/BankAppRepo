using System;
using NUnit.Framework;
using BankAppWeb.BL;
using System.Data;

namespace NunitTestBankApp
{
    [TestFixture]
    public class UnitTest1
    {
        // runs for each testcase
        [SetUp]
        public void setup()
        {

        }

        // test case
        //[TestCase]
        //public void TestMethod1()
        //{
        //    CustomerDetailsBL custDetails = new CustomerDetailsBL();
        //    int CustomerCount = custDetails.GetNumberOfcustomer("ICICI");
        //    NUnit.Framework.Assert.GreaterOrEqual(CustomerCount, 50);
        //}
        [TestCase()]
        public void CustomerThresholdValueTest()
        {
            try
            {
                BusinessLogic blCustomerData = new BusinessLogic();
                //check now
                DataTable dt = new DataTable();
                bool bSucess = blCustomerData.MinCustomerCountCheck(10);
                Assert.AreEqual(bSucess, true);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception has been thrown: Error Details : " + ex.Message);
            }
        }

        [TestCase()]
        public void MinBalanceCheckTest()
        {
            try
            {
                BusinessLogic blCustomerData = new BusinessLogic();
                bool bsucess = blCustomerData.MinBalanceCheck(500);
                Assert.AreEqual(bsucess, false);
                bsucess = blCustomerData.MinBalanceCheck(1500);
                //comment below line
                bsucess = false;
                Assert.AreEqual(bsucess, true);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception has been thrown: Error Details : " + ex.Message);
            }
        }
        // runs for each testcase
        [TearDown]
        public void teardown()
        {
        }
    }
}
