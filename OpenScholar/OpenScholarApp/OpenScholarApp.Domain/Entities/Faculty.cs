using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacultyId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        //public University? University { get; set; }
    }
}
