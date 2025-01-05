using Microsoft.EntityFrameworkCore;
using CursosControllador.Entidades;

namespace CursosBack.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<EstudianteCursos> EstudianteCursos { get; set; }
        public DbSet<Evaluaciones> Evaluaciones { get; set; }
        public DbSet<PreguntasEvaluacion> preguntasEvaluacion { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }
        // Para crear index y evitar repeticiones de nombres de los tipos de categorias
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Tipo>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<EstudianteCursos>()
            .HasKey(e => new { e.EstudianteID, e.CodigoCurso });
        }

    }
}
