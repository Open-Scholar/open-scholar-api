using OpenScholarApp.Dtos.StudentDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
        Task Add(AddStudentDto addDto, string userId);
        Task Update(UpdateStudentDto updateDto);
        Task Delete(int id);
    }
}

