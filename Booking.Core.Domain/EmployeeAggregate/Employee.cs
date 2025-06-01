using Booking.Core.Domain.BranchAggregate;
using Booking.Core.Domain.CompanyAggregate;
using Booking.Core.Domain.CustomerAggregate;

namespace Booking.Core.Domain.EmployeeAggregate;

public class Employee : AuditableEntity
{
    public Employee(long branchId, string firstName, string? lastName)
    {
        BranchId = branchId;
        FirstName = firstName;
        LastName = lastName;
    }
    
    private Employee() { }

    public long Id { get; private set; }
    
    public long BranchId { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string? LastName { get; private set; }
    
    public ICollection<EmployeeService> Services { get; private set; }
    
    public Branch Branch { get; private set; }
    
    public void AddService(EmployeeService service) => Services.Add(service);

    public void Update(long branchId, string firstName, string? lastName)
    {
        BranchId = branchId;
        FirstName = firstName;
        LastName = lastName;
    }
}