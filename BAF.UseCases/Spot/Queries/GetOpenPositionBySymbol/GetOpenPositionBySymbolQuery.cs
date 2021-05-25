using BAF.UseCases.Symbol.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Symbol.GetEntryPointBySymbol
{
    public class GetOpenPositionBySymbolQuery: IRequest<OpenPositionDto>
    {
        public string Symbol;
        public GetOpenPositionBySymbolQuery(string symbol)
        {
            Symbol = symbol;
        }
    }
}
