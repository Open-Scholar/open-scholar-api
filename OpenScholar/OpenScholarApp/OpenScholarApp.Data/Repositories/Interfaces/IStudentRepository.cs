using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<List<Student>> GetAllWithUserAsync();
        Task<Student> GetByUserIdAsync(string userId);
    }
}
