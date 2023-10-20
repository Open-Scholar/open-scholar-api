using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.ApplicationUserDtos;
using OpenScholarApp.Services.UserServices.Interfaces;
using OpenScholarApp.Services.UserServices.Models;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;
using OpenScholarApp.Shared.Requests;

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
            catch (UserDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost("test")]
        //public async Task<IActionResult> RegisterTest([FromBody] RegisterUserModel model)
        //{
        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        try
        //        {
        //            // Step 1: Register the user
        //            var userRegistrationRequest = new RegisterUserRequest
        //            {
        //                Email = model.Email,
        //                Password = model.Password,
        //                Username = model.UserName,
        //                AccountType = model.AccountType
        //            };

        //            var userRegistrationResponse = await _membershipService.RegisterUserAsync(userRegistrationRequest);

        //            if (userRegistrationResponse.IsSuccessfull)
        //            {
        //                // Step 2: Create the student profile
        //                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //                if (userId == null)
        //                    return BadRequest("User not found.");

        //                var studentDto = new AddStudentDto
        //                {
        //                    // Populate student data from model
        //                };

        //                var studentCreationResponse = await _studentService.CreateStudentAsync(studentDto);

        //                if (studentCreationResponse.Success)
        //                {
        //                    // Both steps completed successfully, commit the transaction
        //                    scope.Complete();
        //                    return Ok("User registration and student profile creation successful.");
        //                }
        //                else
        //                {
        //                    // Step 2 failed, so rollback the transaction
        //                    return StatusCode(500, $"Failed to create student profile: {studentCreationResponse.ErrorMessage}");
        //                }
        //            }
        //            else
        //            {
        //                // Step 1 failed, so no need to perform step 2
        //                return BadRequest(userRegistrationResponse.ErrorMessage);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle exceptions or log them
        //            return StatusCode(500, $"Internal server error: {ex.Message}");
        //        }
        //    }
        //}

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
