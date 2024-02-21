using System.ComponentModel.DataAnnotations;

namespace OpenScholarApp.Dtos.ApplicationUserDtos
{
    public class ChangePassword
    {
        public string ExistingPassword { get; set; }

        [Required]
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$", ErrorMessage = "Password must contain at least one uppercase character, one lowercase character, one digit, and one non-alphanumeric character.")]
        public string NewPassword { get; set; } = string.Empty;

        [Required, Compare("NewPassword")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
