using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLibrary.Interfaces
{
    public interface IDownloadRawCotData
    {
        Task<IDictionary<string, string>> Download();
    }
}
