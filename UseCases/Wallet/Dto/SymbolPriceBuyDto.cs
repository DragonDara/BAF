using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Wallet.Dto
{
    public class SymbolPriceBuyDto
    {
        public string Symbol { get; set; }
        public decimal PriceBuy { get; set; }
    }
}
