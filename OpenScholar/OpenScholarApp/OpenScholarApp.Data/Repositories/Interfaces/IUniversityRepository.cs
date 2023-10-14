using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IUniversityRepository : IBaseRepository<University>
    {
        Task<List<University>> GetAllWithUserAsync();
    }
}
