using Booking.Core.Application.Services;
using Booking.Core.Application.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Persistence.Services;

public class ServiceQuery : IServiceQuery
{
    private readonly ApplicationDbContext _dbContext;

    public ServiceQuery(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<ServiceModel>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Services
            .AsNoTracking()
            .Select(x => new ServiceModel
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToListAsync(cancellationToken);
    }
}