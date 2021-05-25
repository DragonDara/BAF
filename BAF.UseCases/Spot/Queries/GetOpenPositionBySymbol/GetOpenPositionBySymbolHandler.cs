using AutoMapper;
using BAF.UseCases.Symbol.Dto;
using Binance.Net.Enums;
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
    internal class GetOpenPositionBySymbolHandler : IRequestHandler<GetOpenPositionBySymbolQuery, OpenPositionDto>
    {
        private readonly IMediator _mediator;
        private readonly IBinanceClient _binance;
        private readonly IMapper _mapper;

        public GetOpenPositionBySymbolHandler(IMediator mediator, IBinanceClient binance, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _binance = binance ?? throw new ArgumentNullException(nameof(binance));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OpenPositionDto> Handle(GetOpenPositionBySymbolQuery request, CancellationToken cancellationToken)
        {
            _binance.SetApiCredentials("9K33biWrOtX8zSsgNnHMKPS6mEpWSeNkwgL8ld0w6ezgzYnK3v5BfMy7WqLvA4eW", "UDdE4t8hb1sZLUEAFkPkTxOtAizaLPulX076GsLeXav0u6EsjwqlRkUUSH8JxcSb");

            var currentPrice = await _binance.Spot.Market.GetPriceAsync(request.Symbol, cancellationToken);
            var orders = await _binance.Spot.Order.GetAllOrdersAsync(request.Symbol, ct: cancellationToken);
            var buyPrice = orders.Data.Where(o => o.Status == OrderStatus.Filled && o.Side == OrderSide.Buy).Last();

            var symbolEntryPointDto1 = _mapper.Map<OpenPositionDto>(currentPrice.Data);
            var symbolEntryPointDto2 = _mapper.Map<OpenPositionDto>(buyPrice);

            var merged = _mapper.Map(symbolEntryPointDto1, symbolEntryPointDto2);

            return merged;
        }
    }
}
