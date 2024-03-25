using AutoMapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MimeKit;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.ApplicationUserDtos;
using OpenScholarApp.Services.StorageServices;
using OpenScholarApp.Services.UserServices.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.EmailExceptions;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;
using OpenScholarApp.Shared.Requests;
using OpenScholarApp.Shared.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Web;

namespace OpenScholarApp.Services.UserServices.Implementations
{
    public class MembershipService : IMembershipService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public MembershipService(UserManager<ApplicationUser> userManager,
                                 IMapper mapper,
                                 ITokenService tokenService,
                                 IConfiguration configuration,
                                 IBlobService blobService)
        {
            _blobService = blobService;
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
            _config = configuration;
        }

        private string GenerateResetPasswordLink(ApplicationUser user, string token)
        {
            var url = _config.GetSection("CurrentUrl").Value;
            var resetPasswordUrl = $"{url}/reset-password?email={user.Email}&token={Uri.EscapeDataString(token)}";
            return resetPasswordUrl;
        }

        public async Task<Response> UploadUserPhotoAsync(string userId, IFormFile photo)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response("User not found.");

                using (var stream = new MemoryStream())
                {
                    await photo.CopyToAsync(stream);
                    stream.Position = 0;
                    user.PhotoUrl = await _blobService.UploadFileAsync(stream, $"{userId}/{photo.FileName}");
                }

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                    return new Response(result.Errors.Select(e => e.Description));

