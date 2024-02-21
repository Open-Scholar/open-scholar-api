using OpenScholarApp.Dtos.FacultyDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<Response<List<FacultyDto>>> GetAllFacultiesAsync();
        Task<Response<FacultyDto>> GetFacultyByIdAsync(int id);
        Task<Response> CreateFacultyAsync(string userId, AddFacultyDto facultyDto);
        Task<Response> UpdateFacultyAsync(string userId, int id, UpdateFacultyDto updateFacultyDto);
        Task<Response> DeleteFacultyAsync(string userId, int id);
    }
}
