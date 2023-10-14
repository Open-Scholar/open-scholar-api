using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class FacultyRepository : BaseRepository<Faculty> ,IFacultyRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public FacultyRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<Faculty>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.Faculties.Include(s => s.User).ToListAsync();
        }
    }
}
