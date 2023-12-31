﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OpenScholarApp.Domain.Entities
{
    public class BookRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("Id")]
        public Book Book { get; set; }
        [ForeignKey("Id")]
        [AllowNull]
        [Range(1, 5, ErrorMessage = "Ratings must be between 1 and 5.")]
        public int RatingStars { get; set; }
        [MaxLength(100)]
        public string Review { get; set; } = string.Empty;
        //public DateTimeOffset RatedOn { get; set; }
    }
}
