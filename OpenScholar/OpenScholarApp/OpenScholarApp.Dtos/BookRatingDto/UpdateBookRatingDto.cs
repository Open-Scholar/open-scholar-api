using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Dtos.BookRatingDto
{
    public class UpdateBookRatingDto
    {
        public int Id { get; set; }
        public int RatingStars { get; set; }
        public string Review { get; set; } = string.Empty;
        public string UserId { get; set; }
        public int BookId { get; set; }
        public DateTimeOffset RatedOn { get; set; } = DateTimeOffset.Now;
    }
}
