using Application;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
   private readonly IRegionService _regionService;
   private readonly IWeatherService _weatherService;
   private readonly ILogger<WeatherForecastController> _logger;

   public WeatherForecastController(
      IRegionService regionService,
      IWeatherService weatherService,
      ILogger<WeatherForecastController> logger)
   {
      _regionService = regionService;
      _weatherService = weatherService;
      _logger = logger;
   }


   [HttpGet("GetWeather")]
   public Task<Weather> GetWeather(string regoinName)
   {
      return _weatherService.GetWeatherAsync(regoinName);
   }

   [HttpPost("AddWeather")]
   public Task AddWeather(string regoinName, double temperature)
   {
      return _weatherService.AddWeatherAsync(
         regoinName,
         new Weather
         {
            Temperature = temperature
         });
   }

   [HttpPost("AddRegion")]
   public Task AddRegion(string regionName)
   {
      return _regionService.AddRegionAsync(regionName);
   }
}
