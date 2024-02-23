using OpenScholarApp.Dtos.Shared;
using OpenScholarApp.Dtos.TopicCommentDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface ITopicCommentService
    {
        Task<Response> CreateTopicCommentAsync(AddTopicCommentDto topicCommentDto, string userId);
        Task<Response<UpdateTopicCommentDto>> UpdateTopicCommentAsync(int id, string userUd, UpdateTopicCommentDto updatedTopicCommentDto);
        Task<Response> DeleteTopicCommentAsync(int id, string userId);
        Task<Response<TopicCommentDto>> GetTopicCommentByIdAsync(int id, string UserId);
        Task<Response<List<TopicCommentDto>>> GetAllTopicCommentsAsync();
        Task <PagedResultDto<TopicCommentDto>>GetAllTopicCommentsPagedAsync(string userId, int pageNumber, int pageSize, int topicId);
    }
}
