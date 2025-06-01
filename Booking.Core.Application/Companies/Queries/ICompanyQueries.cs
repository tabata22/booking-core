namespace Booking.Core.Application.Companies.Queries;

public interface ICompanyQueries
{
    Task<IReadOnlyList<GetCompanyDto>> FilterAsync(CancellationToken cancellationToken = default);
    
    Task<GetCompanyDto?> GetAsync(long id, CancellationToken cancellationToken = default);
}