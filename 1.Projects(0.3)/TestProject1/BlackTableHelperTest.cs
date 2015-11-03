using System;
using CurrencyStore.Business;
using CurrencyStore.Communication;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for BlackTableHelperTest and is intended
    ///to contain all BlackTableHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BlackTableHelperTest
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


        /// <summary>
        ///A test for GetCurrencyNumberBytes
        ///</summary>
        [TestMethod()]
        public void GetCurrencyNumberBytesTest()
        {
            CurrencyBlacklist item = new CurrencyBlacklist()
            {
                CurrencyKindCode = 0,
                FaceAmount = 100,
                CurrencyVersion = 2005,
                CurrencyNumber = "HD12345678"
            };

            byte[] actual;
            actual = BlackTableHelper.GetCurrencyNumberBytes(item);
            var temp = Unity.GetCurrencyNo(actual, 5);
            Assert.IsTrue(temp == item.CurrencyNumber);
        }
    }
}
