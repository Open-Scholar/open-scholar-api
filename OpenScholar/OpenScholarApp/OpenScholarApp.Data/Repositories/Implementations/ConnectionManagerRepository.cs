using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class ConnectionManagerRepository : BaseRepository<UserConnection>, IConnectionManagerRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public ConnectionManagerRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task AddConnectionAsync(string userId, string connectionId)
        {
            _openScholarDbContext.UserConnections.Add(new UserConnection { UserId = userId, ConnectionId = connectionId });
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task RemoveConnectionAsync(string connectionId)
        {
            var connection = await _openScholarDbContext.UserConnections.FirstOrDefaultAsync(uc => uc.ConnectionId == connectionId);
            if (connection != null)
            {
                _openScholarDbContext.UserConnections.Remove(connection);
                await _openScholarDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<string>> GetConnectionsAsync(string userId)
        {
            return await _openScholarDbContext.UserConnections
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.ConnectionId)
                .ToListAsync();
        }
    }
}
