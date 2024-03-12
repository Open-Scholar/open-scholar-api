using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Domain.Entities
{
    public class UserNotification
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string RecieverUserId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public NotificationType NotificationType { get; set; }
        public int? ReferenceId { get; set; } 
        public ApplicationUser? User { get; set; }
    }
}
