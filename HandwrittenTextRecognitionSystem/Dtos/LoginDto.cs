using HandwrittenTextRecognitionSystem.Consts;
using HandwrittenTextRecognitionSystem.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HandwrittenTextRecognitionSystem.Dtos
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        [RegularExpression(AppRegexs.Password, ErrorMessage = AppErrors.PasswordRegex)]
        public string Password { get; set; } = null!;
    }
}
