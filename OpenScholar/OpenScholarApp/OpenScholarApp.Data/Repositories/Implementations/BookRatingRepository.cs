using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class BookRatingRepository : BaseRepository<BookRating>, IBookRatingRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public BookRatingRepository(OpenScholarDbContext context): base(context)
        {
            _openScholarDbContext = context;
        }

        public async Task<List<BookRating>> GetAllWithUserAndBookAsync()
        {
            return await _openScholarDbContext.BookRatings.Include(s => s.User).Include(a => a.Book).ToListAsync();
        }
    }
}
