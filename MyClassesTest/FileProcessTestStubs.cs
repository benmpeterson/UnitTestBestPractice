using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyClasses;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTestStubs
    {
        [TestMethod]
        [Ignore()]
        public void FileNameDoesExist()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        [Ignore()]
        public void FileNameDoesNotExist()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        [Ignore()]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            Assert.Inconclusive();
        }
    }
}
