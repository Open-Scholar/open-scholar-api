using OpenScholarApp.Dtos.SubjectDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectDto>> GetAll();
        Task<SubjectDto> GetById(int id);
        Task Add(AddSubjectDto addDto, string userId);
        Task Update(UpdateSubjectDto updateDto);
        Task Delete(int id);
    }
}
