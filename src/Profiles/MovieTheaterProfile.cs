using AutoMapper;
using src.Dto;
using src.Entities;

namespace src.Profiles;

public class MovieTheaterProfile : Profile
{
    public MovieTheaterProfile()
    {
        CreateMap<MovieTheater, MovieTheaterDTO>();
        CreateMap<MovieTheaterDTO, MovieTheater>();
    }
}