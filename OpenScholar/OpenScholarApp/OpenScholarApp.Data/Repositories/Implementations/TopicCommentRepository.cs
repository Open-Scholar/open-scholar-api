using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class TopicCommentRepository : BaseRepository<TopicComment>, ITopicCommentRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public TopicCommentRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<TopicComment>> GetAllWithUserAndTopicAsync()
        {
            return await _openScholarDbContext.TopicComments.Include(x => x.Topic).Include(a => a.User).ToListAsync();
        }
    }
}
