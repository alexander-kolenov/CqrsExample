using AutoMapper;
using Domain.Requests.WeatherRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeatherRepository.Models;

namespace WeatherRepository.Handlers;

public class RequestToGetWeatherByRegionIdHandler :
   IRequestHandler<RequestToGetWeatherByRegionId, Domain.Models.Weather>
{
   public WeatherExampleDbContext _db;
   public IMapper _mapper;
   private readonly ILogger<RequestToGetWeatherByRegionIdHandler> _logger;

   public RequestToGetWeatherByRegionIdHandler(
      WeatherExampleDbContext db,
      IMapper mapper,
      ILogger<RequestToGetWeatherByRegionIdHandler> logger)
   {
      _db = db;
      _mapper = mapper;
      _logger = logger;
   }

   public async Task<Domain.Models.Weather> Handle(RequestToGetWeatherByRegionId request, CancellationToken cancellationToken)
   {
      var weather = await _db.Weathers
         .Where(x => x.RegionId == request.RegionId)
         .OrderByDescending(x => x.Id)
         .FirstOrDefaultAsync(cancellationToken)
         ?? throw new Exception("Weather not found");

      return _mapper.Map<Domain.Models.Weather>(weather);
   }
}
