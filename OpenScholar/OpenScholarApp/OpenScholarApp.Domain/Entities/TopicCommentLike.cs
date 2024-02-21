namespace OpenScholarApp.Domain.Entities
{
    public class TopicCommentLike
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int TopicCommentId { get; set; }
        public TopicComment? TopicComment { get; set; }
    }
}
