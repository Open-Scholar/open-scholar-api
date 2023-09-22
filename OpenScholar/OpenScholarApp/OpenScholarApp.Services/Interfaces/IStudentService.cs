using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Response> CreateStudentAsync(AddStudentDto studentDto);
        Task<Response> UpdateStudentAsync(string id, UpdateStudentDto updatedStudentDto);
        Task<Response> DeleteStudentAsync(string id);
        Task<Response<StudentDto>> GetStudentByIdAsync(string id);
        Task<Response<List<StudentDto>>> GetAllStudentsAsync();
    }
}

