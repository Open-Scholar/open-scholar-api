using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IFacultyRepository : IBaseRepository<Faculty>
    {
        Task<List<Faculty>> GetAllWithUserAsync();
    }
}
