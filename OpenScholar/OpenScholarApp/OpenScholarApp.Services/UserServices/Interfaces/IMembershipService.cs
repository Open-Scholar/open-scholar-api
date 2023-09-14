using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.ApplicationUserDtos;
using OpenScholarApp.Shared.Requests;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.UserServices.Interfaces
{
    public interface IMembershipService
    {
        Task<Response<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request);
        Task<Response<LoginUserResponse>> LoginUserAsync(LoginUserRequest request);
        Task<Response> GetAllUsers();
        Task<Response<ApplicationUser>> GetUserByIdAsync(string id);
        Task<Response> GetUserByIdInt(int id);
        Task<Response<ApplicationUserDto>> UpdateUserAsync(string id, ApplicationUserDto updatedUser);
        //Task<Response> UpdateUserint(int id);
        Task<Response> DeleteUserAsync(string id);
        //Task<Response> DeleteUser(int id);
        Task ForgotPassword(string email);
        Task<Response> ResetPassword(string email, string token, string newPassword);
        Task SendEmailAsync(string toEmail, string resetPasswordLink);
    }
}
