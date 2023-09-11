using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OpenScholarApp.Domain.Entities
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("CreatorId")]
        public string CreatorId { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string SubjectName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int? EKSTCredits { get; set; }
        [AllowNull]
        public Faculty Faculty { get; set; } 
    }
}
