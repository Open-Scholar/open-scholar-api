using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class BookSeller
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public EmailAddressAttribute EmailAdress { get; set; }
        public string PhoneNumber { get; set;} = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<Book> Books { get; set;} 

    }
}
