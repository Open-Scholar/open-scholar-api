using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        public AccountType AccountType { get; set; }
    }
}
