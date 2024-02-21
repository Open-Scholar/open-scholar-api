using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        Task<List<Professor>> GetAllWithUserAsync();
        Task<Professor> GetByUserIdAsync(string userId);
    }
}
