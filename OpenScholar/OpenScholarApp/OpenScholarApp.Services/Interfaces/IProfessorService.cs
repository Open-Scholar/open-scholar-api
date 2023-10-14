using OpenScholarApp.Dtos.ProfessorDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IProfessorService
    {
        Task<Response<List<ProfessorDto>>> GetAllProfessorsAsync();
        Task<Response<ProfessorDto>> GetProfessorByIdAsync(int id);
        Task<Response> CreateProfessorAsync(AddProfessorDto addDto, string userId);
        Task<Response> UpdateProfessorAsync(int id, UpdateProfessorDto updateDto);
        Task<Response> DeleteProfessorAsync(int id);
    }
}
