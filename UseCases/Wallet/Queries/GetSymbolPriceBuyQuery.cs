using BAF.UseCases.Wallet.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Wallet.Queries
{
    public class GetSymbolPriceBuyQuery: IRequest<SymbolPriceBuyDto>
    {
        public string Symbol;
        public GetSymbolPriceBuyQuery(string symbol)
        {
            Symbol = symbol;
        }
    }
}
