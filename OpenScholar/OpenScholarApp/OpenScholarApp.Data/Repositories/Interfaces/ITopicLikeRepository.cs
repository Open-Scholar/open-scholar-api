using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface ITopicLikeRepository : IBaseRepository<TopicLike>
    {
        //Task<List<TopicLike>> GetAllWithUserAsync(int topicDto);
        Task<TopicLike> GetByIdWithUserAsync(int id, string userId);
        Task<List<TopicLike>> GetAllWithUserByTopicIdAsync(int topicId);
    }
}
