using BAF.UseCases.Spot.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Spot.Queries
{
    public class GetCurrentPriceBySymbolQuery: IRequest<BinancePriceDto>
    {
        public string Symbol;
        public GetCurrentPriceBySymbolQuery(string symbol)
        {
            Symbol = symbol;
        }
    }
}
