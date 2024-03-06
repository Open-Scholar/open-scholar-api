using Microsoft.AspNetCore.SignalR;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.HubExceptions;

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
            try
            {
                var userId = Context.UserIdentifier;
                var connectionId = Context.ConnectionId;
                await _connectionManagerRepository.AddConnectionAsync(userId, connectionId);
                await base.OnConnectedAsync();
            }
            catch (HubOnConnectDataException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                var connectionId = Context.ConnectionId;
                await _connectionManagerRepository.RemoveConnectionAsync(connectionId);
                await base.OnDisconnectedAsync(exception);
            }
            catch (HubOnDisconnectDataException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public Task SendNotificationToUser(string userId, string message)
        {
            return Clients.User(userId).SendAsync("ReceiveNotification", message);
        }

        public Task SendConnectedMessage(string message)
        {
            return Clients.Caller.SendAsync(message);
        }
    }
}
