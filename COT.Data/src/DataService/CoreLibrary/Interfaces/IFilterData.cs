using System.Collections.Generic;

namespace CoreLibrary.Interfaces
{
    public interface IFilterData
    {
        IList<int> Filter(string inputData, string symbol);
    }
}
