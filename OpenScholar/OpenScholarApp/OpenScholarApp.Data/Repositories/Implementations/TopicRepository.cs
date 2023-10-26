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
    }
}
