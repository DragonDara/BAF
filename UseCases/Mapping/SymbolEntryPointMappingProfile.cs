using AutoMapper;
using BAF.UseCases.Mapping.Resolver;
using BAF.UseCases.Spot.Dto;
using BAF.UseCases.Symbol.Dto;
using BAF.UseCases.Wallet.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Mapping
{
    internal class SymbolEntryPointMappingProfile: Profile
    {
        public SymbolEntryPointMappingProfile()
        {
            CreateMap<BinancePriceDto, SymbolEntryPointDto>()
                .ForMember(dst => dst.CurrentPrice, opt => opt.MapFrom(src => src.Price));

            CreateMap<SymbolPriceBuyDto, SymbolEntryPointDto>()
                .ForMember(dst => dst.PriceBuy, opt => opt.MapFrom(src => src.PriceBuy));

            CreateMap<SymbolEntryPointDto, SymbolEntryPointDto>()
                .ForMember(src => src.PriceBuy, opt => opt.MapFrom<PriceBuyResolver>());
        }
    }
}
