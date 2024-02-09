using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        int Id { get; set; }
        [Required]
        string Logradouro { get; set; }
        public int Numero { get; set; }

    }
}
