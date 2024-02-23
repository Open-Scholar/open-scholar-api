using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Dtos.TopicDto
{
    public class TopicDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string? UserName { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset? EditedAt { get; set; }
        public int FacultyId { get; set; }
        public int TopicLikeCount { get; set; } = 0;
        public int TopicCommentCount { get; set; } = 0;
        public bool IsLikedByUser { get; set; } = false;
    }
}
