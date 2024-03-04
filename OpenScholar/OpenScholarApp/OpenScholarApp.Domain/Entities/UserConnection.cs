namespace OpenScholarApp.Domain.Entities
{
    public class UserConnection
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ConnectionId { get; set; }
        public DateTimeOffset ConnectedAt { get; set; }
    }
}
