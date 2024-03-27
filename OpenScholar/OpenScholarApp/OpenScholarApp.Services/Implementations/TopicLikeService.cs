using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.TopicLikeDto;
using OpenScholarApp.Dtos.UserNotificationDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.TopicLikeExceptions;
using OpenScholarApp.Shared.Responses;
using OpenScholarApp.SignalR;

namespace OpenScholarApp.Services.Implementations
{
    public class TopicLikeService : ITopicLikeService
    {
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly ITopicLikeRepository _topicLikeRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public TopicLikeService(IMapper mapper,
                                UserManager<ApplicationUser> userManager,
                                IUserNotificationRepository userNotificationRepository,
                                INotificationService notificationService,
                                ITopicRepository topicRepository,
                                ITopicLikeRepository topicLikeRepository)
        {
            _userNotificationRepository = userNotificationRepository;
            _notificationService = notificationService;
            _topicRepository = topicRepository;
            _mapper = mapper;
            _userManager = userManager;
            _topicLikeRepository = topicLikeRepository;
        }

        public async Task<Response> CreateRemoveTopicLikeAsync(string userId, AddRemoveTopicLikeDto topicLikeDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response("User not found!");

                var existingLike = await _topicLikeRepository.GetByIdWithUserAsync(topicLikeDto.TopicId, userId);
                if (existingLike != null)
                {
                    await _topicLikeRepository.RemoveEntirely(existingLike);
                    return Response.Success;
                }
                else
                {
                    var like = _mapper.Map<TopicLike>(topicLikeDto);
                    like.User = user;
                    var topic = await _topicRepository.GetByIdInt(topicLikeDto.TopicId);
                    if (topic == null)
                        return new Response("Topic Not Found!");

                    like.Topic = topic;
                    like.UserId = userId;
                    like.CreatedAt = DateTime.UtcNow;
                    await _topicLikeRepository.Add(like);

                    if(userId != topic.UserId)
                    {
                        var userNotificationDto = new AddUserNotificationDto()
                        {
                            ReferenceId = topic.Id,
                            UserId = userId,
                            RecieverUserId = topic.UserId,
                            Message = $"{user.UserName} liked your Post",
                            NotificationType = NotificationType.TopicLike,
                            IsRead = false,
                            CreatedAt = DateTime.UtcNow
                        };

                        string userNotificationDtoJson = System.Text.Json.JsonSerializer.Serialize(userNotificationDto).ToString();

                        var userNotification = new UserNotification();
                        _mapper.Map(userNotificationDto, userNotification);
                        await _notificationService.SendNotification(topic.UserId, userNotificationDtoJson);
                        await _userNotificationRepository.Add(userNotification);
                    }
                    return Response.Success;
                }
            }
            catch (TopicLikeDataException ex)
            {
                return new Response(ex.Message);
            }
        }

        public async Task<Response<List<TopicLikeDto>>> GetAllTopicLikesAsync(int topicId)
        {
            try
            {
                var topicLikes = await _topicLikeRepository.GetAllWithUserByTopicIdAsync(topicId);
                var topicDtos = _mapper.Map<List<TopicLikeDto>>(topicLikes);
                return new Response<List<TopicLikeDto>>() { IsSuccessfull = true, Result = topicDtos };
            }
            catch (TopicLikeDataException ex)
            {
                return new Response<List<TopicLikeDto>>() { Errors = new List<string> { $"An error occurred while fetching all topicLikes: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<TopicLikeDto>> GetTopicLikeByIdAsync(int id)
        {
            try
            {
                var topicLike = await _topicLikeRepository.GetByIdInt(id);
                if (topicLike == null)
                    return new Response<TopicLikeDto>("Topic Like Like not found!");

                var topicDto = _mapper.Map<TopicLikeDto>(topicLike);
                return new Response<TopicLikeDto>() { IsSuccessfull = true, Result = topicDto };
            }
            catch (TopicLikeDataException e)
            {
                return new Response<TopicLikeDto>($"{e.Message}");
            }
        }
    }
}
