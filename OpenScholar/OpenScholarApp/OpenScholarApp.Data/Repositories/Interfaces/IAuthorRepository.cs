using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<List<Author>> GetAllWithBookAsync();
    }
}
