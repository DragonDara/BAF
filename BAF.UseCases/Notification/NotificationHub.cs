
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BAF.UseCases.Notification
{
    public class NotificationHub : Hub
    {
        public async Task SendPositionsAsync()
        {
            await Clients.All.SendAsync("Test", "Hi");
        }
    }
}
