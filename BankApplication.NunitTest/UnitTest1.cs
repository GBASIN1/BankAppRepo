using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace BankApplication.NunitTest
{
   [TestFixture]
    public class UnitTest1
    {
             //once for all the whole test cases
        [TestFixtureSetUp]
        public void fixtureSetup()
        { 

        }

        // runs for each testcase
        [SetUp]
        public void setup()
        { 

        }

        // test case
        [TestCase]
        public void testMethod1()
        {
            CustomerDetailsBL custDetails = new CustomerDetailsBL();
            int CustomerCount = custDetails.GetNumberOfcustomer("ICICI");
            NUnit.Framework.Assert.GreaterOrEqual(CustomerCount, 50);
        }
        
        // runs for each testcase
        [TearDown]
        public void teardown()
        { 
        }

        [TestFixtureTearDown]
        public void fixtureteardown()
        { }
        
    }
}
