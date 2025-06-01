using Booking.Core.Application.Services;
using Booking.Core.Domain.ServiceAggregate;

namespace Booking.Core.Persistence.Services;

public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<IReadOnlyList<Service>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}