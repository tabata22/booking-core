using Booking.Core.Application.Companies.Models;

namespace Booking.Core.Application.Companies;

public interface ICompanyQuery
{
    Task<IReadOnlyList<CompanyModel>> FilterAsync(CancellationToken cancellationToken = default);
    
    Task<CompanyModel?> GetAsync(long id, CancellationToken cancellationToken = default);
    
    Task<IReadOnlyList<CompanyServiceModel>> GetCompanyServicesAsync(long id, CancellationToken cancellationToken = default);
}