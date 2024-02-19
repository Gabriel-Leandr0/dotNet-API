using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReadEnderecoDto), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> ReadEndereco()
        {
            var listaDeEnderecos = _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
            return listaDeEnderecos;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound("Endereço não encontrado");
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
