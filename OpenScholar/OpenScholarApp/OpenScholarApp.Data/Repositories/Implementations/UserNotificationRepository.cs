using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class UserNotificationRepository : BaseRepository<UserNotification>, IUserNotificationRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public UserNotificationRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<(IEnumerable<UserNotification> Items, int UnreadCount, int TotalCount)> GetByUserIdAndMarkAsReadPagedAsync(string userId, int pageNumber = 1, int pageSize = 10)
        {
            var allNotifications = await _openScholarDbContext.UserNotifications
                                        .Where(n => n.UserId == userId)
                                        .ToListAsync();

            var unreadCount = allNotifications.Count(n => !n.IsRead);
            var totalCount = allNotifications.Count;
            var paginatedItems = allNotifications
                                    .OrderByDescending(n => n.CreatedAt)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

            var unreadPaginatedItems = paginatedItems.Where(n => !n.IsRead).ToList();
            if (unreadPaginatedItems.Any())
            {
                unreadPaginatedItems.ForEach(item => item.IsRead = true);
            }

            await _openScholarDbContext.SaveChangesAsync();
            return (paginatedItems, unreadCount, totalCount);
        }

        public async Task<int> UnreadNotificationsCount(string userId)
        {
           var result =  _openScholarDbContext.UserNotifications
                                .Where(n => n.UserId == userId && n.IsRead == false)
                                .Count();

            return result;
        }

        public async Task<List<UserNotification>> MarkAllNotificationsAsRead(string userId)
        {
            var notifications = await _openScholarDbContext.UserNotifications
                                .Where(n => n.UserId == userId && !n.IsRead)
                                .OrderByDescending(t => t.CreatedAt)
                                .ToListAsync();

            notifications.ForEach(n => n.IsRead = true);
            await _openScholarDbContext.SaveChangesAsync();
            return notifications;
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _openScholarDbContext.UserNotifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _openScholarDbContext.SaveChangesAsync();
            }
        }
    }
}
