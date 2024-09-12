using Domain.Models;

namespace Application;

public class WeatherService : IWeatherService
{
   public Task AddWeatherAsync(string regionName, Weather weather)
   {
      throw new NotImplementedException();
   }

   public Task<Weather> GetWeatherAsync(string regionName)
   {
      throw new NotImplementedException();
   }
}
