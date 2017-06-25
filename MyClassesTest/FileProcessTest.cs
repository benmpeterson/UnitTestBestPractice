using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
  [TestClass]
  public class FileProcessTest
  {
        //Use Consts in Unit Testing when possible
        private const string BAD_FILE_NAME = @"C:\NotExists.bad";

    [TestMethod]
    public void FileNameDoesExist() {
      FileProcess fp = new FileProcess();
      bool fromCall;

      fromCall = fp.FileExists(@"C:\Windows\Regedit.exe");

      Assert.IsTrue(fromCall);
    }

    [TestMethod]
    public void FileNameDoesNotExist() {
      FileProcess fp = new FileProcess();
      bool fromCall;

      fromCall = fp.FileExists(BAD_FILE_NAME);

      Assert.IsFalse(fromCall);
    }

    [TestMethod]
    public void FileNameNullOrEmpty_ThrowsArgumentNullException() {
      FileProcess fp = new FileProcess();

      try {
        fp.FileExists("");
      }
      catch (ArgumentNullException) {
        // Test was a success
        return;
      }

      // Fail the test
      Assert.Fail("Call to FileExists() did NOT throw an ArgumentNullException.");
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingAttribute() {
      FileProcess fp = new FileProcess();
      
      fp.FileExists("");
    }
  }
}
