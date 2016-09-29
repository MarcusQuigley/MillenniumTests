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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_EmptyPath_ThrowsArgumentNullException()
        {
            PositionDataFetch pdFetch = new PositionDataFetch(null);
        }

        [TestMethod]
        public void Ctr_Always_PopulatesPath()
        {
            string testPath = "TestPath";
            PositionDataFetch pdFetch = new PositionDataFetch(testPath);
            Assert.AreEqual(testPath, pdFetch.Path);
        }

        [TestMethod]
        [Ignore]
        public void GetData_Always_RaturnsData()
        { 
            //TODO need to refactor FileReader/Writer to interfaces so I can mock them.
        }
    }
}
