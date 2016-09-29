using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mlp.interviews.boxing.problem;
using System.Collections.Generic;

namespace mlp.PositionCalculation.Tests
{
    [TestClass]
    public class PositionDataConverterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Convert_Always_FailsIfNoData()
        {
            PositionDataConverter posDataConverter = new PositionDataConverter();
            posDataConverter.Convert(null);
        }

        [TestMethod]
        public void Convert_Always_ReturnsExpectedCount()
        {
            PositionDataConverter posDataConverter = new PositionDataConverter();
            var result = posDataConverter.Convert(CreateTestData());
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void Convert_Always_ReturnsExpectedType()
        {
            PositionDataConverter posDataConverter = new PositionDataConverter();
            var result = posDataConverter.Convert(CreateTestData());
            Assert.IsInstanceOfType(result[0], typeof(Position));
        }

        
        IList<string> CreateTestData()
        {
            List<string> testData = new List<string>(){ 
                        "trader,broker,symbol,quantity,price",
                        "Anna,DB,IBM.N,100,12",
                        "Anna,DB,JNJ.N,-100,15",
                        "Anna,DB,PEP.N,100,10",
                        "John,DB,IBM.N,200,12",
                        "John,CS,IBM.N,-100,12"
            };
            return testData;
        }
    }
}
