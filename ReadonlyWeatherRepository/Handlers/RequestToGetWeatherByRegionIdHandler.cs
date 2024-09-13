using AutoMapper;
using Domain.Requests.ReadonlyWeatherRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReadonlyWeatherRepository.Models;

namespace ReadonlyWeatherRepository.Handlers;

public class RequestToGetWeatherByRegionIdHandler :
   IRequestHandler<RequestToGetWeatherByRegionId, Domain.Models.Weather>
{
   public ReadonlyWeatherExampleDbContext _db;
   public IMapper _mapper;
   private readonly ILogger<RequestToGetWeatherByRegionIdHandler> _logger;

   public RequestToGetWeatherByRegionIdHandler(
      ReadonlyWeatherExampleDbContext db,
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
