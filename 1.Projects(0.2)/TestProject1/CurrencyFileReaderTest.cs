using System;
using System.Linq;
using CurrencyStore.Communication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{


    /// <summary>
    ///This is a test class for CurrencyFileReaderTest and is intended
    ///to contain all CurrencyFileReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CurrencyFileReaderTest
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
        ///A test for ReadHeader
        ///</summary>
        [TestMethod()]
        public void ReadHeaderTest()
        {
            string file = @"F:\Working Folder\Project\CurrencyStore\4.Documents\项目参考资料\20130507.SVD";
            CurrencyFileReader target = new CurrencyFileReader(file); // TODO: Initialize to an appropriate value
            FileHeader actual;
            actual = target.FileHeader;
            Assert.IsNotNull(actual);
            var lst = target.Read(false).ToArray();
            Assert.IsTrue(actual.SumRecords == lst.Length);
            target.Dispose();
        }
    }
}
