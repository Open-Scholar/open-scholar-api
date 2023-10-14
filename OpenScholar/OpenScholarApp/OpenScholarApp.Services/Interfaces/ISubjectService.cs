using OpenScholarApp.Dtos.SubjectDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<Response<List<SubjectDto>>> GetAllSubjectsAsync();
        Task<Response<SubjectDto>> GetSubjectByIdAsync(int id);
        Task<Response> CreateSubjectAsync(AddSubjectDto addDto, string userId);
        Task<Response> UpdateSubjectAsync(int id, UpdateSubjectDto updateDto);
        Task<Response> DeleteSubjectAsync(int id);
    }
}
