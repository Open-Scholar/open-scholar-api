using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface ITopicRepository : IBaseRepository<Topic>
    {
        Task<List<Topic>> GetAllWithUserAsync();
        Task<List<Topic>> GetAllWithUserAndFiltersAsync(int? facultyId = null, int pageNumber = 1, int pageSize = 10);
    }
}
