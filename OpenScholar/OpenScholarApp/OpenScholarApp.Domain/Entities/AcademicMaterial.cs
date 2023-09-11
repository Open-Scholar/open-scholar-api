using OpenScholarApp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class AcademicMaterial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AcademicMaterialId { get; set; }
        [ForeignKey("PublisherId")]
        public int PublisherId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public AcademicMaterialType Type { get; set; } = AcademicMaterialType.Other;
    }
}
