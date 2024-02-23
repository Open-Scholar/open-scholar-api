using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class TopicCommentLikeRepository : BaseRepository<TopicCommentLike>, ITopicCommentLikeRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public TopicCommentLikeRepository(OpenScholarDbContext context) : base(context)
        {
            _openScholarDbContext = context;
        }

        public async Task<List<TopicCommentLike>> GetAllWithUserAndTopicCommentAsync(int topicCommentId)
        {
            return await _openScholarDbContext.TopicCommentLikes.Include(s => s.User)
                                                                .Include(x => x.TopicComment)
                                                                .Where(q => q.TopicCommentId == topicCommentId)
                                                                .ToListAsync();
        }

        public async Task<TopicCommentLike> GetByIdWithUserAsync(int topicCommentId, string userId)
        {
            return await _openScholarDbContext.TopicCommentLikes
                                               .FirstOrDefaultAsync(tcl => tcl.TopicCommentId == topicCommentId && tcl.UserId == userId);
        }
    }
}
