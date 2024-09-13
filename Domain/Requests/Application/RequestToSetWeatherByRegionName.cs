using Domain.Models;
using MediatR;

namespace Domain.Requests.Application;

public record RequestToSetWeatherByRegionName(string RegionName, Weather Weather) : IRequest<Unit>;
