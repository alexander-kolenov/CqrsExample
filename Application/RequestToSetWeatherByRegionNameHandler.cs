using Domain.Requests.Application;
using Domain.Requests.ReadonlyWeatherRepository;
using Domain.Requests.WeatherRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Transactions;

namespace Application;

public class RequestToSetWeatherByRegionNameHandler :
   IRequestHandler<RequestToSetWeatherByRegionName, Unit>
{
   private readonly IMediator _mediator;
   private readonly ILogger<RequestToSetWeatherByRegionNameHandler> _logger;

   public RequestToSetWeatherByRegionNameHandler(
      IMediator mediator,
      ILogger<RequestToSetWeatherByRegionNameHandler> logger)
   {
      _mediator = mediator;
      _logger = logger;
   }

   public async Task<Unit> Handle(RequestToSetWeatherByRegionName request, CancellationToken cancellationToken)
   {
      using var scope  = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

      var region = await _mediator.Send(new RequestToGetRegionByName(request.RegionName), cancellationToken);
      var weather = await _mediator.Send(new RequestToSetWeatherByRegionId(region.Id, request.Weather), cancellationToken);

      if (request.Weather.Temperature > 50)
         throw new ArgumentException(nameof(request.Weather.Temperature), "Temperature exceed limit 50 Celsius degrees");

      scope.Complete();

      return Unit.Value;
   }
}
