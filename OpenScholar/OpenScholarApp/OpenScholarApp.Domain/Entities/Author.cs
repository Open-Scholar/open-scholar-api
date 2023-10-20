using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Book Book { get; set; }
        [ForeignKey("Id")]
        [Required]
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? BirthDate { get; set; } = string.Empty;
        [EmailAddress]
        public string? EmailAddress { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
