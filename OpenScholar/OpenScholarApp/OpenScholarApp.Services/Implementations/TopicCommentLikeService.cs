using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.TopicCommentLikeDto;
using OpenScholarApp.Dtos.UserNotificationDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.TopicCommentLikeExceptions;
using OpenScholarApp.Shared.Responses;
using OpenScholarApp.SignalR;

namespace OpenScholarApp.Services.Implementations
{
    public class TopicCommentLikeService : ITopicCommentLikeService
    {
        private readonly IMapper _mapper;
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly INotificationService _notificationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITopicCommentRepository _topicCommentRepository;
        private readonly ITopicCommentLikeRepository _topicCommentLikeRepository;

        public TopicCommentLikeService(IMapper mapper,
                                       UserManager<ApplicationUser> userManager,
                                       INotificationService notificationService,
                                       IUserNotificationRepository userNotificationRepository,
                                       ITopicCommentLikeRepository topicCommentLikeRepository,
                                       ITopicCommentRepository topicCommentRepository)
        {
            _userNotificationRepository = userNotificationRepository;
            _notificationService = notificationService;
            _mapper = mapper;
            _userManager = userManager;
            _topicCommentLikeRepository = topicCommentLikeRepository;
            _topicCommentRepository = topicCommentRepository;
        }

        public async Task<Response> CreateRemoveTopicCommentLikeAsync(string userId, AddRemoveTopicCommentLikeDto topicCommentLikeDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response("User not found!");

                var existingLike = await _topicCommentLikeRepository.GetByIdWithUserAsync(topicCommentLikeDto.TopicCommentId, userId);
                if (existingLike != null)
                {
                    await _topicCommentLikeRepository.RemoveEntirely(existingLike);
                    return Response.Success;
                }
                else
                {
                    var like = _mapper.Map<TopicCommentLike>(topicCommentLikeDto);
                    like.UserId = user.Id;
                    like.User = user;
                    var topicComment = await _topicCommentRepository.GetByIdInt(topicCommentLikeDto.TopicCommentId);
                    if (topicComment == null)
                        return new Response("Topic Comment not found!");

                    like.TopicCommentId = topicComment.Id;
                    like.TopicComment = topicComment;
                    like.CreatedAt = DateTime.UtcNow;
                    await _topicCommentLikeRepository.Add(like);

                    var userNotificationDto = new AddUserNotificationDto()
                    {
                        ReferenceId = topicComment.Topic.Id,
                        UserId = userId,
                        RecieverUserId = topicComment.UserId,
                        Message = $"{user.UserName} Liked your comment!",
                        NotificationType = NotificationType.TopicCommentLike,
                        IsRead = false,
                        CreatedAt = DateTime.UtcNow
                    };

                    string userNotificationDtoJson = System.Text.Json.JsonSerializer.Serialize(userNotificationDto);
                    var userNotification = new UserNotification();
                    _mapper.Map(userNotificationDto, userNotification);
                    await _notificationService.SendNotification(topicComment.UserId, userNotificationDtoJson);
                    await _userNotificationRepository.Add(userNotification);
                    return Response.Success;
                }
            }
            catch (TopicCommentLikeDataException e)
            {
                return new Response(e.Message);
            }
        }

        public async Task<Response<List<TopicCommentLikeDto>>> GetAllTopicCommentLikesAsync(int topicCommentId)
        {
            try
            {
                var topicCommentLikes = await _topicCommentLikeRepository.GetAllWithUserAndTopicCommentAsync(topicCommentId);
                var topicCommentDtos = _mapper.Map<List<TopicCommentLikeDto>>(topicCommentLikes);
                return new Response<List<TopicCommentLikeDto>>() { IsSuccessfull = true, Result = topicCommentDtos };
            }
            catch (TopicCommentLikeDataException ex)
            {
                return new Response<List<TopicCommentLikeDto>>() { Errors = new List<string> { $"An error occurred while fetching all topic comment likes: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<TopicCommentLikeDto>> GetTopicCommentLikeByIdAsync(int id)
        {
            try
            {
                var topicCommentLike = await _topicCommentLikeRepository.GetByIdInt(id);
                if (topicCommentLike == null)
                    return new Response<TopicCommentLikeDto>("Topic comment Like not found!");

                var topicCommentLikeDto = _mapper.Map<TopicCommentLikeDto>(topicCommentLike);
                return new Response<TopicCommentLikeDto>() { IsSuccessfull = true, Result = topicCommentLikeDto };
            }
            catch (TopicCommentLikeDataException ex)
            {
                return new Response<TopicCommentLikeDto>($"Topic Comment Like Error! {ex.Message}");
            }

        }
    }
}
