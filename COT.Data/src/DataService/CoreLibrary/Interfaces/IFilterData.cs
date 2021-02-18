using System.Collections.Generic;
using CoreLibrary.Models;

namespace CoreLibrary.Interfaces
{
    public interface IFilterData
    {
        IList<double> Filter(string inputData, string symbol);
    }
}
