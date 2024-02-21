using OpenScholarApp.Dtos.UniversityAccDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IUniversityAccService
    {
        Task<Response<List<UniversityAccDto>>> GetAllUniversitiesAsync();
        Task<Response<UniversityAccDto>> GetUniversityByIdAsync(int id);
        Task<Response> CreateUniversityAsync(AddUniversityAccDto addDto, string userId);
        Task<Response> UpdateUniversityAsync(int id, UpdateUniversityAccDto updateDto);
        Task<Response> DeleteUniversityAsync(int id);
    }
}
