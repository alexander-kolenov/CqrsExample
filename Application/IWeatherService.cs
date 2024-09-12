using Domain.Models;

namespace Application;

public interface IWeatherService
{
   Task<Weather> GetWeatherAsync(string regionName);
   Task AddWeatherAsync(string regionName, Weather weather);
}
