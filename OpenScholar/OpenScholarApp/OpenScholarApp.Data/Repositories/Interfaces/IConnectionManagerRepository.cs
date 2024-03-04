using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IConnectionManagerRepository : IBaseRepository<UserConnection>
    {
        Task AddConnectionAsync(string userId, string connectionId);
        Task RemoveConnectionAsync(string connectionId);
        Task<IEnumerable<string>> GetConnectionsAsync(string userId);
    }
}
