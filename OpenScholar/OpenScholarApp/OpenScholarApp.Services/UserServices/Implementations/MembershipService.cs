using Microsoft.AspNetCore.Identity;
//using OpenScholarApp.Data.IdentityModels;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Services.UserServices.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;
using OpenScholarApp.Shared.Requests;
using OpenScholarApp.Shared.Responses;
using System.IdentityModel.Tokens.Jwt;

namespace OpenScholarApp.Services.UserServices.Implementations
{
    public class MembershipService : IMembershipService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public MembershipService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
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


    }

}
