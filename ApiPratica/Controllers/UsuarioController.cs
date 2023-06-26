using ApiPratica.Models;
using ApiPratica.Models.Dto;
using ApiPratica.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiPratica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IConfiguration _config;

        public UsuarioController(IUsuarioRepository usuarioRepo, IConfiguration config)
        {
            _usuarioRepo = usuarioRepo;
            _config = config;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Login([FromBody] UsuarioDto userDto)
        {
            if (userDto == null)
                return BadRequest();
            string name = userDto.NombreUsuario.ToString();
            string password = userDto.Contraseña.ToString();

            var user = await _usuarioRepo.GetUser(name, password);

            if (user == null)
                return NotFound();

            var jwt = _config.GetSection("Jwt").Get<Jwt>();

            // Crear los claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.NombreUsuario),
                new Claim(ClaimTypes.Role, user.Rol)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear el token
            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(4),
                signingCredentials: credentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }

}
