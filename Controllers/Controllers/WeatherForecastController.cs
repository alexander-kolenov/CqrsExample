using Domain.Models;
using Domain.Requests.Application;
using Domain.Requests.WeatherRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controllers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
   private readonly IMediator _mediator;
   private readonly ILogger<WeatherForecastController> _logger;

   public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
   {
      _mediator = mediator;
      _logger = logger;
   }

   [HttpGet("GetWeather")]
   public Task<Weather> GetWeather(string regoinName, CancellationToken ct)
   {
      return _mediator.Send(new RequestToGetWeatherByRegionName(regoinName), ct);
   }

   [HttpPost("AddWeather")]
   public Task AddWeather(string regoinName, double temperature, CancellationToken ct)
   {
      return _mediator.Send(new RequestToSetWeatherByRegionName(
         regoinName,
         new Weather
         {
            Temperature = temperature,
         }),
         ct);
   }

   [HttpPost("AddRegion")]
   public async Task AddRegion(string regionName, CancellationToken ct)
   {
      await _mediator.Send(new RequestToAddNewRegion(
         new Region 
         {
            Name = regionName
         }),
         ct);
   }
}
