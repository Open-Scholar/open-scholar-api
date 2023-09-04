//using OpenScholarApp.Data.IdentityModels;
using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.UserServices.Interfaces
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user);
    }
}
