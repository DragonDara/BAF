using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAF.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("auth")]
        public async Task Auth(string symbol)
        {
            // TODO Apply here cancellation token and figure out why it needs
            return await _mediator.Send(new GetOpenPositionBySymbolQuery(symbol));
        }

    }
}
