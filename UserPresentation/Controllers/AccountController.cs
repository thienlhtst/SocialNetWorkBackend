using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserApplication.Interfaces;
using UserApplication.ViewModel.AccountViewModel;
using UserCore.Entities;

namespace UserPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService=accountService;
            _configuration=configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM request)
        {
            var result = await _accountService.RegisterUser(request);
            if (result.Succeeded)
            {
                return Ok("User registered successfully!");
            }

            return BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM request)
        {
            var checkaccount = await _accountService.FindAccount(request.account);
            if (checkaccount == null)
            {
                return Unauthorized(" Khong co tai khoan");
            }
            var result = await _accountService.LoginAsync(request);
            if (result.Succeeded)
            {
                var token = GenerateJwtToken(checkaccount);

                return Ok(new { token });
            }

            return Unauthorized("Invalid login attempt.");
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.AccountName),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
             new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}