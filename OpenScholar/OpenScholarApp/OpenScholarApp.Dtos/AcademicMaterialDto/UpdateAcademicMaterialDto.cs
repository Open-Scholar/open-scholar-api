using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.AcademicMaterialDto
{
    public class UpdateAcademicMaterialDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public AcademicMaterialType Type { get; set; } = AcademicMaterialType.Other;
    }
}
