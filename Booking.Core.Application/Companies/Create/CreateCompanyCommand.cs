using Booking.Core.Domain.CompanyAggregate;
using CSharpFunctionalExtensions;
using MediatR;

namespace Booking.Core.Application.Companies.Create;

public record CreateCompanyCommand(
    string IdentificationCode,
    string Name,
    CompanyActivityType CompanyActivityType,
    string? Description,
    string Address, 
    double? Latitude,
    double? Longitude, 
    string? GoogleMapPlaceId,
    long[] Services) : IRequest<Result>;