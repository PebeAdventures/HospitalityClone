using Hospitality.Identity.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecondExam.Services.Services.Auth
{
    public class LogInServicert : ILogInService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public LogInServicert(IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<string?> Login(string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser == null) return null;
            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, password);
            if (!isCorrect) return null;
            return await GenerateJwtToken(existingUser);
        }
        private async Task<string> GenerateJwtToken(IdentityUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var claims = await GetValidClaims(user);
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<List<Claim>> GetValidClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Name", user.UserName),
                new Claim("UserId", user.Id.ToString()),
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userClaims);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }
    }
}
