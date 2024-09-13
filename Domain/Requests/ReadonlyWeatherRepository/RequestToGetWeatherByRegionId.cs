using Domain.Models;
using MediatR;

namespace Domain.Requests.ReadonlyWeatherRepository;

public record RequestToGetWeatherByRegionId(int RegionId) : IRequest<Weather>;
