using Microsoft.AspNetCore.Identity;

namespace HandwrittenTextRecognitionSystem.Consts.Seeds
{
    public class SeedRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if(!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole(AppRoles.Admin));
                await _roleManager.CreateAsync(new IdentityRole(AppRoles.Doctor));
                await _roleManager.CreateAsync(new IdentityRole(AppRoles.Assistant));
                await _roleManager.CreateAsync(new IdentityRole(AppRoles.Student));
            }
        }
    }
}
