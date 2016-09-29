using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mlp.interviews.boxing.problem;
using System.Collections.Generic;

namespace mlp.PositionCalculation.Tests
{
    [TestClass]
    public class BoxedPositionCalculatorTests : HelperPositionCalculatorTestFile
    {
        [TestMethod]
        public void Calculate_Always_PopulatesResultData()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            BoxedPositionCalculator boxPosCalc = new BoxedPositionCalculator(dataConverterStub, dataFetchStub);
            boxPosCalc.Calculate();
            Assert.IsTrue(boxPosCalc.ResultData.Count > 1);
        }

        [TestMethod]
        public void Calculate_Always_PopulatesResultDataWithString()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            BoxedPositionCalculator boxPosCalc = new BoxedPositionCalculator(dataConverterStub, dataFetchStub);
            boxPosCalc.Calculate();
            Assert.IsInstanceOfType(boxPosCalc.ResultData[1], typeof(string));
        }

        [TestMethod]
        public void Calculate_Always_DoesntPopulateResultIfNoPositions()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub("BADPATH");

            BoxedPositionCalculator boxPosCalc = new BoxedPositionCalculator(dataConverterStub, dataFetchStub);
            boxPosCalc.Calculate();
            Assert.IsTrue(boxPosCalc.ResultData.Count == 1);
        }

        [TestMethod]
        public void Calculate_Always_CreatesBoxedResultsWithGoodData()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            BoxedPositionCalculator boxPosCalc = new BoxedPositionCalculator(dataConverterStub, dataFetchStub);
            boxPosCalc.Calculate();
            Assert.IsTrue(boxPosCalc.ResultData.Count == 2);
        }

        [TestMethod]
        [Ignore]
        public void Calculate_Always_CreatesBoxedResultsWithBadData()
        {//Need to implement this properly, most probably by refactoring
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            BoxedPositionCalculator boxPosCalc = new BoxedPositionCalculator(dataConverterStub, dataFetchStub);
            boxPosCalc.Calculate();
            Assert.IsTrue(boxPosCalc.ResultData.Count == 2);
        }

        //IList<string> CreateBoxedTestData()
        //{
        //    List<string> testData = new List<string>(){ 
        //                "trader,broker,symbol,quantity,price",
        //                "Anna,DB,PEP.N,100,10",
        //                "John,DB,IBM.N,200,12",
        //                "John,CS,IBM.N,-100,12",
        //                "John,DB,LLY.N,100,13",
        //                "John,ML,MS.N,-100,11",
        //                "John,ML,PEP.N,100,10",
        //                "Julie,DB,BABY.N,-300,16"

        //    };
        //    return testData;
        //}
    }
}
