using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MimeKit;
//using OpenScholarApp.Data.IdentityModels;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Services.UserServices.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.EmailExceptions;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;
using OpenScholarApp.Shared.Requests;
using OpenScholarApp.Shared.Responses;
using System.IdentityModel.Tokens.Jwt;
//using System.Net.Mail;

namespace OpenScholarApp.Services.UserServices.Implementations
{
    public class MembershipService : IMembershipService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public MembershipService(UserManager<ApplicationUser> userManager, ITokenService tokenService, IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _config = configuration;

        }

        private string GenerateResetPasswordLink(ApplicationUser user, string token)
        {
            // Construct the reset password URL using your application's URL structure
            var resetPasswordUrl = $"https://example.com/reset-password?email={user.Email}&token={Uri.EscapeDataString(token)}";
            return resetPasswordUrl;
        }

        public Task<Response> DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserDataException($"There is no user with this email {email}.");
            }

            // Generate a password reset token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Generate a password reset link using the token
            var resetPasswordLink = GenerateResetPasswordLink(user, token);

            // Send the password reset email
            await SendEmailAsync(email, resetPasswordLink);
        }

        public Task<Response> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetResetPasswordToken(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetUserByIdInt(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<LoginUserResponse>> LoginUserAsync(LoginUserRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Username))
                throw new UserDataException("username is a required field");

            if (string.IsNullOrWhiteSpace(request?.Password))
                throw new UserDataException("password is a required field");

            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                return new("user does not exist");

            var passwordIsValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordIsValid)
                return new("invalid password");

            var token = await _tokenService.GenerateTokenAsync(user);

            return new Response<LoginUserResponse>(new LoginUserResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            });
        }

        public async Task<Response<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(request?.Username))
                throw new UserDataException("username is a required field");

            if (string.IsNullOrWhiteSpace(request?.Email)) //additional email validation can be added here
                throw new UserDataException(" is a required field");

            if (string.IsNullOrWhiteSpace(request?.Password)) //additional password validation can be added here
                throw new UserDataException("username is a required field");

            var user = new ApplicationUser { UserName = request.Username, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return new(result.Errors.Select(x => x.Description));

            return new(new RegisterUserResponse
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email
            });
        }

        public async Task<Response> ResetPassword(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserDataException($"There is no user with this email {email}.");
            }

            // Verify the token and reset the password
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (result.Succeeded)
            {
                // Password reset was successful
                return new Response("Password reset successful.");
            }
            else
            {
                // Password reset failed, handle errors
                return new Response(result.Errors.Select(error => error.Description));
            }
        }

        public async Task SendEmailAsync(string toEmail, string resetPasswordLink)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Open Scholar Service mail", _config.GetSection("EmailUsername").Value));
            email.To.Add(new MailboxAddress("Recipient Name", toEmail));
            email.Subject = "Password Reset";

            var builder = new BodyBuilder
            {
                HtmlBody = $"Click <a href=\"{resetPasswordLink}\">here</a> to reset your password."
            };
            email.Body = builder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
                    await smtp.SendAsync(email);
                }
                catch (Exception e)
                {
                    // Handle the exception, log it, and possibly notify the user.
                    // You might want to create a custom exception or error response.
                    throw new EmailSendingException($"An error occurred while sending the email. Exception {e}");
                }
                finally
                {
                    await smtp.DisconnectAsync(true);
                }
            }
        }

        public Task<Response> UpdateUser(string id)
        {
            throw new NotImplementedException();
        }
    }

}
