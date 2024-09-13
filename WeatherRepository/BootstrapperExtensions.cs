using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WeatherRepository.Models;

namespace WeatherRepository;


public static class BootstrapperExtensions
{
   public static IServiceCollection AddWeatherRepository(this IServiceCollection services, string dbConnetionString)
   {
      services.AddDbContext<WeatherExampleDbContext>(options =>
         options.UseNpgsql(dbConnetionString));

      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
      services.AddAutoMapper(typeof(MappingProfile));

      return services;
   }
}
