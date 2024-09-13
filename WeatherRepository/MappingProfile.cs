using AutoMapper;
// !!! Do not use any `using` here !!!
// Use full names instead.

namespace WeatherRepository;

public class MappingProfile : Profile
{
   public MappingProfile()
   {
      CreateMap<Models.Weather, Domain.Models.Weather>();
      CreateMap<Domain.Models.Weather, Models.Weather>()
         .ForMember(x => x.Id, opt => opt.Ignore())
         .ForMember(x => x.RegionId, opt => opt.Ignore());

      CreateMap<Models.Region, Domain.Models.Region>();
      CreateMap<Domain.Models.Region, Models.Region>();
   }
}
