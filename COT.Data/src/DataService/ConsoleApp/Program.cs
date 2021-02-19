using System;
using System.Threading.Tasks;
using CoreLibrary.Interfaces;
using CoreLibrary.Services;
using CoreLibrary.Static;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IDownloadRawCotData downloadRawCotData = new DownloadRawCotData();
            IFilterData filter = new FilterData();

            var data = await downloadRawCotData.Download(RawCotDataUrl.UrlList);
            var rub = filter.Filter(data["currency"], Symbols.Rub);
            var aud = filter.Filter(data["currency"], Symbols.Aud);
            var gold = filter.Filter(data["commodity"], Symbols.Gold);
            var usd = filter.Filter(data["ice"], Symbols.Usd);
            var oil = filter.Filter(data["energy"], Symbols.CrudeOil);
            Console.WriteLine($"RUB: {string.Join(" ", rub)}");
            Console.WriteLine($"AUD: {string.Join(" ", aud)}");
            Console.WriteLine($"Gold: {string.Join(" ", gold)}");
            Console.WriteLine($"Usd: {string.Join(" ", usd)}");
            Console.WriteLine($"Oil: {string.Join(" ", oil)}");
        }
    }
}
