using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.ProfessorDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.ProfessorExceptions;
using OpenScholarApp.Shared.CustomExceptions.StudentExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfessorService(IProfessorRepository professorRepository, IFacultyRepository facultyRepository, IUniversityRepository universityRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _professorRepository = professorRepository;
            _facultyRepository = facultyRepository;
            _universityRepository = universityRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateProfessorAsync(AddProfessorDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var professor = _mapper.Map<Professor>(addDto);
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    throw new StudentDataException("User not found");

                if (user.IsProfileCreated == true)
                    return new Response<AddProfessorDto>("Account already exists");

                if (user.AccountType != AccountType.Professor)
                    return new Response<AddProfessorDto>("You can only create Professor account type");

                var faculty = await _facultyRepository.GetByIdInt(addDto.FacultyId);
                if (faculty == null)
                {
                    return new Response<AddProfessorDto>("Faculty not found while trying to add professor!");
                }
                professor.Faculty = faculty;
                professor.FacultyId = addDto.FacultyId;

                var university = await _universityRepository.GetByIdInt(addDto.UniversityId);
                if (university == null)
                {
                    return new Response<AddProfessorDto>("University not found while trying to add professor");
                }
                professor.University = university;
                professor.universityId = addDto.UniversityId;

                professor.User = user;
                professor.ApplicationUserId = userId;
                await _professorRepository.Add(professor);
                user.IsProfileCreated = true;
                await _userManager.UpdateAsync(user);
                response.IsSuccessfull = true;
                return response;
            }
            catch (ProfessorDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the Professor: {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteProfessorAsync(int id)
        {
            try
            {
                var existingProfessor = await _professorRepository.GetByIdInt(id);

                if (existingProfessor == null)
                {
                    return new Response() { Errors = new List<string> { $"Professor with Id {id} not found" }, IsSuccessfull = false };
                }

                await _professorRepository.RemoveEntirely(existingProfessor);
                return Response.Success;
            }
            catch (ProfessorDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the Professor {ex.Message}" } };
            }
        }

        public async Task<Response<List<ProfessorDto>>> GetAllProfessorsAsync()
        {
            try
            {
                var professors = await _professorRepository.GetAllWithUserAsync();
                var professorDtos = _mapper.Map<List<ProfessorDto>>(professors);
                return new Response<List<ProfessorDto>>() { IsSuccessfull = true, Result = professorDtos };
            }
            catch (ProfessorDataException ex)
            {
                return new Response<List<ProfessorDto>>() { Errors = new List<string> { $"An error occurred while fetching all Professors: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<ProfessorDto>> GetProfessorAsync(string userId)
        {
            try
            {
                var professor = await _professorRepository.GetByUserIdAsync(userId);
                if (professor == null)
                {
                    return new Response<ProfessorDto>() { Errors = new List<string> { $"Professor account not found" }, IsSuccessfull = false };
                }

                var professorDto = _mapper.Map<ProfessorDto>(professor);
                return new Response<ProfessorDto>() { IsSuccessfull = true, Result = professorDto };
            }
            catch (ProfessorDataException ex)
            {
                return new Response<ProfessorDto> { Errors = new List<string> { $"An error occurred while fetching the Professor {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateProfessorAsync(string userId, UpdateProfessorDto updatedProfessorDto)
        {
            try
            {
                var existingProfessor = await _professorRepository.GetByUserIdAsync(userId);

                if (existingProfessor == null)
                {
                    return new Response<UpdateProfessorDto>("Account not found!");
                }
                var updatedProfessor = _mapper.Map(updatedProfessorDto, existingProfessor);

                var result = _professorRepository.Update(updatedProfessor);
                return new Response<UpdateProfessorDto> { IsSuccessfull = true, Result = updatedProfessorDto };
            }
            catch (ProfessorDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Professor {ex.Message}" } };
            }
        }
    }
}
