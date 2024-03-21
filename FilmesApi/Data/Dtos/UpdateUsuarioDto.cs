using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos
{
    public class UpdateUsuarioDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}