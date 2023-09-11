using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public string? Description { get; set; }
        [ForeignKey("PublisherId")]
        public string PublisherId { get; set; } = string.Empty;
        public List<Author> Authors { get; set; } = new List<Author>() { };
    }
}
