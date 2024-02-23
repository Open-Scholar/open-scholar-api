namespace OpenScholarApp.Dtos.TopicCommentDto
{
    public class AddTopicCommentDto
    {
        public string Comment { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow; 
        public int TopicId { get; set; }
    }
}
