namespace OpenScholarApp.Dtos.BookSellerDto
{
    public class AddBookSellerDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
