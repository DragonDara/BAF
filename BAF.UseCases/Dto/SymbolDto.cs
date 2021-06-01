using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Dto
{
    public class SymbolDto
    {
        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }

        public string BaseQuote
        {
            get
            {
                return BaseCurrency + QuoteCurrency;
            }
        }
    }
}
