using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supliex.Application.Common.Interface.Iservices;
using Supliex.Application.Common.Service;
using Supliex.Domain.Dtos.Account;
using Supliex.Domain.Entities;

namespace Supliex.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IAuthService _authService;

        public AccountController(UserManager<ApplicationUser> userManager, IAuthService AuthService, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _authService = AuthService;
            _signinManager = signInManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var loginResult = await _authService.Login(loginDto);
            
            if (loginResult.IsLogedIn)
            {
                return Ok(loginResult);
            }
            
            return Unauthorized();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (await _authService.RegisterUser(registerDto))
            {
                return Ok("Successfully done");
            }
            return BadRequest("Something went wrong");

        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto model)
        {
            var loginResult = await _authService.RefreshToken(model);
            if (loginResult.IsLogedIn)
            {
                return Ok(loginResult);
            }
            return Unauthorized();
        }

    }
}
