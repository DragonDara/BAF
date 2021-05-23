using AutoMapper;
using BAF.UseCases.Spot.Queries;
using BAF.UseCases.Symbol.Dto;
using BAF.UseCases.Wallet.Queries;
using Binance.Net.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAF.UseCases.Symbol.GetEntryPointBySymbol
{
    internal class GetEntryPointBySymbolHandler : IRequestHandler<GetEntryPointBySymbolQuery, SymbolEntryPointDto>
    {
        private readonly IMediator _mediator;
        private readonly IBinanceClient _binance;
        private readonly IMapper _mapper;

        public GetEntryPointBySymbolHandler(IMediator mediator, IBinanceClient binance, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _binance = binance ?? throw new ArgumentNullException(nameof(binance));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SymbolEntryPointDto> Handle(GetEntryPointBySymbolQuery request, CancellationToken cancellationToken)
        {
            var currentPrice = await _mediator.Send(new GetCurrentPriceBySymbolQuery(request.Symbol), cancellationToken);
            var buyPrice = await  _mediator.Send(new GetSymbolPriceBuyQuery(request.Symbol), cancellationToken);

            var symbolEntryPointDto1 = _mapper.Map<SymbolEntryPointDto>(currentPrice);
            var symbolEntryPointDto2 = _mapper.Map<SymbolEntryPointDto>(buyPrice);

            var merged = _mapper.Map(symbolEntryPointDto1, symbolEntryPointDto2);

            return merged;
        }
    }
}
