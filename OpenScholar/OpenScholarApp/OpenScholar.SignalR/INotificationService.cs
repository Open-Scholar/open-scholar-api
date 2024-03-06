namespace OpenScholarApp.SignalR
{
    public interface INotificationService
    {
        Task SendNotification(string userId, string message);
    }
}
