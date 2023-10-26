using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.ProfessorDto;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.ProfessorExceptions;
using OpenScholarApp.Shared.CustomExceptions.StudentExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfessorService(IProfessorRepository professorRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _professorRepository = professorRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateProfessorAsync(AddProfessorDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var professor = _mapper.Map<Professor>(addDto);
                var user = await _userManager.FindByIdAsync(addDto.UserId);
                if (user == null)
                    throw new StudentDataException("User not found");

                if (user.IsProfileCreated == true)
                    return new Response<AddStudentDto>("Account already exists");

                if (user.AccountType != AccountType.Professor)
                    return new Response<AddStudentDto>("You can only create Professor account type");

                professor.User = user;
                await _professorRepository.Add(professor);
                user.IsProfileCreated = true;
                await _userManager.UpdateAsync(user);
                response.IsSuccessfull = true;
                return response;
            }
            catch (StudentDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the student: {ex.Message}" } };
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

        public async Task<Response<ProfessorDto>> GetProfessorByIdAsync(int id)
        {
            try
            {
                var professor = await _professorRepository.GetByIdInt(id);
                if (professor == null)
                {
                    return new Response<ProfessorDto>() { Errors = new List<string> { $"Professor with Id {id} not found" }, IsSuccessfull = false };
                }

                var professorDto = _mapper.Map<ProfessorDto>(professor);
                return new Response<ProfessorDto>() { IsSuccessfull = true, Result = professorDto };
            }
            catch (ProfessorDataException ex)
            {
                return new Response<ProfessorDto> { Errors = new List<string> { $"An error occurred while fetching the Professor {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateProfessorAsync(int id, UpdateProfessorDto updateDto)
        {
            try
            {
                var response = new Response();
                var existingProfessor = await _professorRepository.GetByIdInt(id);

                if (existingProfessor == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() { ($"Professor with ID {id} not found.") };
                    return response;
                }

                await _professorRepository.Update(existingProfessor);
                return response;
            }
            catch (ProfessorDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Professor {ex.Message}" } };
            }
        }
    }
}
