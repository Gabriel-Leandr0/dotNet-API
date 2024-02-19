using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Models;

public class Filme
{
    //Regras de validação para camada de dados

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string Titulo { get; set; }

    [Required]
    public string Genero { get; set; }

    [Required]
    public int duracao { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }

}