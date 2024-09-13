using AutoMapper;
using Domain.Requests.ReadonlyWeatherRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReadonlyWeatherRepository.Models;

namespace ReadonlyWeatherRepository.Handlers;

public class RequestToGetRegionByNameHandler :
   IRequestHandler<RequestToGetRegionByName, Domain.Models.Region>
{
   public ReadonlyWeatherExampleDbContext _db;
   public IMapper _mapper;
   private readonly ILogger<RequestToGetRegionByNameHandler> _logger;

   public RequestToGetRegionByNameHandler(
      ReadonlyWeatherExampleDbContext db,
      IMapper mapper,
      ILogger<RequestToGetRegionByNameHandler> logger)
   {
      _db = db;
      _mapper = mapper;
      _logger = logger;
   }

   public async Task<Domain.Models.Region> Handle(RequestToGetRegionByName request, CancellationToken cancellationToken)
   {
      var region = await _db.Regions
         .FirstOrDefaultAsync(x => x.Name == request.RegionName, cancellationToken)
       ?? throw new Exception("Region not found");

      return _mapper.Map<Domain.Models.Region>(region);
   }
}
