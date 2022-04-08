// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var context = new ApplicationDbContext();

var resultado = context.Autores.Include(x => x.AutoresLibros)
                                .ThenInclude(x => x.Libro)
                                    .ThenInclude(x => x.Editora)
                                .Include(x => x.AutoresLibros)
                                .ThenInclude(x => x.Libro)
                                    .ThenInclude(x => x.Genero)
                                .ToList();

var a = 2;