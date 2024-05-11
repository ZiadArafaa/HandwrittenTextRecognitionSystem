using HandwrittenTextRecognitionSystem.Consts;
using HandwrittenTextRecognitionSystem.Data;
using HandwrittenTextRecognitionSystem.Dtos;
using HandwrittenTextRecognitionSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace HandwrittenTextRecognitionSystem.Validations
{
    public class ValidateUniqueUserAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
          AppErrors.DataWrong;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //  var Dto = (LoginDto)validationContext.ObjectInstance;

            var scope = validationContext.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

          //  var userId = validationContext.Items["Authorization"];

            string fetchedValue = value!.ToString()!;

            var user = userManager.FindByEmailAsync(fetchedValue).GetAwaiter().GetResult()
                ?? userManager.FindByNameAsync(fetchedValue).GetAwaiter().GetResult();

            if (user is not null)
                return new ValidationResult(GetErrorMessage());


            return ValidationResult.Success;
        }


    }
}
