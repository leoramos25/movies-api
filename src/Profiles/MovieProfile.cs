using AutoMapper;
using src.Dto;
using src.Entities;

namespace src.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<MovieDTO, Movie>();
        CreateMap<Movie, MovieDTO>();
    }
}