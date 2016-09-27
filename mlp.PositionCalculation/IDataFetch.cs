using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlp.interviews.boxing.problem
{
    public interface IDataFetch
    {
        string Path { get; set; }
        IList<string> GetData();
    }
}
