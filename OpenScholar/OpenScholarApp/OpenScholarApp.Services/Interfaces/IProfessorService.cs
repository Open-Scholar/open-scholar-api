using OpenScholarApp.Dtos.ProfessorDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IProfessorService
    {
        Task<List<ProfessorDto>> GetAll();
        Task<ProfessorDto> GetById(int id);
        Task Add(AddProfessorDto addDto, string userId);
        Task Update(UpdateProfessorDto updateDto);
        Task Delete(int id);
    }
}
