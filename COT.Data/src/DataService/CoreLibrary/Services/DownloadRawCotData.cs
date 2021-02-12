using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CoreLibrary.Interfaces;

namespace CoreLibrary.Services
{
    public class DownloadRawCotData: WebClient, IDownloadRawCotData
    {
        private readonly IDictionary<string, string> _rawCotData;
        private readonly IDictionary<string, string> _urlList;

        public DownloadRawCotData(IDictionary<string, string> urlList)
        {
            _rawCotData = new Dictionary<string, string>{};
            _urlList = urlList;
        }
        public async Task<IDictionary<string, string>> Download()
        {
            foreach (var item in _urlList)
            {
                _rawCotData.Add(item.Key, await DownloadStringTaskAsync(item.Value));
            }

            return _rawCotData;
        }
    }
}
