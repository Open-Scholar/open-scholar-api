using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ApplicationUser UserId { get; set; }
        [ForeignKey("Id")]
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}
