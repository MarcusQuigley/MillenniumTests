using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    class PositionDataFetch : IDataFetch
    {
        public string Path { get; set; }

        public PositionDataFetch(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            this.Path = path;
        }

        public IList<string> GetData()
        {
            try
            {
                var data = FileReader.ReadData(this.Path);
                return new List<string>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception reading data. {0}", ex);
                throw ex;
            }
        }
    }
}
