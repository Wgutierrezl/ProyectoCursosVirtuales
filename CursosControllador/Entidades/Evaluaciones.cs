using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosControllador.Entidades
{
    public class Evaluaciones
    {
        [Key]
        public int EvaluacionID { get; set; }
        public string CursoCodigo { get; set; } = null!;
        public string Titulo {  get; set; }=null!;
        public DateOnly FechaPublicacion { get; set; }
    }
}
