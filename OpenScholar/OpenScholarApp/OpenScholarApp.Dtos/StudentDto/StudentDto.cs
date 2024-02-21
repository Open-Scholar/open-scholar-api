using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.StudentDto
{
    public class StudentDto
    {
        public string ApplicationUserId { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string? FieldOFStudies { get; set; } = string.Empty;
        public StudentStatus StudentStatus { get; set; } = StudentStatus.Graduate;
        public int StudentIndexNumber { get; set; }
        public string? Description { get; set; }
        public int UniversityId { get; set; }
        public int FacultyId { get; set; }
    }
}
