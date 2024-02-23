using OpenScholarApp.Dtos.TopicDto;
using OpenScholarApp.Shared.Responses;
using OpenScholarApp.Dtos.Shared;

namespace OpenScholarApp.Services.Interfaces
{
    public interface ITopicService
    {
        Task<Response> CreateTopicAsync(AddTopicDto topicDto, string userId);
        Task<Response<UpdateTopicDto>> UpdateTopicAsync(int id, string userUd, UpdateTopicDto updatedTopicDto);
        Task<Response> DeleteTopicAsync(int id, string userId);
        Task<Response<TopicDto>> GetTopicByIdAsync(int id, string UserId);
        Task<Response<List<TopicDto>>> GetAllTopicsAsync();
        Task<Response<PagedResultDto<TopicDto>>> GetAllTopicsFilteredAsync(string userId, int? facultyId, int? universityId, bool? isMostPopular, int pageNumber, int pageSize);
    }
}
