using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IUserNotificationRepository : IBaseRepository<UserNotification>
    {
        Task<(IEnumerable<UserNotification> Items, int UnreadCount, int TotalCount)> GetByUserIdAndMarkAsReadPagedAsync(string userId, int pageNumber = 1, int pageSize = 10);
        Task MarkAsReadAsync(int notificationId);
        Task<int> UnreadNotificationsCount(string userId);
    }
}
