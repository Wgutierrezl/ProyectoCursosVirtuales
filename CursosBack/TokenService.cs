using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CursosControllador.Entidades; // Ajusta según la ubicación de tu clase Usuario.

public static class TokenService
{
    public static string GenerateJwtToken(Usuario usuario)
    {
        // Clave secreta (asegúrate de almacenarla de manera segura)
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("G5z8!bXy9qLmP#cRkTh3@VwZ$YdN4f2A"));

        // Credenciales de firma
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Claims (información del usuario)
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.UsuarioID),
            new Claim(ClaimTypes.Role, usuario.Rol ?? "Usuario")
        };

        // Configuración del token
        var tokenDescriptor = new JwtSecurityToken(
            issuer: "CursosBack",                // Emisor
            audience: "CursosBackFrontend",      // Audiencia
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2), // Tiempo de expiración
            signingCredentials: credentials      // Credenciales de firma
        );

        // Generar el token
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}