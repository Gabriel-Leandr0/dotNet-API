using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Models.Endereco, ReadEnderecoDto>();
            CreateMap<Data.Dtos.CreateEnderecoDto, Endereco>();
            CreateMap<Data.Dtos.UpdateEnderecoDto, Endereco>();
        }
    }
}
