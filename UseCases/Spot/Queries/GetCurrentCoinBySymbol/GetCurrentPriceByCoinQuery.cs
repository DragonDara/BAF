using BAF.UseCases.Spot.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Spot.Queries
{
    public class GetCurrentPriceByCoinQuery: IRequest<BinancePriceDto>
    {
        public string Symbol;
        public GetCurrentPriceByCoinQuery(string symbol)
        {
            Symbol = symbol;
        }
    }
}
