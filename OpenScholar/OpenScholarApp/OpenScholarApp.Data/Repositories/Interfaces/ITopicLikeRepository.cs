using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface ITopicLikeRepository : IBaseRepository<TopicLike>
    {
        Task<TopicLike> GetByIdWithUserAsync(int id, string userId);
        Task<List<TopicLike>> GetAllWithUserByTopicIdAsync(int topicId);
    }
}
