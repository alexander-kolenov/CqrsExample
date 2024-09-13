using AutoMapper;
using Domain.Requests.WeatherRepository;
using MediatR;
using Microsoft.Extensions.Logging;
using WeatherRepository.Models;

namespace WeatherRepository.Handlers;

public class RequestToAddNewRegionHandler :
   IRequestHandler<RequestToAddNewRegion, int>
{

   public WeatherExampleDbContext _db;
   public IMapper _mapper;
   private readonly ILogger<RequestToAddNewRegionHandler> _logger;

   public RequestToAddNewRegionHandler(
      WeatherExampleDbContext db,
      IMapper mapper,
      ILogger<RequestToAddNewRegionHandler> logger)
   {
      _db = db;
      _mapper = mapper;
      _logger = logger;
   }

   public async Task<int> Handle(RequestToAddNewRegion request, CancellationToken cancellationToken)
   {
      var result = _db.Regions
         .Add(_mapper.Map<Region>(request.Region));

      await _db.SaveChangesAsync(cancellationToken);

      return result.Entity.Id;
   }
}
