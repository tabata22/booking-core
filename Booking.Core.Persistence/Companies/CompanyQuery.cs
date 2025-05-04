using Booking.Core.Application.Companies;
using Booking.Core.Application.Companies.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Persistence.Companies;

public class CompanyQuery :  ICompanyQuery
{
    private readonly ApplicationDbContext _dbContext;

    public CompanyQuery(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<CompanyModel>> FilterAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Companies
            .AsNoTracking()
            .Select(x => new CompanyModel
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

    public async Task<CompanyModel?> GetAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Companies
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new CompanyModel
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

    public async Task<IReadOnlyList<CompanyServiceModel>> GetCompanyServicesAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.CompanyServices
            .AsNoTracking()
            .Include(x => x.Service)
            .Where(c => c.CompanyId == id)
            .Select(x => new CompanyServiceModel
            {
                ServiceId = x.Service.Id,
                ServiceName = x.Service.Name
            })
            .ToListAsync(cancellationToken);
    }
}