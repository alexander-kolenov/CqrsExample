using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class WeatherService : IWeatherService
{
   public WeatherRepository.Models.WeatherExampleDbContext _db;
   public IRegionService _regionService;
   public IMapper _mapper;

   public WeatherService(
      WeatherRepository.Models.WeatherExampleDbContext db,
      IRegionService regionService,
      IMapper mapper)
   {
      _db = db;
      _regionService = regionService;
      _mapper = mapper;
   }

   public async Task AddWeatherAsync(string regionName, Weather weather)
   {
      var region = await _regionService.GetRegionIdAsync(regionName);

      _db.Weathers.Add(new WeatherRepository.Models.Weather
      {
         Temperature = weather.Temperature,
         RegionId = region.Id,
      });
      await _db.SaveChangesAsync();
   }

   public async Task<Weather> GetWeatherAsync(string regionName)
   {
      var region = await _regionService.GetRegionIdAsync(regionName);

      var weather = await _db.Weathers
         .Where(x => x.RegionId == region.Id)
         .OrderByDescending(x => x.Id)
         .FirstOrDefaultAsync()
         ?? throw new Exception("Weather not found");

      return _mapper.Map<Weather>(weather);
   }
}
