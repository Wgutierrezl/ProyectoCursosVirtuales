using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosControllador.Entidades
{
    public class Cursos
    {
        [Key]
        public string CursoID { get; set; } = null!;
        public string InstructorID { get; set; } = null!;
        public string NombreCurso { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Duracion { get; set; }
    }
}
