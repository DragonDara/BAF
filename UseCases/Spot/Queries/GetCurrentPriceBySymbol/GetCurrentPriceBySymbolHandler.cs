using AutoMapper;
using BAF.UseCases.Spot.Dto;
using Binance.Net.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAF.UseCases.Spot.Queries
{
    internal class GetCurrentPriceBySymbolHandler : IRequestHandler<GetCurrentPriceBySymbolQuery, BinancePriceDto>
    {
        private readonly IBinanceClient _binanceClient;
        private readonly IMapper _mapper;

        public GetCurrentPriceBySymbolHandler(IBinanceClient binanceClient, IMapper mapper)
        {
            _binanceClient = binanceClient ?? throw new ArgumentNullException(nameof(binanceClient));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BinancePriceDto> Handle(GetCurrentPriceBySymbolQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var price = await _binanceClient.Spot.Market.GetPriceAsync(request.Symbol, cancellationToken);

                // TODO Handle errors properly(create own exception handler)
                if (!price.Success && !(price.Error is null)) throw new Exception(price.Error.Message);

                var binancePriceDto = _mapper.Map<BinancePriceDto>(price.Data);

                return binancePriceDto;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
