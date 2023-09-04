using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class Professor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfessorId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Subject> Subject { get; set; } = new List<Subject>();
        public List<Faculty> Faculty { get; set; } = new List<Faculty>();
        public List<Book> Books { get; set; } = new List<Book>();

    }
}
