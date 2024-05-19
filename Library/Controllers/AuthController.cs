using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var authCredentials = _configuration.GetSection("AuthCredentials").Get<List<AuthCredential>>();

            foreach (var credential in authCredentials)
            {
                if (loginModel.UserName == credential.UserName && loginModel.Password == credential.Password)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, credential.UserName),
                        new Claim(ClaimTypes.Role, credential.Role)
                       
                    };
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                        audience: _configuration.GetValue<string>("Jwt:Audience"),
                        claims: claims,
                        expires: DateTime.Now.AddHours(5),//i handle in the client case of 401 unauthorized access if the time over i will be sent to page to click login again!
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString });
                }
            }

            // No matching credentials found
            return Unauthorized();
        }
    }
}
public class AuthCredential
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    
}