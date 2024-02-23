namespace OpenScholarApp.Dtos.TopicCommentDto
{
    public class UpdateTopicCommentDto
    {
        public string Comment { get; set; } = string.Empty;
        public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
