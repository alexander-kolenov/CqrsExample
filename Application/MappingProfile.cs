using AutoMapper;

namespace Application;

public class MappingProfile : Profile
{
   public MappingProfile()
   {
      CreateMap<WeatherRepository.Models.Weather, Domain.Models.Weather>();
      CreateMap<WeatherRepository.Models.Region, Domain.Models.Region>();
      CreateMap<Domain.Models.Region, WeatherRepository.Models.Region>();
   }
}
