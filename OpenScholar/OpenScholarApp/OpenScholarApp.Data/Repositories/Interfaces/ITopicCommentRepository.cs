using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface ITopicCommentRepository : IBaseRepository<TopicComment>
    {
        Task<List<TopicComment>> GetAllWithUserAndTopicAsync();
    }
}
