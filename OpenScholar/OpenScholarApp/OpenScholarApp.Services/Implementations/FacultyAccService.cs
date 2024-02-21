using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.FacultyDto;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.FacultyExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class FacultyAccService : IFacultyAccService
    {
        private readonly IFacultyAccRepository _facultyRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public FacultyAccService(IFacultyAccRepository facultyRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateFacultyAsync(AddFacultyAccDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var faculty = _mapper.Map<FacultyAcc>(addDto);
                var user = await _userManager.FindByIdAsync(addDto.UserId);

                if (user == null)
                    throw new FacultyAccDataException("User not found");

                if (user.IsProfileCreated == true)
                    return new Response<AddStudentDto>("Account already exists");

                if (user.AccountType != AccountType.Faculty)
                    return new Response<AddStudentDto>("You can only create Faculty account type");

                faculty.User = user;
                await _facultyRepository.Add(faculty);
                user.IsProfileCreated = true;
                await _userManager.UpdateAsync(user);
                response.IsSuccessfull = true;
                return response;
            }
            catch (FacultyAccDataException ex)
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
            catch (FacultyAccDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the Faculty {ex.Message}" } };
            }
        }

        public async Task<Response<List<FacultyAccDto>>> GetAllFacultiesAsync()
        {
            try
            {
                var faculties = await _facultyRepository.GetAllWithUserAsync();
                var facultyDtos = _mapper.Map<List<FacultyAccDto>>(faculties);
                return new Response<List<FacultyAccDto>>() { IsSuccessfull = true, Result = facultyDtos };
            }
            catch (FacultyAccDataException ex)
            {
                return new Response<List<FacultyAccDto>>() { Errors = new List<string> { $"An error occurred while fetching all Faculties: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<FacultyAccDto>> GetFacultyByIdAsync(int id)
        {
            try
            {
                var faculty = await _facultyRepository.GetByIdInt(id);
                if (faculty == null)
                {
                    return new Response<FacultyAccDto>() { Errors = new List<string> { $"Faculty with Id {id} not found" }, IsSuccessfull = false };
                }

                var facultyDto = _mapper.Map<FacultyAccDto>(faculty);
                return new Response<FacultyAccDto>() { IsSuccessfull = true, Result = facultyDto };
            }
            catch (FacultyAccDataException ex)
            {
                return new Response<FacultyAccDto> { Errors = new List<string> { $"An error occurred while fetching the Faculty {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateFacultyAsync(int id, UpdateFacultyAccDto updateDto)
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
            catch (FacultyAccDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Faculty {ex.Message}" } };
            }
        }
    }
}
