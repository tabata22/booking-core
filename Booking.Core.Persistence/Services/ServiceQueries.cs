using Booking.Core.Application.Services.Queries;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Persistence.Services;

public class ServiceQueries : IServiceQueries
{
    private readonly ApplicationDbContext _dbContext;

    public ServiceQueries(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<GetServiceDto>> GetAll(long companyId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Services
            .AsNoTracking()
            .Where(x => x.CompanyId == companyId)
            .Select(x => new GetServiceDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                Duration = x.Duration
            })
            .ToListAsync(cancellationToken);
    }
}