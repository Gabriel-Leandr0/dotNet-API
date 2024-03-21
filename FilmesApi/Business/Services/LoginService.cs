using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BCrypt.Net;
using FilmesApi.Business.Services.Interfaces;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FilmesApi.Business.Services
{
    public class LoginService : ILoginService
    {

        private readonly FilmeContext _context;
        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        public LoginService(FilmeContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }


public async Task<ReadUsuarioDto> Login(LoginDto loginDto)
{
    Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

    if (usuario == null || BCrypt.Net.BCrypt.Verify(loginDto.Senha, usuario.Senha) == false)
    {
        return null;
    }

    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, usuario.Email)
        }),
        IssuedAt = DateTime.UtcNow,
        Issuer = _configuration["JWT:Issuer"],
        Audience = _configuration["JWT:Audience"],
        Expires = DateTime.UtcNow.AddHours(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    var login = new ReadUsuarioDto
    {
        Email = usuario.Email,
        Nome = usuario.Nome,
        Cpf = usuario.Cpf,
        Token = tokenHandler.WriteToken(token)
    };

    return login;
}


        public async Task Register(CreateUsuarioDto createUsuarioDto)
        {
            createUsuarioDto.Senha = BCrypt.Net.BCrypt.HashPassword(createUsuarioDto.Senha);

            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);

            _context.Usuarios.Add(new Usuario
            {
                Email = usuario.Email,
                Senha = usuario.Senha,
                Nome = usuario.Nome,
                Cpf = usuario.Cpf
            });

            
            await _context.SaveChangesAsync();

        }
    }
}