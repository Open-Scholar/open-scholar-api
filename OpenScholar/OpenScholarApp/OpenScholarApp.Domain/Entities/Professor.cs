namespace OpenScholarApp.Domain.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? BirthDate { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public int universityId { get; set; }
        public University? University { get; set; }
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public string Expertise { get; set; } = string.Empty;
        public List<Subject>? Subject { get; set; } = new List<Subject>();
        public List<Book>? Books { get; set; } = new List<Book>();
    }
}
