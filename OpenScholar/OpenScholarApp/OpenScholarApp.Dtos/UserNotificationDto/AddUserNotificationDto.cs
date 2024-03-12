using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.UserNotificationDto
{
    public class AddUserNotificationDto
    {
        public string UserId { get; set; }
        public string RecieverUserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public NotificationType NotificationType { get; set; }
        public int? ReferenceId { get; set; }
    }
}
