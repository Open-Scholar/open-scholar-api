using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class FacultyAccRepository : BaseRepository<FacultyAcc> ,IFacultyAccRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public FacultyAccRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<FacultyAcc>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.FacultyAccounts.Include(s => s.User).ToListAsync();
        }
    }
}
