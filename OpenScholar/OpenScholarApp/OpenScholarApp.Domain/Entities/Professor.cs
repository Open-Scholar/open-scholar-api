using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class Professor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ApplicationUser UserId { get; set; }
        [ForeignKey("Id")]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? BirthDate { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public List<Subject> Subject { get; set; } = new List<Subject>();
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