                return new Response("Photo uploaded successfully.");
            }
            catch (UserDataException ex)
            {
                return new Response($"error while uploading the user photo! {ex.Message}");
            }
        }

        public async Task<Response> RemoveUserPhotoAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response("User not found.");

                if (string.IsNullOrWhiteSpace(user.PhotoUrl))
                    return new Response("No photo to remove.");

                await _blobService.DeleteFileAsync(user.PhotoUrl);
                user.PhotoUrl = string.Empty;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                    return new Response(result.Errors.Select(e => e.Description));

                return new Response("Photo removed successfully.");
            }
            catch (UserDataException ex)
            {
                return new Response($"Error in removing the photo! {ex.Message}");
            }
        }

        public async Task<Response> ChangeUserPhotoAsync(string userId, IFormFile newPhoto)
        {
            try
            {
                var removalResponse = await RemoveUserPhotoAsync(userId);
                if (!removalResponse.IsSuccessfull)
                    return removalResponse;

                return await UploadUserPhotoAsync(userId, newPhoto);
            }
            catch (UserDataException ex)
            {
                return new Response($"error while changing the user photo! {ex.Message}");
            }
        }

        public async Task<Response> DeleteUserAsync(string id, DeleteUserDto password)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var inputPassword = password.Password;
                    var passwordIsValid = await _userManager.CheckPasswordAsync(user, inputPassword);
                    if (!passwordIsValid)
                        return new("invalid password or username");

                    var result = await _userManager.DeleteAsync(user);
                    if (!result.Succeeded)
                        return new Response(result.Errors.Select(error => error.Description));

                    return new Response<DeleteUserDto> { IsSuccessfull = true };
                }
                else
                {
                    return new Response("User not found.");
                }
            }
            catch (UserDataException ex)
            {
                return new Response($"error while deleting the user {ex.Message}");
            }
        }

        public async Task ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserDataException($"There is no user with this email {email}.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPasswordLink = GenerateResetPasswordLink(user, token);
            await SendEmailAsync(email, resetPasswordLink);
        }

        public async Task<Response> GetAllUsers()
        {
            try
            {
                var response = new Response<List<ApplicationUser>>();
                var userDb = await _userManager.Users.ToListAsync();
                response.Result = userDb;
                response.IsSuccessfull = true;
                return response;
            }
            catch (UserDataException ex)
            {
                return new Response($"Error in getting all users! {ex.Message}");
            }
        }

        public async Task<Response<ApplicationUserDto>> GetUserByIdAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                    return new Response<ApplicationUserDto>("User not found.");

                var userDto = _mapper.Map<ApplicationUserDto>(user);
                return new Response<ApplicationUserDto>(userDto);
            }
            catch (UserDataException ex)
            {
                return new Response<ApplicationUserDto>($"Error while getting the user {ex.Message}");
            }
        }

        public Task<Response> GetUserByIdInt(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<LoginUserResponse>> LoginUserAsync(LoginUserRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request?.Username))
                    throw new UserDataException("username is a required field");

                if (string.IsNullOrWhiteSpace(request?.Password))
                    throw new UserDataException("password is a required field");

                var user = await _userManager.FindByNameAsync(request.Username);
                if (user == null)
                    return new("invalid password or username");

                var passwordIsValid = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!passwordIsValid)
                    return new("invalid password or username");

                var token = await _tokenService.GenerateTokenAsync(user);
                return new Response<LoginUserResponse>(new LoginUserResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ValidTo = token.ValidTo
                });
            }
            catch (UserDataException ex)
            {
                return new Response<LoginUserResponse>($"Error while logging in! {ex.Message}");
            }
        }

        public async Task<Response<RegisterUserResponse>> RegisterUserAsync(RegisterUserRequest request)
        {
            try
            {
                var existingMail = _userManager.FindByEmailAsync(request.Email);
                if (existingMail.Result != null)
                    return new Response<RegisterUserResponse>("user with provded mail already exists!");

                if (string.IsNullOrWhiteSpace(request?.Username))
                    throw new UserDataException("username is a required field");

                if (string.IsNullOrWhiteSpace(request?.Email))
                    throw new UserDataException(" is a required field");

                if (string.IsNullOrWhiteSpace(request?.Password))
                    throw new UserDataException("username is a required field");

                if (string.IsNullOrWhiteSpace(request?.AccountType.ToString()))
                    throw new UserDataException("Account type is a required field");

                var user = new ApplicationUser { UserName = request.Username, Email = request.Email, AccountType = request.AccountType };
                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                    return new(result.Errors.Select(x => x.Description));

                return new(new RegisterUserResponse
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    AccountType = user.AccountType
                });
            }
            catch (UserDataException ex)
            {
                return new Response<RegisterUserResponse>($"Error while creating the account {ex.Message}");
            }
        }

        public async Task<Response> ResetPassword(string email, string token, string newPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    return new Response($"There is no user with this email {email}.");

                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
                if (!result.Succeeded)
                    return new Response(result.Errors.Select(error => error.Description));

                return new Response(result.Errors.Select(error => error.Description));
            }
            catch (Exception ex)
            {
                return new Response($"Could not Reset password! ${ex.Message}");
            }
        }

        public async Task<Response> ChangePassword(string userId, ChangePassword model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response($"User Not Found!");

                bool isProvidedPasswordValid = await _userManager.CheckPasswordAsync(user, model.ExistingPassword);
                if (isProvidedPasswordValid == false)
                    return new Response("Provided password is not valid, please try again");

                var result = await _userManager.ChangePasswordAsync(user, model.ExistingPassword, model.NewPassword);
                if (!result.Succeeded)
                    return new Response("Operation unsuccessfull!");

                return new Response {IsSuccessfull = true};
            }
            catch (UserDataException ex)
            {
                return new Response($"Error in changing the password {ex.Message}");
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
                HtmlBody = $"Dear user, you have requested to reset your password. " +
                $"Please click on the following link to reset your password: <a href=\"{resetPasswordLink}\">CLICK HERE</a>. " +
                "If this request was made by mistake, please disregard this message."
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
                    throw new EmailSendingException($"An error occurred while sending the email. Exception {e}");
                }
                finally
                {
                    await smtp.DisconnectAsync(true);
                }
            }
        }

        public async Task<Response<ApplicationUserDto>> UpdateUserAsync(string id, ApplicationUserDto updatedUser)
        {

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return new Response<ApplicationUserDto>("User not found.");

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return new Response<ApplicationUserDto>(result.Errors.Select(error => error.Description));

            return new Response<ApplicationUserDto>("User updated successfully.");
        }

        public async Task<Response> ConfirmAccountSendMail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return new Response("User not found");

            var userEmail = user.Email;
            if (userEmail == null)
                return new Response($"Email {userEmail} not found!");
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = $"https://open-scholar.vercel.app/confirm-account?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Open Scholar Service mail", _config.GetSection("EmailUsername").Value));
            email.To.Add(new MailboxAddress("Recipient Name", $"{userEmail}"));
            email.Subject = "Account Confirmation";

            var builder = new BodyBuilder
            {
                HtmlBody = "Dear user, you are just one step away from creating your account. " +
                $"Please click on the following link to confirm your account: <a href=\"{callbackUrl}\">CLICK HERE</a>. " +
                "If this request was made by mistake, please disregard this message."
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
                    throw new EmailSendingException($"An error occurred while sending the confirm account email. Exception {e}");
                }
                finally
                {
                    await smtp.DisconnectAsync(true);
                }
            }
            return new Response("Email Send");
        }

        public async Task<Response> ConfirmAccountCheck(string userId, string token)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return new Response("User not found");

                var decodedToken = HttpUtility.UrlDecode(token);
                var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
                if (!result.Succeeded)
                    return new Response("Account is already verified");
                user.IsAccountVerified = true;

                var updatedUser = await _userManager.UpdateAsync(user);

                if (!updatedUser.Succeeded)
                    return new Response("Problem in confirming account!");

                return new Response { IsSuccessfull = true };
            }
            catch (UserDataException e)
            {
                return new Response($"There is problem with account confirmation, contact admin {e.Message}");
            }
        }
    }
}
