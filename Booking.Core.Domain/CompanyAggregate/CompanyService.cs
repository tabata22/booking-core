using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Domain.CompanyAggregate;

public class CompanyService
{
    public Guid Id { get; set; }
    
    public long ServiceId { get; set; }
    
    public long CompanyId { get; set; }
    
    public Service Service { get; set; }
    
    public Company Company { get; set; }
}