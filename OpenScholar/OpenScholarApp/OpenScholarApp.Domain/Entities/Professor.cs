using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class Professor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfessorId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Subject> Subject { get; set; } = new List<Subject>();
        public List<Book> Books { get; set; } = new List<Book>();

    }
}
