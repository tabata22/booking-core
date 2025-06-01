namespace Booking.Core.Domain.PackageAggregate;

public class Package : AuditableEntity
{
    public Package(string name, decimal price)
    {
        Status = PackageStatus.Active;
        Name = name;
        Price = price;
    }
    
    private Package() { }

    public long Id { get; private set; }
    
    public PackageStatus Status { get; private set; }
    
    public string Name { get; private set; }
    
    public decimal Price { get; private set; }
}