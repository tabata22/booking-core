using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Application.Services;

public interface IServiceRepository : IBaseRepository<Service>
{
    Task<IReadOnlyList<Service>> GetAllAsync(CancellationToken cancellationToken = default);
}