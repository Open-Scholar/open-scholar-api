namespace OpenScholarApp.Dtos.BookRatingDto
{
    public class BookRatingDto
    {
        public int Id { get; set; }
        public int RatingStars { get; set; }
        public string Review { get; set; } = string.Empty;
        public string UserId { get; set; }
        public int BookId { get; set; }
        public DateTimeOffset RatedOn { get; set; } = DateTimeOffset.Now;
    }
}
