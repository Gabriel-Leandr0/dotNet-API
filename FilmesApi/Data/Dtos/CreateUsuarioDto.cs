using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

    }
}