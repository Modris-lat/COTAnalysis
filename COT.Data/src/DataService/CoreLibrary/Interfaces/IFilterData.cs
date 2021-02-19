using System.Collections.Generic;

namespace CoreLibrary.Interfaces
{
    public interface IFilterData
    {
        IList<double> Filter(string inputData, string symbol);
    }
}
