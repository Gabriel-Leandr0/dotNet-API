using System.ComponentModel.DataAnnotations;
using FilmesApi.Data.Dtos;
using Microsoft.AspNetCore.Identity;

namespace FilmesApi.Data.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

    }
}
