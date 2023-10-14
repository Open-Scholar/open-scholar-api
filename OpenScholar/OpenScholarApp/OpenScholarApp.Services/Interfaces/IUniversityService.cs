using OpenScholarApp.Dtos.UniversityDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IUniversityService
    {
        Task<Response<List<UniversityDto>>> GetAllUniversitiesAsync();
        Task<Response<UniversityDto>> GetUniversityByIdAsync(int id);
        Task<Response> CreateUniversityAsync(AddUniversityDto addDto, string userId);
        Task<Response> UpdateUniversityAsync(int id, UpdateUniversityDto updateDto);
        Task<Response> DeleteUniversityAsync(int id);
    }
}
