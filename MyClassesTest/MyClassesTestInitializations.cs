using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClassesTest
{
    /// <summary>
    /// Assembly Init and CleanUpMethods
    /// </summary>
    [TestClass]
    public class MyClassesTestInitializations
    {

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext tc)
        {
            tc.WriteLine("Assembly Init Method");
            //Create resrouces needed for your tests.
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //Clean up any resrouces by your tests.
        }
    }
}
