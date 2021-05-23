using BAF.UseCases.Wallet.Dto;
using Binance.Net.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Enums;
using AutoMapper;
using Binance.Net.Objects.Spot.SpotData;

namespace BAF.UseCases.Wallet.Queries
{
    public class GetSymbolPriceBuyHandler : IRequestHandler<GetSymbolPriceBuyQuery, SymbolPriceBuyDto>
    {
        private readonly IBinanceClient _binance;
        private readonly IMapper _mapper;

        public GetSymbolPriceBuyHandler(IBinanceClient binance, IMapper mapper)
        {
            _binance = binance ?? throw new ArgumentNullException(nameof(binance));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<SymbolPriceBuyDto> Handle(GetSymbolPriceBuyQuery request, CancellationToken cancellationToken)
        {
            _binance.SetApiCredentials("9K33biWrOtX8zSsgNnHMKPS6mEpWSeNkwgL8ld0w6ezgzYnK3v5BfMy7WqLvA4eW", "UDdE4t8hb1sZLUEAFkPkTxOtAizaLPulX076GsLeXav0u6EsjwqlRkUUSH8JxcSb");

            var orders = await _binance.Spot.Order.GetAllOrdersAsync(request.Symbol, ct: cancellationToken);

            // TODO Handle errors properly(create own exception handler)
            if (!orders.Success && !(orders.Error is null)) throw new Exception(orders.Error.Message);

            var orderFilledStatus = orders.Data.Where(o => o.Status == OrderStatus.Filled && o.Side == OrderSide.Buy).Last();

            var symbolPriceButDto = _mapper.Map<SymbolPriceBuyDto>(orderFilledStatus);

            return symbolPriceButDto;
        }
    }
}
