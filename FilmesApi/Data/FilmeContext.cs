using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FilmesApi.Data
{
    public class FilmeContext : DbContext
    {
        //Constructor
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }
        
    }
}