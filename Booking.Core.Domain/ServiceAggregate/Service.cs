using Booking.Core.Domain.BranchAggregate;
using Booking.Core.Domain.CompanyAggregate;
using Booking.Core.Domain.EmployeeAggregate;

namespace Booking.Core.Domain.ServiceAggregate;

public class Service : AuditableEntity
{
    public Service(long branchId, string name, string? description, decimal price, int duration)
    {
        BranchId = branchId;
        Name = name;
        Description = description;
        Price = price;
        Duration = duration;
    }
    
    private Service() { }

    public long Id { get; private set; }
    
    public long BranchId { get; private set; }
    
    public string Name { get; private set; }
    
    public string? Description { get; private set; }
    
    public decimal Price { get; private set; }
    
    public int Duration { get; private set; }
    
    public Branch Branch { get; private set; }
    
    public ICollection<EmployeeService> EmployeeServices { get; private set; }

    public void Update(string name, string? description, decimal price, int duration)
    {
        Name = name;
        Description = description;
        Price = price;
        Duration = duration;
    }
}