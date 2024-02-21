using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using System.Data.Entity;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public UserRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<ApplicationUser>> GetAllUsersWithDetails()
        {
            return await _openScholarDbContext.Users
                .Include(x => x.Students)
                .Include(q => q.Professors)
                .Include(w => w.BookSellers)
                .Include(r => r.BookStores)
                .ToListAsync();
          
        }
    }
}
