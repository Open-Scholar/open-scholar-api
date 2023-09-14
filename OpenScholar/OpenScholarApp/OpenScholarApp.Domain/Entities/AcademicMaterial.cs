using OpenScholarApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class AcademicMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcademicMaterialId { get; set; }
        [ForeignKey("ApplicationUser")]
        public int PublisherId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public AcademicMaterialType Type { get; set; } = AcademicMaterialType.Other;
    }
}
