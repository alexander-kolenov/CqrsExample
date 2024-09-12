using Domain.Models;

namespace Application;

public interface IRegionService
{
   Task<int> AddRegionAsync(string regionName);
   Task<Region> GetRegionIdAsync(string regionName);
}
