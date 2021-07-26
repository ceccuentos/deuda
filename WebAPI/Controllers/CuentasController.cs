using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Dominio;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Obsolete]  // Sólo para ignorar salida a swagger
    public class CuentasController : Controller
    {
        private readonly IConfiguration _configuration;

        public CuentasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Crear")]
        public ActionResult<UserToken> CreateUser([FromBody] UserInfo model)
        {
            if (model.Email == "autoventa@autoventa.cl")
            {
                return BuildToken(model, new List<string>());
            }
            else
            {
                return BadRequest("No Autorizado");
            }
        }

        private UserToken BuildToken(UserInfo userInfo, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(Int32.Parse(_configuration["jwt:ExpirationYears"]));

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
