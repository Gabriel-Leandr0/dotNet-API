using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }

        //Explicita que a relação é de 1 para 1
        public virtual Cinema Cinema { get; set; }

    }
}
