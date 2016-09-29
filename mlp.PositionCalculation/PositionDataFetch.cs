using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    class PositionDataFetch : IDataFetch
    {
        public string Path { get; set; }

        public IFileReader FileReader { get; set; }

        public PositionDataFetch(string path, IFileReader fileReader)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            if (fileReader == null)
                throw new ArgumentNullException("fileReader");

            this.Path = path;
            this.FileReader = fileReader;
        }

        /// <summary>
        /// Reads data from path and returns as list of strings
        /// </summary>
        /// <returns>list of strings</returns>
        public IList<string> GetData()
        {
            try
            {
                var data = this.FileReader.ReadData(this.Path);
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
