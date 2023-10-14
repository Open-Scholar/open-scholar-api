using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OpenScholarApp.Dtos.StudentDto
{
    public class StudentDto
    {
        public string UserId { get; set; } = string.Empty;
        public int Id { get; set; }
        //public string EmailAddress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string FieldOFStudies { get; set; } = string.Empty;
        public StudentStatus StudentStatus { get; set; } = StudentStatus.Graduate;
        public int StudentIndexNumber { get; set; }
        public string? Description { get; set; }
        public List<Faculty>? Faculties { get; set; } = new List<Faculty>();
        public List<AcademicMaterial>? AcademicMaterials { get; set; } = new List<AcademicMaterial>();
        [JsonIgnore]
        [ForeignKey("Id")]
        public ApplicationUser? User { get; set; }
    }
}
