using AutoMapper;
using BAF.UseCases.Wallet.Dto;
using Binance.Net.Objects.Spot.SpotData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Wallet.Mapping
{
    internal class SymbolPriceBuyMappingProfile: Profile
    {
        public SymbolPriceBuyMappingProfile()
        {
            CreateMap<BinanceOrder, SymbolPriceBuyDto>()
                .ForMember(dst => dst.PriceBuy, opt => opt.MapFrom(src => src.Price))
                .ForMember(dst => dst.Symbol, opt => opt.MapFrom(src => src.Symbol));
        }
    }
}
