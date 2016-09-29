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
            IFileWriter fileWriter = CreateFileWriterStub();

            fileWriter.WriteData("", null);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteData_Always_FailsIfNoFileName()
        {
            IFileWriter fileWriter = CreateFileWriterStub();

            fileWriter.WriteData(null, new List<string>() { "data" });
           
            
         }

        [TestMethod]
        [Ignore]
        public void WriteData_Always_CreatesFile()
        {
            //TODO cant test this without a mocking framework
            //IFileWriter fileWriter = CreateFileWriterStub();
            //fileWriter.WriteData("fileName", new List<string>() { "data" });
            //Assert.
        }

        IFileWriter CreateFileWriterStub()
        {
            IFileWriter fileWriter = new FileWriter();
            return fileWriter;
        }
    }
}
