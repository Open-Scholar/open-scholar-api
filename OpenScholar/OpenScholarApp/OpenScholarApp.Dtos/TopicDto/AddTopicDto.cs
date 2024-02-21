namespace OpenScholarApp.Dtos.TopicDto
{
    public class AddTopicDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        //public string UserId { get; set; }
        //public DateTimeOffset? EditedAt { get; set; }
        public int FacultyId { get; set; }
        //public List<TopicComment>? Comments { get; set; }
    }
}
