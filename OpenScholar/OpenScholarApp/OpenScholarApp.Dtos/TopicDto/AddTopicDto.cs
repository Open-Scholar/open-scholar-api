namespace OpenScholarApp.Dtos.TopicDto
{
    public class AddTopicDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public int FacultyId { get; set; }
    }
}
