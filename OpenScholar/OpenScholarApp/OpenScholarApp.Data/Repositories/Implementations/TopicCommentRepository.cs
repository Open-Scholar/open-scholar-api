using Microsoft.AspNetCore.Identity;
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

        public async Task<List<TopicComment>> GetAllTopicCommentsByTopicId(int topicId)
        {
            return await _openScholarDbContext.TopicComments.Where(tc => tc.TopicId == topicId).ToListAsync();
        }

        public async Task<TopicComment> GetByIdWithLikesAsync(int topicCommentId)
        {
            return await _openScholarDbContext.TopicComments.Include(l => l.Likes).FirstOrDefaultAsync(tc => tc.Id == topicCommentId);
        }

        public async Task<(IEnumerable<TopicComment> Items, int TotalCount)> GetAllTopicCommentsByTopicIdPagedAsync(int topicId, int pageNumber, int pageSize)
        {
            var query = _openScholarDbContext.TopicComments
                .Where(tc => tc.TopicId == topicId)
                .Include(a => a.Likes)
                .Include(u => u.User)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(tc => tc.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
