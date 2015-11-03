using System;
using System.Collections.Generic;
using CurrencyStore.Common.Query;
using CurrencyStore.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyStore.Entity;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for DBHelperTest and is intended
    ///to contain all DBHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBHelperTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void ExecutePagingListTest()
        {
            var script = @"Select * From TBL_DEVICE_INFO WHERE PKID >10 ORDER BY PKID";
            var paging = new Pagination() { CurrentPageIndex = 0, PageSize = 25, Paging = true };
            var result = DbHelper.ExecutePagingList<DeviceInfo>(script, paging);
            Assert.IsTrue(result != null);
        }


        [TestMethod()]
        public void ExecutePagingListTestWithCustomerConvert()
        {
            var script = @"Select * From TBL_CURRENCY_INFO WHERE PKID >10 ORDER BY PKID";
            var paging = new Pagination() { CurrentPageIndex = 0, PageSize = 2, Paging = true };
            var result = DbHelper.ExecutePagingList<CurrencyInfo>(script, paging, Convert);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result[0].CurrencyImage.Length > 0);
        }

        private bool Convert(CurrencyInfo item, string field, object value)
        {
            if (string.Compare(field, "CurrencyImage", true) != 0)
                return false;
            item.CurrencyImage = CurrencyStore.Common.Helper.ToBytes(value.ToString());
            return true;
        }
    }
}
