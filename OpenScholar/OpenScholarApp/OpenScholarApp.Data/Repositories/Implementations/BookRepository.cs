using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{

    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly OpenScholarDbContext _context;

        public BookRepository(OpenScholarDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
