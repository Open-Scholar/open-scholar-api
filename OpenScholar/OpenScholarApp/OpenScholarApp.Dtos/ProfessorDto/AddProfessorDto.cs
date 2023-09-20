using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Dtos.ProfessorDto
{
    public class AddProfessorDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
