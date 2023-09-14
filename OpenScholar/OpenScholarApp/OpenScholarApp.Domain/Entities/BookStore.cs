using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class BookStore
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookStoreId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Adress { get; set; } = string.Empty;
        //[Required]
        //[EmailAddress]
        //public string EmailAddress { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; }
        public string? Description { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; } 
        //public Book? Book { get; set; }
    }
}
