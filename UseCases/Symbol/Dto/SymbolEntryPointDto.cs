using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Symbol.Dto
{
    public class SymbolEntryPointDto
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }

        public decimal PriceBuy { get; set; }
    }
}
