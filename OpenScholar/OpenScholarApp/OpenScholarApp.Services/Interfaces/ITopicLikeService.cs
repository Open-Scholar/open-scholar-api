using OpenScholarApp.Dtos.TopicLikeDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface ITopicLikeService
    {
        Task<Response> CreateRemoveTopicLikeAsync(string userId, AddRemoveTopicLikeDto topicLikeDto);
        Task<Response<List<TopicLikeDto>>> GetAllTopicLikesAsync(int topicId);
        Task<Response<TopicLikeDto>> GetTopicLikeByIdAsync(int id);
    }
}
