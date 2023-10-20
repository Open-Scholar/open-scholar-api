namespace OpenScholarApp.Dtos.AuthorDto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? EmailAdress { get; set; } = string.Empty;
    }
}
