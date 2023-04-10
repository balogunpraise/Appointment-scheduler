using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskScheduler.Api.dtos.RequestDtos;
using TaskScheduler.Api.dtos.ResponseDtos;
using TaskScheduler.Api.Wrappers;
using TaskScheduler.Core.Application.Extensions;
using TaskScheduler.Core.Entities;
using TaskScheduler.Infrastructure;

namespace TaskScheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignupAsync(SignupDto signupDto)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(signupDto.Email);
                if (user != null) return BadRequest(new ApiErrorResponse(400));
                user = new ApplicationUser()
                {
                    FirstName = signupDto.FirstName,
                    LastName = signupDto.LastName,
                    Email = signupDto.Email,
                    PhoneNumber = signupDto.PhoneNumber,
                    UserName = signupDto.UserName.IsNotNullOrEmpty() ? signupDto.UserName : signupDto.Email
                };
                await _userManager.CreateAsync(user, signupDto.Password);
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return BadRequest(new ApiErrorResponse(400, message));
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult> LoginAsync(SigninDto signinDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(signinDto.EmailOrUsername);
                if (user == null) return Unauthorized(new ApiErrorResponse(401));
                await _signInManager.CheckPasswordSignInAsync(user, signinDto.Password, false);
                var token = new TokenService(_config);
                var loginResponse = new LoginResponseDto { Token = token.GenerateToken(user) };
                return Ok(new ApiResponse<LoginResponseDto>(loginResponse, 200, "Authenticated"));
            }
            catch(Exception)
            {
                var message = "Invalid credential. Please check your credentials and login again";
                return Unauthorized(new ApiErrorResponse(401, message));
            }

        }
    }
}
