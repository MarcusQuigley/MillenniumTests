using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    class Program
    {
        static string dataPath = @"C:\Programming\Workspace\GitRepo\Millenium\PositionCalculation\DataFiles\";
        static string testDataFile = "test_data.csv";
        const string netPositionsFile = "net_positions.csv";
        const string boxedPositionsFile = "boxed_positions.csv";
       
        static void Main(string[] args)
        {
            Console.WriteLine("Running 'Position Calculation application'");
            //Console.WriteLine("Enter path and name of test file.");
            //string newArgsString = Console.ReadLine();

            //if (newArgsString.Any())
            //{

            //    dataPath = args[0];
            //    if (args[1] != null)
            //        testDataFile = args[1];
            //}
            string testData = Path.Combine(dataPath, testDataFile);

            IDataConverter<Position> dataConverter = new PositionDataConverter();
            IFileReader fileReader = new FileReader();
            IDataFetch dataFetch = new PositionDataFetch(testData, fileReader);
            IFileWriter fileWriter = new FileWriter();

            RunNetPositions(dataFetch, dataConverter, netPositionsFile, fileWriter);

            RunBoxedPositions(dataFetch, dataConverter, boxedPositionsFile, fileWriter);

            Console.WriteLine("Application finished. Results at '{0}'", dataPath);
            Console.WriteLine("Enter to quit");
            Console.ReadLine();

        }

       

        static void RunNetPositions(IDataFetch fetcher, IDataConverter<Position> converter, string outputFile, IFileWriter fileWriter)
        {
            string netOutputFile = Path.Combine(dataPath, outputFile);
            NetPositionCalculator netPosnCalc = new NetPositionCalculator(converter, fetcher);
            netPosnCalc.Calculate();
            if (netPosnCalc.HasResultData)
            {
                fileWriter.WriteData(netOutputFile, netPosnCalc.ResultData);
            }
        }

        static void RunBoxedPositions(IDataFetch fetcher, IDataConverter<Position> converter, string outputFile, IFileWriter fileWriter)
        {
            string boxedOutputFile = Path.Combine(dataPath, outputFile);
            BoxedPositionCalculator boxPosnCalc = new BoxedPositionCalculator(converter, fetcher);
            boxPosnCalc.Calculate();
            if (boxPosnCalc.HasResultData)
            {
                fileWriter.WriteData(boxedOutputFile, boxPosnCalc.ResultData);
            }
        }

    }
}
