using BAF.UseCases.Spot.Dto;
using BAF.UseCases.Spot.Queries;
using BAF.UseCases.Symbol.Dto;
using BAF.UseCases.Symbol.GetEntryPointBySymbol;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAF.Controller.Controllers
{
    [ApiController]
    [Route("spot")]
    public class SpotController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SpotController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("get-entry-point/{symbol}")]
        public async Task<SymbolEntryPointDto> GetEntryPointAsync(string symbol)
        {
            // TODO Apply here cancellation token and figure out why it needs
            return await _mediator.Send(new GetEntryPointBySymbolQuery(symbol));
        }
    }
}
