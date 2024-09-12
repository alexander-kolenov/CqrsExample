using Domain.Models;

namespace Application;

public interface IRegionService
{
   Task<Region> GetRegionAsync(int RegionId);
   Task<int> AddRegionAsync(string regionName);
}
