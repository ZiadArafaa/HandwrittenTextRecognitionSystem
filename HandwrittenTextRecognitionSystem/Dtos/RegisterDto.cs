using HandwrittenTextRecognitionSystem.Consts;
using HandwrittenTextRecognitionSystem.Validations;
using System.ComponentModel.DataAnnotations;
using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace HandwrittenTextRecognitionSystem.Dtos
{
    public class RegisterDto
    {
        [MaxLength(30, ErrorMessage = AppErrors.MaxLength)]
        public string FirstName { get; set; } = null!;
        [MaxLength(30, ErrorMessage = AppErrors.MaxLength)]
        public string LastName { get; set; } = null!;
        [RegularExpression(AppRegexs.Username, ErrorMessage = AppErrors.UsernameRegex)]
        [ValidateUniqueUser]
        public string UserName { get; set; } = null!;
        [EmailAddress]
        [ValidateUniqueUser]
        public string Email { get; set; } = null!;
        [AssertThat("Role == 'Student' || Role == 'Assistant' || Role == 'Doctor'", ErrorMessage = AppErrors.RoleValues)]
        public string Role { get; set; } = null!;
        [RegularExpression(AppRegexs.Password, ErrorMessage = AppErrors.PasswordRegex)]
        public string Password { get; set; } = null!;
        [Compare(nameof(Password), ErrorMessage = AppErrors.ComparePassword)]
        public string ConfirmedPassword { get; set; } = null!;
    }
}