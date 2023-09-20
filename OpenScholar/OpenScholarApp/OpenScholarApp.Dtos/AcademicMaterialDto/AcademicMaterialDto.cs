using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.AcademicMaterialDto
{
    public class AcademicMaterialDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public AcademicMaterialType Type { get; set; } = AcademicMaterialType.Other;
    }
}
