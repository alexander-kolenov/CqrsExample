using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeatherRepository.Models;

namespace WeatherRepository;


public static class BootstrapperExtensions
{
   public static IServiceCollection AddWeatherRepository(this IServiceCollection services, string dbConnetionString)
   {
      services.AddDbContext<WeatherExampleDbContext>(options =>
         options.UseNpgsql(dbConnetionString));
      
      return services;
   }
}
