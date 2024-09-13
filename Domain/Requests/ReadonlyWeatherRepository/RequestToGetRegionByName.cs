using Domain.Models;
using MediatR;

namespace Domain.Requests.ReadonlyWeatherRepository;

public record RequestToGetRegionByName(string RegionName) : IRequest<Region>;
