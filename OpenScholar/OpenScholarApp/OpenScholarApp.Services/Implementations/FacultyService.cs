using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.FacultyDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.FacultyExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public FacultyService(IFacultyRepository facultyRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateFacultyAsync(AddFacultyDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var faculty = _mapper.Map<Faculty>(addDto);
                var user = await _userManager.FindByIdAsync(addDto.UserId);
                if (user == null)
                    throw new FacultyDataException("User not found");

                faculty.User = user;
                await _facultyRepository.Add(faculty);
                response.IsSuccessfull = true;
                return response;
            }
            catch (FacultyDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the Faculty: {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteFacultyAsync(int id)
        {
            try
            {
                var existingFaculty = await _facultyRepository.GetByIdInt(id);

                if (existingFaculty == null)
                {
                    return new Response() { Errors = new List<string> { $"Faculty with Id {id} not found" }, IsSuccessfull = false };
                }

                await _facultyRepository.RemoveEntirely(existingFaculty);
                return Response.Success;
            }
            catch (FacultyDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the Faculty {ex.Message}" } };
            }
        }

        public async Task<Response<List<FacultyDto>>> GetAllFacultiesAsync()
        {
            try
            {
                var faculties = await _facultyRepository.GetAllWithUserAsync();
                var facultyDtos = _mapper.Map<List<FacultyDto>>(faculties);
                return new Response<List<FacultyDto>>() { IsSuccessfull = true, Result = facultyDtos };
            }
            catch (FacultyDataException ex)
            {
                return new Response<List<FacultyDto>>() { Errors = new List<string> { $"An error occurred while fetching all Faculties: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<FacultyDto>> GetFacultyByIdAsync(int id)
        {
            try
            {
                var faculty = await _facultyRepository.GetByIdInt(id);
                if (faculty == null)
                {
                    return new Response<FacultyDto>() { Errors = new List<string> { $"Faculty with Id {id} not found" }, IsSuccessfull = false };
                }

                var facultyDto = _mapper.Map<FacultyDto>(faculty);
                return new Response<FacultyDto>() { IsSuccessfull = true, Result = facultyDto };
            }
            catch (FacultyDataException ex)
            {
                return new Response<FacultyDto> { Errors = new List<string> { $"An error occurred while fetching the Faculty {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateFacultyAsync(int id, UpdateFacultyDto updateDto)
        {
            try
            {
                var response = new Response();
                var existingFaculty = await _facultyRepository.GetByIdInt(id);

                if (existingFaculty == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() { ($"Faculty with ID {id} not found.") };
                    return response;
                }

                await _facultyRepository.Update(existingFaculty);
                return response;
            }
            catch (FacultyDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Faculty {ex.Message}" } };
            }
        }
    }
}
