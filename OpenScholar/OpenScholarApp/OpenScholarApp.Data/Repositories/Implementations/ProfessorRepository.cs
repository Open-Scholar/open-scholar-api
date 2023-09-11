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
    }
}
