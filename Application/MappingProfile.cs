using AutoMapper;
using Domain.Models;

namespace Application;


public class MappingProfile : Profile
{
   public MappingProfile()
   {
      CreateMap<WeatherRepository.Models.Weather, Weather>();
      CreateMap<WeatherRepository.Models.Region, Region>();
      CreateMap<Region, WeatherRepository.Models.Region>();
   }
}
