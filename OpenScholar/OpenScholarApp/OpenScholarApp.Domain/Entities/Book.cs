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
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public List<Author> Authors { get; set; } = new List<Author>();
        //public List<string> AuthorId { get; set; } 
    }
}
