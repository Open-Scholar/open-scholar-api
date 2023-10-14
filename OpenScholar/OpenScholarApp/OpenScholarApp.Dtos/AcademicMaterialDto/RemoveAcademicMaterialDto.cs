using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.AcademicMaterialDto
{
    public class RemoveAcademicMaterialDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public AcademicMaterialType Type { get; set; } = AcademicMaterialType.Other;
    }
}
