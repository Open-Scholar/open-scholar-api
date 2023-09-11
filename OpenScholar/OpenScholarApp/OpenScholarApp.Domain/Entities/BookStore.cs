﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class BookStore
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookStoreId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Adress { get; set; } = string.Empty;
        public string? EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        //public Book? Book { get; set; }
    }
}
