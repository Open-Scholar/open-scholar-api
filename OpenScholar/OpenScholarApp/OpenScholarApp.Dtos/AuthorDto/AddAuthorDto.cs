namespace OpenScholarApp.Dtos.AuthorDto
{
    public class AddAuthorDto
    {
        public string FirstName { get; set; } = string.Empty;
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? EmailAdress { get; set; } = string.Empty;
    }
}
