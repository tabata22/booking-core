namespace Booking.Core.Domain.ServiceAggregate;

public class Service : BaseEntity
{
    public Service(string name, string? description, decimal price, long duration)
    {
        Name = name;
        Description = description;
        Price = price;
        Duration = duration;
    }
    
    private Service() { }

    public long Id { get; private set; }
    
    public string Name { get; private set; }
    
    public string? Description { get; private set; }
    
    public decimal Price { get; private set; }
    
    public long Duration { get; private set; }
}