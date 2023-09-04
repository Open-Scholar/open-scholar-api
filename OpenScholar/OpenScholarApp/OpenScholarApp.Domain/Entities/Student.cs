using OpenScholarApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public string EmailAddress { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string FieldOFStudies { get; set; } = string.Empty;
        public StudentStatus StudentStatus { get; set; } = StudentStatus.Graduate;
        public int StudentIndexNumber { get; set; }
        public string? Description { get; set; }
        //public University University { get; set; }
        public List<Faculty> Faculties { get; set; } = new List<Faculty>();
        public List<AcademicMaterial> AcademicMaterials { get; set; } = new List<AcademicMaterial>();
    } 
}
