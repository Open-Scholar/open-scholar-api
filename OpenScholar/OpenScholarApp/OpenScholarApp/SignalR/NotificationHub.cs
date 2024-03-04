using Microsoft.AspNetCore.SignalR;
using OpenScholarApp.Data.Repositories.Interfaces;

namespace OpenScholarApp.SignalR
{
    public class NotificationHub : Hub
    {

        private readonly IConnectionManagerRepository _connectionManagerRepository;

        public NotificationHub(IConnectionManagerRepository connectionManagerRepository)
        {
            _connectionManagerRepository = connectionManagerRepository;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            var connectionId = Context.ConnectionId;
            await _connectionManagerRepository.AddConnectionAsync(userId, connectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            await _connectionManagerRepository.RemoveConnectionAsync(connectionId);
            await base.OnDisconnectedAsync(exception);
        }

        public Task SendNotificationToUser(string userId, string message)
        {
            return Clients.User(userId).SendAsync("ReceiveNotification", message);
        }
    }
}
