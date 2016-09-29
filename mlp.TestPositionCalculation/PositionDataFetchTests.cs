using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mlp.interviews.boxing.problem;

namespace mlp.PositionCalculation.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PositionDataFetchTests
    {
        const string TEST_DATA_PATH = @"..\..\..\..\DataFiles\test_data.csv";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_EmptyPath_ThrowsArgumentNullException()
        {
            PositionDataFetch pdFetch = new PositionDataFetch(null, CreateFileReaderStub());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_NoFileReader_ThrowsArgumentNullException()
        {
            PositionDataFetch pdFetch = new PositionDataFetch("path", null);
        }

        [TestMethod]
        public void Ctr_Always_PopulatesPath()
        {
            string testPath = "TestPath";
            PositionDataFetch pdFetch = new PositionDataFetch(testPath, CreateFileReaderStub());
            Assert.AreEqual(testPath, pdFetch.Path);
        }

        [TestMethod]
         public void GetData_Always_RaturnsData()
        {
            PositionDataFetch pdFetch = new PositionDataFetch(TEST_DATA_PATH, CreateFileReaderStub());
            var resultList = pdFetch.GetData();
            Assert.IsNotNull(resultList);
        }

        IFileReader CreateFileReaderStub()
        {
            IFileReader fileReader = new FileReader();
            return fileReader;
        }
    }
}
