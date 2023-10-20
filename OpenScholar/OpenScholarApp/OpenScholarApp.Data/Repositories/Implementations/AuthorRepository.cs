using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public AuthorRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<Author>> GetAllWithBookAsync()
        {
            return await _openScholarDbContext.Authors.Include(s => s.Book).ToListAsync();
        }
    }
}
