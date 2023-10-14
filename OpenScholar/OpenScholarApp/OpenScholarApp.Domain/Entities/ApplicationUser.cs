using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        public AccountType AccountType { get; set; }

        //Acc types
        public List<Student>? Students { get; set; } = new List<Student>();
        public List<Professor>? Professors { get; set; } = new List<Professor>();
        public List<Faculty>? Faculty { get; set;} = new List<Faculty>();
        public List<University>? University { get; set; } = new List<University>();
        public List<BookStore>? BookStores { get; set; } = new List<BookStore>();
        public List<BookSeller>? BookSellers { get; set; } = new List<BookSeller>();
    }
}
