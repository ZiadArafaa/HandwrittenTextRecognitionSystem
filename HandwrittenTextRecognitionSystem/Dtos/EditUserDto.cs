using HandwrittenTextRecognitionSystem.Consts;
using HandwrittenTextRecognitionSystem.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HandwrittenTextRecognitionSystem.Dtos
{
    public class EditUserDto
    {
        [MaxLength(30, ErrorMessage = AppErrors.MaxLength)]
        public string FirstName { get; set; } = null!;
        [MaxLength(30, ErrorMessage = AppErrors.MaxLength)]
        public string LastName { get; set; } = null!;
        [RegularExpression(AppRegexs.Username, ErrorMessage = AppErrors.UsernameRegex)]
        public string UserName { get; set; } = null!;
        [RegularExpression(AppRegexs.Phone, ErrorMessage = AppErrors.Phone)]
        public string PhoneNumber { get; set; } = null!;
        [ValidateImage]
        public IFormFile? Image { get; set; } 
    }
}
