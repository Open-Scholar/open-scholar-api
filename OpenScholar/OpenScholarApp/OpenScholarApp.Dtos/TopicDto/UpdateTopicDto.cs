namespace OpenScholarApp.Dtos.TopicDto
{
    public class UpdateTopicDto
    {
        //public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTimeOffset? EditedAt { get; set; } = DateTimeOffset.UtcNow;

    }
}
