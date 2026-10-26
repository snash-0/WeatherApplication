using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeatherApplication.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _configuration;
        private readonly Iuser _userRepository;
        public LoginController(ILogger<LoginController> logger, IConfiguration configuration, Iuser userRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _userRepository = userRepository;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult Get(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest(new { message = "Username and password are required" });
            }

            var user = _userRepository.GetUserByNameAndPassword(username, password).Result;
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.userid.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.username),
                    new Claim(ClaimTypes.Role, user.userRole)
                };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:Key"]!
                    ));

                var credentials =
                    new SigningCredentials(
                        key,
                        SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler()
                             .WriteToken(token)
                });
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }        
    }
}
