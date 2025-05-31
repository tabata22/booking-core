using Booking.Core.Domain.EmployeeAggregate;

namespace Booking.Core.Domain.CompanyAggregate;

public class Branch : AuditableEntity
{
    public Branch(long companyId, string name)
    {
        CompanyId = companyId;
        Name = name;
    }
    
    private Branch() { }

    public long Id { get; private set; }
    
    public long CompanyId { get; private set; }
    
    public string Name { get; private set; }
    
    public Company Company { get; private set; }
    
    public ICollection<Employee> Employees { get; private set; }
}