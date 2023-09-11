namespace OpenScholarApp.Dtos.BookStoreDto
{
    public class AddBookStoreDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string? EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
