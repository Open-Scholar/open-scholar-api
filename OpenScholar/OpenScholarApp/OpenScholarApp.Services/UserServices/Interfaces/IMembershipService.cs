using OpenScholarApp.Shared.Requests;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.UserServices.Interfaces
{
    public interface IMembershipService
    {
        Task<Response<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request);
        Task<Response<LoginUserResponse>> LoginUserAsync(LoginUserRequest request);
    }
}
