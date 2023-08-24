using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class Student : ApplicationUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public EmailAddressAttribute EmailAddress { get; set; } = new EmailAddressAttribute();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string FieldOFStudies { get; set; } = string.Empty;
        public Enum StudentStatus { get; set; }
        public int StudentIndexNumber { get; set; }
        public string? Description { get; set; }
        //public University University { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
        public ICollection<AcademicMaterial> AcademicMaterials { get; set; }
    } 
}
