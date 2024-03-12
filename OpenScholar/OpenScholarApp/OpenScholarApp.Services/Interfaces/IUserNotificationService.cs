using OpenScholarApp.Dtos.UserNotificationDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IUserNotificationService
    {
        Task<UserNotificationPagedDto<UserNotificationDto>> GetUserNotificationsAsync(string userId, int pageNumber = 1, int pageSize = 10);
        Task<Response> MarkNotificationAsReadAsync(string userId, int notificationId);
        Task<Response> GetUnreadNotificationsCount(string userId);
    }
}
