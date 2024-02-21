namespace OpenScholarApp.Domain.Entities
{
    public class BookStore
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public int RegistrationNumber { get; set; }
        public int TaxNumber { get; set; }
        public string ContactEmail { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
