using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    public static class FileReader
    {
        /// <summary>
        /// Returns an collection of strings from path if valid
        /// </summary>
        /// <param name="path">Path of file</param>
        /// <returns>IEnumerable of string</returns>
        public static IEnumerable<string> ReadData(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            var lines = File.ReadLines(path);
            return lines;
        }
    }
}
