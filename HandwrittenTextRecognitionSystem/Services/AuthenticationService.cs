using HandwrittenTextRecognitionSystem.Dtos;
using HandwrittenTextRecognitionSystem.Models;
using HandwrittenTextRecognitionSystem.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace HandwrittenTextRecognitionSystem.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Jwt _jwt;
        public AuthenticationService(UserManager<ApplicationUser> userManager, IOptions<Jwt> jwt)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
        }

        public async Task<AuthorizedDto> LoginAsync(ApplicationUser user)
        {
            var token = await CreateUserTockenAsync(user);

            var model = new AuthorizedDto
            {
                Roles = await _userManager.GetRolesAsync(user),
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpireOn = token.ValidTo
            };

            return model;
        }


        private async Task<JwtSecurityToken> CreateUserTockenAsync(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var Roles = await _userManager.GetRolesAsync(user);
            var RoleClaims = new List<Claim>();

            foreach (var role in Roles)
                RoleClaims.Add(new Claim("roles", role));

            var Claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                new Claim("uid",user.Id),
            }.Union(userClaims).Union(RoleClaims);


            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(issuer: _jwt.Issuer, audience: _jwt.Audience,
                Claims, expires: DateTime.Now.AddDays(_jwt.DurationOnDays), signingCredentials: Credentials);

            return Token;

        }
    }
}
