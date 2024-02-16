using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Models;

public class Sessao
{
    [Key]
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public Filme Filme { get; set; }
    public int CinemaId { get; set; }
    public Cinema Cinema { get; set; }
    public DateTime HorarioDeEncerramento { get; set; }
    public DateTime HorarioDeInicio { get; set; }
    
}