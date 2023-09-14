using OpenScholarApp.Dtos.FacultyDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<List<FacultyDto>> GetAll();
        Task<FacultyDto> GetById(int id);
        Task Add(AddFacultyDto addDto, string userId);
        Task Update(UpdateFacultyDto updateDto);
        Task Delete(int id);
    }
}
