using Booking.Core.Domain.CompanyAggregate;

namespace Booking.Core.Domain.ServiceAggregate;

public class Service : AuditableEntity
{
    public Service(long companyId, string name, string? description, decimal price, int duration)
    {
        CompanyId = companyId;
        Name = name;
        Description = description;
        Price = price;
        Duration = duration;
    }
    
    private Service() { }

    public long Id { get; private set; }
    
    public long CompanyId { get; private set; }
    
    public string Name { get; private set; }
    
    public string? Description { get; private set; }
    
    public decimal Price { get; private set; }
    
    public int Duration { get; private set; }
    
    public Company Company { get; private set; }
}