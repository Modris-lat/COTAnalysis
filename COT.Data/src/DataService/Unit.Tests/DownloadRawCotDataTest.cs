using System.Threading.Tasks;
using CoreLibrary.Interfaces;
using CoreLibrary.Services;
using CoreLibrary.Static;
using Xunit;

namespace Unit.Tests
{
    public class DownloadRawCotDataTest
    {
        private readonly IDownloadRawCotData _download;

        public DownloadRawCotDataTest()
        {
            _download = new DownloadRawCotData();
        }

        [Fact]
        public async Task DownloadReturnFourItems()
        {
            var data = await _download.Download(RawCotDataUrl.UrlList);
            int actualItemCount = data.Count;
            int expectedItemsCount = 4;
            Assert.Equal(expectedItemsCount, actualItemCount);
        }
    }
}
