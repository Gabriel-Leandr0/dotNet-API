using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CinemaController : ControllerBase
{
   private FilmeContext _context;
   private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadCinema), new { Id = cinema.Id }, cinema);
    }

    [HttpGet]
    public IActionResult ReadCinema()
    {
        return Ok(_context.Cinemas);
    }

    [HttpGet("{id}")]
    public IActionResult ReadCinemaById(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema != null)
        {
            var cinemaReadDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaReadDto);
        }
        return NotFound("Cinema não encontrado");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound("Cinema não encontrado");
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null)
        {
            return NotFound("Cinema não encontrado");
        }
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}
