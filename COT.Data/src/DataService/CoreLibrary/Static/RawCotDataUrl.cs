using System.Collections.Generic;

namespace CoreLibrary.Static
{
    public static class RawCotDataUrl
    {
        public static string ChicagoExchange => "https://www.cftc.gov/dea/futures/deacmesf.htm";
        public static string CommodityExchange => "https://www.cftc.gov/dea/futures/deacmxsf.htm";
        public static string IceFutures => "https://www.cftc.gov/dea/futures/deanybtsf.htm";
        public static string NewYorkExchange => "https://www.cftc.gov/dea/futures/deanymesf.htm";
        public static IDictionary<string, string> UrlList => new Dictionary<string, string>
        {
            {DataType.Currency, ChicagoExchange},
            {DataType.Commodity, CommodityExchange},
            {DataType.Ice, IceFutures},
            {DataType.Energy, NewYorkExchange}
        };
    }
}
