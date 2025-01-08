using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosControllador.Entidades
{
    public class EstudianteCursos
    {
        public string? EstudianteID { get; set; } 
        public string? CodigoCurso { get; set; } 
        public DateOnly FechaInscripcion { get; set; }
    }
}
