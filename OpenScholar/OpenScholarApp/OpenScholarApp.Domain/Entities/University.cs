using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class University
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UniversityId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Adress { get; set; } = string.Empty;
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string WebAdress { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
