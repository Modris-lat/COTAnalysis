using System;
using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.Models
{
    public abstract class CotDataDb: Entity
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int NonCommercialsLong { get; set; }
        public int NonCommercialsShort { get; set; }
        public double NonCommercialsPercentLong { get; set; }
        public double NonCommercialsPercentShort { get; set; }
        public double NonCommercialsNetPositions { get; set; }
        public int CommercialsLong { get; set; }
        public int CommercialsShort { get; set; }
        public double CommercialsPercentLong { get; set; }
        public double CommercialsPercentShort { get; set; }
        public int CommercialsNetPositions { get; set; }
        public int TotalLong { get; set; }
        public int TotalShort { get; set; }
        public int TotalNetPositions { get; set; }
    }
}
