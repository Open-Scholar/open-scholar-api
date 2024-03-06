namespace OpenScholarApp.Dtos.TopicDto
{
    public class AddTopicDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int FacultyId { get; set; }
    }
}
