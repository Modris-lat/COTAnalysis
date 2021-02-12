using System.Collections.Generic;
using CoreLibrary.Models;

namespace CoreLibrary.Interfaces
{
    public interface IFilterData
    {
        IEnumerable<CotDataDb> Filter(string data);
    }
}
