using BAF.UseCases.Dto;
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
        public SymbolDto Symbol;
        public GetOpenPositionBySymbolQuery(SymbolDto symbol)
        {
            Symbol = symbol;
        }
    }
}
