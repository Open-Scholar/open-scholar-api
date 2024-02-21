namespace OpenScholarApp.Dtos.TopicCommentDto
{
    public class UpdateTopicCommentDto
    {
        public string Comment { get; set; } = string.Empty;
        //public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow; 
        public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        //public string? UserId { get; set; }
        //public ApplicationUser? User { get; set; }
        //public int TopicId { get; set; }
        //public Topic? Topic { get; set; }

    }
}
