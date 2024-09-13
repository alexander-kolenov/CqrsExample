using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application;

public static class SetWeather
{
   public record Command(string RegionName, double Temperature) : IRequest<Unit>;

   public class Handler : IRequestHandler<Command, Unit>
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

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
         var region = await _mediator.Send(new Region.GetIdCommand(request.RegionName), cancellationToken);

         _db.Weathers.Add(new WeatherRepository.Models.Weather
         {
            Temperature = request.Temperature,
            RegionId = region.Id,
         });

         await _db.SaveChangesAsync();

         return Unit.Value;
      }
   }
}
