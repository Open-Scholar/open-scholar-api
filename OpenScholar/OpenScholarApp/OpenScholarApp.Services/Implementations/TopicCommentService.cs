using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.Shared;
using OpenScholarApp.Dtos.TopicCommentDto;
using OpenScholarApp.Services.Helpers.Interaces;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.TopicCommentExceptions;
using OpenScholarApp.Shared.CustomExceptions.TopicExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class TopicCommentService : ITopicCommentService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IUserHelperService _userHelperService;
        private readonly ITopicCommentRepository _topicCommentRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public TopicCommentService(ITopicCommentRepository topicCommentRepository,
                                   IUserHelperService userHelperService,
                                   ITopicRepository topicRepository,
                                   UserManager<ApplicationUser> userManager,
                                   IMapper mapper)
        {
            _userHelperService = userHelperService;
            _topicRepository = topicRepository;
            _topicCommentRepository = topicCommentRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response> CreateTopicCommentAsync(AddTopicCommentDto topicCommentDto, string UserId)
        {
            try
            {
                var topicComment = _mapper.Map<TopicComment>(topicCommentDto);
                var user = await _userManager.FindByIdAsync(UserId);
                if (user == null)
                    return new Response<AddTopicCommentDto>("User Not found");

                topicComment.User = user;
                topicComment.UserId = user.Id;

                var topic = await _topicRepository.GetByIdInt(topicCommentDto.TopicId);
                if (topic == null)
                    return new Response<AddTopicCommentDto>("Topic not found!");

                topicComment.Topic = topic;
                topicComment.TopicId = topicCommentDto.TopicId;

                var result = _topicCommentRepository.Add(topicComment);
                return new Response<AddTopicCommentDto> { IsSuccessfull = true, Result = topicCommentDto };
            }
            catch (TopicCommentDataException e)
            {
                throw new TopicDataException(e.Message);
            }
        }

        public async Task<Response> DeleteTopicCommentAsync(int id, string userId)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                    return new Response() { Errors = new List<string> { $"User with Id {id} not found" }, IsSuccessfull = false };

                var topicComment = await _topicCommentRepository.GetByIdInt(id);
                if (topicComment == null)
                    return new Response() { Errors = new List<string> { $"Topic Comment with Id {id} not found" }, IsSuccessfull = false };

                if (topicComment.User.Id != userId)
                    return new Response() { Errors = new List<string> { $"You dont have permissions to delete this topic Comment" }, IsSuccessfull = false };

                await _topicCommentRepository.RemoveEntirely(topicComment);
                return Response.Success;
            }
            catch (TopicCommentDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the topic Comment {ex.Message}" } };
            }
        }

        public async Task<Response<List<TopicCommentDto>>> GetAllTopicCommentsAsync()
        {
            try
            {
                var topicComments = await _topicCommentRepository.GetAllWithUserAndTopicAsync();
                var topicCommentDtos = new List<TopicCommentDto>();
                foreach (var topicComment in topicComments)
                {
                    var topicCommentDto = _mapper.Map<TopicCommentDto>(topicComment);
                    var userName = await _userHelperService.GetUsername(topicComment.User);
                    topicCommentDto.UserName = userName;
                    topicCommentDtos.Add(topicCommentDto);
                }
                return new Response<List<TopicCommentDto>>() { IsSuccessfull = true, Result = topicCommentDtos };
            }
            catch (TopicCommentDataException ex)
            {
                return new Response<List<TopicCommentDto>>() { Errors = new List<string> { $"An error occurred while fetching all topic Comments: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<PagedResultDto<TopicCommentDto>> GetAllTopicCommentsPagedAsync(string userId, int pageNumber, int pageSize, int topicId)
        {
            var (items, totalCount) = await _topicCommentRepository.GetAllTopicCommentsByTopicIdPagedAsync(topicId, pageNumber, pageSize);
            var topicCommentDtos = new List<TopicCommentDto>();

            foreach (var topicComment in items)
            {
                var topicCommentDto = new TopicCommentDto();
                var userName = await _userHelperService.GetUsername(topicComment.User);
                topicCommentDto.Id = topicComment.Id;
                topicCommentDto.UserName = userName;
                topicCommentDto.IsLikedByUser = topicComment.Likes.Any(like => like.UserId == userId);
                topicCommentDto.UserId = topicComment.User.Id;
                topicCommentDto.TopicCommentLikeCount = topicComment.Likes.Count();
                topicCommentDtos.Add(topicCommentDto);
            }
            return new PagedResultDto<TopicCommentDto>
            {
                Items = topicCommentDtos,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            };
        }

        public async Task<Response<TopicCommentDto>> GetTopicCommentByIdAsync(int id, string userId)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                    return new Response<TopicCommentDto>() { Errors = new List<string> { $"User not found" }, IsSuccessfull = false };

                var topicComment = await _topicCommentRepository.GetByIdWithLikesAsync(id);
                if (topicComment == null)
                    return new Response<TopicCommentDto>("Topic Comment not found!");

                var topicCommentDto = _mapper.Map<TopicCommentDto>(topicComment);
                topicCommentDto.UserName = await _userHelperService.GetUsername(topicComment.User);
                topicCommentDto.TopicCommentLikeCount = topicComment.Likes.Count();
                topicCommentDto.IsLikedByUser = topicComment.Likes.Any(t => t.UserId == userId);
                return new Response<TopicCommentDto>() { IsSuccessfull = true, Result = topicCommentDto };
            }
            catch (TopicCommentDataException ex)
            {
                return new Response<TopicCommentDto> { Errors = new List<string> { $"An error occurred while fetching the topic Comment {ex.Message}" } };
            }
        }

        public async Task<Response<UpdateTopicCommentDto>> UpdateTopicCommentAsync(int id, string userId, UpdateTopicCommentDto updatedTopicCommentDto)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                    return new Response<UpdateTopicCommentDto> { Errors = new List<string> { $"User with Id {userId} not found" }, IsSuccessfull = false };

                var existingTopicComment = await _topicCommentRepository.GetByIdInt(id);

                if (existingTopicComment == null)
                    return new Response<UpdateTopicCommentDto> { Errors = new List<string> { $"Topic Comment with ID {id} not found." }, IsSuccessfull = false };

                if (existingTopicComment.User.Id != userId)
                    return new Response<UpdateTopicCommentDto> { Errors = new List<string> { $"You don't have permissions to update this topic" }, IsSuccessfull = false };

                var updatedTopicComment = _mapper.Map(updatedTopicCommentDto, existingTopicComment);
                await _topicCommentRepository.Update(updatedTopicComment);
                return new Response<UpdateTopicCommentDto> { IsSuccessfull = true, Result = updatedTopicCommentDto };
            }
            catch (TopicDataException ex)
            {
                return new Response<UpdateTopicCommentDto> { Errors = new List<string> { $"An error occurred while updating the topic: {ex.Message}" }, IsSuccessfull = false };
            }
        }
    }
}
