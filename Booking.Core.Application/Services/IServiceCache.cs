using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Application.Services;

public interface IServiceCache
{
    Task LoadAsync(CancellationToken cancellationToken = default);
    
    IReadOnlyList<Service> GetAll();
    
    Service Get(long key);
}