using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class BookSeller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookSellerId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("BookId")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string PhoneNumber { get; set;} = string.Empty;
        public string? Description { get; set; } = string.Empty;
        //public List<Book> Books { get; set; } = new List<Book>(); 

    }
}
