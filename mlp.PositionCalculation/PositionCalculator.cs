using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    abstract class PositionCalculator
    {
        IList<Position> positions;
        IDataConverter<Position> converter;
        const string RESULTS_HEADER = "TRADER,SYMBOL,QUANTITY";

        protected PositionCalculator(IDataConverter<Position> converter)
        {
            if (converter == null)
                throw new ArgumentNullException("converter");
 
            this.converter = converter;

            ResultData = new List<string>();
            ResultData.Add(RESULTS_HEADER);

            try
            {
                var csvData = converter.GetData();
               // if (csvData)
                this.positions = converter.Convert(csvData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         }

        /// <summary>
        /// The IDataConverter that will create a list of Positions
        /// </summary>
        public IDataConverter<Position> Converter { get { return converter; } }

        /// <summary>
        /// A list of Positions
        /// </summary>
        public IList<Position> Positions { get { return positions; } }

        /// <summary>
        /// the result that needs to be write to file.
        /// </summary>
        public IList<String> ResultData { get; protected set; }

        public bool HasResultData
        {
            get { return ResultData.Count > 1; }
        }

        /// <summary>
        /// Method that must be implemented that will calculate the end result
        /// </summary>
        public abstract void Calculate();
    }
}
