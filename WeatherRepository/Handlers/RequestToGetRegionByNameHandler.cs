using AutoMapper;
using Domain.Requests.WeatherRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeatherRepository.Models;

namespace WeatherRepository.Handlers;

public class RequestToGetRegionByNameHandler : 
   IRequestHandler<RequestToGetRegionByName, Domain.Models.Region>
{
   public WeatherExampleDbContext _db;
   public IMapper _mapper;
   private readonly ILogger<RequestToGetRegionByNameHandler> _logger;

   public RequestToGetRegionByNameHandler(
      WeatherExampleDbContext db,
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
