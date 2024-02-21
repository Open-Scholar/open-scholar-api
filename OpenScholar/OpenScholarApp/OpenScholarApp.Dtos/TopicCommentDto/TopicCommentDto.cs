namespace OpenScholarApp.Dtos.TopicCommentDto
{
    public class TopicCommentDto
    {
        public int Id { get; set; }
        public string Comment { get; set; } 
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow; 
        public DateTimeOffset? UpdatedAt { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        //public ApplicationUser? User { get; set; }
        public int TopicId { get; set; }
        //public Topic? Topic { get; set; }
    }
}
