namespace Booking.Core.Domain.EmployeeAggregate;

public class Employee : BaseEntity
{
    public Employee(string firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    private Employee() { }

    public long Id { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string? LastName { get; private set; }
    
    public ICollection<EmployeeService> Services { get; private set; }
    
    public void AddService(EmployeeService service) => Services.Add(service);

    public void Update(string firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}