namespace Booking.Core.Domain.BranchAggregate;

public record BranchAddress(
    string Address, 
    double? Latitude,
    double? Longitude, 
    string? GoogleMapPlaceId);