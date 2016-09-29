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
        public void Calculate_Always_CreatesBoxedResultsWithCorrectDataCount()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            BoxedPositionCalculator boxPosCalc = new BoxedPositionCalculator(dataConverterStub, dataFetchStub);
            boxPosCalc.Calculate();

            Assert.IsTrue(boxPosCalc.ResultData.Count == 2, "The path needs to point to 'test_data.csv'");
        }

        [TestMethod]
        public void Calculate_Always_CreatesBoxedResultsWithGoodData()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            BoxedPositionCalculator boxPosCalc = new BoxedPositionCalculator(dataConverterStub, dataFetchStub);
            boxPosCalc.Calculate();
            var splitData = boxPosCalc.ResultData[1].Split(DELIMITER);

            Assert.IsTrue(int.Parse(splitData[2]) == 100, "The path needs to point to 'test_data.csv'");
        }

        [TestMethod]
        public void Calculate_Always_DoesntCreateBoxedResultsWithBadData()
        {
            //Refactor.. dont populate BoxedPositionCalculator.ResultData with header until we have data
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_NOBOXEDPOSNS_PATH);

            BoxedPositionCalculator boxPosCalc = new BoxedPositionCalculator(dataConverterStub, dataFetchStub);
            boxPosCalc.Calculate();

            Assert.IsFalse(boxPosCalc.HasResultData, "Test Data needs to contain whats commented out below!");

            /*
             TEST_DATA_NOBOXEDPOSNS_PATH = 
            trader	broker	symbol	quantity	price
            Anna	DB	IBM.N	100	12
            Anna	DB	JNJ.N	-100	15
            Anna	DB	PEP.N	100	10
            John	DB	IBM.N	200	12
            John	CS	IBM.N	100	12
            John	DB	LLY.N	100	13
            John	ML	MS.N	-100	11
            John	ML	PEP.N	100	10

             */
        }
    }
}
