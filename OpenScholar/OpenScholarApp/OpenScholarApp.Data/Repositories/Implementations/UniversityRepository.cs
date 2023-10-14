using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class UniversityRepository : BaseRepository<University>, IUniversityRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public UniversityRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<University>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.Universities.Include(s => s.User).ToListAsync();
        }
    }
}
