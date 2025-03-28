﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursosBack.Data;
using CursosControllador.Entidades;

namespace CursosBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestasController : ControllerBase
    {
        private readonly DataContext _context;

        public RespuestasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Respuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Respuestas>>> GetRespuestas()
        {
            return await _context.Respuestas.ToListAsync();
        }

        // GET: api/Respuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Respuestas>> GetRespuestas(int id)
        {
            var respuestas = await _context.Respuestas.FindAsync(id);

            if (respuestas == null)
            {
                return NotFound();
            }

            return respuestas;
        }

        // PUT: api/Respuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRespuestas(int id, Respuestas respuestas)
        {
            if (id != respuestas.RespuestaID)
            {
                return BadRequest();
            }

            _context.Entry(respuestas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Respuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Respuestas>> PostRespuestas(Respuestas respuestas)
        {
            _context.Respuestas.Add(respuestas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRespuestas", new { id = respuestas.RespuestaID }, respuestas);
        }

        // DELETE: api/Respuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRespuestas(int id)
        {
            var respuestas = await _context.Respuestas.FindAsync(id);
            if (respuestas == null)
            {
                return NotFound();
            }

            _context.Respuestas.Remove(respuestas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RespuestasExists(int id)
        {
            return _context.Respuestas.Any(e => e.RespuestaID == id);
        }
    }
}
