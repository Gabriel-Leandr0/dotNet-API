using FilmesApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmeContext : DbContext
{
    //Constructor
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sessao>()
            .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });
        
        modelBuilder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);
    }
    //Modelo de dados (Model)
    //Dbset<Model> NomeDaTabela { get; set; }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }

}