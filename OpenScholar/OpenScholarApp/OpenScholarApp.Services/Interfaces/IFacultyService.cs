using OpenScholarApp.Dtos.FacultyDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<Response<List<FacultyDto>>> GetAllFacultiesAsync();
        Task<Response<FacultyDto>> GetFacultyByIdAsync(int id);
        Task<Response> CreateFacultyAsync(AddFacultyDto addDto, string userId);
        Task<Response> UpdateFacultyAsync(int id, UpdateFacultyDto updateDto);
        Task<Response> DeleteFacultyAsync(int id);
    }
}
