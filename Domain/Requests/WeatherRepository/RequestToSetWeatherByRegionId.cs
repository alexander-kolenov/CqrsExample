using Domain.Models;
using MediatR;

namespace Domain.Requests.WeatherRepository;

public record RequestToSetWeatherByRegionId(int RegionId, Weather Weather) : IRequest<Unit>;
