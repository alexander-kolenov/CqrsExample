using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application;

public static partial class Region
{
   public record AddCommand(string RegionName) : IRequest<int>;

   public class AddHandler : IRequestHandler<AddCommand, int>
   {
      public WeatherRepository.Models.WeatherExampleDbContext _db;
      public IMapper _mapper;
      private readonly ILogger<AddCommand> _logger;

      public AddHandler(
         WeatherRepository.Models.WeatherExampleDbContext db,
         IMapper mapper,
         ILogger<AddCommand> logger)
      {
         _db = db;
         _mapper = mapper;
         _logger = logger;
      }

      public async Task<int> Handle(AddCommand request, CancellationToken cancellationToken)
      {
         var result = _db.Regions
            .Add(new WeatherRepository.Models.Region
         {
            Name = request.RegionName,
         });

         await _db.SaveChangesAsync(cancellationToken);

         return result.Entity.Id;
      }
   }
}
