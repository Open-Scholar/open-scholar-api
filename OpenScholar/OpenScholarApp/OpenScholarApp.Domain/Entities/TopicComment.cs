namespace OpenScholarApp.Domain.Entities
{
    public class TopicComment
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int TopicId { get; set; } 
        public Topic? Topic { get; set; }
        public List <TopicCommentLike> Likes { get; set; }
    }
}
