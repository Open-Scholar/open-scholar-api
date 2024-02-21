using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IFacultyAccRepository : IBaseRepository<FacultyAcc>
    {
        Task<List<FacultyAcc>> GetAllWithUserAsync();
    }
}
