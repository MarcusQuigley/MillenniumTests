using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    class BoxedPositionCalculator : PositionCalculator
    {

        public BoxedPositionCalculator(IDataConverter<Position> converter, IDataFetch dataFetch)
            : base(converter, dataFetch)
        { }

        /// <summary>
        /// Calculates the boxed position
        /// </summary>
        public override void Calculate()
        {
            if (this.Positions != null)
            {
                //Groups by Trader and symbol and adds a dictionary of details based on the group by
                var distinctTradersPositions = this.Positions
                  .GroupBy(p => new { p.TraderName, p.Symbol })
                  .ToDictionary(group => new { group.FirstOrDefault().TraderName, group.FirstOrDefault().Symbol }, grpVal => grpVal.ToList());

                foreach (var netPosGroup in distinctTradersPositions)
                {
                    int boxedQty = 0;
                    bool isBoxedPosition = TryGetBoxedPositions(netPosGroup.Value, ref boxedQty);

                    if (isBoxedPosition)
                    {
                        var posData = string.Format("{0}, {1}, {2}",
                            netPosGroup.Key.TraderName,
                            netPosGroup.Key.Symbol,
                            Math.Abs(boxedQty));
                        ResultData.Add(posData);
                    }
                }
            }
        }

        /// <summary>
        /// Checks to see if list of positions has both a positive and negative quantity.
        /// If so then returns true and the absolute value of the minimum quantity
        /// </summary>
        /// <param name="listOfPositions"></param>
        /// <param name="boxedQuantity">absolute value of the minimum quantity</param>
        /// <returns></returns>
        bool TryGetBoxedPositions(List<Position> listOfPositions, ref int boxedQuantity)
        {
            if (listOfPositions == null)
                throw new ArgumentNullException("listOfPositions");

            if (listOfPositions.Count < 2)
                return false;

            bool hasLongPosition = false;
            bool hasShortPosition = false;

            for (int i = 0; i < listOfPositions.Count; i++)
            {
                if (listOfPositions[i].Quantity > 0)
                    hasLongPosition = true;
                if (listOfPositions[i].Quantity < 0)
                {
                    hasShortPosition = true;
                    boxedQuantity += listOfPositions[i].Quantity;
                }
            }

            if (hasLongPosition && hasShortPosition)
            {
                boxedQuantity = Math.Abs(boxedQuantity);
                return true;
            }

            return false;
        }
    }
}
