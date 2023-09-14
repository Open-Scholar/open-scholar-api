using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.ApplicationUserDtos;
using OpenScholarApp.Services.UserServices.Interfaces;
using OpenScholarApp.Services.UserServices.Models;
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
                Username = model.UserName
            };
            var response = await _membershipService.RegisterUserAsync(request);
            return Response(response);
            }
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserModel model)
        {
            var request = new LoginUserRequest
            {
                Password = model.Password,
                Username = model.Username,
            };
            var response = await _membershipService.LoginUserAsync(request);
            return Response(response);
        }
        //[Authorize]
        //[HttpGet("introspect")]
        //public IActionResult Introspection()
        //{
        //    return Ok(new
        //    {
        //        UserId = HttpContext.GetUserId(),
        //        TokenValidUntil = HttpContext.GetJWTokenExpiryDate()
        //    });
        //}

        //[Authorize(Roles = "SuperAdmin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _membershipService.GetAllUsers();

            if (response.IsSuccessfull)
            {
                return Ok(response); // Return the list of users
            }
            else
            {
                return BadRequest(response.Errors); // Return errors, if any
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var response = await _membershipService.DeleteUserAsync(id);

            if (response.IsSuccessfull)
            {
                return Ok(response.Errors);
            }
            else
            {
                return NotFound(response.Errors);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUserDto updatedUser)
        {
            var response = await _membershipService.UpdateUserAsync(id, updatedUser);

            if (response.IsSuccessfull)
            {
                return Ok(response.Errors);
            }
            else
            {
                return BadRequest(response.Errors);
            }
        }


        [HttpGet("error")]
        public IActionResult Error()
        {
            throw new Exception("error");
        }

        [HttpGet("getauthuser")]
        public int GetAuthorizedUserId()
        {

            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?
                .Value, out var userId))
            {
                string? name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new UserNotFoundException(
                    "Name identifier claim does not exist!");
            }
            return userId;
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
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
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
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
