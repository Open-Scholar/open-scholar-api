namespace OpenScholarApp.Domain.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTimeOffset? EditedAt { get; set; }
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public List<TopicComment>? Comments { get; set; }
        public List<TopicLike>? Likes { get; set; }
    }
}
