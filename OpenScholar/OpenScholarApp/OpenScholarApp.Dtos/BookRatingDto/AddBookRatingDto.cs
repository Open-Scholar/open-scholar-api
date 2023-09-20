using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Dtos.BookRatingDto
{
    public class AddBookRatingDto
    {
        public int RatingStars { get; set; }
        public string Review { get; set; } = string.Empty;
        public string UserId { get; set; }
        public int BookId { get; set; }
        public DateTimeOffset RatedOn { get; set; } = DateTimeOffset.UtcNow;
    }
}
