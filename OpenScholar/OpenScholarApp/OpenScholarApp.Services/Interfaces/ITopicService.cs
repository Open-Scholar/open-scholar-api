using OpenScholarApp.Dtos.TopicDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface ITopicService
    {
        Task<Response> CreateTopicAsync(AddTopicDto topicDto, string userId);
        Task<Response> UpdateTopicAsync(int id, string userUd, UpdateTopicDto updatedTopicDto);
        Task<Response> DeleteTopicAsync(int id, string userId);
        Task<Response<TopicDto>> GetTopicByIdAsync(int id, string UserId);
        Task<Response<List<TopicDto>>> GetAllTopicsAsync();
    }
}
