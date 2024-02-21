using OpenScholarApp.Dtos.ProfessorDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IProfessorService
    {
        Task<Response<List<ProfessorDto>>> GetAllProfessorsAsync();
        Task<Response<ProfessorDto>> GetProfessorAsync(string userId);
        Task<Response> CreateProfessorAsync(AddProfessorDto addDto, string userId);
        Task<Response> UpdateProfessorAsync(string userId, UpdateProfessorDto updateDto);
        Task<Response> DeleteProfessorAsync(int id);
    }
}
