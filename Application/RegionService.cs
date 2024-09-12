using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class RegionService : IRegionService
{
   public WeatherRepository.Models.WeatherExampleDbContext _db;
   public IMapper _mapper;

   public RegionService(
      WeatherRepository.Models.WeatherExampleDbContext db,
      IMapper mapper)
   {
      _db = db;
      _mapper = mapper;
   }

   public async Task<int> AddRegionAsync(string regionName)
   {
      var result = await _db.Regions.AddAsync(new WeatherRepository.Models.Region
      {
         Name = regionName,
      });
      await _db.SaveChangesAsync();
      return result.Entity.Id;
   }

   public async Task<Region> GetRegionIdAsync(string regionName)
   {
      var region = await _db.Regions.FirstOrDefaultAsync(x => x.Name == regionName)
         ?? throw new Exception("Region not found");
      return _mapper.Map<Region>(region);
   }
}