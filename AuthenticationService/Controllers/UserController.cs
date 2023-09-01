using AuthenticationService.Entities;
using AuthenticationService.Exceptions;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _config;
        public UserController(IUserService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult post([FromBody] User user)
        {
            try
            {
                var obj = _service.RegisterUser(user);
                return Created("Get/", obj);
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                var obj = _service.LoginUser(user);
                if (!obj)
                {
                    return Unauthorized("Invalid User Id or password");
                }
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                var claims = new ClaimsIdentity(new Claim[]

                {
                    new Claim(ClaimTypes.Name, user.Password)
                }) ;

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _config["Jwt:Issuer"],
                    Audience = _config["Jwt:Audience"],
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = credentials

                };


                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));

            }
            catch (Exception)
            {
                return Unauthorized("Invalud User Id or Password");
            }
        }
    }
}
