using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    

    [HttpPost]
    public void AdicionaFilme(Filme filme)
    {
        filmes.Add(filme);
    }


    [HttpGet]
    public List<Filme> RecuperaFilmes()
    {
        return filmes;
    }

}