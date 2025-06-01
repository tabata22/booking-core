using Booking.Core.Application.Companies.Queries;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Persistence.Companies;

public class CompanyQueries :  ICompanyQueries
{
    private readonly ApplicationDbContext _dbContext;

    public CompanyQueries(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<GetCompanyDto>> FilterAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Companies
            .AsNoTracking()
            .Select(x => new GetCompanyDto
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                ActivityType = x.ActivityType,
                LogoUrl = x.LogoUrl,
                Description = x.Description
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<GetCompanyDto?> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Companies
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new GetCompanyDto
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                ActivityType = x.ActivityType,
                LogoUrl = x.LogoUrl,
                Description = x.Description
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}