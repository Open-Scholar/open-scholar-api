using Microsoft.AspNetCore.Http;
using OpenScholarApp.Dtos.ApplicationUserDtos;
using OpenScholarApp.Shared.Requests;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.UserServices.Interfaces
{
    public interface IMembershipService
    {
        Task<Response> UploadUserPhotoAsync(string userId, IFormFile photo);
        Task<Response> ConfirmAccountCheck(string userId, string token);
        Task<Response> ConfirmAccountSendMail(string id);
        Task<Response<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request);
        Task<Response<LoginUserResponse>> LoginUserAsync(LoginUserRequest request);
        Task<Response> GetAllUsers();
        Task<Response<ApplicationUserDto>> GetUserByIdAsync(string id);
        Task<Response> GetUserByIdInt(int id);
        Task<Response<ApplicationUserDto>> UpdateUserAsync(string id, ApplicationUserDto updatedUser);
        Task<Response> DeleteUserAsync(string id, DeleteUserDto password);
        Task ForgotPassword(string email);
        Task<Response> ResetPassword(string email, string token, string newPassword);
        Task<Response> ChangePassword(string userId, ChangePassword model);
        Task SendEmailAsync(string toEmail, string resetPasswordLink);
    }
}
