﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class BookSeller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ApplicationUser? User { get; set; }
        [ForeignKey("Id")]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Adress { get; set; } = string.Empty;
        public string? PhoneNumber { get; set;} = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
