using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class UniversityAccRepository : BaseRepository<UniversityAcc>, IUniversityAccRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public UniversityAccRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<UniversityAcc>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.UniversityAccounts.Include(s => s.User).ToListAsync();
        }
    }
}
