using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Implementations;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Dtos.TopicDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.StudentExceptions;
using OpenScholarApp.Shared.CustomExceptions.TopicExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public TopicService(ITopicRepository topicRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
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

                if (user.AccountType != AccountType.Student || user.AccountType != AccountType.Professor)
                    return new Response<AddTopicDto>("You dont have permission to post");

                topic.User = user;
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
               
                if(topic.User.Id != userId)
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
                var topics = await _topicRepository.GetAllWithUserAsync();
                var topicDtos = _mapper.Map<List<TopicDto>>(topics);
                return new Response<List<TopicDto>>() { IsSuccessfull = true, Result = topicDtos };
            }
            catch (TopicDataException ex)
            {
                return new Response<List<TopicDto>>() { Errors = new List<string> { $"An error occurred while fetching all topics: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<TopicDto>> GetTopicByIdAsync(int id, string userId)
        {
            try
            {
                var existingUser = await _userManager.FindByIdAsync(userId);
                if (existingUser == null)
                    return new Response<TopicDto>() { Errors = new List<string> { $"User with Id {id} not found" }, IsSuccessfull = false };

                var topic = await _topicRepository.GetByIdInt(id);

                var topicDto = _mapper.Map<TopicDto>(topic);
                return new Response<TopicDto>() { IsSuccessfull = true, Result = topicDto };
            }
            catch (TopicDataException ex)
            {
                return new Response<TopicDto> { Errors = new List<string> { $"An error occurred while fetching the topic {ex.Message}" } };
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

                var existingTopic = await _topicRepository.GetByIdInt(id);

                if (existingTopic == null)
                {
                    return new Response { Errors = new List<string> { $"Topic with ID {id} not found." }, IsSuccessfull = false };
                }

                if (existingTopic.User.Id != userId)
                {
                    return new Response { Errors = new List<string> { $"You don't have permissions to update this topic" }, IsSuccessfull = false };
                }

                var updatedTopic = _mapper.Map<Topic>(updatedTopicDto);
                await _topicRepository.Update(updatedTopic);

                return new Response { IsSuccessfull = true };
            }
            catch (TopicDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the topic: {ex.Message}" }, IsSuccessfull = false };
            }
        }
    }
}
