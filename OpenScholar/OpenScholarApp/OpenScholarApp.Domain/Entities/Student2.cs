using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class Student2 : IdentityUser
    {
        public int Student2ID { get; set; }
        public bool IsDeleted2 { get; set; }
        public string testesteeeeeed { get; set; } = string.Empty;
        public int blabla { get; set; }
    }
}
