using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Dtos.FacultyDto
{
    public class AddFacultyDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
