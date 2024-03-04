namespace OpenScholarApp.SignalR
{
    public interface INotificationService
    {
        Task SendLikeNotification(string userId, string message);
    }
}
