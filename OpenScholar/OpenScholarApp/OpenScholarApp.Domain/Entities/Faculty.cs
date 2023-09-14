using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OpenScholarApp.Domain.Entities
{
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacultyId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        //[Required]
        //[EmailAddress]
        //public string EmailAddress { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; }
        public string? Description { get; set; } = string.Empty;
        public University? University { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
