using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class Student3 : IdentityUser
    {
        public bool IsDeleted3 { get; set; }
    }
}
