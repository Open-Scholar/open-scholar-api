using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Response> CreateStudentAsync(AddStudentDto studentDto, string UserId);
        Task<Response> UpdateStudentAsync(string userId, UpdateStudentDto updatedStudentDto);
        Task<Response> DeleteStudentAsync(int id);
        Task<Response<StudentDto>> GetStudent(string userId);
        Task<Response<List<StudentDto>>> GetAllStudentsAsync();
    }
}

