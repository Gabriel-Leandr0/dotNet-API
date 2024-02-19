using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessaoController :ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdicionaSessao(CreateSessaoDto createSessaoDto)
        {
            //mapper serve para mapear um objeto para outro objeto (createSessaoDto para Sessao)
            //instalar o pacote AutoMapper

            Sessao sessao = _mapper.Map<Sessao>(createSessaoDto);
            
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId),
             new { Id = sessao.Id },
              sessao);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ReadSessaoDto> RecuperaSessoes([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<IEnumerable<ReadSessaoDto>>(_context.Sessoes.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null) return NotFound();
            var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return Ok(sessaoDto);
        }
        
    }
}