using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class FIlmeProfile : Profile
    {
        public FIlmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap< UpdateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();

        }
    }
}
