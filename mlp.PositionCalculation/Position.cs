using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    public class Position
    {
        /// <summary>
        /// Name of trader
        /// </summary>
        public string TraderName { get; set; }

        /// <summary>
        /// Broker code
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("T : {0} B : {1} S : {2} Q : {3} P : {4}",
                TraderName, Broker, Symbol, Quantity, Price);
        }

    }
}
