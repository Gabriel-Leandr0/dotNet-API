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

    // Virtual serve para que o Entity Framework Core possa fazer o carregamento preguiçoso (lazy loading)
    public virtual Endereco Endereco { get; set; }
    public virtual ICollection<Sessao> Sessoes { get; set; }

}
