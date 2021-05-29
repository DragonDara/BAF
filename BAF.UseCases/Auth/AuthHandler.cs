using Binance.Net.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAF.UseCases.Auth
{
    public class AuthHandler : IRequestHandler<AuthQuery>
    {
        private readonly IBinanceClient _binance;

        public AuthHandler(IBinanceClient binance)
        {
            _binance = binance;
        }

        public Task<Unit> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            _binance.SetApiCredentials(request.userDto.ApiKeyHash, request.userDto.ApiSecretValueHash);


            return Task.FromResult(Unit.Value); ;
        }
    }
}
