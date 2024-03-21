using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;

namespace FilmesApi.Profiles;

public class UsuarioProfile : Profile
{
    //Constructor
    public UsuarioProfile()
    {
        // Profile serve para mapear um objeto para outro
        // - CreateMap<ClasseOrigem, ClasseDestino>()
        // - ForMember(destino => destino.Propriedade, origem => origem.Propriedade)
        CreateMap<Usuario, ReadUsuarioDto>();
        CreateMap<Usuario, LoginDto>();
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<UpdateUsuarioDto, Usuario>();
    }
}