using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class AcademicMaterialRepository : BaseRepository<AcademicMaterial>, IAcademicMaterialRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public AcademicMaterialRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }
    }
}
