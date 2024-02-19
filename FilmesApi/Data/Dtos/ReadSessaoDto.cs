using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos
{
    public class ReadSessaoDto
    {
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public int CinemaId { get; set; }

    }
}