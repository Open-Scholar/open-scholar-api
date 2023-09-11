using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
//using OpenScholarApp.Data.IdentityModels;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Services.UserServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.UserServices.Implementations
{
    public class JWTService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                };

            var token = GetJWT(claims);
            return Task.FromResult(token);
        }

        private JwtSecurityToken GetJWT(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddYears(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
