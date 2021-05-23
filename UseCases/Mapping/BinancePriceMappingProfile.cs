using AutoMapper;
using BAF.UseCases.Spot.Dto;
using Binance.Net.Objects.Spot.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Spot.Mapping
{
    internal class BinancePriceMappingProfile: Profile
    {
        public BinancePriceMappingProfile()
        {
            CreateMap<BinancePrice, BinancePriceDto>();
        }
    }
}
