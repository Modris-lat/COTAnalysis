using System;
using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.Models
{
    public abstract class CotDataDb: Entity
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Non Commercials Long")]
        public int NonCommercialsLong { get; set; }
        [Display(Name = "Non Commercials Short")]
        public int NonCommercialsShort { get; set; }
        [Display(Name = "Non Commercials % Long")]
        public double NonCommercialsPercentLong { get; set; }
        [Display(Name = "Non Commercials % Short")]
        public double NonCommercialsPercentShort { get; set; }
        [Display(Name = "Non Commercials Net Positions")]
        public double NonCommercialsNetPositions { get; set; }
        [Display(Name = "Commercials Long")]
        public int CommercialsLong { get; set; }
        [Display(Name = "Commercials Short")]
        public int CommercialsShort { get; set; }
        [Display(Name = "Commercials % Long")]
        public double CommercialsPercentLong { get; set; }
        [Display(Name = "Commercials % Short")]
        public double CommercialsPercentShort { get; set; }
        [Display(Name = "Commercials Net Positions")]
        public int CommercialsNetPositions { get; set; }
        [Display(Name = "Total Long")]
        public int TotalLong { get; set; }
        [Display(Name = "Total Short")]
        public int TotalShort { get; set; }
        [Display(Name = "Total Net Positions")]
        public int TotalNetPositions { get; set; }
    }
}
