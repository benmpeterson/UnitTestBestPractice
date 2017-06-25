using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        //Use Consts in Unit Testing when possible
        private const string BAD_FILE_NAME = @"C:\NotExists.bad";
        private string _GoodFileName;

        #region Class Init and Cleanup
        [ClassInitialize]
        public static void ClassInit(TestContext tc)
        {
            tc.WriteLine("In the class Init");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //Cleanup
        }
        #endregion

        #region Test Init and Cleanup
        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                //Creates a temp file using app.config then deletes it automatically
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creaing File: " + _GoodFileName);
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine("Creaing File: " + _GoodFileName);
                    File.Delete(_GoodFileName);
                }
            }
        }
        #endregion

        public TestContext TestContext { get; set; }

        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("Ben")]
        [Priority(0)]
        public void FileNameDoesExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;
            TestContext.WriteLine("Testing the file: " + _GoodFileName);
            fromCall = fp.FileExists(_GoodFileName);
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsFalse(fromCall, "File Does NOT Exist.");
        }

        [TestMethod]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }


        [TestMethod]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                // Test was a success
                return;
            }

            // Fail the test
            Assert.Fail("Call to FileExists() did NOT throw an ArgumentNullException.");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000);
        }
    }
}
