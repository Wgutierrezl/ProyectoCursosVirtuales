﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CursosControllador.Entidades;
using CursosBack.Data;
using Microsoft.EntityFrameworkCore;
namespace CursosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();
            Usuario? response = await _context.Usuario.Where(u => u.Email == login.Correo && u.Contraseña == login.Clave).FirstOrDefaultAsync();
            if (response != null)
            {
                sesionDTO.UserID = response.UsuarioID;
                sesionDTO.Nombre = response.NombreUsuario;
                sesionDTO.Correo = response.Email;
                sesionDTO.Rol = response.Rol;
                return Ok(sesionDTO);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
