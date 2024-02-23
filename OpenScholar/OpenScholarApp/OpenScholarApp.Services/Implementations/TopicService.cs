using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.TopicDto;
using OpenScholarApp.Dtos.Shared;
using OpenScholarApp.Services.Helpers.Interaces;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.TopicExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class TopicService : ITopicService
    {
        private readonly IFacultyRepository _faultyRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserHelperService _userHelperService;

        public TopicService(IUserHelperService userHelperService,
                            IFacultyRepository facultyRepository,
                            ITopicRepository topicRepository,
                            IMapper mapper,
                            UserManager<ApplicationUser> userManager)
        {
            _userHelperService = userHelperService;
            _faultyRepository = facultyRepository;
            _topicRepository = topicRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateTopicAsync(AddTopicDto topicDto, string UserId)
        {
            try
            {
                var response = new Response();
                var topic = _mapper.Map<Topic>(topicDto);
                var user = await _userManager.FindByIdAsync(UserId);

                if (user == null)
                    return new Response<AddTopicDto>("User Not found");

                topic.User = user;
                topic.UserId = UserId;

                var faculty = await _faultyRepository.GetByIdInt(topic.FacultyId);
                if (faculty == null)
                    return new Response<AddTopicDto>("Selected faculty not found!");

                topic.Faculty = faculty;
                topic.FacultyId = topicDto.FacultyId;
                await _topicRepository.Add(topic);
                response.IsSuccessfull = true;
                return response;
            }
            catch (TopicDataException e)
            {
                throw new TopicDataException(e.Message);
            }
        }

        public async Task<Response> DeleteTopicAsync(int id, string userId)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                    return new Response() { Errors = new List<string> { $"User with Id {id} not found" }, IsSuccessfull = false };

                var topic = await _topicRepository.GetByIdInt(id);
                if (topic == null)
                    return new Response() { Errors = new List<string> { $"Topic with Id {id} not found" }, IsSuccessfull = false };

                if (topic.User.Id != userId)
                    return new Response() { Errors = new List<string> { $"You dont have permissions to delete this topic" }, IsSuccessfull = false };

                await _topicRepository.RemoveEntirely(topic);
                return Response.Success;
            }
            catch (TopicDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the topic {ex.Message}" } };
            }
        }

        public async Task<Response<List<TopicDto>>> GetAllTopicsAsync()
        {
            try
            {
                var topics = await _topicRepository.GetAllWithUserAndLikesAsync();
                var topicDtos = new List<TopicDto>();
                foreach (var topic in topics)
                {
                    var topicDto = _mapper.Map<TopicDto>(topic);
                    var userName = await _userHelperService.GetUsername(topic.User);
                    topicDto.UserName = userName;
                    topicDtos.Add(topicDto);
                }
                return new Response<List<TopicDto>>() { IsSuccessfull = true, Result = topicDtos };
            }
            catch (TopicDataException ex)
            {
                return new Response<List<TopicDto>>() { Errors = new List<string> { $"An error occurred while fetching all topics: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<PagedResultDto<TopicDto>>> GetAllTopicsFilteredAsync(string userId,
                                                                                        int? facultyId,
                                                                                        int? universityId,
                                                                                        bool? isMostPopular,
                                                                                        int pageNumber,
                                                                                        int pageSize)
        {
            try
            {
                var (topics, totalCount) = await _topicRepository.GetAllWithUserAndFiltersAsync(facultyId, universityId, isMostPopular, pageNumber, pageSize);
                var topicDtos = new List<TopicDto>();
                foreach (var topic in topics)
                {
                    var topicDto = _mapper.Map<TopicDto>(topic);
                    var userName = await _userHelperService.GetUsername(topic.User);
                    topicDto.UserName = userName;
                    topicDto.IsLikedByUser = topic.Likes.Any(like => like.UserId == userId);
                    topicDto.TopicLikeCount = topic.Likes.Count;
                    topicDto.TopicCommentCount = topic.Comments.Count;
                    topicDtos.Add(topicDto);
                }

                var result = new PagedResultDto<TopicDto>
                {
                    Items = topicDtos,
                    TotalItems = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
                };
                return new Response<PagedResultDto<TopicDto>>() { IsSuccessfull = true, Result = result };
            }
            catch (TopicDataException ex)
            {
                return new Response<PagedResultDto<TopicDto>>() { Errors = new List<string> { $"An error occurred: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<TopicDto>> GetTopicByIdAsync(int id, string userId)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                    return new Response<TopicDto>() { Errors = new List<string> { $"User with Id {id} not found" }, IsSuccessfull = false };

                var topic = await _topicRepository.GetByIdWithLikesAsync(id);
                if (topic == null)
                    return new Response<TopicDto>() { Errors = new List<string> { $"Topic not found!" }, IsSuccessfull = false };

                var topicDto = _mapper.Map<TopicDto>(topic);
                topicDto.TopicLikeCount = topic.Likes.Count();
                topicDto.IsLikedByUser = topic.Likes.Any(t => t.UserId == userId);
                topicDto.UserName = await _userHelperService.GetUsername(topic.User);
                return new Response<TopicDto>() { IsSuccessfull = true, Result = topicDto };
            }
            catch (TopicDataException ex)
            {
                return new Response<TopicDto> { Errors = new List<string> { $"An error occurred while fetching the topic {ex.Message}" } };
            }
        }

        public async Task<Response<UpdateTopicDto>> UpdateTopicAsync(int id, string userId, UpdateTopicDto updatedTopicDto)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                    return new Response<UpdateTopicDto> { Errors = new List<string> { $"User not found" }, IsSuccessfull = false };

                var existingTopic = await _topicRepository.GetByIdInt(id);
                if (existingTopic == null)
                    return new Response<UpdateTopicDto> { Errors = new List<string> { $"Topic not found." }, IsSuccessfull = false };

                if (existingTopic.User.Id != userId)
                    return new Response<UpdateTopicDto> { Errors = new List<string> { $"You don't have permissions to update this topic" }, IsSuccessfull = false };

                var updatedTopic = _mapper.Map(updatedTopicDto, existingTopic);
                var result = _topicRepository.Update(updatedTopic);
                return new Response<UpdateTopicDto> { IsSuccessfull = true, Result = updatedTopicDto };
            }
            catch (TopicDataException ex)
            {
                return new Response<UpdateTopicDto> { Errors = new List<string> { $"An error occurred while updating the topic: {ex.Message}" }, IsSuccessfull = false };
            }
        }
    }
}
