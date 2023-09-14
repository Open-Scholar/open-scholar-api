using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class University
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UniversityId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Adress { get; set; } = string.Empty;
        //[Required]
        //[EmailAddress]
        //public string EmailAddress { get; set; } = string.Empty;
        public string? WebAddress { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
