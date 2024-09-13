using Domain.Models;
using MediatR;

namespace Domain.Requests.WeatherRepository;

public record RequestToGetWeatherByRegionId(int RegionId) : IRequest<Weather>;
