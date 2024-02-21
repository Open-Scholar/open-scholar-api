using OpenScholarApp.Dtos.FacultyDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IFacultyAccService
    {
        Task<Response<List<FacultyAccDto>>> GetAllFacultiesAsync();
        Task<Response<FacultyAccDto>> GetFacultyByIdAsync(int id);
        Task<Response> CreateFacultyAsync(AddFacultyAccDto addDto, string userId);
        Task<Response> UpdateFacultyAsync(int id, UpdateFacultyAccDto updateDto);
        Task<Response> DeleteFacultyAsync(int id);
    }
}
