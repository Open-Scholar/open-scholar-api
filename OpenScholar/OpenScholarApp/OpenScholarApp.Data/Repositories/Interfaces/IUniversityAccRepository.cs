using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IUniversityAccRepository : IBaseRepository<UniversityAcc>
    {
        Task<List<UniversityAcc>> GetAllWithUserAsync();
    }
}
