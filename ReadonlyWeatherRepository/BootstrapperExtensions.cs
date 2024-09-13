using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ReadonlyWeatherRepository.Models;

namespace ReadonlyWeatherRepository;


public static class BootstrapperExtensions
{
   public static IServiceCollection AddReadonlyWeatherRepository(this IServiceCollection services, string dbConnetionString)
   {
      services.AddDbContext<ReadonlyWeatherExampleDbContext>(options =>
         options.UseNpgsql(dbConnetionString));

      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
      services.AddAutoMapper(typeof(MappingProfile));

      return services;
   }
}
