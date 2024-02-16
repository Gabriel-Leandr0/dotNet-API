using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{
    //CreateMap serve para mapear um objeto para outro objeto
    //Toda vez que quisermos criar um Dto para um Model, devemos criar um CreateMap
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}