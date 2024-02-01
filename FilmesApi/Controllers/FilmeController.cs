using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;

    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    

    [HttpPost]
    public IActionResult AdicionaFilme(CreateFilmeDto createFilmeDto)
    {
        //mapper serve para mapear um objeto para outro objeto (createFilmeDto para Filme)
        //instalar o pacote AutoMapper

        Filme filme = _mapper.Map<Filme>(createFilmeDto);
        
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmesPorId),
         new { Id = filme.Id },
          filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<IEnumerable<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesPorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpGet("titulo")]
    public IEnumerable<ReadFilmeDto> RecuperaFilmesPorTitulo([FromQuery] string titulo)
    {
        return _mapper.Map<IEnumerable<ReadFilmeDto>>
        (_context.Filmes.Where(filme => filme.Titulo == titulo));
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, UpdateFilmeDto updateFilmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(updateFilmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaParcialFilme(int id, JsonPatchDocument<UpdateFilmeDto> patchFilme)
    {
        //JsonPatchDocument serve para atualizar parcialmente um objeto
        //instalar o pacote Microsoft.AspNetCore.Mvc.NewtonsoftJson

        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeDto = _mapper.Map<UpdateFilmeDto>(filme);
        patchFilme.ApplyTo(filmeDto, ModelState);
       
        if (!TryValidateModel(filmeDto)) return ValidationProblem(ModelState);
       
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}