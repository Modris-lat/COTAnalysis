using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CoreLibrary.Interfaces;

namespace CoreLibrary.Services
{
    public class DownloadRawCotData: WebClient, IDownloadRawCotData
    {
        private readonly IDictionary<string, string> _rawCotData;

        public DownloadRawCotData()
        {
            _rawCotData = new Dictionary<string, string>{};
        }
        public async Task<IDictionary<string, string>> Download(IDictionary<string, string> urlList)
        {
            foreach (var item in urlList)
            {
                _rawCotData.Add(item.Key, await DownloadStringTaskAsync(item.Value));
            }

            return _rawCotData;
        }
    }
}
