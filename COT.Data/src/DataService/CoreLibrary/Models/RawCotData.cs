using System;
using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.Models
{
    public class RawCotData: Entity
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string ChicagoExchange { get; set; }
        public string CommodityExchange { get; set; }
        public string IceExchange { get; set; }
        public string NewYorkExchange { get; set; }
    }
}
