using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAppWeb.BL;
using System.Data;
namespace BankApplication.BL.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod()]
        //public void LoadCustomerDataTest()
        //{
        //    try
        //    {
        //        BusinessLogic blCustomerData = new BusinessLogic();
        //        //check now
        //        DataTable dt = new DataTable();
        //        int noOfRecord;
        //        dt = blCustomerData.GetCustomerDetails(out noOfRecord);
        //        Assert.IsTrue(dt.Rows.Count > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail("Exception has been thrown: Error Details : " + ex.Message);
        //    }
        //}

        [TestMethod()]
        public void BalanceCheckMethodTest()
        {
            try
            {
                BusinessLogic blCustomerData = new BusinessLogic();
                bool bsucess = blCustomerData.MinBalanceCheck(500);
                Assert.AreEqual(bsucess, false);
                bsucess = blCustomerData.MinBalanceCheck(1500);
                Assert.AreEqual(bsucess, true);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception has been thrown: Error Details : " + ex.Message);
            }
        }

        //[TestMethod()]
        //public void AddCustomerDataTest()
        //{
        //    try
        //    {
        //        BusinessLogic blCustomerData = new BusinessLogic();
        //        //check now
        //        DataTable dt = new DataTable();
        //        CustDetail custDetail = new CustDetail();
        //        custDetail.AccountNumber = "3446422";
        //        custDetail.CustomerID = "3456222";
        //        custDetail.CustomerName = "UnitTestUser";
        //        custDetail.DOB = DateTime.Now.ToString();
        //        custDetail.EmailAddress = "charmi@infosys.com";
        //        custDetail.MaritalStatus = "Married";
        //        bool bSuccess = blCustomerData.InsertCustomerData(custDetail);
        //        Assert.AreEqual(bSuccess.ToString().ToLower(), "true");
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail("Exception has been thrown: Error Details : " + ex.Message);
        //    }
        //}
    }
}
