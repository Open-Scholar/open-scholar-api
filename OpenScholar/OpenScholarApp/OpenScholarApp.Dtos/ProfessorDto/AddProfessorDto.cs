using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Dtos.ProfessorDto
{
    public class AddProfessorDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Subject> Subject { get; set; } = new List<Subject>();
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
