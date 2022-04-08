using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BDElon7abril;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AutorLibro>().HasKey(x => new { x.AutorId, x.LibroId });
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<AutorLibro> AutoresLibros { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Genero> Generos { get; set; }

    }

    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<AutorLibro> AutoresLibros { get; set; }
    }

    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
        public List<AutorLibro> AutoresLibros { get; set; }
    }

    public class AutorLibro
    {
        public int AutorId { get; set; }
        public int LibroId { get; set; }
        public Autor Autor { get; set; }
        public Libro Libro { get; set; }
    }

    public class Editora
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }
    }

    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }
    }

}

