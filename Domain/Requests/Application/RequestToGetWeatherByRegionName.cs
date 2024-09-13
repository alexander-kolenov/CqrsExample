using Domain.Models;
using MediatR;

namespace Domain.Requests.Application;

public record RequestToGetWeatherByRegionName(string RegionName) : IRequest<Weather>;
