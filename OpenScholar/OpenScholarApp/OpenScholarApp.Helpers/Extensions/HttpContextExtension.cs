using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace OpenScholarApp.Shared.Extensions
{
    public static class HttpContextExtension
    {
        public static string GetUserId(this HttpContext context) => context?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        public static DateTime GetJWTokenExpiryDate(this HttpContext context)
        {
            var ticksString = context?.User?.Claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)?.Value ?? string.Empty;
            if (!long.TryParse(ticksString, out long ticks)) return new(0);

            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(ticks);
            return dateTimeOffset.DateTime;
        }
    }
}
