using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Domain.EmployeeAggregate;

public class EmployeeService
{
    public Guid Id { get; set; }
    
    public long ServiceId { get; set; }
    
    public long EmployeeId { get; set; }
    
    public Service Service { get; set; }
    
    public Employee Employee { get; set; }
}