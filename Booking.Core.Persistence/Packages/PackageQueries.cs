using Booking.Core.Application.Packages.Queries;
using Booking.Core.Domain.PackageAggregate;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Persistence.Packages;

public class PackageQueries : IPackageQueries
{
    private readonly ApplicationDbContext _dbContext;

    public PackageQueries(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<GetPackageDto>> GetPackagesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Packages
            .AsNoTracking()
            .Where(x => x.Status == PackageStatus.Active)
            .Select(x => new GetPackageDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            })
            .ToListAsync(cancellationToken);
    }
}