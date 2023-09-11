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
    }
}
