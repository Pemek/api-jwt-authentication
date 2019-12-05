using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api_jwt_authentication.Entities;
using api_jwt_authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api_jwt_authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        public IActionResult Login([FromBody] UserForLoginDto userAuthenticateDto)
        {
            User user = UserManager.GetUser(userAuthenticateDto.Email, userAuthenticateDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _config.GetSection("AppSettings:Secret").Value;
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            user.Token = accessToken;
            return Ok(user.WithoutPassword());
        }
    }
}