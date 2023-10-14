using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Response> CreateStudentAsync(AddStudentDto studentDto);
        Task<Response> UpdateStudentAsync(int id, UpdateStudentDto updatedStudentDto);
        Task<Response> DeleteStudentAsync(int id);
        Task<Response<StudentDto>> GetStudentByIdAsync(int id);
        Task<Response<List<StudentDto>>> GetAllStudentsAsync();
    }
}

