using OpenScholarApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Dtos.UniversityDto
{
    public class UniversityDto
    {
        public int Id { get; set; }
        public ApplicationUser? User { get; set; }
        [ForeignKey("Id")]
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string? WebAddress { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
