using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("error")]
        public IActionResult Error()
        {
            throw new Exception("error");
        }
    }
}
