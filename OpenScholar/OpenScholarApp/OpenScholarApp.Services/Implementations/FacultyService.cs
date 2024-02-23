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

        private readonly IFacultyRepository _repository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public FacultyService(IFacultyRepository repository, IUniversityRepository universityRepository,IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _universityRepository = universityRepository;
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateFacultyAsync(string userId, AddFacultyDto facultyDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response("You dont have authorization to add new Faculties");

                var universityExists = await _universityRepository.GetByIdInt(facultyDto.UniversityId);
                if (universityExists == null)
                    return new Response("The specified university does not exist.");

                var faculty = _mapper.Map<Faculty>(facultyDto);
                await _repository.Add(faculty);
                return new Response<AddFacultyDto> { IsSuccessfull = true, Result = facultyDto };
            }
            catch (FacultyDataException ex)
            {
                return new Response($"Error in creating new faculty! {ex.Message}");
            }
        }

        public async Task<Response> DeleteFacultyAsync(string userId, int id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response("You dont have authorization to add new Faculties");

                var faculty = await _repository.GetByIdInt(id);
                if (faculty == null)
                    return new Response("Faculty not found, cannot delete!");

                var response = _repository.RemoveEntirely(faculty);
                return new Response { IsSuccessfull = true, };
            }
            catch (FacultyDataException ex)
            {
                return new Response($"Error in deleting the faculty! {ex.Message}");
            }
        }

        public async Task<Response<List<FacultyDto>>> GetAllFacultiesAsync()
        {
            try
            {
                var faculties = await _repository.GetAll();
                var facultiesDto = _mapper.Map<List<FacultyDto>>(faculties);
                return new Response<List<FacultyDto>>() { IsSuccessfull = true, Result = facultiesDto };
            }
            catch (FacultyDataException ex)
            {
                return new Response<List<FacultyDto>>($"Error getting all the faculties! {ex.Message}");
            }
        }

        public async Task<Response<FacultyDto>> GetFacultyByIdAsync(int id)
        {
            try
            {
                var faculty = await _repository.GetByIdInt(id);
                var facultyDto = _mapper.Map<FacultyDto>(faculty);
                return new Response<FacultyDto>() { IsSuccessfull = true, Result = facultyDto };
            }
            catch (FacultyDataException ex)
            {
                return new Response<FacultyDto>($"Error getting the faculty! {ex.Message}");
            }
        }

        public async Task<Response> UpdateFacultyAsync(string userId, int id, UpdateFacultyDto updateFacultyDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new Response("You dont have authorization to update Faculty");

            var faculty = await _repository.GetByIdInt(id);
            if (faculty == null)
                return new Response("Faculty not found, cannot update!");

            var updatedFaculty = _mapper.Map(updateFacultyDto, faculty);
            await _repository.Update(updatedFaculty);
            return new Response<UpdateFacultyDto> { IsSuccessfull = true, Result = updateFacultyDto };
        }
    }
}
