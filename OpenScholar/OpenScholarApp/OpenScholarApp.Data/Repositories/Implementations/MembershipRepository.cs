using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class MembershipRepository : BaseRepository<ApplicationUser> ,IMembershipRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

         public MembershipRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }
    }
}
