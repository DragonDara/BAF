using AutoMapper;
using BAF.UseCases.Symbol.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Mapping.Resolver
{
    internal class PriceBuyResolver : IValueResolver<OpenPositionDto, OpenPositionDto, decimal>
    {
        public decimal Resolve(OpenPositionDto source, OpenPositionDto destination, decimal destMember, ResolutionContext context)
        {
            return destination.PriceBuy;
        }
    }
}
