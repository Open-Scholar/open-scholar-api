﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class Professor : ApplicationUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public string? Description { get; set; }
        public ICollection<Faculty> Faculty { get; set; } = new List<Faculty>();

    }
}
