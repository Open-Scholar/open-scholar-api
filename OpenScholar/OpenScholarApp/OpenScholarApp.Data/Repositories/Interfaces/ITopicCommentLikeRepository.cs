using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface ITopicCommentLikeRepository : IBaseRepository<TopicCommentLike>
    {
        Task<List<TopicCommentLike>> GetAllWithUserAndTopicCommentAsync(int topicCommentId);
        Task<TopicCommentLike> GetByIdWithUserAsync(int topicId, string userId);
    }
}
