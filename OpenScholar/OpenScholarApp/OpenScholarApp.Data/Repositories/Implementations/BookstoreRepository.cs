using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class BookStoreRepository : BaseRepository<BookStore>, IBookStoreRepository
    { 
        private readonly OpenScholarDbContext _openScholarDbContext;

        public BookStoreRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }
        
    }
}
