using System;
using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.Models
{
    public class CotDataDb: Entity
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double Long { get; set; }
        public double Short { get; set; }
        public double PercentLong { get; set; }
        public double PercentShort { get; set; }
        public double NetPositions { get; set; }
    }
}
