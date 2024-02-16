using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }

    public int EnderecoId { get; set; }
    //Explicita que a relação é de 1 para 1
    public virtual Endereco Endereco { get; set; }

}
