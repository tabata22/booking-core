namespace Booking.Core.Application.Services.Queries;

public class GetServiceDto
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal Price { get; set; }
    
    public int Duration { get; set; }
}