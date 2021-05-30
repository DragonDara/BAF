using AutoMapper;
using BAF.DataAccess.SqlServer;
using BAF.Entities;
using BAF.UseCases.Auth.ApplicationServices;
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
        private readonly IApplicationDbContext _context;
        private readonly HashBuilder _hash;
        private readonly IMapper _mapper;

        public AuthHandler(IBinanceClient binance, IApplicationDbContext context, HashBuilder hash, IMapper mapper)
        {
            _binance = binance;
            _context = context;
            _hash = hash;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            request.userDto.ApiKeyHash = _hash.CreateHash(request.userDto.ApiKeyHash);
            request.userDto.ApiSecretValueHash = _hash.CreateHash(request.userDto.ApiSecretValueHash);

            var user = _mapper.Map<User>(request.userDto);

            await _context.Users.AddAsync(user, cancellationToken: cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            _binance.SetApiCredentials(request.userDto.ApiKeyHash, request.userDto.ApiSecretValueHash);

            return await Task.FromResult(Unit.Value); ;
        }
    }
}
