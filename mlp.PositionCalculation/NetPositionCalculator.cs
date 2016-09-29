using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    class NetPositionCalculator : PositionCalculator
    {
        public NetPositionCalculator(IDataConverter<Position> converter, IDataFetch dataFetch)
            : base(converter, dataFetch)
        { }
          
        /// <summary>
        /// Calculates the net position
        /// </summary>
        public override void Calculate()
        {
            if (this.Positions != null)
            {
                //Groups by Trader and symbol and adds a dictionary of details based on the group by
                var distinctTradersPositions = this.Positions
                    .GroupBy(p => new { p.TraderName, p.Symbol })
                    .ToDictionary(group => new { group.FirstOrDefault().TraderName, group.FirstOrDefault().Symbol }, grpVal => grpVal.ToList());

                foreach (var positionGroup in distinctTradersPositions)
                {
                    var posData = string.Format("{0}, {1}, {2}", 
                        positionGroup.Key.TraderName, 
                        positionGroup.Key.Symbol, 
                        GetNetPositionCount(positionGroup.Key.TraderName, 
                                            positionGroup.Key.Symbol, 
                                            positionGroup.Value));
                    ResultData.Add(posData);
                }
            }
        }

        /// <summary>
        /// Gets the Net position count for given trader and symbol
        /// </summary>
        /// <param name="trader"></param>
        /// <param name="symbol"></param>
        /// <param name="positions"></param>
        /// <returns>Net position count</returns>
        int GetNetPositionCount(string trader, string symbol, IList<Position> positions)
        {
            if (trader == null)
                throw new ArgumentNullException("trader");
            if (symbol == null)
                throw new ArgumentNullException("symbol");
            if (positions == null)
                throw new ArgumentNullException("positions");

            int netPosCount = 0;
            for (int i = 0; i < positions.Count; i++)
            {
                if (string.Compare(positions[i].TraderName, trader, true) == 0
                    && string.Compare(positions[i].Symbol, symbol, true) == 0)
                    netPosCount += positions[i].Quantity;
            }
            return netPosCount;
        }
    }
}
