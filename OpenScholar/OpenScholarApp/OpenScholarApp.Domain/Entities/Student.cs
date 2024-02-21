using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string? FieldOFStudies { get; set; } = string.Empty;
        public StudentStatus StudentStatus { get; set; } = StudentStatus.Graduate;
        public int StudentIndexNumber { get; set; }
        public string? Description { get; set; }
        public int UniversityId { get; set; }
        public University? University { get; set; }
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public List<AcademicMaterial>? AcademicMaterials { get; set; } = new List<AcademicMaterial>();
    } 
}
