using BAF.UseCases.Notification;
using BAF.UseCases.Wallet.Dto;
using MediatR;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAF.UseCases.Wallet.Notificaion
{
    internal class NotificateOpenPositionDispatcher : INotificationHandler<OpenPositionNotificationDto>
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public Task Handle(OpenPositionNotificationDto notification, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendPositionsAsync();
        }
    }
}
