using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application;

public static class GetWeather
{
   public record Command(string RegionName) : IRequest<Weather>;

   public class Handler : IRequestHandler<Command, Weather>
   {

      public WeatherRepository.Models.WeatherExampleDbContext _db;
      public IMapper _mapper;
      private readonly IMediator _mediator;
      private readonly ILogger<Handler> _logger;

      public Handler(WeatherRepository.Models.WeatherExampleDbContext db, IMapper mapper, IMediator mediator, ILogger<Handler> logger)
      {
         _db = db;
         _mapper = mapper;
         _mediator = mediator;
         _logger = logger;
      }

      public async Task<Weather> Handle(Command request, CancellationToken cancellationToken)
      {
         var region = await _mediator.Send(new Region.GetIdCommand(request.RegionName), cancellationToken);

         var weather = await _db.Weathers
            .Where(x => x.RegionId == region.Id)
            .OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new Exception("Weather not found");

         return _mapper.Map<Weather>(weather);
      }
   }
}
