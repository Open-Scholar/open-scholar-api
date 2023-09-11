namespace OpenScholarApp.Dtos.BookSellerDto
{
    public class BookSellerDto
    {
        public int BookSellerId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        //public List<Book> Books { get; set; } = new List<Book>();
    }
}
