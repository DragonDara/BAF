using AutoMapper;
using BAF.UseCases.Symbol.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Mapping.Resolver
{
    internal class SymbolResolver : IValueResolver<OpenPositionDto, OpenPositionDto, string>
    {
        public string Resolve(OpenPositionDto source, OpenPositionDto destination, string destMember, ResolutionContext context)
        {
            return destination.Symbol;
        }
    }
}
