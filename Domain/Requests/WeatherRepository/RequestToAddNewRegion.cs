using Domain.Models;
using MediatR;

namespace Domain.Requests.WeatherRepository;

public record RequestToAddNewRegion(Region Region) : IRequest<int>;
