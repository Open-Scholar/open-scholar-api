namespace OpenScholarApp.Dtos.TopicCommentDto
{
    public class UpdateTopicCommentDto
    {
        //public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        //public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; }
        //public string UserId { get; set; }
        //public int TopicId { get; set; }
    }
}
