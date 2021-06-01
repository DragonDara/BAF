using AutoMapper;
using BAF.UseCases.Mapping.Resolver;
using BAF.UseCases.Symbol.Dto;
using Binance.Net.Objects.Spot.MarketData;
using Binance.Net.Objects.Spot.SpotData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Mapping
{
    internal class OpenPositionMappingProfile: Profile
    {
        public OpenPositionMappingProfile()
        {
            CreateMap<BinancePrice, OpenPositionDto>()
                .ForMember(dst => dst.CurrentPrice, opt => opt.MapFrom(src => src.Price))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<BinanceOrder, OpenPositionDto>()
                .ForMember(dst => dst.PriceBuy, opt => opt.MapFrom(src => src.Price))
                .ForMember(dst => dst.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForAllOtherMembers(mem => mem.Ignore());

            CreateMap<OpenPositionDto, OpenPositionDto>()
                .ForMember(dst => dst.PriceBuy, opt => opt.MapFrom<PriceBuyResolver>())
                .ForMember(dst => dst.Symbol, opt => opt.MapFrom<SymbolResolver>());
        }
    }
}
