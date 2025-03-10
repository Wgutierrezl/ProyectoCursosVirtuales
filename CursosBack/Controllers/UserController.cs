using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CursosControllador.Entidades;
using CursosBack.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
namespace CursosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserController(DataContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var usuario = await _context.Usuario.Where(e => e.Email == login.Correo && e.Contraseña == login.Clave).FirstOrDefaultAsync();
            if (usuario==null)
            {
                return Unauthorized(new { mensaje="contraseña o correo incorrectas" });
            }

            var token = GenerarToken(usuario);

            return Ok(new SesionDTO
            {
                UserID = usuario.UsuarioID,
                Nombre = usuario.NombreUsuario,
                Correo = usuario.Email,
                Rol = usuario.Rol,
                Token = token
            });

        }


        private string GenerarToken(Usuario usuario)
        {
            var jwtsetting = _configuration.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtsetting["SecretsKey"]);

            var claims = new List<Claim>
            {
                new Claim("UsuarioID",usuario.UsuarioID!),
                new Claim(ClaimTypes.Name,usuario.NombreUsuario!),
                new Claim(ClaimTypes.Email,usuario.Email !),
                new Claim(ClaimTypes.Role,usuario.Rol !)
            };

            var key= new SymmetricSecurityKey(secretKey);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtsetting["Issuer"],
                audience: jwtsetting["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials:creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
