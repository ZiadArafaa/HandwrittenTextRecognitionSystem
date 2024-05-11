using HandwrittenTextRecognitionSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace HandwrittenTextRecognitionSystem.Consts.Seeds
{
    public class SeedUsers
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SeedUsers(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task Seed()
        {
            if (!_userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    FirstName = "User",
                    LastName = "One",
                    UserName = "UserOne",
                    Email = "User@Gp.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssword123");

                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(user, AppRoles.Admin);
            }
        }
    }
}
