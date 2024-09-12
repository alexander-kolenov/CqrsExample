using Microsoft.Extensions.DependencyInjection;

namespace Application;


public static class BootstrapperExtensions
{
   public static IServiceCollection AddApplicationServices(this IServiceCollection services)
   {
      services.AddScoped<IRegionService, RegionService>();
      services.AddScoped<IWeatherService, WeatherService>();

      services.AddAutoMapper(typeof(MappingProfile));

      return services;
   }
}
