using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.UserNotificationDto
{
    public class UserNotificationDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RecieverUserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTimeOffset CreatedAt { get; set; }
        public NotificationType NotificationType { get; set; }
        public int? ReferenceId { get; set; }
    }
}
