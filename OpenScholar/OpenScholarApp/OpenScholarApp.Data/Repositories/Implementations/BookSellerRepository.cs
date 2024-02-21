using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class BookSellerRepository : BaseRepository<BookSeller>, IBookSellerRepository
    {

        private readonly OpenScholarDbContext _openScholarDbContext;

        public BookSellerRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<BookSeller>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.BookSellers.Include(s => s.User).ToListAsync();
        }

        public async Task<BookSeller> GetByUserIdAsync(string userId)
        {
            return await _openScholarDbContext.BookSellers
                        .FirstOrDefaultAsync(s => s.User != null && s.User.Id == userId);
        }
    }
}
