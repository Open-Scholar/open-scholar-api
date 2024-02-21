using OpenScholarApp.Dtos.University;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IUniversityService
    {
        Task<Response<List<UniversityDto>>> GetAllUniversitiesAsync();
        Task<Response<UniversityDto>> GetUniversityByIdAsync(int id);
        Task<Response> CreateUniversityAsync(string userId, AddUniversityDto universityDto);
        Task<Response> UpdateUniversityAsync(string userId, int id, UpdateUniversityDto updateFacultyDto);
        Task<Response> DeleteUniversityAsync(string userId, int id);
    }
}
