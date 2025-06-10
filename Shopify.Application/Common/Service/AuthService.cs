using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Supliex.Application.Common.Interface.Iservices;
using Supliex.Domain.Dtos.Account;
using Supliex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Supliex.Application.Common.Service
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<ApplicationUser> _userManager;


        public AuthService(IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _config = config;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string CreateToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = creds,
                //Issuer = _config["JWT:Issuer"],
                //Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private ClaimsPrincipal? GetTokenPrincipal(string token)
        {


            try
            {
                var validation = new TokenValidationParameters
                {
                    IssuerSigningKey = _key,
                    ValidateLifetime = false,
                    ValidateActor = false,  
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };
                return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
            }
            catch (SecurityTokenException)
            {
                // Handle token validation failure (e.g., log or return null)
                return null;
            }
            catch (Exception ex)
            {
                // Handle other possible exceptions
                return null;
            }
        }

        public async Task<NewUserDto> RefreshToken(RefreshTokenDto model)
        {
            var principal = GetTokenPrincipal(model.AccessToken);

            var response = new NewUserDto();
            if (principal?.Identity?.Name is null)
                return response;

            var identityUser = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (identityUser is null || identityUser.RefreshToken != model.RefreshToken || identityUser.RefreshTokenExpiry < DateTime.UtcNow)
                return response;

            response.IsLogedIn = true;
            response.AccessToken = this.CreateToken(identityUser);
            response.RefreshToken = this.GenerateRefreshTokenString();

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(identityUser);

            return response;
        }

        private string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[64];

            using (var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }

        public async Task<NewUserDto> Login(LoginDto user)
        {
            var response = new NewUserDto();
            var identityUser = await _userManager.FindByEmailAsync(user.Email);

            if (identityUser is null || (await _userManager.CheckPasswordAsync(identityUser, user.Password)) == false)
            {
                return response;
            }

            response.IsLogedIn = true;
            response.AccessToken = this.CreateToken(identityUser);
            response.RefreshToken = this.GenerateRefreshTokenString();

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.UtcNow.AddHours(12);
            await _userManager.UpdateAsync(identityUser);

            return response;
        }

        public async Task<bool> RegisterUser(RegisterDto user)
        {
            var identityUser = new ApplicationUser
            {
                UserName = user.Email,
                Email = user.Email,
                FirstName=user.FirstName,
                LastName=user.LastName,
                PhoneNumber = user.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }



    }
}
