using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Dtos.BookDto
{
    public class RemoveBookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string PublisherId { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = new List<Author>() { };
    }
}
