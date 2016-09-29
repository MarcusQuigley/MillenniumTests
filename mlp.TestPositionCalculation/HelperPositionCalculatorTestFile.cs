using mlp.interviews.boxing.problem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.PositionCalculation.Tests
{
   public class HelperPositionCalculatorTestFile
    {
        protected const string TEST_DATA_PATH = @"..\..\..\..\DataFiles\test_data.csv";

        protected IDataFetch CreateDataFetchStub(string path)
        {
            return new PositionDataFetch(path);
        }

        protected IDataConverter<Position> CreateDataConverter()
        {
            return new PositionDataConverter();
        }
    }
}
