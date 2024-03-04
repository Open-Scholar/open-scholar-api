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

        public async Task<List<Topic>> GetAllWithUserAndLikesAsync()
        {
            return await _openScholarDbContext.Topics.Include(t => t.User)
                                                     .Include(l => l.Likes)
                                                     .Include(c =>c.Comments)
                                                     .ToListAsync();
        }

        public async Task<(IEnumerable<Topic> Items, int TotalCount)> GetAllWithUserAndFiltersAsync(int? facultyId = null, int? universityId = null, bool? isMostPopular = false, int pageNumber = 1, int pageSize = 10)
        {
            var query = _openScholarDbContext.Topics.Include(t => t.User)
                                                    .Include(q => q.Likes)
                                                    .Include(c => c.Comments)/*.Select(c => c.Id)*/
                                                    .AsQueryable();

            var totalCount = await query.CountAsync();

            if (facultyId.HasValue)
                query = query.Where(t => t.FacultyId == facultyId.Value);

            if (universityId.HasValue)
                query = query.Where(t => t.Faculty.UniversityId == universityId.Value);

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            query = query.OrderByDescending(t => t.CreatedDate);

            //query.Include(t => t.User);

            if (isMostPopular.HasValue && isMostPopular.Value == true)
                query = query.OrderByDescending(t => t.Likes.Count());

            var items = await query.ToListAsync();
            //var items = await query.
            return (items, totalCount);
        }

        public async Task<Topic> GetByIdWithLikesAsync(int id)
        {
            var result = await _openScholarDbContext.Topics.Include(l => l.Likes)
                .Include(t => t.User)                      .Include(c => c.Comments)
                                                           .FirstOrDefaultAsync(t => t.Id == id);
            return result;
        }
    }
}
