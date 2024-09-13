using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application;

public static partial class Region
{
   public record GetIdCommand(string RegionName) : IRequest<Domain.Models.Region>;

   public class GetIdHandler : IRequestHandler<GetIdCommand, Domain.Models.Region>
   {
      public WeatherRepository.Models.WeatherExampleDbContext _db;
      public IMapper _mapper;
      private readonly ILogger<GetIdHandler> _logger;

      public GetIdHandler(
         WeatherRepository.Models.WeatherExampleDbContext db,
         IMapper mapper,
         ILogger<GetIdHandler> logger)
      {
         _db = db;
         _mapper = mapper;
         _logger = logger;
      }

      public async Task<Domain.Models.Region> Handle(GetIdCommand request, CancellationToken cancellationToken)
      {
         var region = await _db.Regions.FirstOrDefaultAsync(x => x.Name == request.RegionName, cancellationToken)
           ?? throw new Exception("Region not found");

         return _mapper.Map<Domain.Models.Region>(region);
      }
   }
}
