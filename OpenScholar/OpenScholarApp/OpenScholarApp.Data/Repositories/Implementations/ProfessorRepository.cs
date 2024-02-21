using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class ProfessorRepository :BaseRepository<Professor>, IProfessorRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public ProfessorRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<Professor>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.Professors.Include(s => s.User).ToListAsync();
        }

        public async Task<Professor> GetByUserIdAsync(string userId)
        {
            return await _openScholarDbContext.Professors
                        .FirstOrDefaultAsync(s => s.User != null && s.User.Id == userId);
        }
    }
}
