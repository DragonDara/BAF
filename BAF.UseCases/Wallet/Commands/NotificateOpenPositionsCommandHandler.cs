using BAF.UseCases.Spot.Queries.GetOpenPositions;
using BAF.UseCases.Symbol.Dto;
using BAF.UseCases.Wallet.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAF.UseCases.Wallet.Commands
{
    internal class NotificateOpenPositionsCommandHandler : IRequestHandler<NotificateOpenPositionsCommand>
    {
        private readonly IMediator _mediator;

        public NotificateOpenPositionsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(NotificateOpenPositionsCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(new TimeSpan(0, 0, 15)).ContinueWith(async (o) =>
              {
                  Debug.WriteLine("test123412");
                  await _mediator.Publish(new OpenPositionNotificationDto(), cancellationToken);
              }
            );
            

            return Unit.Value;
        }
    }
}
