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
        public int BookStoreId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }
        public List<Book> Books { get; set;} = new List<Book>();
    }
}