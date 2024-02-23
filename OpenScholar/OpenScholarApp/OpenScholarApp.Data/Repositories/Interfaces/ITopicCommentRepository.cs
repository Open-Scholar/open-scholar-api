using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface ITopicCommentRepository : IBaseRepository<TopicComment>
    {
        Task<List<TopicComment>> GetAllWithUserAndTopicAsync();
        Task<(IEnumerable<TopicComment> Items, int TotalCount)> GetAllTopicCommentsByTopicIdPagedAsync(int topicId, int pageNumber, int pageSize);
        Task<TopicComment> GetByIdWithLikesAsync(int topicCommentId);
    }
}
