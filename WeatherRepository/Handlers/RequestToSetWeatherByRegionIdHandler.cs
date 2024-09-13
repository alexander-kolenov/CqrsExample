using AutoMapper;
using Domain.Requests.WeatherRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using WeatherRepository.Models;

namespace WeatherRepository.Handlers;

public class RequestToSetWeatherByRegionIdHandler :
   IRequestHandler<RequestToSetWeatherByRegionId, Unit>
{
   public WeatherExampleDbContext _db;
   public IMapper _mapper;
   private readonly ILogger<RequestToSetWeatherByRegionIdHandler> _logger;

   public RequestToSetWeatherByRegionIdHandler(
      WeatherExampleDbContext db,
      IMapper mapper,
      ILogger<RequestToSetWeatherByRegionIdHandler> logger)
   {
      _db = db;
      _mapper = mapper;
      _logger = logger;
   }

   public async Task<Unit> Handle(RequestToSetWeatherByRegionId request, CancellationToken cancellationToken)
   {
      var weather = _mapper.Map<Weather>(request.Weather);
      weather.RegionId = request.RegionId;
      
      _db.Weathers.Add(weather);

      await _db.SaveChangesAsync();

      return Unit.Value;
   }
}
