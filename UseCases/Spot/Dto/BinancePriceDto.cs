using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Spot.Dto
{
    public class BinancePriceDto
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
