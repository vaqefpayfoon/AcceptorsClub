using AcceptorsClub.Application;
using AcceptorsClub.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcceptorsClub.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IMediator _mediator;
    private readonly List<LoginPazirandegan> logins;

    public AuthController(IConfiguration configuration, IMediator mediator,List<LoginPazirandegan> logins)
    {
        _configuration = configuration;
        _mediator = mediator;
        this.logins = logins;
    }

    [HttpPost]
    public IActionResult Login([FromBody] UserLogin userLogin)
    {
        if (userLogin.Username == "AcceptorsClub" && userLogin.Password == "P@ssw0rd987654")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userLogin.Username)
                }),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        return Unauthorized();
    }

    [HttpPost("LoginWithNationalCode")]
    public async Task<IActionResult> LoginWithNationalCode([FromBody] ClubUser userLogin)
    {
        if (string.IsNullOrEmpty(userLogin.NationalCode) || userLogin.NationalCode.Length < 10)
        {
            return BadRequest("invalid national code");
        }
        try
        {
            if (userLogin.Username != "AcceptorsClub" && userLogin.Password != "P@ssw0rd987654")
            {
                return Unauthorized();
            }
            var result = await _mediator.Send(new CheckCustomerExistQuery(userLogin.NationalCode));
            var expire = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:Expire"]));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = new Dictionary<string, object>(),
                Subject = new ClaimsIdentity(new[] { new Claim("id", result.Id.ToString()), new Claim("type", "2"), new Claim("key", result.Key.ToString()) }),
                Expires = expire,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };
            //tokenDescriptor.Claims.Add(ClaimTypes.NameIdentifier, id.ToString());
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //return Ok(new { token = tokenHandler.WriteToken(token), customer = result });

            var login = new LoginPazirandegan() { Key = Guid.NewGuid().ToString(), Token = tokenHandler.WriteToken(token) };
            logins.Add(login);
            return Ok(_configuration["acceptors:address"] + "?key=" + login.Key);
        }
        catch
        {
            return NotFound("national code not found please register");
        }
    }

    [HttpGet("CallTokenWithKey")]
    public async Task<IActionResult> GetToken([FromQuery]string key)
    {
        var login = logins.FirstOrDefault(c => c.Key == key);

        if (login == null)
            return NotFound();


        return Ok(login.Token);
    }
}
