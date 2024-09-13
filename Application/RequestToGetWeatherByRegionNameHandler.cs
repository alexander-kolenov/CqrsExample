using Domain.Models;
using Domain.Requests.Application;
using Domain.Requests.ReadonlyWeatherRepository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application;

public class RequestToGetWeatherByRegionNameHandler :
   IRequestHandler<RequestToGetWeatherByRegionName, Weather>
{
   private readonly IMediator _mediator;
   private readonly ILogger<RequestToGetWeatherByRegionNameHandler> _logger;

   public RequestToGetWeatherByRegionNameHandler(
      IMediator mediator,
      ILogger<RequestToGetWeatherByRegionNameHandler> logger)
   {
      _mediator = mediator;
      _logger = logger;
   }

   public async Task<Weather> Handle(RequestToGetWeatherByRegionName request, CancellationToken cancellationToken)
   {
      var region = await _mediator.Send(new RequestToGetRegionByName(request.RegionName), cancellationToken);
      var weather = await _mediator.Send(new RequestToGetWeatherByRegionId(region.Id), cancellationToken);
      return weather;
   }
}
