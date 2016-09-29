using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    public interface IFileReader
    {
        IEnumerable<string> ReadData(string path);
    }
}
