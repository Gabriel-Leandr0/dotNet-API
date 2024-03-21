using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;

namespace FilmesApi.Business.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<ReadUsuarioDto> Login(LoginDto loginDto);
        public Task Register(CreateUsuarioDto createUsuarioDto);
    }
}