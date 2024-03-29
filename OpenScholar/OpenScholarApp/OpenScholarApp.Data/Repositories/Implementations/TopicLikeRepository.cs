﻿using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class TopicLikeRepository : BaseRepository<TopicLike>, ITopicLikeRepository
    {
        private readonly OpenScholarDbContext _context;

        public TopicLikeRepository(OpenScholarDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TopicLike>> GetAllWithUserByTopicIdAsync(int topicId)
        {
            return await _context.TopicLikes.Include(s => s.User).Where(x => x.TopicId == topicId).ToListAsync();
        }

        public async Task<TopicLike> GetByIdWithUserAsync(int topicId, string userId)
        {
            return await _context.TopicLikes.FirstOrDefaultAsync(tl => tl.TopicId == topicId && tl.UserId == userId);
        }
    }
}
