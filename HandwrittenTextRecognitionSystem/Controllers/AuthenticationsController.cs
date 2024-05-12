using HandwrittenTextRecognitionSystem.Consts;
using HandwrittenTextRecognitionSystem.Data;
using HandwrittenTextRecognitionSystem.Dtos;
using HandwrittenTextRecognitionSystem.Models;
using HandwrittenTextRecognitionSystem.Services;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HandwrittenTextRecognitionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageService _imageService;
        public AuthenticationsController(IAuthenticationService authentication, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IImageService imageService)
        {
            _authentication = authentication;
            _userManager = userManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return BadRequest(new ErrorModelDto { ErrorDescription = AppErrors.DataWrong });

            var authorized = await _authentication.LoginAsync(user);

            return Ok(authorized);
        }
        [HttpPost("Register")]
        [Authorize(Roles = AppRoles.Admin)]
        public async Task<IActionResult> RegisterAsync(RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var CreateResult = await _userManager.CreateAsync(user, model.Password);

            if (!CreateResult.Succeeded)
                return BadRequest(new ErrorModelDto { ErrorDescription = string.Join(',', CreateResult.Errors.Select(e => e.Description).ToList()) });

            var RoleResult = await _userManager.AddToRoleAsync(user, model.Role);

            if (!RoleResult.Succeeded)
                return BadRequest(new ErrorModelDto { ErrorDescription = string.Join(',', RoleResult.Errors.Select(e => e.Description).ToList()) });

            return Ok();
        }
        [HttpPost("EditTecher")]
        [Authorize(Roles = "Doctor,Assistant")]
        public async Task<IActionResult> EditTeacherAsync([FromForm] EditTeacherDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue("uid");
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return BadRequest(new ErrorModelDto { Key = nameof(user.Id), ErrorDescription = AppErrors.DataWrong });

            var applicationUser = await _userManager.FindByNameAsync(model.UserName);

            if (applicationUser is not null && applicationUser.Id != user.Id)
                return BadRequest(new ErrorModelDto { Key = nameof(applicationUser.UserName), ErrorDescription = AppErrors.DataWrong });

            var department = await _context.Departments.AsNoTracking().SingleOrDefaultAsync(d => d.Id == model.DepartmentId);
            if (department is null)
                return BadRequest(new ErrorModelDto { Key = nameof(model.DepartmentId), ErrorDescription = AppErrors.DataWrong });


            var Teacher = await _context.Set<Teacher>().AsNoTracking().SingleOrDefaultAsync(d => d.ApplicationUserId == user.Id) ?? new Teacher();
            Teacher.ApplicationUserId ??= user.Id;
            Teacher.DepartmentId = department.Id;

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;


            using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _userManager.UpdateAsync(user);

                if (Teacher.Id.Equals(0))
                    _context.Add(Teacher);
                else
                    _context.Update(Teacher);

                _context.SaveChanges();


                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return BadRequest(new ErrorModelDto { ErrorDescription = AppErrors.DatabaseFailure });
            }

            if (model.Image is not null)
                await _imageService.CreateImageAsync(user.Id, model.Image);

            return Ok(new { userId = user.Id });
        }
        [HttpPost("EditStudent")]
        [Authorize(Roles = AppRoles.Student)]
        public async Task<IActionResult> EditStudentAsync()
        {
            return Ok();
        }
    }
}
