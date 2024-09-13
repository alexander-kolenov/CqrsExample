using Application;
using Domain.Models;
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
      return _mediator.Send(new GetWeather.Command(regoinName), ct);
   }

   [HttpPost("AddWeather")]
   public Task AddWeather(string regoinName, double temperature, CancellationToken ct)
   {
      return _mediator.Send(new SetWeather.Command(regoinName, temperature), ct);
   }

   [HttpPost("AddRegion")]
   public Task AddRegion(string regionName, CancellationToken ct)
   {
      return _mediator.Send(new Application.Region.AddCommand(regionName), ct);
   }
}
