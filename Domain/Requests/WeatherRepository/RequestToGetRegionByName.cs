using Domain.Models;
using MediatR;

namespace Domain.Requests.WeatherRepository;

public record RequestToGetRegionByName(string RegionName) : IRequest<Region>;
