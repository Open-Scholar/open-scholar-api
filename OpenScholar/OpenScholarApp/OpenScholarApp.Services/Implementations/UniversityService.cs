using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.UniversityDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.UniversityExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UniversityService(IUniversityRepository universityRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateUniversityAsync(AddUniversityDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var university = _mapper.Map<University>(addDto);
                var user = await _userManager.FindByIdAsync(addDto.UserId);
                if (user == null)
                    throw new UniversityDataException("User not found");

                university.User = user;
                await _universityRepository.Add(university);
                response.IsSuccessfull = true;
                return response;
            }
            catch (UniversityDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the University: {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteUniversityAsync(int id)
        {
            try
            {
                var existingUniversity = await _universityRepository.GetByIdInt(id);

                if (existingUniversity == null)
                {
                    return new Response() { Errors = new List<string> { $"University with Id {id} not found" }, IsSuccessfull = false };
                }

                await _universityRepository.RemoveEntirely(existingUniversity);
                return Response.Success;
            }
            catch (UniversityDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the University {ex.Message}" } };
            }
        }

        public async Task<Response<List<UniversityDto>>> GetAllUniversitiesAsync()
        {
            try
            {
                var universities = await _universityRepository.GetAllWithUserAsync();
                var universitiesDtos = _mapper.Map<List<UniversityDto>>(universities);
                return new Response<List<UniversityDto>>() { IsSuccessfull = true, Result = universitiesDtos };
            }
            catch (UniversityDataException ex)
            {
                return new Response<List<UniversityDto>>() { Errors = new List<string> { $"An error occurred while fetching all Universities: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<UniversityDto>> GetUniversityByIdAsync(int id)
        {
            try
            {
                var university = await _universityRepository.GetByIdInt(id);
                if (university == null)
                {
                    return new Response<UniversityDto>() { Errors = new List<string> { $"University with Id {id} not found" }, IsSuccessfull = false };
                }

                var universityDto = _mapper.Map<UniversityDto>(university);
                return new Response<UniversityDto>() { IsSuccessfull = true, Result = universityDto };
            }
            catch (UniversityDataException ex)
            {
                return new Response<UniversityDto> { Errors = new List<string> { $"An error occurred while fetching the University {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateUniversityAsync(int id, UpdateUniversityDto updateDto)
        {
            try
            {
                var response = new Response();
                var existingUniversity = await _universityRepository.GetByIdInt(id);

                if (existingUniversity == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() { ($"University with ID {id} not found.") };
                    return response;
                }

                await _universityRepository.Update(existingUniversity);
                return response;
            }
            catch (UniversityDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the University {ex.Message}" } };
            }
        }
    }
}
