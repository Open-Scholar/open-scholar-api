using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Services.UserServices.Models
{
    public class RegisterUserModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AccountType AccountType { get; set;}
    }
}
