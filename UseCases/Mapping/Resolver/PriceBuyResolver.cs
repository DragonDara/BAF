using AutoMapper;
using BAF.UseCases.Spot.Dto;
using BAF.UseCases.Symbol.Dto;
using BAF.UseCases.Wallet.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Mapping.Resolver
{
    internal class PriceBuyResolver : IValueResolver<SymbolEntryPointDto, SymbolEntryPointDto, decimal>
    {
        public decimal Resolve(SymbolEntryPointDto source, SymbolEntryPointDto destination, decimal destMember, ResolutionContext context)
        {
            return destination.PriceBuy;
        }
    }
}
