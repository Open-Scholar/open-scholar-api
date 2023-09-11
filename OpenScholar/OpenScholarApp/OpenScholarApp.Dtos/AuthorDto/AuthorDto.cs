namespace OpenScholarApp.Dtos.AuthorDto
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? EmailAdress { get; set; } = string.Empty;
    }
}
