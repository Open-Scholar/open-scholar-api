using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IBookStoreRepository : IBaseRepository<BookStore> 
    {
        Task<List<BookStore>> GetAllWithUserAsync();
        Task<BookStore> GetByUserIdAsync(string userId);
    }
}
