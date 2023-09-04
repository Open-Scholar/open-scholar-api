using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        public AccountType AccountType { get; set; }
    }
}
