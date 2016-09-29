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
        protected const string TEST_DATA_NOBOXEDPOSNS_PATH = @"..\..\..\..\DataFiles\test_data_NoBoxedPositions.csv";
        protected const char DELIMITER = ',';

        protected IDataFetch CreateDataFetchStub(string path)
        {
            return new PositionDataFetch(path, CreateFileReaderStub());
        }

        protected IDataConverter<Position> CreateDataConverter()
        {
            return new PositionDataConverter();
        }

        IFileReader CreateFileReaderStub()
        {
            IFileReader fileReader = new FileReader();
            return fileReader;
        }
    }
}
