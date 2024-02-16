using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.Models;

namespace FilmesApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<Data.Dtos.CreateEnderecoDto, Endereco>();
            CreateMap<Data.Dtos.UpdateEnderecoDto, Endereco>();
        }
    }
}
