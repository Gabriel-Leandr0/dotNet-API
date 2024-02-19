using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{  
    //Constructor
    public CinemaProfile()
    {
        // Profile serve para mapear um objeto para outro
            // - CreateMap<ClasseOrigem, ClasseDestino>()
            // - ForMember(destino => destino.Propriedade, origem => origem.Propriedade)
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(ReadCinemaDto => ReadCinemaDto.Endereco, 
                opt => opt.MapFrom(Cinema => Cinema.Endereco))
            .ForMember(ReadCinemaDto => ReadCinemaDto.Sessoes, 
                opt => opt.MapFrom(Cinema => Cinema.Sessoes)); 
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}
