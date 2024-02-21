namespace OpenScholarApp.Dtos.BookStoreDto
{
    public class BookStoreDto
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BusinessName { get; set; }
        public string Adress { get; set; } = string.Empty;
        public int RegistrationNumber { get; set; }
        public int TaxNumber { get; set; }
        public string ContactEmail { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}
