using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{  
    //Constructor
    public CinemaProfile()
    {
        CreateMap<Cinema, ReadCinemaDto>();
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}
