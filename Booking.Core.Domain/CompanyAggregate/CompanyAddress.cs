namespace Booking.Core.Domain.CompanyAggregate;

public record CompanyAddress(
    string Address, 
    double? Latitude,
    double? Longitude, 
    string? GoogleMapPlaceId);