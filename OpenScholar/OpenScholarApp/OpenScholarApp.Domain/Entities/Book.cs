using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string PublisherId { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        public int? NumOfPages { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Description { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>() { };
    }
}
