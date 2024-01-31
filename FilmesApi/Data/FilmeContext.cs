using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmeContext : DbContext
{
    //Constructor
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {
    }
    //Modelo de dados (Model)
    public DbSet<Filme> Filmes { get; set; }
    
}