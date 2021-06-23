using BAF.UseCases.Dto;
using BAF.UseCases.Spot.Queries.GetOpenPositions;
using BAF.UseCases.Symbol.Dto;
using BAF.UseCases.Symbol.GetEntryPointBySymbol;
using BAF.UseCases.Wallet.Dto;
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

        [HttpGet("get-open-positions")]
        public async Task<IList<OpenPositionDto>> GetOpenPositionBySymbolAsync()
        {
            await _mediator.Publish(new OpenPositionNotificationDto());
            // TODO Apply here cancellation token and figure out why it needs
            return await _mediator.Send(new GetOpenPositionsQuery());
        }

        [HttpGet("get-open-position")]
        public async Task<OpenPositionDto> GetOpenPositionBySymbolAsync([FromQuery]SymbolDto symbol)
        {
            // TODO Apply here cancellation token and figure out why it needs
            return await _mediator.Send(new GetOpenPositionBySymbolQuery(symbol));
        }
    }
}
