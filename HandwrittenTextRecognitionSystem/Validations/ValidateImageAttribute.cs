using HandwrittenTextRecognitionSystem.Consts;
using System.ComponentModel.DataAnnotations;

namespace HandwrittenTextRecognitionSystem.Validations
{
    public class ValidateImageAttribute : ValidationAttribute
    {
        private const long _imageSize = 2_097_152;
        private readonly IList<string> _imageExtensions = new List<string>() { ".jpg", ".png", ".jpeg" };
        public string GetErrorMessage() =>
            AppErrors.ValidateImage;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //var Dto = validationContext.ObjectInstance;

            if (value is null)
                return ValidationResult.Success;

            var image = (IFormFile)value;

            var imageExtension = Path.GetExtension(image.FileName);

            if (!_imageExtensions.Contains(imageExtension.ToLower()) || image.Length > _imageSize)
                return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }
    }
}
