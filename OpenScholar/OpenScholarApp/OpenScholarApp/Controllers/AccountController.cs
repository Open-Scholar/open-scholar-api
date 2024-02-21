using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.ApplicationUserDtos;
using OpenScholarApp.Services.UserServices.Interfaces;
using OpenScholarApp.Services.UserServices.Models;
using OpenScholarApp.Shared.CustomExceptions;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;
using OpenScholarApp.Shared.Requests;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserModel model)
        {
            try
            {
                var request = new RegisterUserRequest
                {
                    Email = model.Email,
                    Password = model.Password,
                    Username = model.UserName,
                    AccountType = model.AccountType
                };
                var response = await _membershipService.RegisterUserAsync(request);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserModel model)
        {
            try
            {
                var request = new LoginUserRequest
                {
                    Password = model.Password,
                    Username = model.Username,
                };
                var response = await _membershipService.LoginUserAsync(request);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    throw new UserNotFoundException("You are not authorized!");
                }
                var response = await _membershipService.GetAllUsers();

                if (response.IsSuccessfull)
                    return BadRequest(response.Errors);

                return Ok(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return NotFound("User Not Found");
                }
                var response = await _membershipService.GetUserByIdAsync(userId);
                if (!response.IsSuccessfull)
                    return BadRequest(response.Errors);

                return Ok(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDto password)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return NotFound("User Not Found");
                
                var response = await _membershipService.DeleteUserAsync(userId, password);
                if (!response.IsSuccessfull)
                    return BadRequest(response.Errors);

                return Ok(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] ApplicationUserDto updatedUser)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return NotFound("User Not Found");
                
                var response = await _membershipService.UpdateUserAsync(userId, updatedUser);
                if (!response.IsSuccessfull)
                    return BadRequest(response.Errors);

                return Ok(response.Errors);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword model)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return BadRequest("User Id not found!");
                }
                var response = await _membershipService.ChangePassword(userId, model);
                return Ok(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _membershipService.ResetPassword(request.Email, request.Token, request.NewPassword);
                return Ok("Password reset successful.");
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Authorize]
        [HttpPost("confirm-account")]
        public async Task<IActionResult> ConfirmAccount()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return NotFound("User Not Found");
                }
                await _membershipService.ConfirmAccountSendMail(userId);
                return Ok("Verification email send!");
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Authorize]
        [HttpPost("confirm-account-check")]
        public async Task<IActionResult> ConfirmAccountCheck(string token)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return NotFound("User Not Found");
                }

                var response = await _membershipService.ConfirmAccountCheck(userId, token);
                return Ok(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("upload-photo")]
        public async Task<IActionResult> UploadPhoto(IFormFile photo)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    return NotFound("User Not Found");
                }
                if (photo == null || photo.Length == 0)
                {
                    return BadRequest("Photo file must be provided.");
                }

                var response = await _membershipService.UploadUserPhotoAsync(userId, photo);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _membershipService.ForgotPassword(request.Email);
                return Ok("Password reset email sent successfully.");
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
