using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Services.Helpers.Interaces
{
    public interface IUserHelperService
    {
        Task<string> GetUsername(ApplicationUser user);
    }
}
