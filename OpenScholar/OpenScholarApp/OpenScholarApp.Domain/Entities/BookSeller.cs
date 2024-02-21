namespace OpenScholarApp.Domain.Entities
{
    public class BookSeller
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Adress { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<Book>? Books { get; set; } = new List<Book>();
    }
}
