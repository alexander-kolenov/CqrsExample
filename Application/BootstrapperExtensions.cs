using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;


public static class BootstrapperExtensions
{
   public static IServiceCollection AddApplicationServices(this IServiceCollection services)
   {
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

      return services;
   }
}
