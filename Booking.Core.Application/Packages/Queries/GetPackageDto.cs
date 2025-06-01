namespace Booking.Core.Application.Packages.Queries;

public class GetPackageDto
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
}