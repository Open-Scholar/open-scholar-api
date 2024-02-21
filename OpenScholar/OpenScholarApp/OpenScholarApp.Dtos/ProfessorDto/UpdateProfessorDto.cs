namespace OpenScholarApp.Dtos.ProfessorDto
{
    public class UpdateProfessorDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; }
        public string? BirthDate { get; set; }
        public string? Description { get; set; }
        public int UniversityId { get; set; }
        public int FacultyId { get; set; }
        public string Expertise { get; set; }
    }
}
