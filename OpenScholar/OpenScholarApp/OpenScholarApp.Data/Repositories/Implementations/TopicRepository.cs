using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public TopicRepository(OpenScholarDbContext context) : base(context) 
        {
            _openScholarDbContext = context;
        }

        public async Task<List<Topic>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.Topics.Include(t => t.User).ToListAsync();
        }

        public async Task<List<Topic>> GetAllWithUserAndFiltersAsync(int? facultyId = null, int pageNumber = 1, int pageSize = 10)
        {
            var query = _openScholarDbContext.Topics.AsQueryable();

            if (facultyId.HasValue)
                query = query.Where(t => t.FacultyId == facultyId.Value);

            query = query.Include(t => t.User);
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return await query.ToListAsync();
        }
    }
}
