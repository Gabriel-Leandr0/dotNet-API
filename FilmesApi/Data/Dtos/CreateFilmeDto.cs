using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos;

public class CreateFilmeDto
{

    [Required(ErrorMessage = "O campo título é obrigatório")]
    [StringLength(25, ErrorMessage = "O campo título não pode passar de 25 caracteres")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo genero é obrigatório")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo duração é obrigatório")]
    [Range(60, 300, ErrorMessage = "A duração deve ter no mínimo 60 e no máximo 300 minutos")]
    public int duracao { get; set; }

}