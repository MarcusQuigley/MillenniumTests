using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mlp.interviews.boxing.problem;

namespace mlp.PositionCalculation.Tests
{
    [TestClass]
    public class NetPositionCalculatorTests : HelperPositionCalculatorTestFile
    {

        #region START OF PositionCalculator Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_Always_FailsIfNoIDataConverter()
        {
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            NetPositionCalculator netPosCalc = new NetPositionCalculator(null, dataFetchStub);
         }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_Always_FailsIfNoIDataFetch()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();

            NetPositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, null);
        }

        [TestMethod]
        public void Ctr_Always_CreatesResultData()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            NetPositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, dataFetchStub);
            Assert.IsNotNull(netPosCalc.ResultData);
        }

        [TestMethod]
         public void Ctr_Always_AddsHeaderToResultData()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            NetPositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, dataFetchStub);

              string RESULTS_HEADER = "TRADER,SYMBOL,QUANTITY";
            Assert.AreEqual(RESULTS_HEADER, netPosCalc.ResultData[0]);
        }

        [TestMethod]
         public void Ctr_Always_CreatesPositions()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            NetPositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, dataFetchStub);
            
            Assert.IsNotNull(netPosCalc.Positions);
        }
        #endregion END OF PositionCalculator Tests

        #region START OF NetPositionCalculator Tests

        [TestMethod]
        public void Calculate_Always_PopulatesResultData()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            NetPositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, dataFetchStub);
            netPosCalc.Calculate();
            Assert.IsTrue(netPosCalc.ResultData.Count > 1);
        }

        [TestMethod]
        public void Calculate_Always_PopulatesResultDataWithString()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            NetPositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, dataFetchStub);
            netPosCalc.Calculate();
            Assert.IsInstanceOfType(netPosCalc.ResultData[1], typeof(string));
        }

        [TestMethod]
        public void Calculate_Always_DoesntPopulateResultIfNoPositions()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub("BADPATH");

            NetPositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, dataFetchStub);
            netPosCalc.Calculate();
            Assert.IsTrue(netPosCalc.ResultData.Count == 1);
        }

        [TestMethod]
        public void Calculate_Always_CreatesNetResultsWithCorrectDataCount()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            PositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, dataFetchStub);
            netPosCalc.Calculate();
            Assert.IsTrue(netPosCalc.ResultData.Count == 20);
        }

        [TestMethod]
        public void Calculate_Always_CreatesNetResultsWithGoodData()
        {
            IDataConverter<Position> dataConverterStub = CreateDataConverter();
            IDataFetch dataFetchStub = CreateDataFetchStub(TEST_DATA_PATH);

            PositionCalculator netPosCalc = new NetPositionCalculator(dataConverterStub, dataFetchStub);
            netPosCalc.Calculate();
            var splitData = netPosCalc.ResultData[2].Split(DELIMITER);

            Assert.IsTrue(int.Parse(splitData[2]) == -100, "The path needs to point to 'test_data.csv'");
             
        }

        
        #endregion END OF NetPositionCalculator Tests

      
    }
}
