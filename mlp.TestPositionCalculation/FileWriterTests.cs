using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mlp.interviews.boxing.problem;
using System.Collections.Generic;

// public void <Method>_<Scenario>_<ExpectedResult>()

namespace mlp.PositionCalculation.Tests
{
    [TestClass]
    public class FileWriterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteData_Always_FailsIfNoData()
        {
            FileWriter.WriteData("", null);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteData_Always_FailsIfNoFileName()
        {
            FileWriter.WriteData(null, new List<string>(){"data"});
         }

        [TestMethod]
        public void WriteData_Always_CreatesFile()
        {
            //I really need to mock this up by using an interface
  
        }
    }
}
