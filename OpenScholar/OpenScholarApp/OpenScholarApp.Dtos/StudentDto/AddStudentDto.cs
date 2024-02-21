using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.StudentDto
{
    public class AddStudentDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string? FieldOFStudies { get; set; } = string.Empty;
        public StudentStatus StudentStatus { get; set; } = StudentStatus.Graduate;
        public int UniversityId { get; set; }
        public int FacultyId { get; set; }
        public int StudentIndexNumber { get; set; }
        public string? Description { get; set; }
    }
}
