using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.TopicCommentDto;
using OpenScholarApp.Dtos.TopicDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.TopicCommentExceptions;
using OpenScholarApp.Shared.CustomExceptions.TopicExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class TopicCommentService : ITopicCommentService
    {
        private readonly ITopicCommentRepository _topicCommentRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public TopicCommentService(ITopicCommentRepository topicCommentRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _topicCommentRepository = topicCommentRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response> CreateTopicCommetAsync(AddTopicCommentDto topicCommentDto, string UserId)
        {
            try
            {
                var response = new Response();
                var topicComment = _mapper.Map<TopicComment>(topicCommentDto);
                var user = await _userManager.FindByIdAsync(UserId);

                if (user == null)
                    return new Response<AddTopicCommentDto>("User Not found");

                if (user.AccountType != AccountType.Student || user.AccountType != AccountType.Professor)
                    return new Response<AddTopicCommentDto>("You dont have permission to post");

                topicComment.User = user;
                await _topicCommentRepository.Add(topicComment);
                response.IsSuccessfull = true;
                return response;
            }
            catch (TopicCommentDataException e)
            {
                throw new TopicDataException(e.Message);
            }
        }

        public async Task<Response> DeleteTopiCommentcAsync(int id, string userId)
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

        public async Task<Response<List<TopicCommentDto>>> GetAllTopicsAsync()
        {
            try
            {
                var topics = await _topicCommentRepository.GetAllWithUserAndTopicAsync();
                var topicDtos = _mapper.Map<List<TopicCommentDto>>(topics);
                return new Response<List<TopicCommentDto>>() { IsSuccessfull = true, Result = topicDtos };
            }
            catch (TopicCommentDataException ex)
            {
                return new Response<List<TopicCommentDto>>() { Errors = new List<string> { $"An error occurred while fetching all topic Comments: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<TopicCommentDto>> GetTopicByIdAsync(int id, string userId)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                    return new Response<TopicCommentDto>() { Errors = new List<string> { $"User with Id {id} not found" }, IsSuccessfull = false };

                var topicComment = await _topicCommentRepository.GetByIdInt(id);

                var topicCommentDto = _mapper.Map<TopicCommentDto>(topicComment);
                return new Response<TopicCommentDto>() { IsSuccessfull = true, Result = topicCommentDto };
            }
            catch (TopicCommentDataException ex)
            {
                return new Response<TopicCommentDto> { Errors = new List<string> { $"An error occurred while fetching the topic Comment {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateTopicAsync(int id, string userId, UpdateTopicDto updatedTopicDto)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                {
                    return new Response { Errors = new List<string> { $"User with Id {userId} not found" }, IsSuccessfull = false };
                }

                var existingTopicComment = await _topicCommentRepository.GetByIdInt(id);

                if (existingTopicComment == null)
                {
                    return new Response { Errors = new List<string> { $"Topic Comment with ID {id} not found." }, IsSuccessfull = false };
                }

                if (existingTopicComment.User.Id != userId)
                {
                    return new Response { Errors = new List<string> { $"You don't have permissions to update this topic" }, IsSuccessfull = false };
                }

                var updatedTopicComment = _mapper.Map<TopicComment>(updatedTopicDto);
                await _topicCommentRepository.Update(updatedTopicComment);

                return new Response { IsSuccessfull = true };
            }
            catch (TopicDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the topic: {ex.Message}" }, IsSuccessfull = false };
            }
        }
    }
}
