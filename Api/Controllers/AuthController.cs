using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet("LogIn")]
        public IActionResult LogIn(string UserName, string Password)
        {
            if (UserName == "admin" && Password == "admin")
            {
                var token = CreateJwtToken();
                return Ok(new { Status = true, Message = "success", Data = new { Token = token } });
            }
            return BadRequest();
        }

        private string CreateJwtToken()
        {

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,"1"),
                new Claim(JwtRegisteredClaimNames.Email,"shanker"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Extensions.Key));

            var token = new JwtSecurityToken(
                issuer: "https://example.com",
                audience: "https://example.com",
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
