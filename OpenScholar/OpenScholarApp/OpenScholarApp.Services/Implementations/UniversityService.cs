using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.University;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.UniversityExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UniversityService(IUniversityRepository repository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Response> CreateUniversityAsync(string userId, AddUniversityDto universityDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response("You dont have authorization to add new Faculties");

                var university = _mapper.Map<University>(universityDto);
                await _repository.Add(university);
                return new Response<AddUniversityDto> { IsSuccessfull = true, Result = universityDto };
            }
            catch (UniversityDataException ex)
            {
                return new Response($"Error in creating new university! {ex.Message}");
            }
        }

        public async Task<Response> DeleteUniversityAsync(string userId, int id)
        {
            try
            {
                var existingUniversity = await _repository.GetByIdInt(id);
                if (existingUniversity == null)
                    return new Response() { Errors = new List<string> { $"University not found! not found" }, IsSuccessfull = false };

                var response = _repository.RemoveEntirely(existingUniversity);
                return Response.Success;
            }
            catch (UniversityDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the university {ex.Message}" } };
            }
        }

        public async Task<Response<List<UniversityDto>>> GetAllUniversitiesAsync()
        {
            try
            {
                var universities = await _repository.GetAll();
                var universityDtos = _mapper.Map<List<UniversityDto>>(universities);
                return new Response<List<UniversityDto>>() { IsSuccessfull = true, Result = universityDtos };
            }
            catch (UniversityDataException ex)
            {
                return new Response<List<UniversityDto>>() { Errors = new List<string> { $"An error occurred while fetching all universities: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<UniversityDto>> GetUniversityByIdAsync(int id)
        {
            try
            {
                var university = await _repository.GetByIdInt(id);
                if (university == null)
                    return new Response<UniversityDto>() { Errors = new List<string> { $"University not found" }, IsSuccessfull = false };

                var universityDto = _mapper.Map<UniversityDto>(university);
                return new Response<UniversityDto>() { IsSuccessfull = true, Result = universityDto };
            }
            catch (UniversityDataException ex)
            {
                return new Response<UniversityDto> { Errors = new List<string> { $"An error occurred while fetching the university {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateUniversityAsync(string userId, int id, UpdateUniversityDto updateUniversityDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null/* && user.AccountType != Domain.Enums.AccountType.SuperAdmin*/)
                    return new Response("You dont have authorization to add new Universities");

                var existingUniversity = await _repository.GetByIdInt(id);
                if (existingUniversity == null)
                    return new Response<UpdateUniversityDto>("University not found.");

                var updatedUniversity = _mapper.Map(updateUniversityDto, existingUniversity);
                var result = _repository.Update(updatedUniversity);
                return new Response<UpdateUniversityDto> { IsSuccessfull = true, Result = updateUniversityDto };
            }
            catch (UniversityDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the University {ex.Message}" } };
            }
        }
    }
}
