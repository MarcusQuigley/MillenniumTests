using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
   class PositionDataConverter : IDataConverter<Position>
    {
        private char delimiter = ',';

        public PositionDataConverter() 
        { }

        public IList<Position> Convert(IList<string> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            List<Position> result = new List<Position>();

            //I assume that the data will contain a header line
            if (data.Count > 1)
            {
                foreach (string line in data.Skip(1)) //skip header
                {
                    string[] splitResult = line.Split(delimiter);
                    result.Add(new Position()
                    {
                        TraderName = splitResult[0],
                        Broker = splitResult[1],
                        Symbol = splitResult[2],
                        //exercise states that all data will be valid so no need to use TryParse here. Would not happen in real world
                        Quantity = int.Parse(splitResult[3]),
                        Price = decimal.Parse(splitResult[4])
                    });
                }
            }

            return result;
        }
    }
}
