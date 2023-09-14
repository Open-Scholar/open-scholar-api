using OpenScholarApp.Shared.Requests;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.UserServices.Interfaces
{
    public interface IMembershipService
    {
        Task<Response<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request);
        Task<Response<LoginUserResponse>> LoginUserAsync(LoginUserRequest request);
        Task<Response> GetAllUsers();
        Task<Response> GetUserById(string id);
        Task<Response> GetUserByIdInt(int id);
        Task<Response> UpdateUser(string id);
        //Task<Response> UpdateUserint(int id);
        Task<Response> DeleteUser(string id);
        //Task<Response> DeleteUser(int id);
        Task ForgotPassword(string email);
        Task<Response> ResetPassword(string email, string token, string newPassword);
        Task<Response> GetResetPasswordToken(string email);
        Task SendEmailAsync(string toEmail, string resetPasswordLink);
    }
}
