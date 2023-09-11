using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.StudentDto
{
    public class UpdateStudentDto
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string FieldOFStudies { get; set; } = string.Empty;
        public StudentStatus StudentStatus { get; set; } = StudentStatus.Graduate;
        public int StudentIndexNumber { get; set; }
        public string? Description { get; set; }
        public List<Faculty>? Faculties { get; set; } = new List<Faculty>();
        public List<AcademicMaterial>? AcademicMaterials { get; set; } = new List<AcademicMaterial>();
    }
}
