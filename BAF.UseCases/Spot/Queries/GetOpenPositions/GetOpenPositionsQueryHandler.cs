using AutoMapper;
using BAF.Common;
using BAF.Entities.Exceptions;
using BAF.UseCases.Spot.Extensions;
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

namespace BAF.UseCases.Spot.Queries.GetOpenPositions
{
    internal class GetOpenPositionsQueryHandler : IRequestHandler<GetOpenPositionsQuery, IList<OpenPositionDto>>
    {

        private readonly IBinanceClient _binance;
        private readonly IMapper _mapper;

        public GetOpenPositionsQueryHandler(IBinanceClient binance, IMapper mapper)
        {
            _binance = binance ?? throw new ArgumentNullException(nameof(binance));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IList<OpenPositionDto>> Handle(GetOpenPositionsQuery request, CancellationToken cancellationToken)
        {

            //https://github.com/JKorf/Binance.Net/issues/768#issuecomment-858573615

            _binance.SetApiCredentials("9K33biWrOtX8zSsgNnHMKPS6mEpWSeNkwgL8ld0w6ezgzYnK3v5BfMy7WqLvA4eW", "UDdE4t8hb1sZLUEAFkPkTxOtAizaLPulX076GsLeXav0u6EsjwqlRkUUSH8JxcSb");

            var allBalances = await _binance.General.GetAccountInfoAsync(ct: cancellationToken);
            var assets = allBalances.Data.Balances.Where(b => b.Total != 0).ExcludeCoins();
            if(!assets.Any())
                throw new BalancesNotFoundException();


            IList<OpenPositionDto> openPositions = new List<OpenPositionDto>();

            foreach(var balance in assets)
            {
                string symbol = balance.Asset;
                var currentPrice = await _binance.Spot.Market.GetPriceAsync(symbol + GlobalConst.QuoteCurrency, cancellationToken);
                var orders = await _binance.Spot.Order.GetAllOrdersAsync(symbol + GlobalConst.QuoteCurrency, ct: cancellationToken);
                var buyPrice = orders.Data.Where(o => o.Status == OrderStatus.Filled && o.Side == OrderSide.Buy).LastOrDefault();

                if (buyPrice == null) continue;

                var symbolEntryPointDto1 = _mapper.Map<OpenPositionDto>(currentPrice.Data);
                var symbolEntryPointDto2 = _mapper.Map<OpenPositionDto>(buyPrice);

                var merged = _mapper.Map(symbolEntryPointDto1, symbolEntryPointDto2);

                openPositions.Add(merged);
            }

            return openPositions;
        }
    }
}
