using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenScholarApp.Data.Context;

namespace OpenScholarApp.Services.CleanUpServices
{
    public class NotificationCleanupService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationCleanupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await DeleteOldNotifications(stoppingToken);
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }

        private async Task DeleteOldNotifications(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<OpenScholarDbContext>();
                var notificationsToDelete = dbContext.UserNotifications
                    .Where(n => n.CreatedAt < DateTimeOffset.UtcNow.AddDays(-30));

                dbContext.UserNotifications.RemoveRange(notificationsToDelete);
                await dbContext.SaveChangesAsync(stoppingToken);
            }
        }
    }
}
