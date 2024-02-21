using OpenScholarApp.Dtos.TopicCommentLikeDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface ITopicCommentLikeService
    {
        Task<Response> CreateRemoveTopicCommentLikeAsync(string userId, AddRemoveTopicCommentLikeDto topicCommentLikeDto);
        Task<Response<List<TopicCommentLikeDto>>> GetAllTopicCommentLikesAsync(int topicCommentid);
        Task<Response<TopicCommentLikeDto>> GetTopicCommentLikeByIdAsync(int id);
    }
}
