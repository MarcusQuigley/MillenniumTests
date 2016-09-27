using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
   public static  class FileWriter
    {
       /// <summary>
       /// static method that creates/overwrites a file and writes the data to it.
       /// </summary>
       /// <param name="fileName">The file to create</param>
       /// <param name="data">The data to write to the file</param>
       public static void WriteData(string fileName, IList<string> data)
       {
           if (string.IsNullOrEmpty(fileName))
               throw new ArgumentNullException("fileName");
           if (data == null)
               throw new ArgumentNullException("data");

           System.IO.File.WriteAllLines(fileName, data);
       }
    }
}
