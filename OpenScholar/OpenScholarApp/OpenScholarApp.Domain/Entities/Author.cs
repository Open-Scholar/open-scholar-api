using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? EmailAdress { get; set; } = string.Empty;
    }
}
