﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Domain.Entities
{
    public class BookStore
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Book Book { get; set; }
        public ICollection<Book> Books { get; set;}
    }
}
