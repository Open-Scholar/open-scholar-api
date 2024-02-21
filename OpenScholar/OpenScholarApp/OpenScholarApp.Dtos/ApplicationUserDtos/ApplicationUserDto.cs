using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.ApplicationUserDtos
{
    public class ApplicationUserDto
    {
        public string? Id { get; set; }
        public AccountType AccountType { get; set; }
        public bool IsProfileCreated { get; set; }
        public bool IsAccountCreated { get; set; }
        public bool IsAccountVerified { get; set; } = false;
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
