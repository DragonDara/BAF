using BAF.UseCases.Auth;
using BAF.UseCases.Auth.Dto;
using MediatR;
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
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Register an user
        /// </summary>
        /// <param name="userDto">
        /// Stores data, such as password, api key, api secret value
        /// </param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<Unit> Register(UserDto userDto)
        {
            // TODO Apply here cancellation token and figure out why it needs
            return await _mediator.Send(new AuthQuery(userDto));
        }

    }
}
