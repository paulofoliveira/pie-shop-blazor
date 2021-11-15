using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PieShop.Api.Infrastructure.Authentication;
using PieShop.Api.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// Read more: https://jasonwatmore.com/post/2021/05/27/net-5-hash-and-verify-passwords-with-bcrypt

namespace PieShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public AccountController(IUserRepository userRepository, JwtSettings jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthDto userForAuth)
        {
            var user = await _userRepository.FindByEmail(userForAuth.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userForAuth.Password, user.Password))
                return Unauthorized(new AuthResponseDto() { ErrorMessage = "Invalid Authentication" });

            var signinCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto() { IsSuccessful = true, Token = token });
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _jwtSettings.ValidIssuer,
                audience: _jwtSettings.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.ExpireInMinutes)));
        }

        private static List<Claim> GetClaims(User user) => new() { new Claim(ClaimTypes.Name, user.Email) };

        private SigningCredentials GetSigningCredentials()
        {
            var securityKey = Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey);
            var secret = new SymmetricSecurityKey(securityKey);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
