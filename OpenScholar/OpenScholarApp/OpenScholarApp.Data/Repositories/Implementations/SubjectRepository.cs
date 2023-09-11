using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public SubjectRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }
    }
}
