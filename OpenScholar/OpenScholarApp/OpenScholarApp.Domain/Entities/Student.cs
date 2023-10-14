using OpenScholarApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ApplicationUser? User { get; set; }
        [ForeignKey("Id")]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string BirthDate { get; set; } = string.Empty;
        [Required]
        public string FieldOFStudies { get; set; } = string.Empty;
        [Required]
        public StudentStatus StudentStatus { get; set; } = StudentStatus.Graduate;
        [Required]
        public int StudentIndexNumber { get; set; }
        public string? Description { get; set; }
        public List<Faculty>? Faculties { get; set; } = new List<Faculty>();
        public List<AcademicMaterial>? AcademicMaterials { get; set; } = new List<AcademicMaterial>();
    } 
}
